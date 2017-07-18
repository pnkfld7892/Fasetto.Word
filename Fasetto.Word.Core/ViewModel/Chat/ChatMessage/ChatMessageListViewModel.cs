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

        #endregion

        #region Public Commands
        public ICommand AttachmentButtonCommand { get; set; }

        #endregion

        #region Ctor
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
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
