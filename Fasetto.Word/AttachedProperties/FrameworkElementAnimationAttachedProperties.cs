﻿using System;
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
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            //ON first load
            if(FirstLoad)
            {
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
}