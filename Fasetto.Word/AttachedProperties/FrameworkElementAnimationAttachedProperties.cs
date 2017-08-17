using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;

namespace Fasetto.Word
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Protected Properties

        /// <summary>
        /// True if this is the very first time the value has been updated
        /// Used to make sure we run the logic at least once during first load
        /// </summary>
        protected Dictionary<DependencyObject, bool> mAlreadyLoaded = new Dictionary<DependencyObject, bool>();

        /// <summary>
        /// The most recent value used if we get a value changed before we do the first load
        /// </summary>
        protected Dictionary<DependencyObject, bool> mFirstLoadValue = new Dictionary<DependencyObject, bool>();

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Don't fire if the value doesn't change
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && mAlreadyLoaded.ContainsKey(sender))
                return;

            // On first load...
            if (!mAlreadyLoaded.ContainsKey(sender))
            {
                // Flag that we are in first load but have not finished it
                mAlreadyLoaded[sender] = false;

                // Start off hidden before we decide how to animate
                // if we are to be animated out initially
                if (!(bool)value)
                    element.Visibility = Visibility.Hidden;

                // Create a single self-unhookable event 
                // for the elements Loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = async (ss, ee) =>
                {
                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Slight delay after load is needed for some elements to get laid out
                    // and their width/heights correctly calculated
                    await Task.Delay(5);

                    // Do desired animation
                    DoAnimation(element, mFirstLoadValue.ContainsKey(sender) ? mFirstLoadValue[sender] : (bool)value, true);

                    // Flag that we have finished first load
                    mAlreadyLoaded[sender] = true;
                };

                // Hook into the Loaded event of the element
                element.Loaded += onLoaded;
            }
            // If we have started a first load but not fired the animation yet, update the property
            else if (mAlreadyLoaded[sender] == false)
                mFirstLoadValue[sender] = (bool)value;
            else
                // Do desired animation
                DoAnimation(element, (bool)value, false);
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="value">The new value</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the left on show
    /// and sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Left, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }


    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// NOTE: Keeps the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Animates a framework element fading in on show
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            else
                // Animate out
                await element.FadeOutAsync(firstLoad ? 0 : 0.3f);
        }
    }

 
}

//namespace Fasetto.Word
//{
//    /// <summary>
//    /// A base class to run any animation method when a boolean is set ot true
//    /// and a reverse animation when set to false
//    /// </summary>
//    /// <typeparam name="Parent"></typeparam>
//    public abstract class AnimateBaseProperty<Parent>:BaseAttachedProperty<Parent,bool>
//        where Parent : BaseAttachedProperty<Parent,bool>, new()
//    {
//        protected bool mFirstFire = true;
//        #region public properties
//        /// <summary>
//        /// a flag indication if this is the first time this property has been loaded
//        /// </summary>
//        public bool FirstLoad { get; set; } = true;
//        #endregion
//        public override void OnValueUpdated(DependencyObject sender, object value)
//        {
//            //get the famework element
//            if (!(sender is FrameworkElement element))
//                return;

//            //don't fire if the value doesn't change
//            if ((bool)sender.GetValue(ValueProperty) == (bool)value && !mFirstFire)
//                return;

//            //no longer first fire
//            mFirstFire = false;

//            //ON first load
//            if(FirstLoad)
//            {
//                //start of hidden before we decvie how to animate
//                //if we are to be animated out initally
//                if(!(bool)value)
//                    element.Visibility = Visibility.Hidden;

//                //create single self-unhookalble event
//                RoutedEventHandler onLoaded = null;
//                onLoaded = (ss, ee) =>
//                {
//                    //unhook ourselves
//                    element.Loaded -= onLoaded;

//                    DoAnimation(element, (bool)value);

//                    //no longer in first load
//                    FirstLoad = false;
//                };
//                // hook into the loaded event
//                element.Loaded += onLoaded;
//            }
//            else
//                DoAnimation(element, (bool)value);

//        }

//        /// <summary>
//        /// The animation method that is fired when the value changes
//        /// </summary>
//        /// <param name="element">The UI Element</param>
//        /// <param name="value">the new value</param>
//        protected virtual void DoAnimation(FrameworkElement element, bool value)
//        {

//        }
//    }

//    /// <summary>
//    /// Animates a fframework element sliding it in from the left on show
//    /// and slide out to the left on hide
//    /// </summary>
//    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
//    {
//        protected override async void DoAnimation(FrameworkElement element, bool value)
//        {
//            if (value)
//                //animate in
//                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
//            else
//                //animate out
//                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
//        }
//    }

//    /// <summary>
//    /// Animates a fframework element sliding it up from the bottom on show
//    /// and slide out to the bottom on hide
//    /// </summary>
//    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
//    {
//        protected override async void DoAnimation(FrameworkElement element, bool value)
//        {
//            if (value)
//                //animate in
//                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
//            else
//                //animate out
//                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
//        }
//    }

//    /// <summary>
//    /// Animates a fframework element sliding it up from the bottom on show
//    /// and slide out to the bottom on hide
//    /// NOTE: Keeps the margin
//    /// </summary>
//    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
//    {
//        protected override async void DoAnimation(FrameworkElement element, bool value)
//        {
//            if (value)
//                //animate in
//                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
//            else
//                //animate out
//                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
//        }
//    }

//    /// <summary>
//    /// Animates a fframework element fading in on show
//    /// and out on hide
//    /// </summary>
//    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
//    {
//        protected override async void DoAnimation(FrameworkElement element, bool value)
//        {
//            if (value)
//                //animate in
//                await element.FadeInAsync(FirstLoad ? 0 : 0.3f);
//            else
//                //animate out
//                await element.FadeOutAsync(FirstLoad ? 0 : 0.3f);
//        }
//    }
//}
