using EMCMasterPluginLib;

namespace WatchSeriesAppPlugin.Entities
{
    public class LinkSummaryInfo
    {
        private LinkWebsiteInfo m_Website;
        private int m_Id;
        private int m_No;

        public LinkWebsiteInfo Website
        {
            get { return m_Website; }
            set { m_Website = value; }
        }

        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public int No
        {
            get { return m_No; }
            set { m_No = value; }
        }

        public LinkSummaryInfo(LinkWebsiteInfo website, int id, int no)
        {
            m_Website = website;
            m_Id = id;
            m_No = no;
        }

        public override string ToString()
        {
            return "Link #" + m_No;
        }

        public LinkInfo LoadLink()
        {
            dynamic l = EMCGlobal.GetWebServiceResult("WatchSeries|GetUrl", m_Id.ToString());
            if (l == null)
                return null;

            LinkInfo link = new LinkInfo(this, l.FullUrl, l.Supported, l.WebSite, l.Args);
            return link;
        }
    }
}