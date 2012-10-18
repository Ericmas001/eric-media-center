using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.WebService;

namespace EMCTestWSPlugin
{
    public class WatchSeriesWSPlugin : IEMCWebServicePlugin
    {
        #region IEMCWebServicePlugin Members

        public IWebService GetWebService()
        {
            return new WatchSeriesWebService();
        }

        #endregion

        #region IEMCMasterPlugin Members

        public string UniqueName
        {
            get { return "WatchSeriesWSPlugin"; }
        }

        public string FullName
        {
            get { return "Webservice client for WatchSeries"; }
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
