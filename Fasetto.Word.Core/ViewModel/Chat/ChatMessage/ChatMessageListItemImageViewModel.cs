using System;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view modle for each chat message 
    /// thread item's image in a chat thread
    /// </summary>
    public class ChatMessageListItemImageViewModel : BaseViewModel
    {
        #region Private Memebers
        /// <summary>
        /// the thumbail url
        /// </summary>
        private string mThumbnailUrl;
        #endregion
        /// <summary>
        /// Title of the image file
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Original file name of the attachment
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// the file size in bytes of this attachment
        /// </summary>
        public long FileSize { get; set; }

        public string ThumnailUrl
        {
            get => mThumbnailUrl;

            set
            {
                if (value == mThumbnailUrl)
                    return;

                //update
                mThumbnailUrl = value;

                //TODO:Download image from website
                //  create a thumbnail sized version
                //  Set localFIelPath value
                Task.Delay(2000).ContinueWith(t => LocalFilePath = "/Images/Samples/rusty.jpg");
            }
        }

        /// <summary>
        /// THe local file path on this machine to the downloaded thumbnail
        /// </summary>
        public string LocalFilePath { get; set; }

        /// <summary>
        /// Indicates if the image has loaded
        /// </summary>
        public bool ImageLoaded => LocalFilePath != null;
    }
}
