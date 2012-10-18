using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EMCWatchSeriesWSPlugin.Entries
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
        private Dictionary<int,SeasonInfo> m_Seasons;
        
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
        public Dictionary<int,SeasonInfo> m_Seasons          
        {
            get { return m_Seasons; } 
            set { m_Seasons = value; }       
        }         
        public ShowInfo(ShowSummaryInfo i, DateTime releaseDate, string genre, string status, string network, string imdb, string description, int nbEpisodes, string rssFeed, string logoUrl, Dictionary<int,SeasonInfo> seasons)
            : this(i.Name, i.Title, i.ReleaseYear, releaseDate, genre, status, network, imdb, description, nbEpisodes, rssFeed, logoUrl, seasons)
        {
        }
        public ShowInfo(string name, string title, int releaseYear, DateTime releaseDate, string genre, string status, string network, string imdb, string description, int nbEpisodes, string rssFeed, string logoUrl, Dictionary<int,SeasonInfo> seasons)
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
			m_LogoURL = logoURL;
			m_Seasons = seasons;
        }
        public ShowInfo(JObject r)
            : base(r)
        {			
            // {
            // "ReleaseDate":"\/Date(1347865200000-0700)\/",
            // "Genre":"mystery",
            // "Status":"New Series",
            // "Network":"NBC (US)",
            // "Imdb":"tt2070791",
            // "Description":"What would you do without it all? In this epic adventure from J.J. Abrams' Bad Robot Productions...",
            // "NbEpisodes":5,
            // "RssFeed":"5921",
            // "Logo":"http://watchseries.eu/imagini/Revolution2012.JPG",
            // "Seasons": [...],
            // "ShowName":"revolution_(2012)",
            // "ShowTitle":"Revolution (2012)",
            // "ReleaseYear":2012}
			// }
			m_ReleaseDate = (DateTime)r["ReleaseDate"];
			m_Genre = (string)r["Genre"];
			m_Status = (string)r["Status"];
			m_Network = (string)r["Network"];
			m_Imdb = (string)["Imdb"];
			m_Description = (string)r["Description"];
			m_NbEpisodes = (int)r["NbEpisodes"];
			m_RssFeed = (string)r["RssFeed"];
			m_LogoURL = (string)r["Logo"];
			m_Seasons = SeasonInfo.DeserializeSeasons((JArray)r["Seasons"]);
        }
        public override string ToString()
        {
			//TODO
            return base.ToString();
        }
    }
	
    public class SeasonInfo
    {
		private int m_No;
		private int m_NbEpisodes;
		private string m_Name;
		private Dictionary<int,EpisodeSummaryInfo> m_Episodes;
		private ShowInfo m_Show;
        public int No          
        {
            get { return m_No; } 
            set { m_No = value; }       
        }   
        public int NbEpisodes          
        {
            get { return m_NbEpisodes; } 
            set { m_NbEpisodes = value; }       
        }   
        public string Name          
        {
            get { return m_Name; } 
            set { m_Name = value; }       
        }   
        public Dictionary<int,EpisodeSummaryInfo> Episodes          
        {
            get { return m_Episodes; } 
            set { m_Episodes = value; }       
        }  
        public ShowInfo Show          
        {
            get { return m_Show; } 
            set { m_Show = value; }       
        }   
        public SeasonInfo(ShowInfo show, int no, int nbEpisodes, string name, Dictionary<int,EpisodeSummaryInfo> episodes)
        {
			m_No = no;
			m_NbEpisodes = nbEpisodes;
			m_Name = name;
			m_Episodes = episodes;
			m_Show = show;
        }
		public static Dictionary<int,SeasonInfo> DeserializeSeasons(ShowInfo show, JArray results )
		{
			Dictionary<int,SeasonInfo> all = new Dictionary<int,SeasonInfo>();
			foreach( JObject r in results )
			{
				SeasonInfo info = new SeasonInfo(show, r);
				all.Add(info.No, info);
			}
			return all;
		}
        public SeasonInfo(ShowInfo show, JObject r)
        {
            //      {
            //      "SeasonNo":1,
            //      "NbEpisodes":5,
            //      "SeasonName":null,
            //      "Episodes":[...]
            //       }
			m_No = (int)r["SeasonNo"];
			m_NbEpisodes = (int)r["NbEpisodes"];
			m_Name = (string)r["SeasonName"];
			m_Episodes = EpisodeSummaryInfo.DeserializeEpisodes((JArray)r["Episodes"]);
			m_Show = show;
        }
        public override string ToString()
        {
			//TODO
            return base.ToString();
        }
    }
	
    public class EpisodeSummaryInfo
    {
		private int m_No;
		private int m_Id;
		private string m_Name;
		private string m_Title;
		private DateTime m_ReleaseDate;
		private SeasonInfo m_Season;
		
		public int No          
        {
            get { return m_No; } 
            set { m_No = value; }       
        }   
		public int Id          
        {
            get { return m_Id; } 
            set { m_Id = value; }       
        }   
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
        public DateTime ReleaseDate          
        {
            get { return m_ReleaseDate; } 
            set { m_ReleaseDate = value; }       
        }  
        public SeasonInfo Season          
        {
            get { return m_Season; } 
            set { m_Season = value; }       
        }  
		
        public EpisodeSummaryInfo(SeasonInfo season, int no, int id, string name, string title, DateTime releaseDate)
        {
			m_No = no;
			m_Id = id;
			m_Name = name;
			m_Title = title;
			m_ReleaseDate = releaseDate;
			m_Season = season;
        }
		public static Dictionary<int,EpisodeSummaryInfo> DeserializeEpisodes( SeasonInfo season, JArray results )
		{
			Dictionary<int,EpisodeSummaryInfo> all = new Dictionary<int,EpisodeSummaryInfo>();
			foreach( JObject r in results )
			{
				EpisodeSummaryInfo info = new EpisodeSummaryInfo(season, r);
				all.Add(info.No, info);
			}
			return all;
		}
        public EpisodeSummaryInfo(SeasonInfo season, JObject r)
        {
            //          {
            //          "EpisodeNo":1,
            //          "EpisodeId":194518,
            //          "EpisodeName":"revolution_(2012)_s1_e1-194518",
            //          "EpisodeTitle":"Pilot",
            //          "ReleaseDate":"\/Date(1347865200000-0700)\/"
            //          }
			m_No = (int)r["EpisodeNo"];
			m_Id = (int)r["EpisodeId"];
			m_Name = (string)r["EpisodeName"];
			m_Title = (string)r["EpisodeTitle"];
			m_ReleaseDate = (DateTime)r["ReleaseDate"];
			m_Season = season;
        }
        public override string ToString()
        {
			//TODO
            return base.ToString();
        }
    }
	
	
    public class EpisodeInfo : EpisodeSummaryInfo
    {
		private string m_Description;
		private Dictionary<string,LinksInfo> m_Links;
		
        public string Description          
        {
            get { return m_Description; } 
            set { m_Description = value; }       
        }   
        public Dictionary<string,LinksInfo> Links          
        {
            get { return m_Links; } 
            set { m_Links = value; }       
        }   
		
        public EpisodeInfo(EpisodeSummaryInfo i, string description, Dictionary<string,LinksInfo> links)
		: this (i.Season, i.No, i.Id, i.Name, i.Title, i.ReleaseDate, description, links)
        {
        }
        public EpisodeInfo(SeasonInfo season, int no, int id, string name, string title, DateTime releaseDate, string description, Dictionary<string,LinksInfo> links)
		: base (season, no, id, name, title, releaseDate)
        {
			m_Description = description;
			m_Links = links;
        }
        public EpisodeInfo(SeasonInfo season, JObject r)
		: base (season, r)
        {
			//{
			//"SeasonNo":1,
			//"Description":"After 15 years of darkness, an unlikely trio sets out on a journey to save the world. Source: NBCDirector: Jon FavreauWriter: Eric Kripke",
			//"ShowTitle":"Revolution (2012)",
			//"Links":
			// [
			//	{
			//	"Name":"allmyvideos.net",
			//	"LinkIDs":
			//	 [
			//		6804502,
			//		6802462,
			//		6802391
			//	 ]
			//	}
			// ],
			//"EpisodeNo":1,
			//"EpisodeId":194518,
			//"EpisodeName":"revolution_(2012)_s1_e1-194518",
			//"EpisodeTitle":"Pilot",
			//"ReleaseDate":"\/Date(1347865200000-0700)\/"
			//}  
		    m_Description = (string)r["Description"];
			m_Links = LinkSummaryInfo.DeserializeLinks((JArray)r["Episodes"]);
        }
        public override string ToString()
        {
			//TODO
            return base.ToString();
        }
    }
}
