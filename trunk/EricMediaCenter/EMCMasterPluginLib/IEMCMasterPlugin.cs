using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCMasterPluginLib
{
    public interface IEMCMasterPlugin
    {
        string UniqueName { get; }
        string FullName { get; }
        Version Version { get; }

        bool Load();
    }
}
