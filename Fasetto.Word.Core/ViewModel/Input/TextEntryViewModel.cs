using System.Windows.Input;

namespace Fasetto.Word.Core
{
    ///<summary>
    ///The viewmodel for a text entry to edit a string value
    ///</summary>
    public class TextEntryViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// The label to identifiy what this value is for
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// The current saved value
        /// </summary>
        public string OriginalText { get; set; }
        /// <summary>
        /// The current non-commit edited text
        /// </summary>
        public string EditedText { get; set; }
        /// <summary>
        /// Flag for indicating edit mode
        /// </summary>
        public bool Editing { get; set; }
        #endregion

        #region Public Commands
        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }
        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }
        /// <summary>
        /// Commits the edits and saves the value
        /// Returns to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }
        #endregion

        #region Constructor
        ///<summary>
        ///Default Constructor
        ///</summary>
        public TextEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts conetol into edit mode
        /// </summary>
        public void Edit()
        {
            // set the edited text to the current value
            EditedText = OriginalText;
            //go to edit mode
            Editing = true;
        }
        /// <summary>
        /// Leaves Edit Mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;
        }
        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            // TODO: Save content
            OriginalText = EditedText;
            Editing = false;
        }
        #endregion
    }
}
