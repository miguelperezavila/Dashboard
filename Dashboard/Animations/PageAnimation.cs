using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    /// <summary>
    /// Styles of page animations for appearing/disapperaing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// The page has no animation
        /// </summary>
        None = 0,

        /// <summary>
        /// The page slides in and fades in from right
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// The page slides out and fade out to left
        /// </summary>
        SlideAndFadeOutToLeft = 2,
    }
}
