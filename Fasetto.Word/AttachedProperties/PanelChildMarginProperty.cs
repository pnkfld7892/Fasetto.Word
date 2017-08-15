using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// The NoFrameHistory attached property for create a <see cref="Frame"/> that never shows nagiation
    /// and keeps the navigaion hisory empty
    /// </summary>
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the panel (grid typically)
            var panel = (sender as Panel);
            panel.Loaded += (s, ee) =>
            {
                foreach (var child in panel.Children)

                    (child as FrameworkElement).Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));

            };

        }
    }
}