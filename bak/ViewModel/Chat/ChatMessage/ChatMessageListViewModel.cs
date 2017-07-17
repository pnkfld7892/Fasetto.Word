using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for the a chat message thread
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        /// <summary>
        /// The Chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }
        
        

    }
}
