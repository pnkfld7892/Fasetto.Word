
namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for any popup menu
    /// </summary>
    public class ChatAttachmentPopupMenuDesignModel : BasePopupMenuViewModel
    {

        #region Singleton
        public static ChatAttachmentPopupMenuDesignModel Instance => new ChatAttachmentPopupMenuDesignModel();

        #endregion  

        #region Constructor
        /// <summary>
        /// Default Ctor
        /// </summary>
        public ChatAttachmentPopupMenuDesignModel()
        {
            
        }
        #endregion
    }
}
