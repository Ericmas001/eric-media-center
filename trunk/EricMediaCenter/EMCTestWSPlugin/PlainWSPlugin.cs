using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.WebService;

namespace EMCTestWSPlugin
{
    public class PlainWSPlugin : IEMCWebServicePlugin
    {
        #region IEMCWebServicePlugin Members

        public IWebService GetWebService()
        {
            return new MyPlainWebService();
        }

        #endregion

        #region IEMCMasterPlugin Members

        public string UniqueName
        {
            get { return "plainWSPlugin"; }
        }

        public string FullName
        {
            get { return "Webservice de test (plain)"; }
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
