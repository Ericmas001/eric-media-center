using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace EMCWatchSeriesWSPlugin.Entries
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

        public static Dictionary<string, LinkInfo> DeserializeLinks(EpisodeInfo episode, JArray results)
        {
            Dictionary<string, LinkInfo> all = new Dictionary<string, LinkInfo>();
            if (results == null)
                return all;
            foreach (JObject r in results)
            {
                LinkInfo info = new LinkInfo(episode, r);
                all.Add(info.Name, info);
            }
            return all;
        }

        public LinkInfo(EpisodeInfo episode, JObject r)
        {
            //  {
            //	"Name":"allmyvideos.net",
            //	"LinkIDs":
            //	 [
            //		6804502,
            //		6802462,
            //		6802391
            //	 ]
            //	}
            m_Name = (string)r["Name"];
            m_Ids = new List<int>();
            foreach (JToken t in (JArray)r["LinkIDs"])
                m_Ids.Add((int)t);
        }

        public override string ToString()
        {
            //TODO
            string ids = "";
            foreach (int i in m_Ids)
                ids += i + ", ";
            if (ids.Length > 1)
                ids = ids.Remove(ids.Length - 3);
            return String.Format("\"{0}\": {1}", m_Name, ids);
        }
    }
}