using Newtonsoft.Json.Linq;

namespace EMCWatchSeriesWSPlugin.Entries
{
    public class DownloadUrl
    {
        private string m_FullUrl;
        private bool m_Supported;
        private string m_WebSite;
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

        public string WebSite
        {
            get { return m_WebSite; }
            set { m_WebSite = value; }
        }

        public string Args
        {
            get { return m_Args; }
            set { m_Args = value; }
        }

        public DownloadUrl(string fullUrl, bool supported, string webSite, string args)
        {
            m_FullUrl = fullUrl;
            m_Supported = supported;
            m_WebSite = webSite;
            m_Args = args;
        }

        public DownloadUrl(JObject r)
        {
            //{
            //"url":"http://www.allmyvideos.net/ga0lxylkcuy7",
            //"supported":false,
            //"website":"allmyvideos.net",
            //"args":null
            //}

            //{
            //"url":"http://gorillavid.in/r7k9my4xu42c",
            //"supported":true,
            //"website":"gorillavid.in",
            //"args":"r7k9my4xu42c"
            //}
            m_FullUrl = (string)r["url"];
            m_Supported = (bool)r["supported"];
            m_WebSite = (string)r["website"];
            m_Args = (string)r["args"];
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}