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
        /// View model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }


        #endregion

        #region Public Commands
        public ICommand AttachmentButtonCommand { get; set; }

        #endregion

        #region Ctor
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

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
        #endregion


    }
}
