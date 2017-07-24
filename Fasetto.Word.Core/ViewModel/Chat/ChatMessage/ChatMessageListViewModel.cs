using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for the a chat message thread
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region public properties
        /// <summary>
        /// The Chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any pop menus are visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// View model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }


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

        #endregion

        #region Ctor
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickAwayCommand = new RelayCommand(PopupClickAway);
            SendCommand = new RelayCommand(Send);

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
        private  void Send()
        {
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Send Message",
                Message = "Thank you for wiriting a nice message :)",
                OkText = "OK"
            });

            

        }
        #endregion


    }
}
