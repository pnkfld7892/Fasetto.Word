namespace Fasetto.Word.Core
{
    /// <summary>
    /// A designtime data for a <see cref="MenuItemViewModel"/>
    /// </summary>
    public class MenuItemDesignModel : MenuItemViewModel
    {
        #region Singleton
        public static MenuItemDesignModel Instance => new MenuItemDesignModel();
            
        #endregion

        #region Constructor
         public MenuItemDesignModel()
            {
                Text = "Hello World";
                Icon = IconType.File;
            }
        #endregion
    }
}
