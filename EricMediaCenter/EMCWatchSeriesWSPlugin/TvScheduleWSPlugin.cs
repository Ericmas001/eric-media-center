using EMCMasterPluginLib.WebService;
using System;

namespace EMCWatchSeriesWSPlugin
{
    public class TvScheduleWSPlugin : IEMCWebServicePlugin
    {
        #region IEMCWebServicePlugin Members

        public IWebService GetWebService()
        {
            return new TvScheduleWebService();
        }

        #endregion IEMCWebServicePlugin Members

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

        #endregion IEMCMasterPlugin Members
    }
}