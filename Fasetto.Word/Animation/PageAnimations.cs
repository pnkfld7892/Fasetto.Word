using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.Word { 

   public static class PageAnimations
    {
        /// <summary>
        /// Slides a page in from right
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            //create storyboard
            var sb = new Storyboard();

            //add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);
            //add fadein
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(page);
            //make page visible
            page.Visibility = Visibility.Visible;

            //await task

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page out to the left
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float seconds)
        {
            //create storyboard
            var sb = new Storyboard();

            //add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);
            //add fadein
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(page);
            //make page visible
            page.Visibility = Visibility.Visible;

            //await task

            await Task.Delay((int)(seconds * 1000));
        }
    }
}
