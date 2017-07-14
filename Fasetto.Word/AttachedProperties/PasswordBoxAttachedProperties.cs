using System.Windows;
using System.Windows.Controls;
namespace Fasetto.Word
{
    /// <summary>
    /// the monitorPasswordAttached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get caller
            var passwordBox = sender as PasswordBox;

            //make sure it is passwordBox
            if (passwordBox == null)
                return;

            //remove previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            //if true listen out
            if((bool)e.NewValue)
            {
                //set default value

                HasTextProperty.SetValue(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// TheHasTextAttached proeprty for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty: BaseAttachedProperty<HasTextProperty, bool> {
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender,!(((PasswordBox)sender).SecurePassword.Length > 0));
        }
    }
}
