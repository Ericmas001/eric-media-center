using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.Application;
using System.Drawing;
using System.Windows.Forms;

namespace EMCAppTestPlugin
{
    public class AppTestPlugin : IEMCApplicationPlugin
    {
        #region IEMCApplicationPlugin Members

        public IApplication GetApplication()
        {
            return new MyTestApp();
        }

        #endregion

        #region IEMCMasterPlugin Members

        public string UniqueName
        {
            get { return "appTestPlugin"; }
        }

        public string FullName
        {
            get { return "Application de test"; }
        }

        public Version Version
        {
            get { return new Version(0, 0, 3); }
        }

        public bool Load()
        {
            return true;
        }

        #endregion
    }
}
