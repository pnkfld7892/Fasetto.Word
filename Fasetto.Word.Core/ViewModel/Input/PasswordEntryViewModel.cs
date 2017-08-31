using System.Security;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    ///<summary>
    ///The viewmodel for a password entry to edit a string value
    ///</summary>
    public class PasswordEntryViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// The label to identifiy what this value is for
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// The fake password mask
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// the current password hint text
        /// </summary>
        public string CurrentPasswordHintText { get; set; }
        
        /// <summary>
        /// the new password hint text
        /// </summary>
        public string NewPasswordHintText { get; set; }
        
        /// <summary>
        /// the confrim password hint text
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }


        /// <summary>
        /// The current saved password
        /// </summary>
        public SecureString CurrentPassword { get; set; }
        /// <summary>
        /// The current non-commit edited password
        /// </summary>
        /// 
        public SecureString NewPassword { get; set; }
        /// <summary>
        /// The current non-commit confirmation password
        /// </summary>
        public SecureString ConfirmPassword { get; set; }
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
        public PasswordEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            //set default hints
            // TODO: replace with localization text
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts control into edit mode
        /// </summary>
        public void Edit()
        {
            //clear all password
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();


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

            //double check password for integrity
            // TODO: This will come from the backend store
            var storedPassword = "Testing";

            //NOTE: typically done serverside not client side
            if (storedPassword != CurrentPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong Password",
                    Message = "The current password is invalid",

                });
            }

            //check new and confirm password match
            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password Mismatch",
                    Message = "The new and confirm password do not match",

                });
            }

            //check new and confirm password match
            if (NewPassword.Unsecure().Length == 0)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password Too Short",
                    Message = "You must enter a password!",

                });
            }

            //set the edited password to the current value
            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);

            Editing = false;
        }
        #endregion
    }
}
