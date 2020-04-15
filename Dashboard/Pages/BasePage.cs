
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Dashboard
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Private Members

        private VM mViewModel;

        #endregion

        #region Public Properties
        /// <summary>
        /// The animation the play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;


        /// <summary>
        /// The animation the play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }

            set
            {
                // If nothing has changed, return
                if (mViewModel == value)
                    return;

                mViewModel = value;

                //Set the data context for this page
                this.DataContext = mViewModel;
            }
        }
        #endregion

        #region Constructor

        public BasePage()
        {
            //If we are animating in, hide to begin with 
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            //List out for the page loading
            this.Loaded += BasePage_Loaded;

            // Create a default view Model
            this.ViewModel = new VM();
        }
        #endregion

        #region Animation Load / unload

        /// <summary>
        /// Once the page is loaded, perfomr any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            // Animate the page in
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch(this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    
                    //Start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;
            }
        }


        /// <summary>
        /// Animated the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft :

                    //Start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds * 2);
                    break;

            }
        }

        #region Animation Helpers



        #endregion
        #endregion

    }
}
