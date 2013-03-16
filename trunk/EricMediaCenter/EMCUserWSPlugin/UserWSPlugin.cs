using EMCMasterPluginLib.WebService;
using System;

namespace EMCUserWSPlugin
{
    public class UserWSPlugin : IEMCWebServicePlugin
    {
        #region IEMCWebServicePlugin Members

        public IWebService GetWebService()
        {
            return new UserWebService();
        }

        #endregion IEMCWebServicePlugin Members

        #region IEMCMasterPlugin Members

        public string UniqueName
        {
            get { return "userWSPlugin"; }
        }

        public string FullName
        {
            get { return "Webservice de user"; }
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