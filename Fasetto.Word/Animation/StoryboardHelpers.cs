using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// Animation helpers for storyboards
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Adds Slide From Right
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin">keep the element at same width? </param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds Slide From left
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset">the distance to the left to start from</param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin">keep the element at same width? </param>
        /// 
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds SLide to left
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin">keep the element at same width? </param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds SLide to right
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds FadeIn Animation
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds FadeOut Animation
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }
    }
}
