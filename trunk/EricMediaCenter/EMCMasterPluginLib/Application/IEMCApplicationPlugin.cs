namespace EMCMasterPluginLib.Application
{
    public interface IEMCApplicationPlugin : IEMCMasterPlugin
    {
        IApplication GetApplication();
    }
}