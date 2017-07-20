namespace Fasetto.Word.Core
{
    /// <summary>
    /// A viewmodel for a menu item
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The text of the menu item
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// THe Icon for this menu item
        /// </summary>
        public IconType Icon { get; set; }

        /// <summary>
        /// Type this menu item is
        /// </summary>
        public MenuItemType Type { get; set; }


    }
}
