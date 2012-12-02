using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WatchSeriesAppPlugin.Entities
{

    public class LinkWebsiteInfo
    {
        private EpisodeInfo m_Episode;
        private string m_Name;
        private List<int> m_LinkIds;


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

        public List<int> LinkIds
        {
            get { return m_LinkIds; }
            set { m_LinkIds = value; }
        }

        public LinkWebsiteInfo(EpisodeInfo episode, string name, List<int> ids)
        {
            m_Episode = episode;
            m_Name = name;
            m_LinkIds = ids;
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
                LinkWebsiteInfo l = new LinkWebsiteInfo(episode,lstLinks[s].Name,lstLinks[s].Ids);
                links.Add(s, l);
            }
            return links;
        }
    }
}
