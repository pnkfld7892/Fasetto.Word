using Fasetto.Word.Core;
using System.Security;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        #region Constructors
        public RegisterPage()
        {
            InitializeComponent();

        }

        public RegisterPage(RegisterViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        } 
        #endregion

        /// <summary>
        /// The Secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
       
    }
}
