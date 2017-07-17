namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Display name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// THe latest chat message
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// user initials
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values in hex for hte backgroundond for the profile picture
        /// EXAMPLE: #FF00FF
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// Tur if there are unread messages in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

    }
}
