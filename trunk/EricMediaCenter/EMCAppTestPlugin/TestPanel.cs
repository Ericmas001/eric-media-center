using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net;
using EMCMasterPluginLib;
using EricUtility.Networking.Gathering;
using EricUtility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EMCAppTestPlugin
{
    public partial class TestPanel : UserControl
    {
        public TestPanel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string listChoice = (string)listBox1.SelectedItem;
                string args = textBox1.Text;
                if (!String.IsNullOrEmpty(args))
                    args = "|" + args;
                listChoice = listChoice.IndexOf('/') == -1 ? listChoice : listChoice.Remove(listChoice.IndexOf('/'));
                string url = "http://emc.ericmas001.com/" + (listChoice + args).Replace('|', '/');
                string result;
                try
                {
                    result = StringUtility.RemoveHTMLTags(GatheringUtility.GetPageSource(url));
                    result = ParseResult(listChoice, result);
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }
                textBox3.Text = result;
            }
        }

        private void TestPanel_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("TimeService|CurrentTime");
            listBox1.Items.Add("TvSchedule|AvailableSchedule");
            listBox1.Items.Add("TvSchedule|GetSchedule/{id}");
            listBox1.Items.Add("VideoParsing|AvailableWebsites");
            listBox1.Items.Add("VideoParsing|Parse/{website}/{args}");
            listBox1.Items.Add("User|Connect/{user}/{pass}");
            listBox1.Items.Add("User|Register/{user}/{pass}");
            listBox1.Items.Add("User|GetFavs/{token}}");
            listBox1.Items.Add("User|AddFav/{token}/{showname}");
            listBox1.Items.Add("User|DelFav/{token}/{showname}");
            listBox1.Items.Add("User|SetLastViewed/{token}/{showname}/{lastViewedSeason}/{lastViewedEpisode}");
            listBox1.Items.Add("WatchSeries|GetPopulars");
            listBox1.Items.Add("WatchSeries|AvailableLetters");
            listBox1.Items.Add("WatchSeries|AvailableGenres");
            listBox1.Items.Add("WatchSeries|GetLetter/{letter}");
            listBox1.Items.Add("WatchSeries|GetGenre/{genre}");
            listBox1.Items.Add("WatchSeries|Search/{keywords}");
            listBox1.Items.Add("WatchSeries|GetShow/{showname}");
            listBox1.Items.Add("WatchSeries|GetLinks/{epid}");
            listBox1.Items.Add("WatchSeries|GetEpisode/{epname}");
            listBox1.Items.Add("WatchSeries|GetUrl/{linkid}");
            listBox1.Items.Add("Automated|UpdateLastEpisodes");
            listBox1.Items.Add("EpGuide|Search/{id}");
            listBox1.Items.Add("EpGuide|GetShow/{id}");
            listBox1.Items.Add("TvRage|Search/{id}");
            listBox1.Items.Add("TvRage|GetShow/{id}");
            listBox1.SelectedIndex = 0;
        }

        private string ParseResult(string listChoice, string result)
        {
            string newRes = result;
            switch (listChoice)
            {
                case "TimeService|CurrentTime": newRes = TimeServiceCurrentTime(result); break;
                case "TvSchedule|AvailableSchedule": newRes = TvScheduleAvailableSchedule(result); break;
                case "TvSchedule|GetSchedule": newRes = TvScheduleGetSchedule(result); break;
                case "VideoParsing|AvailableWebsites": newRes = VideoParsingAvailableWebsites(result); break;
                case "VideoParsing|Parse": newRes = VideoParsingParse(result); break;
                case "User|Connect": newRes = UserConnect(result); break;
                case "User|Register": newRes = UserRegister(result); break;
                case "User|GetFavs": newRes = UserGetFavs(result); break;
                case "User|AddFav": newRes = UserAddFav(result); break;
                case "User|SetLastViewed": newRes = UserSetLastViewed(result); break;
                case "WatchSeries|GetPopulars": newRes = WatchSeriesGetPopulars(result); break;
                case "WatchSeries|AvailableLetters": newRes = WatchSeriesAvailableLetters(result); break;
                case "WatchSeries|AvailableGenres": newRes = WatchSeriesAvailableGenres(result); break;
                case "WatchSeries|GetLetter": newRes = WatchSeriesGetLetter(result); break;
                case "WatchSeries|GetGenre": newRes = WatchSeriesGetGenre(result); break;
                case "WatchSeries|Search": newRes = WatchSeriesSearch(result); break;
                case "WatchSeries|GetShow": newRes = WatchSeriesGetShow(result); break;
                case "WatchSeries|GetLinks": newRes = WatchSeriesGetLinks(result); break;
                case "WatchSeries|GetEpisode": newRes = WatchSeriesGetEpisode(result); break;
                case "WatchSeries|GetUrl": newRes = WatchSeriesGetUrl(result); break;
                case "Automated|UpdateLastEpisodes": newRes = AutomatedUpdateLastEpisodes(result); break;
                case "EpGuide|Search": newRes = EpGuideSearch(result); break;
                case "EpGuide|GetShow": newRes = EpGuideGetShow(result); break;
                case "TvRage|Search": newRes = TvRageSearch(result); break;
                case "TvRage|GetShow": newRes = TvRageGetShow(result); break;
            }
            return newRes;
        }

        private string TimeServiceCurrentTime(string result)
        {
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
                newRes = "Server Current Time: " + r["value"].ToString();
            return newRes;
        }

        private string TvScheduleAvailableSchedule(string result)
        {
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach(JObject r in results)
            {
                newRes += "(" + r["Key"].ToString() + ") " + r["Value"].ToString();
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string TvScheduleGetSchedule(string result)
        {
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JObject r in results)
            {
                newRes += r["ShowName"].ToString() + " " + r["Season"].ToString() + "x" + r["Episode"].ToString() + ": " + r["ShowTitle"].ToString();
                if (r["Url"].ToString() != "#")
                    newRes += " (" + r["Url"].ToString() + ")";
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string VideoParsingAvailableWebsites(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string VideoParsingParse(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserConnect(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserRegister(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserGetFavs(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserAddFav(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserSetLastViewed(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetPopulars(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesAvailableLetters(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesAvailableGenres(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetLetter(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetGenre(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesSearch(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetShow(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetLinks(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetEpisode(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetUrl(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string AutomatedUpdateLastEpisodes(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string EpGuideSearch(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string EpGuideGetShow(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string TvRageSearch(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string TvRageGetShow(string result)
        {
            string newRes = result;
            return newRes;
        }
    }
}
