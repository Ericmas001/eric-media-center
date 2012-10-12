using System;
using System.Collections.Generic;
using System.Text;

namespace EMCMasterPluginLib.WebService
{
    public interface IEMCWebServicePlugin : IEMCMasterPlugin
    {
        IWebService GetWebService();
    }
}
