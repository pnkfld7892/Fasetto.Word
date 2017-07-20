using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    public class MenuDesignModel : MenuViewModel
    {

        #region Singleton
        public static MenuDesignModel Instance => new MenuDesignModel();
        #endregion

        #region Constructor
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel{Type = MenuItemType.Header, Text = "Design Time Header..."},
                new MenuItemViewModel{ Text = "Menu Item 1",Icon = IconType.File},
                new MenuItemViewModel{ Text = "Menu Item 2",Icon = IconType.Picture},
            });
        }
            
        #endregion
    }
}
