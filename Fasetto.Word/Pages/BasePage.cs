using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Fasetto.Word.Core;
using System.ComponentModel;

namespace Fasetto.Word
{
    /// <summary>
    /// THe base page for all pages to gain mase funcitonality
    /// </summary>
    public class BasePage : UserControl
    {
        #region Public Properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate if this page should animate out
        /// when loaded into a new frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }
        #endregion

        #region Ctor
        public BasePage()
        {
            // dont' animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            //hook page loaded event
            Loaded += BasePage_LoadedAsync;

        }
        #endregion

        #region Animation Load /Unload

        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //if we should animate out on load
            if (ShouldAnimateOut)
                await AnimateOutAsync();
            //otherwise
            else
                //animate in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            
            //make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;
            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds, width: (int)Application.Current.MainWindow.Width);
                    break;
            }

        }

        /// <summary>
        /// animates page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            //make sure we have something to do
            if (PageUnloadAnimation == PageAnimation.None)
                return;
            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);
                    break;
            }
        }

        #endregion
    }

    /// <summary>
    /// A base page with added viwe model support
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : BasePage
        where VM: BaseViewModel, new()
    {


        #region Private Members
        private VM mViewModel;
        #endregion

        #region Public Properties
        
        /// <summary>
        /// The view model assoc'd with the page
        /// </summary>
        public VM ViewModel
        {
            get => mViewModel;
            
            set
            {
                if (mViewModel == value)
                    return;
                mViewModel = value;
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Ctor
        public BasePage() : base()
        {

            //create default viewmodel
            ViewModel = new VM();

        }
        #endregion


    }
}
