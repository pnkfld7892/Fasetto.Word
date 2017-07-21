namespace Fasetto.Word.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        #region Public Properties
        /// <summary>
        /// Message inside box
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Text for Ok Button
        /// </summary>
        public string OkText { get; set; }
        #endregion
    }
}
