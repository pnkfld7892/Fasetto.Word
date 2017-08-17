using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fasetto.Word
{
    /// <summary>
    /// Focueses this element on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;
            control.Loaded += (s, se) => control.Focus();
        }
    }

    /// <summary>
    /// Focuses this element if true
    /// </summary>
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is TextBoxBase control))
                return;
            if ((bool)e.NewValue)
            {
                //focus this control
                control.Focus();
                //select all text
                control.SelectAll();
            }

        }
    }
}