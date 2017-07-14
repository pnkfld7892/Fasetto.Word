using System;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class RelayCommand : ICommand
    {
        #region private members
        private Action mAction;
        #endregion 
        /// <summary>
        /// Event fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender,e) => { };

        /// <summary>
        /// a relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        //execute passed in action
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
