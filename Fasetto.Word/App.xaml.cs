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
        /// Custom start up to load IoC container immediately
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Setup the main application
            ApplicationSetup();

            IoC.Logger.Log("Application starting up...", LogLevel.Debug);

            //IoC.Task.Run(() =>
            //{
            //    throw new ArgumentNullException("Oooops code crash");
            //});

            //show main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            //setup IoC
            IoC.Setup();

            //Bind a logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[] 
            {
                //TODO: Add ApplicationSettings so we can set/edit a log location
                //      for now just log to the path where this application is running
                new FileLogger("log.txt")
            }));

            //bind to Task
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            //Bind a file manager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());
            
            //Bind a UI manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}
