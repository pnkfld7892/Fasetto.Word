using Ninject;
using System;

namespace Fasetto.Word.Core
{

    /// <summary>
    /// the IoC Container for our application
    /// </summary>
    /// 
    public static class IoC
    {
        #region public properties
        /// <summary>
        /// Kernel of our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the IUIManager
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// A shortcut to access the LogFactory
        /// </summary>
        public static ILogFactory Logger => IoC.Get<ILogFactory>();

        /// <summary>
        /// A shortcut to access the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager File => IoC.Get<IFileManager>();

        /// <summary>
        /// A shortcut to access the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager Task => IoC.Get<ITaskManager>();

        /// <summary>
        /// A shortcut to access the app view model
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// A shortcut to access the app view model
        /// </summary>
        public static SettingsViewModel Settings => IoC.Get<SettingsViewModel>();


        #endregion


        #region Construction
        /// <summary>
        /// sets up IoC container and binds all info
        /// NOTE: Must be called at app startup
        /// </summary>
        public static void Setup()
        {
            //Bind all required view models
            BindViewModels();
        }
        /// <summary>
        /// Binds All singleton viewmodels
        /// </summary>
        private static void BindViewModels()
        {
            //bind to a single instance of application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            //bind to a single instance of settings view model
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }
        #endregion
        /// <summary>
        /// Get's a serive from the IoC, of the spcified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
