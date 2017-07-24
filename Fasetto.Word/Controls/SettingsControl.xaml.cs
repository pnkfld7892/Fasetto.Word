using Fasetto.Word.Core;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            //set datacontext to settings view model
            DataContext = IoC.Settings;
        }
    }
}
