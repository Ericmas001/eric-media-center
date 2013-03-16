namespace EMCMasterPluginLib.WebService
{
    public interface IEMCWebServicePlugin : IEMCMasterPlugin
    {
        IWebService GetWebService();
    }
}