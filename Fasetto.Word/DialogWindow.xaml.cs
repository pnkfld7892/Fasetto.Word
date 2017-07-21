using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {

        #region Private Members
        /// <summary>
        /// Viewmodel for this window
        /// </summary>
        private DialogWindowViewModel mViewModel;
        #endregion
        #region Public properties
        /// <summary>
        /// Public View Model for this window
        /// </summary>
        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;

            set
            {
                //set the new value
                mViewModel = value;
                //Update Datacontext
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor
        public DialogWindow()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
