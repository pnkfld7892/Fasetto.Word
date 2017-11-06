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

    /// <summary>
    /// Auto keep the scroll at the bottom of teh screen when we are already colse to bottom
    /// </summary>
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
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
            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;
            //are we close to bottom
            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                scroll.ScrollToEnd();

        }
    }

}