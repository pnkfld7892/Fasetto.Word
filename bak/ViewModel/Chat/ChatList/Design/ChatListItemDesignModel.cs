namespace Fasetto.Word.Core
{
    /// <summary>
    /// Design time data for
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance =>  new ChatListItemDesignModel();

        #endregion

        #region Ctor
        public ChatListItemDesignModel()
        {
            Initials = "ES";
            Name = "Eli";
            Message = "This chat app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
        }
        #endregion
    }
}