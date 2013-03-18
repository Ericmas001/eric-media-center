using System.Collections.Generic;

namespace EMCTv
{
    public class TvShow : ListedShow
    {
        private SortedDictionary<int, IEnumerable<ListedEpisode>> m_Episodes = new SortedDictionary<int, IEnumerable<ListedEpisode>>();
        private int m_NoLastSeason;
        private int m_NoLastEpisode;

        public SortedDictionary<int, IEnumerable<ListedEpisode>> Episodes
        {
            get { return m_Episodes; }
            set { m_Episodes = value; }
        }

        public int NoLastSeason
        {
            get { return m_NoLastSeason; }
            set { m_NoLastSeason = value; }
        }

        public int NoLastEpisode
        {
            get { return m_NoLastEpisode; }
            set { m_NoLastEpisode = value; }
        }
    }
}