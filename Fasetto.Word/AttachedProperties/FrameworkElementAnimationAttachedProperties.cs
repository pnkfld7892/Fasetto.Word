using System;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set ot true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent>:BaseAttachedProperty<Parent,bool>
        where Parent : BaseAttachedProperty<Parent,bool>, new()
    {
        protected bool mFirstFire = true;
        #region public properties
        /// <summary>
        /// a flag indication if this is the first time this property has been loaded
        /// </summary>
        public bool FirstLoad { get; set; } = true;
        #endregion
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //get the famework element
            if (!(sender is FrameworkElement element))
                return;

            //don't fire if the value doesn't change
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && !mFirstFire)
                return;

            //no longer first fire
            mFirstFire = false;

            //ON first load
            if(FirstLoad)
            {
                //start of hidden before we decvie how to animate
                //if we are to be animated out initally
                if(!(bool)value)
                    element.Visibility = Visibility.Hidden;

                //create single self-unhookalble event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    //unhook ourselves
                    element.Loaded -= onLoaded;

                    DoAnimation(element, (bool)value);

                    //no longer in first load
                    FirstLoad = false;
                };
                // hook into the loaded event
                element.Loaded += onLoaded;
            }
            else
                DoAnimation(element, (bool)value);

        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The UI Element</param>
        /// <param name="value">the new value</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
            
        }
    }

    /// <summary>
    /// Animates a fframework element sliding it in from the left on show
    /// and slide out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //animate out
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a fframework element sliding it up from the bottom on show
    /// and slide out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //animate out
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a fframework element sliding it up from the bottom on show
    /// and slide out to the bottom on hide
    /// NOTE: Keeps the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
            else
                //animate out
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Animates a fframework element fading in on show
    /// and out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.FadeInAsync(FirstLoad ? 0 : 0.3f);
            else
                //animate out
                await element.FadeOutAsync(FirstLoad ? 0 : 0.3f);
        }
    }
}
