using Fasetto.Word.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom start up to load IoC container immediatly
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //setup IoC
            IoC.Setup();

            //show main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
