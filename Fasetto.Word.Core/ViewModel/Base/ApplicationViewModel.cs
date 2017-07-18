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
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = true;

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">the page to go to</param>
        public void GoToPage(ApplicationPage page)
        {

            CurrentPage = page;

            //show side menu or not?
           SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
