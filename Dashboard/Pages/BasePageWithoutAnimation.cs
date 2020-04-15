
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
    public class BasePageWithoutAnimation<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Private Members

        private VM mViewModel;

        #endregion

        #region Public Properties
       

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

        public BasePageWithoutAnimation()
        {
           

            // Create a default view Model
            this.ViewModel = new VM();
        }
        #endregion


    }
}
