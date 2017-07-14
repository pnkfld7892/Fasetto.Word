﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.Word { 

   public static class FrameworkElementAnimations
    {
        /// <summary>
        /// Slides an element in from right
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create storyboard
            var sb = new Storyboard();

            //add slide from right animation
            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);
            //add fadein
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            
            //await task

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element in from left
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create storyboard
            var sb = new Storyboard();

            //add slide from Left animation
            sb.AddSlideFromLeft(seconds, element.ActualWidth,keepMargin:keepMargin);
            //add fadein
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;

            //await task

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the left
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin  = true)
        {
            //create storyboard
            var sb = new Storyboard();

            //add slide from right animation
            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);
            //add fadein
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;

            //await task

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the Right
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create storyboard
            var sb = new Storyboard();

            //add slide from right animation
            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargin);
            //add fadein
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;

            //await task

            await Task.Delay((int)(seconds * 1000));
        }
    }
}