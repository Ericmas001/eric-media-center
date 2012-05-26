using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCRestService
{
    public class ScheduleEntry
    {
        private string m_Url;

        public string Url
        {
            get { return m_Url; }
            set { m_Url = value; }
        }
        private string m_ShowName;

        public string ShowName
        {
            get { return m_ShowName; }
            set { m_ShowName = value; }
        }
        private string m_ShowTitle;

        public string ShowTitle
        {
            get { return m_ShowTitle; }
            set { m_ShowTitle = value; }
        }
        private int m_Season;

        public int Season
        {
            get { return m_Season; }
            set { m_Season = value; }
        }
        private int m_Episode;

        public int Episode
        {
            get { return m_Episode; }
            set { m_Episode = value; }
        }
    }
}