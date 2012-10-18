﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EMCWatchSeriesWSPlugin.Entries
{
    public class ShowSummaryInfo
    {
        string m_Name;
        string m_Title;
        int m_ReleaseYear;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int ReleaseYear
        {
            get { return m_ReleaseYear; }
            set { m_ReleaseYear = value; }
        }

        public ShowSummaryInfo(string name, string title, int releaseYear)
        {
            m_Name = name;
            m_Title = title;
            m_ReleaseYear = releaseYear;
        }
        public ShowSummaryInfo(JObject r)
        {
            m_Name = (string)r["ShowName"];
            m_Title = (string)r["ShowTitle"];
            m_ReleaseYear = (int)r["ReleaseYear"];
        }
        public override string ToString()
        {
            return String.Format("{0}{1}: {2}", m_Title, m_ReleaseYear > 0 ? String.Format(" ({0})", m_ReleaseYear) : "", m_Name);
        }
    }
}
