using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The application state as a view model
    /// 
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// Current Users name
        /// </summary>
        public TextEntryViewModel Name { get; set; }
        /// <summary>
        /// Current Users UserName
        /// </summary>
        public TextEntryViewModel Username { get; set; }
        /// <summary>
        /// Current Users password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }
        /// <summary>
        /// Current Users email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The text for the logout button
        /// </summary>
        public string LogoutButtonText { get; set; }

        #endregion
        #region Commands
        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        /// <summary>
        /// Logout of the application
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// Clears the users data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }
        #endregion

        #region Constructor
        public SettingsViewModel()
        {

           
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);



            // TODO: get from localization
            LogoutButtonText = "Logout";
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// Closes the settings menu
        /// </summary>
        private void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Opens the settings menu
        /// </summary>
        private void Open()
        {
            IoC.Application.SettingsMenuVisible = true;
        }

        public void Logout()
        {
            // TODO: Confirm the user wants to logout

            // TODO: End user session and clear user data

            // TODO: Clean all application level view models that contain
            // andy user data
            ClearUserData();
            //Go To Login Page
            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        #endregion

        /// <summary>
        /// Clears all user data on logout
        /// </summary>
        public void ClearUserData()
        {
            //Clear all vie mdels containin the users info.
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
    }

    
}
