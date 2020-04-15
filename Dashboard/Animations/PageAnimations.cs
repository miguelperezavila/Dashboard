
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Dashboard
{
    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slides a page from the right
        /// </summary>
        /// <param name="page">Page to animated</param>
        /// <param name="seconds">Animation taskes</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight( this Page page, float seconds )
        {
            // Create the story board
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);


            // Add slide from right animation
            sb.AddFadeIn(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // wait for it to finish

            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page out to the left
        /// </summary>
        /// <param name="page">Page to animated</param>
        /// <param name="seconds">Animation taskes</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // Create the story board
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);


            // Add slide from right animation
            sb.AddFadeOut(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // wait for it to finish

            await Task.Delay((int)seconds * 1000);
        }
    }
}
