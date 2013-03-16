using EMCMasterPluginLib.Application;
using System.Drawing;
using System.Windows.Forms;

namespace EMCAppTestPlugin
{
    public class MyTestApp : IApplication
    {
        #region IApplication Members

        public string Title
        {
            get { return "Test"; }
        }

        public Image Icon
        {
            get { return null; }
        }

        public string ShortDescription
        {
            get { return "Application de TEST"; }
        }

        public UserControl Content
        {
            get { return new TestPanel(); }
        }

        #endregion IApplication Members
    }
}