namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="PasswordEntryViewModel"/>
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        #region singleton
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();
        #endregion

        #region Constructor
        public PasswordEntryDesignModel()
        {

            Label = "Password";
            FakePassword = "********";
            

        }
        #endregion

    }
}
