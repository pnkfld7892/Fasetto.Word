using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        #region Public Properties
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
        #endregion


        #region Commands
        /// <summary>
        /// Opens selected message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region constructor
        public ChatListItemViewModel()
        {
            //create commands
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }
        #endregion

        #region Command Helpers
        public void OpenMessage()
        {

            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                Items = new List<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Eli",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A recieved message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Derrick",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Another Recieved Messge",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Derrick",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Eli",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A recieved message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Eli",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Another Recieved Messge",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Derrick",
                        SentByMe = false,
                    },
                }
            });
        }
        #endregion
    }
}
