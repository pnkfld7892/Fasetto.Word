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

            //make the message text box focused
            MessageText.Focus();
        }

        #endregion

        /// <summary>
        /// Preview the input into he message box and respond as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;

            if(e.Key == Key.Enter)
            {
                //if we have
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    //add new line at curosr
                    var index = textbox.CaretIndex;

                    //insert new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    //shift caret forward
                    textbox.CaretIndex = index + Environment.NewLine.Length;
                    //mark as handled
                    e.Handled = true;
                    
                }
                else
                {
                    ViewModel.Send();
                    //handle the event
                    e.Handled = true; 
                }
            }
        }
    }
}
