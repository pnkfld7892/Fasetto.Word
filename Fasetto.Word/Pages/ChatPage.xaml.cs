using Fasetto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatPage()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Constructor with viewmodel
        /// </summary>
        /// <param name="specificViewModel"></param>
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();

        }
        #endregion

        #region OverrideMethods
        /// <summary>
        /// Fired when viewmodel changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            //make sure UI exists
            if (ChatMessageList == null)
                return;
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);
        }
        #endregion

    }
}
