using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Design time data for
    /// </summary>
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatMessageListItemDesignModel Instance =>  new ChatMessageListItemDesignModel();

        #endregion

        #region Ctor
        public ChatMessageListItemDesignModel()
        {
            Initials = "ES";
            SenderName = "Eli";
            Message = "Something totally random to see if it will chagne!";
            ProfilePictureRGB = "3099c5";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.2));
        }
        #endregion
    }
}