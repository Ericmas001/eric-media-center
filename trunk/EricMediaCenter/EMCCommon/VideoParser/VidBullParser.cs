using EricUtility;
using EricUtility.Networking.Gathering;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMCCommon.VideoParser
{
    public class VidBullParser : IVideoParser
    {
        public int MaxSegments
        {
            get { return 2; }
        }

        //jwplayer("flvplayer").setup({file:"http://fs16.vidbull.com:182/d/7rsmcg3kljrwuxim4u6wf4scxjbvkefgfcrng7mespi6a42jmy7waorr/video.flv",image:"http://fs16.vidbull.com/i/00003/pig37wrhjbry.jpg",provider:"http",skin:"../player/modieus1.zip",duration:"2679",width:650,height:328,flashplayer:"http://vidbull.com/player/player.swf",plugins:"sharing-3,lightsout-1",'events':{'onFullscreen':function(event){if(!event.fullscreen){displayAgain()}}},'dock.position':"left",'allowfullscreen':"always",'wmode':"opaque",'allowscriptaccess':"always",'stretching':"uniform",'sharing.link':"http://vidbull.com/ucm0pksi5nqd",'sharing.code':"%3CIFRAME%20SRC%3D%22http%3A%2F%2Fvidbull.com%2Fembed-ucm0pksi5nqd-650x328.html%22%20FRAMEBORDER%3D0%20MARGINWIDTH%3D0%20MARGINHEIGHT%3D0%20SCROLLING%3DNO%20WIDTH%3D650%20HEIGHT%3D348%3E%3C%2FIFRAME%3E",'logo.file':"http://vidbull.com/images/vidbull_playerlogo.png",'logo.hide':false,'logo.timeout':15,'logo.over':1,'logo.out':0.8,'logo.position':"top-right",'logo.link':"http://vidbull.com",abouttext:"VidBull",aboutlink:"http://vidbull.com"});
        public virtual async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string u = GatheringUtility.GetPageUrl(url, new CookieContainer()).Replace("vidbull.com/", "vidbull.com/embed-") + "-640x318.html";

            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(u);
            string scripts = res.Extract("<script type='text/javascript' src='http://vidbull.com/player/jwplayer.js'></script>", "<br></div>");
            scripts = scripts.Replace("eval", "function fct42() {return").Replace(".split('|')))", ".split('|')))}");
            WebBrowser wb = new WebBrowser();
            wb.Navigate("about:blank");
            wb.Document.Write(scripts);
            string info = wb.Document.InvokeScript("fct42").ToString();
            string finalUrl = info.Extract( "file:\"", "\"");
            return finalUrl;
        }
    }
}