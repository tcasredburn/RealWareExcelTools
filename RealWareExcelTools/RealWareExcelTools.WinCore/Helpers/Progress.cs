using DevExpress.XtraSplashScreen;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Helpers
{
    /// <summary>
    /// Helper functions for loading/displaying progress to the user.
    /// </summary>
    public sealed class Progress
    {
        /// <summary>
        /// Create the loading wheel on the specified control.
        /// </summary>
        /// <param name="c">The control to create a loading wheel on</param>
        /// <returns>A handle ID for using later</returns>
        public static IOverlaySplashScreenHandle CreateProgressPanel(Control c)
        {
            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = ShowProgressPanel(c);
            }
            catch { handle = null; }
            return handle;
        }

        /// <summary>
        /// Closes the progress panel.
        /// NOTE: Use the same handle from <see cref="CreateProgressPanel(Control)"></see>
        /// </summary>
        /// <param name="handle">Handle identifier for loading wheel</param>
        public static void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }
        private static IOverlaySplashScreenHandle ShowProgressPanel(Control c)
            => SplashScreenManager.ShowOverlayForm(c);
    }
}
