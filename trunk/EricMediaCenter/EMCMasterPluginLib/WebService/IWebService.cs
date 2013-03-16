using System.Collections.Generic;

namespace EMCMasterPluginLib.WebService
{
    public interface IWebService
    {
        string Title { get; }

        string BaseUrl { get; }

        Dictionary<string, string> Commands { get; }

        object GetResult(string command, string result);
    }
}