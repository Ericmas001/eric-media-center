using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WatchSeriesAppPlugin.Entities
{

    public class LinkInfo
    {
        private string m_Name;
        private List<int> m_Ids;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public List<int> Ids
        {
            get { return m_Ids; }
            set { m_Ids = value; }
        }

        public LinkInfo(EpisodeInfo episode, string name, List<int> ids)
        {
            m_Name = name;
            m_Ids = ids;
        }
        public override string ToString()
        {
            return m_Name;
        }
        public static Dictionary<string, LinkInfo> GetLinks(EpisodeInfo episode, dynamic lstLinks)
        {
            Dictionary<string, LinkInfo> links = new Dictionary<string, LinkInfo>();
            foreach (string s in lstLinks.Keys)
            {
                LinkInfo l = new LinkInfo(episode,lstLinks[s].Name,lstLinks[s].Ids);
                links.Add(s, l);
            }
            return links;
        }
    }
}
