using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Design time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Ctor
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "ES",
                    Name = "Eli",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true,

                },
                new ChatListItemViewModel
                {
                    Initials = "JS",
                    Name = "Jason",
                    Message = "Get some New Icons!",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "DR",
                    Name = "Derrick",
                    Message = "The new server is up",
                    ProfilePictureRGB = "00d405",
                    IsSelected = true,
                },
                                new ChatListItemViewModel
                {
                    Initials = "ES",
                    Name = "Eli",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JS",
                    Name = "Jason",
                    Message = "Get some New Icons!",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "DR",
                    Name = "Derrick",
                    Message = "The new server is up",
                    ProfilePictureRGB = "00d405"
                },
                                new ChatListItemViewModel
                {
                    Initials = "ES",
                    Name = "Eli",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JS",
                    Name = "Jason",
                    Message = "Get some New Icons!",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "DR",
                    Name = "Derrick",
                    Message = "The new server is up",
                    ProfilePictureRGB = "00d405"
                },
            };
        }

        #endregion
    }
}