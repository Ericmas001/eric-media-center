using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.Application;
using System.Drawing;
using System.Windows.Forms;

namespace EMCMoviesAZPlugin
{
    public class MoviesAZApp : IApplication
    {
        #region IApplication Members

        public string Title
        {
            get { return "Movies A-Z"; }
        }

        public Image Icon
        {
            get { return Properties.Resources.logoMovies; }
        }

        public string ShortDescription
        {
            get { return "Movies A-Z"; }
        }

        public UserControl Content
        {
            get { return new MoviesAZPanel(); }
        }

        #endregion
    }
}
