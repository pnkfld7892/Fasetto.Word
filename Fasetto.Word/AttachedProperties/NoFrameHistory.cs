using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// The NoFrameHistory attached property for create a <see cref="Frame"/> that never shows nagiation
    /// and keeps the navigaion hisory empty
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get frame
            var frame = (sender as Frame);
            //hide nav bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();

        }
    }
}