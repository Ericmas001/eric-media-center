using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCMasterPluginLib
{
    public abstract class AbstractParsedWebsite
    {
        private readonly string m_Url;
        public string Url { get { return m_Url; } }
        public AbstractParsedWebsite(string url)
        {
            m_Url = url;
        }
    }
}
