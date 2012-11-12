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
