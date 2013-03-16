using System.Drawing;
using System.Windows.Forms;

namespace EMCMasterPluginLib.Application
{
    public interface IApplication
    {
        string Title { get; }

        Image Icon { get; }

        string ShortDescription { get; }

        UserControl Content { get; }
    }
}