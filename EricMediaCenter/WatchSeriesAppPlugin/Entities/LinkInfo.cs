using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WatchSeriesAppPlugin.Entities
{

    public class LinkInfo : LinkSummaryInfo
    {
        private string m_FullUrl;
        private bool m_Supported;
        private string m_WebSiteURL;
        private string m_Args;

        public string FullUrl
        {
            get { return m_FullUrl; }
            set { m_FullUrl = value; }
        }

        public bool Supported
        {
            get { return m_Supported; }
            set { m_Supported = value; }
        }

        public string WebSiteURL
        {
            get { return m_WebSiteURL; }
            set { m_WebSiteURL = value; }
        }

        public string Args
        {
            get { return m_Args; }
            set { m_Args = value; }
        }

        public LinkInfo(LinkSummaryInfo nfo, string fullUrl, bool supported, string webSiteURL, string args):
            base(nfo.Website,nfo.Id,nfo.No)
        {
            m_FullUrl = fullUrl;
            m_Supported = supported;
            m_WebSiteURL = webSiteURL;
            m_Args = args;
        }
    }
}
