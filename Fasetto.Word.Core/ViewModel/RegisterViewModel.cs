using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core
{

    /// <summary>
    /// The View Model for a register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Private Member

        

        #endregion

        #region Public Properties

        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the register command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }


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
        public RegisterViewModel()
        {
           
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());

        }
        #endregion

        /// <summary>
        /// Attempt register a new user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {

            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
            });


        }

        /// <summary>
        /// Takes User to the login Page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {


            // TODO: Go to register page?
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);


        }


    }
}