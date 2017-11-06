using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for each chat message thread item in a chat thread
    /// </summary>
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Display name of the sender of the message
        /// </summary>
        public string SenderName { get; set; }
        
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
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// True if this message was sent by signed in user
        /// </summary>
        public bool SentByMe { get; set; }

        /// <summary>
        /// Time message was read, or <see cref="DateTimeOffset.MinValue"/> if not read
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }

        /// <summary>
        /// True if this message has been read
        /// </summary>
        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;

        /// <summary>
        /// Time message was sent
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }

        /// <summary>
        /// A Flag indicationg if this item was added since the first Mainlist of items was created
        /// </summary>
        public bool NewItem { get; set; }

        /// <summary>
        /// ViewModel for the image attachments
        /// </summary>
        public ChatMessageListItemImageViewModel ImageAttachment { get; set; }

        /// <summary>
        /// A flag indicating if we have any meessage text
        /// </summary>
        public bool HasMessage => Message != null;



        /// <summary>
        /// A flag indicating if we have an image attached
        /// </summary>
        public bool HasImageAttachment => ImageAttachment != null;


    }
}
