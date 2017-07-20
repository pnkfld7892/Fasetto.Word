
namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for any popup menu
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// The Background Color of the bubble in ARGB
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// The content for the content
        /// </summary>
        public BaseViewModel Content { get; set; }
        /// <summary>
        /// The alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Ctor
        /// </summary>
        public BasePopupViewModel()
        {
            //Set defaults
            // TODO: Move colros into core and make use
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }
        #endregion
    }
}
