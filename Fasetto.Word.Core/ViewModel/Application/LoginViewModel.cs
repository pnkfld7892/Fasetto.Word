using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core
{

    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member
        
        

        #endregion

        #region Public Properties

        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }


        #endregion

        #region Commands

        /// <summary>
        /// Command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
           
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());

        }
        #endregion

        /// <summary>
        /// Attempt user login
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {

            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                // TODO Fake login
                await Task.Delay(1000);

                // sucessful login now populate data

                // TODO: get data from server
                // TODO: remove this with real information pulled from database
                IoC.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Eli Schwarz {DateTime.Now.ToLocalTime()}" };
                IoC.Settings.Username = new TextEntryViewModel { Label = "Username", OriginalText = "eschwarz" };
                IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
                IoC.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = "contact@schwarz.com" };

                //Go to chat page
                IoC.Application.GoToPage(ApplicationPage.Chat);

            //    var email = Email;
            //    //IMPORTANT: Never store unsecure password in variable
            //    var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });


        }

        /// <summary>
        /// Takes User to the Register Page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            
            
            // TODO: Go to register page?
            IoC.Application.GoToPage(ApplicationPage.Register);

            await Task.Delay(1);


        }


    }
}