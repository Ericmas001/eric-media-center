using EMCMasterPluginLib.Application;
using System.Drawing;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Panels;

namespace WatchSeriesAppPlugin
{
    public class WatchSeriesApp : IApplication
    {
        #region IApplication Members

        public string Title
        {
            get { return "Watch Series"; }
        }

        public Image Icon
        {
            get { return Properties.Resources.watchseries_small; }
        }

        public string ShortDescription
        {
            get { return "Application WatchSeries"; }
        }

        public UserControl Content
        {
            get { return new MainPanel(); }
        }

        #endregion IApplication Members
    }
}