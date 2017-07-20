namespace Fasetto.Word.Core
{
    /// <summary>
    /// Helper functions for <see cref="IconType"/>
    /// </summary>
    public static class IconTypeExtensions
    {
        /// <summary>
        ///converts <see cref="IconType"/> to a fontawesome String
        /// </summary>
        public static string ToFontAwesome(this IconType type)
        {
            ///Return a fontAwesome string based on the icon type
            switch (type)
            {
                case IconType.File:
                    return "\uf0f6";

                case IconType.Picture:
                    return "\uf1c5";

                case IconType.None:
                    return string.Empty;

                default:
                    return null;
            }
        }
    }
}
