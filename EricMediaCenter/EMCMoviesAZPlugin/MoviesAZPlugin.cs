using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.Application;
using System.Drawing;
using System.Windows.Forms;

namespace EMCMoviesAZPlugin
{
    public class MoviesAZPlugin : IEMCApplicationPlugin
    {
        #region IEMCApplicationPlugin Members

        public IApplication GetApplication()
        {
            return new MoviesAZApp();
        }

        #endregion

        #region IEMCMasterPlugin Members

        public string UniqueName
        {
            get { return "appMoviesAZPlugin"; }
        }

        public string FullName
        {
            get { return "MoviesAZ"; }
        }

        public Version Version
        {
            get { return new Version(0, 0, 1); }
        }

        public bool Load()
        {
            return true;
        }

        #endregion
    }
}
