using System;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class RelayParameterizedCommand : ICommand
    {
        #region private members
        private Action<object> mAction;
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
        public RelayParameterizedCommand(Action<object> action)
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
            mAction(parameter);
        }
    }
}
