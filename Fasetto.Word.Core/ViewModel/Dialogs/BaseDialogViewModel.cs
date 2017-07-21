using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A base view model for any dialog
    /// </summary>
    public class BaseDialogViewModel : BaseViewModel
    {
        /// <summary>
        /// The title of the dialog
        /// </summary>
        public string Title { get; set; }
    }
}