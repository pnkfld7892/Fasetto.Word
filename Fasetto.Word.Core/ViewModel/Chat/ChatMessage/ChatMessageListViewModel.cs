using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for the a chat message thread
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {

        #region Protected Memebers

        /// <summary>
        /// The last search text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The current text to search in search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// The Chat thread items for the search list
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        /// <summary>
        /// A flag indicating if the search bar should be open
        /// </summary>
        protected bool mSearchIsOpen;

        #endregion

        #region public properties
        /// <summary>
        /// The Chat thread items for the list
        /// NOTE: Do not call Items.Add on this list
        ///       as it will make the FilteredItems out of sync.
        /// </summary>
       // public ObservableCollection<ChatMessageListItemViewModel> Items { get; set; }

        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                if (mItems == value)
                    return;
                mItems = value;
                //update filtered list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// the chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The text to show in the title bar
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;

            set
            {
                //check value is different
                if (mSearchText == value)
                    return;
                //update value
                mSearchText = value;

                //if empty
                if (string.IsNullOrEmpty(SearchText))
                    //search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// Flag indicating if the serach is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                if (mSearchIsOpen == value)
                    return;
                mSearchIsOpen = value;

                //if dialog closes 
                if (!mSearchIsOpen)
                    SearchText = string.Empty;
            }
        }


        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any pop menus are visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// View model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// The message text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }


        #endregion

        #region Public Commands
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// Command for any area clicked out side of menu
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// The Command for when the Send Button is clicked
        /// </summary>
        public ICommand SendCommand { get; set; }

        /// <summary>
        /// Command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// Command for when the user wants to open search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// Command for when the user wants to close search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// Command for when the user wants to clear search text
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        #endregion

        #region Ctor
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickAwayCommand = new RelayCommand(PopupClickAway);
            SendCommand = new RelayCommand(Send);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);
            
            //make default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }




        #endregion

        #region command methods
        public void AttachmentButton()
        {
            //toggle menu vis
            AttachmentMenuVisible ^= true;
        }
        /// <summary>
        /// WHen the popclickaway area is clicked hide any popups
        /// </summary>
        private void PopupClickAway()
        {
            // Hide attachment menu
            AttachmentMenuVisible = false;
        }
        /// <summary>
        /// Sends the message
        /// </summary>
        public void Send()
        {
            //don't send a blank message
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            //Ensure lists are not null
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();
            //Ensure lists are not null
            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            var message = new ChatMessageListItemViewModel
            {
                Initials = "ES",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Eli Schwarz",
                NewItem = true

            };
            Items.Add(message);
            FilteredItems.Add(message);

            //Clear text
            PendingMessageText = "";
        }

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            //make sure we don't search the same text twice
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;
            // if we have no search tet or no items
            if(string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                //Make filtered list the same
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);

                //update last search text
                mLastSearchText = SearchText;

                return;
            }

            //Find all Items that contain the given text
            // TODO: Make more efficient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(item => item.Message.ToLower().Contains(SearchText)));

            //update last search
            mLastSearchText = SearchText;
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            //if there is some text clear it
            if (!string.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            //otherwise
            else
                //close search dialog
                SearchIsOpen = false;

        }

        /// <summary>
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;

        /// <summary>
        /// Closes the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;
        #endregion


    }
}
