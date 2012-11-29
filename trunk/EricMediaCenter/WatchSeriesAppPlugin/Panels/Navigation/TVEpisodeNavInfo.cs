using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchSeriesAppPlugin.Panels.Navigation.Core;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public class TVEpisodeNavInfo : NavInfo
    {
        private EpisodeSummaryInfo m_EpisodeSummary;
        private EpisodeSummaryInfo m_EpisodePrev;
        private EpisodeSummaryInfo m_EpisodeNext;
        private EpisodeInfo m_EpisodeFull;

        public EpisodeSummaryInfo EpisodeSummary
        {
            get { return m_EpisodeSummary; }
            set { m_EpisodeSummary = value; }
        }
        public EpisodeSummaryInfo EpisodePrev
        {
            get { return m_EpisodePrev; }
            set { m_EpisodePrev = value; }
        }
        public EpisodeSummaryInfo EpisodeNext
        {
            get { return m_EpisodeNext; }
            set { m_EpisodeNext = value; }
        }
        public EpisodeInfo EpisodeFull
        {
            get { return m_EpisodeFull; }
            set { m_EpisodeFull = value; }
        }

        public TVEpisodeNavInfo(EpisodeSummaryInfo nfo, EpisodeSummaryInfo prev, EpisodeSummaryInfo next, NavInfo[] parents, UserInfo user)
            : base(nfo.Title, NavType.TVEpisode, parents, user)
        {
            m_EpisodeSummary = nfo;
            m_EpisodePrev = prev;
            m_EpisodeNext = next;
            m_EpisodeFull = m_EpisodeSummary.LoadEpisode();
        }
    }
}
