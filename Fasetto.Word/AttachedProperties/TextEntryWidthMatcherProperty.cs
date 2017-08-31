using System;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Mathch the lable width of all text entry controls inside this panel
    /// </summary>
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the panel (grid typically)
            var panel = (sender as Panel);

            // Call SetWidths Init (also helps design time to work properly)
            SetWidths(panel);


            RoutedEventHandler onLoaded = null;
            onLoaded = (s, ee) =>
            {
                //unhook
                panel.Loaded -= onLoaded;

                SetWidths(panel);
                foreach (var child in panel.Children)
                {
                    //Ignore any non text-entry controls
                    if (!(child is TextEntryControl control))
                        continue;

                    //set margin to given value
                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        SetWidths(panel);
                    };

                    ////set margin to given value
                    //control.Label. += (ss, eee) =>
                    //{
                    //    SetWidths(panel);
                    //};
                }

            };

            //hook onto event to size when loaded
            panel.Loaded += onLoaded;

        }

        /// <summary>
        /// Update all child TextEntry controls so the widths match the largest width of the group
        /// </summary>
        /// <param name="panel">the panel containing the text entry controls</param>
        private void SetWidths(Panel panel)
        {
            //Keep track of max width
            var maxSize = 0d;

            foreach(var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                //find max size
                maxSize = Math.Max(maxSize, (control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right));
            }

            //create gridlength converter
            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());


            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;
                // set each controls LabelWidth value to the max size
                control.LabelWidth = gridLength;
            }
        }
    }
}