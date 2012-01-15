using System;
using System.Collections.Generic;
using System.Text;

namespace EMCMasterPluginLib.Application
{
    public interface IEMCApplicationPlugin : IEMCMasterPlugin
    {
        IApplication GetApplication();
    }
}
