using Fasetto.Word.Core;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fasetto.Word
{

    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {

        #region Public Properties

        public string Title { get; set; }
        /// <summary>
        /// The Content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructor
        public DialogWindowViewModel(Window window):base(window)
        {
            WindowMinHeight = 100;
            WindowMinWidth = 250;

            TitleHeight = 30;
        }
        #endregion


    }
}