namespace Fasetto.Word.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region singleton
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();
        #endregion

        #region Constructor
        public MessageBoxDialogDesignModel()
        {
            
            Message = "Design time messages are fun";
            OkText = "OK";

        }
        #endregion

    }
}
