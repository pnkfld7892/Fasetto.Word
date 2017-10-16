using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Scroll an items control to bottom when data context chagnes
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Don't do this in design time
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            // If we don't hae a control return
            if (!(sender is ScrollViewer control))
                return;

            //Scroll content to the bottom
            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged; 
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Scroll to bottom
            (sender as ScrollViewer).ScrollToBottom();
        }
    }

}