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
        #region Commands
        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        #endregion

        #region Constructor
        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
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

        #endregion
    }
}
