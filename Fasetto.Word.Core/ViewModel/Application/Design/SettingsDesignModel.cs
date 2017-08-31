using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Design time data for a <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsDesignModel : SettingsViewModel
    {
        #region singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Ctor
        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name" ,OriginalText="Eli Schwarz"};
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "eschwarz" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "contact@schwarz.com" };
        }

        #endregion
    }
}