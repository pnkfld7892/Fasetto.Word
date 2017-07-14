using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for the overview chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// The Chat list items for the list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
        
        

    }
}
