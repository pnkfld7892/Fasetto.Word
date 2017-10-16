using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The application state as a view model
    /// 
    /// </summary>
    public class ApplicationViewModel: BaseViewModel
    {
        /// <summary>
        /// The Current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        /// <summary>
        /// The view model to use for the current page when the current page changes
        /// NOTE: this is not a live up to date view modle of the current page
        ///     it is simple used to set the view model of the current page
        ///     at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = true;

        /// <summary>
        /// True if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible { get; set; }

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">the page to go to</param>
        /// <param name="viewModel"> the view model, if any, to set explicity to the new page</param>
        public void GoToPage(ApplicationPage page,BaseViewModel viewModel = null)
        {
            //Always hide settings page when moving pages
            SettingsMenuVisible = false;

            //set the new view model
            CurrentPageViewModel = viewModel;



            //set current page
            CurrentPage = page;

            //fire off a current page chagned event
            OnPropertyChanged(nameof(CurrentPage));

            //show side menu or not?
           SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
