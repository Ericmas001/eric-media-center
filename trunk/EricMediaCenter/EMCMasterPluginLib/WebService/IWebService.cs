using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Drawing;
using System.Windows.Forms;

namespace EMCMasterPluginLib.WebService
{
    public interface IWebService
    {
        string Title { get; }
        string BaseUrl { get; }
        string[] Commands { get; }
        object GetResult(string command, string args);
    }
}
