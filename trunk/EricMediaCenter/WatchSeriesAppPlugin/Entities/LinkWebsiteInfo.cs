using System.Collections.Generic;

namespace WatchSeriesAppPlugin.Entities
{
    public class LinkWebsiteInfo
    {
        private EpisodeInfo m_Episode;
        private string m_Name;
        private List<LinkSummaryInfo> m_LinkIds;

        public EpisodeInfo Episode
        {
            get { return m_Episode; }
            set { m_Episode = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public List<LinkSummaryInfo> LinkIds
        {
            get { return m_LinkIds; }
            set { m_LinkIds = value; }
        }

        public LinkWebsiteInfo(EpisodeInfo episode, string name)
        {
            m_Episode = episode;
            m_Name = name;
        }

        public override string ToString()
        {
            return m_Name;
        }

        public static Dictionary<string, LinkWebsiteInfo> GetLinks(EpisodeInfo episode, dynamic lstLinks)
        {
            Dictionary<string, LinkWebsiteInfo> links = new Dictionary<string, LinkWebsiteInfo>();
            foreach (string s in lstLinks.Keys)
            {
                LinkWebsiteInfo l = new LinkWebsiteInfo(episode, lstLinks[s].Name);
                l.LinkIds = new List<LinkSummaryInfo>();
                for (int i = 0; i < lstLinks[s].Ids.Count; ++i)
                    l.LinkIds.Add(new LinkSummaryInfo(l, lstLinks[s].Ids[i], i + 1));
                links.Add(s, l);
            }
            return links;
        }
    }
}