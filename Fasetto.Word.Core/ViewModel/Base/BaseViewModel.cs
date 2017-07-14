using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (indicating the function is already running) the action isn't run
        /// If the flag is false(indicating the fuction isn't already running) the action is run
        /// Onthe action is finished(or crashed) the flag is then reset to false
        /// </summary>
        /// <param name="updatingFlag"> The boolean flag dfinin if the cmommand is already running</param>
        /// <param name="action">Action to run</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //check if the flag property is true
            if (updatingFlag.GetPropertyValue())
                return;

            //set the property flag to true
            updatingFlag.SetPropertyValue(true);

            try
            {
                //run passed in action
                await action();
            }
            finally
            {
                //set flag back to false after finish
                updatingFlag.SetPropertyValue(false);
            }
        }
        #endregion
    }
}