using System;
using System.Collections.Generic;

namespace WatchSeriesAppPlugin.Entities
{
    public class ShowInfo : ShowSummaryInfo
    {
        private DateTime m_ReleaseDate;
        private string m_Genre;
        private string m_Status;
        private string m_Network;
        private string m_Imdb;
        private string m_Description;
        private int m_NbEpisodes;
        private string m_RssFeed;
        private string m_LogoURL;
        private Dictionary<int, SeasonInfo> m_Seasons;

        public DateTime ReleaseDate
        {
            get { return m_ReleaseDate; }
            set { m_ReleaseDate = value; }
        }

        public string Genre
        {
            get { return m_Genre; }
            set { m_Genre = value; }
        }

        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public string Network
        {
            get { return m_Network; }
            set { m_Network = value; }
        }

        public string Imdb
        {
            get { return m_Imdb; }
            set { m_Imdb = value; }
        }

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        public int NbEpisodes
        {
            get { return m_NbEpisodes; }
            set { m_NbEpisodes = value; }
        }

        public string RssFeed
        {
            get { return m_RssFeed; }
            set { m_RssFeed = value; }
        }

        public string LogoURL
        {
            get { return m_LogoURL; }
            set { m_LogoURL = value; }
        }

        public Dictionary<int, SeasonInfo> Seasons
        {
            get { return m_Seasons; }
            set { m_Seasons = value; }
        }

        public ShowInfo(ShowSummaryInfo i, DateTime releaseDate, string genre, string status, string network, string imdb, string description, int nbEpisodes, string rssFeed, string logoUrl)
            : this(i.Name, i.Title, i.ReleaseYear, releaseDate, genre, status, network, imdb, description, nbEpisodes, rssFeed, logoUrl)
        {
        }

        public ShowInfo(string name, string title, int releaseYear, DateTime releaseDate, string genre, string status, string network, string imdb, string description, int nbEpisodes, string rssFeed, string logoUrl)
            : base(name, title, releaseYear)
        {
            m_ReleaseDate = releaseDate;
            m_Genre = genre;
            m_Status = status;
            m_Network = network;
            m_Imdb = imdb;
            m_Description = description;
            m_NbEpisodes = nbEpisodes;
            m_RssFeed = rssFeed;
            m_LogoURL = logoUrl;
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}