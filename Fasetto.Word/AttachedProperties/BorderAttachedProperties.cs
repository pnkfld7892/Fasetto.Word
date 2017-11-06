using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fasetto.Word
{
    /// <summary>
    /// Create a clipping region form the parent <see cref="Border"/> <see cref="CornerRadius"/>
    /// </summary>
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {
        #region Event Handlers
        private RoutedEventHandler mBorder_Loaded;
        private SizeChangedEventHandler mBorder_SizeChanged;

        #endregion

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get self
            var self = (sender as FrameworkElement);

            //check we have a parent border
            if (!(self.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            //setup loaded event
            mBorder_Loaded = (s1, e1) => Border_OnChange(s1, e1, self);

            //setup size changed event
            mBorder_SizeChanged = (s1, e1) => Border_OnChange(s1, e1, self);

            //if true, hook events
            if ((bool)e.NewValue)
            {
                //if true hook
                border.Loaded += mBorder_Loaded;
                border.SizeChanged += mBorder_SizeChanged;
            }
            else
            {
                //unhook
                border.Loaded -= mBorder_Loaded;
                border.SizeChanged -= mBorder_SizeChanged;
            }
        }

        /// <summary>
        /// Called when the border is loaded and size is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="child">The Child element(ourselves)</param>
        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            //Get Border
            var border = (Border)sender;

            //check we have an actual size
            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;

            //setup the new child clipping area
            var rect = new RectangleGeometry();

            //Match the corner radius with the borders corner radius
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            //set rect size to match child's actual size
            rect.Rect = new Rect(child.RenderSize);

            //assign clipping area
            child.Clip = rect;
        }
    }
}