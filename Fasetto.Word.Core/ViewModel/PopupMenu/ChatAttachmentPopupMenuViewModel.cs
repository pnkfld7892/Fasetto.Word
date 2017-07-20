
using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for any popup menu
    /// </summary>
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {


        #region Constructor
        /// <summary>
        /// Default Ctor
        /// </summary>
        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                     new MenuItemViewModel{Type = MenuItemType.Header, Text = "Attach a file..."},
                     new MenuItemViewModel{ Text = "From Computer",Icon = IconType.File},
                     new MenuItemViewModel{ Text = "From Pictures",Icon = IconType.Picture},
                })
            };
        }
        #endregion
    }
}
