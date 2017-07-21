using Fasetto.Word.Core;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// The Base Class for any content that is being used inside a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members
        /// <summary>
        /// the dialog window we will be contined within
        /// </summary>
        private DialogWindow mDialogWindow;
        #endregion

        #region Public Commands
        public ICommand CloseCommand { get; private set; }
        #endregion

        #region Public Properties
        /// <summary>
        /// Minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// Minimum height of this dialog
        /// </summary>
        public int WindowMininmumHeight { get; set; } = 100;

        /// <summary>
        /// The height of hte title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// THe Title for this dialog
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Public Commands

        #endregion

        #region Contstructor
        /// <summary>
        /// Default Ctor
        /// </summary>
        public BaseDialogUserControl()
        {
            mDialogWindow = new DialogWindow();
            mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

            CloseCommand = new RelayCommand(() => mDialogWindow.Close());
        }

        #endregion

        #region Public Dialog Show Methods
        /// <summary>
        /// Displays a single message box to user
        /// </summary>
        /// <param name="viewModel">the view model</param>
        /// <typeparam name="T">The Viewmodel type for this control</typeparam>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            //create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            //Run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    
                    //Match controls expected sized to the idalog windows view model
                    mDialogWindow.ViewModel.WindowMinWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.WindowMinHeight = WindowMininmumHeight;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    //Set this control to the dialog window content
                    mDialogWindow.ViewModel.Content = this;

                    //Set this contorls datacontext to the view model
                    DataContext = viewModel;

                    //show dialog
                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    //let caller know we finished
                    tcs.TrySetResult(true);
                }

            });
            return tcs.Task;
        }
        #endregion
    }
}
