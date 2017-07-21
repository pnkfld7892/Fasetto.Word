using Fasetto.Word.Core;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to user
        /// </summary>
        /// <param name="viewModel">the view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            // TODO:

            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}
