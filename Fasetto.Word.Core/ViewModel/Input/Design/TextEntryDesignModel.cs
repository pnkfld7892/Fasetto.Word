namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="TextEntryViewModel"/>
    /// </summary>
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region singleton
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();
        #endregion

        #region Constructor
        public TextEntryDesignModel()
        {

            Label = "Name";
            OriginalText = "Eli Schwarz";
            EditedText = "Editing :)";

        }
        #endregion

    }
}
