using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.WebService;

namespace EMCTestWSPlugin
{
    public class TvScheduleWSPlugin : IEMCWebServicePlugin
    {
        #region IEMCWebServicePlugin Members

        public IWebService GetWebService()
        {
            return new TvScheduleWebService();
        }

        #endregion

        #region IEMCMasterPlugin Members

        public string UniqueName
        {
            get { return "TvScheduleWSPlugin"; }
        }

        public string FullName
        {
            get { return "Webservice client for TvSchedule"; }
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
