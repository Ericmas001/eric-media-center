using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCRestService
{
    public static class TubePlusHelper
    {
        public static string ObtainURL(string website, string args)
        {
            string url = null;
            switch (website)
            {
                case "youtube": url = "http://www.youtube.com/v/" + args + "&hl=en_US&fs=1&rel=0&color1=0x7E9687&color2=0x65786C&hd=1"; break;
                case "stagevu.com": url = "http://stagevu.com/embed?width=655&height=500&background=000&uid=" + args; break;
                case "movshare.net": url = "http://www.movshare.net/embed/" + args + "/?width=653&height=362"; break;
                case "vidbux.com": url = "http://www.vidbux.com/embed-" + args + "-width-653-height-400.html"; break;
                case "videoweed.com":
                case "videoweed.es": url = "http://embed.videoweed.es/embed.php?v=" + args + "&width=653&height=525"; break;
                case "putlocker.com": url = "http://www.putlocker.com/file/" + args; break;
                case "sockshare.com": url = "http://www.sockshare.com/file" + args; break;
                case "videobb.com": url = "http://videobb.com/e/" + args; break;
                case "divxden.com":
                case "vidxden.com": url = "http://www.vidxden.com/embed-" + args + ".html"; break;
                case "tudou": url = "http://www.tudou.com/v/" + args + "/v.swf"; break;
                case "novamov.com": url = "http://embed.novamov.com/embed.php?width=653&height=525&px=1&v=" + args; break;
                case "divxstage.eu": url = "http://embed.divxstage.eu/embed.php?&width=653&height=438&v=" + args; break;
                case "youku": url = "http://player.youku.com/player.php/sid/" + args + "=/v.swf"; break;
                case "smotri.com": url = "http://pics.smotri.com/scrubber_custom8.swf?file=" + args + "&bufferTime=3&autoStart=false&str_lang=rus&xmlsource=http%3A%2F%2Fpics%2Esmotri%2Ecom%2Fcskins%2Fblue%2Fskin%5Fcolor%2Exml&xmldatasource=http%3A%2F%2Fpics%2Esmotri%2Ecom%2Fcskins%2Fblue%2Fskin%5Fng%2Exml"; break;
                case "videozer.com": url = "http://www.videozer.com/embed/" + args; break;
                case "veevr.com": url = "http://veevr.com/embed/" + args + "?w=653&h=370"; break;
                case "ovfile.com": url = "http://ovfile.com/embed-" + args + "-650x325.html"; break;
                case "gorillavid.com":
                case "gorillavid.in": url = "http://gorillavid.in/" + args; break;
                case "zalaa.com": url = "http://www.zalaa.com/embed-" + args + ".html"; break;
                case "filebox.com": url = "http://www.filebox.com/embed-" + args + "-650x450.html"; break;
                case "muchshare.net": url = "http://muchshare.net/embed-" + args + ".html"; break;
                case "uploadc.com": url = "http://www.uploadc.com/embed-" + args + ".html"; break;
                case "moviezer.com": url = "http://moviezer.com/e/" + args; break;
                case "stream2k.com": url = null; break;
                case "vidhog.com": url = "http://www.vidhog.com/embed-" + args + ".html"; break;
                case "hostingbulk.com": url = "http://hostingbulk.com/embed-" + args + "-650x350.html"; break;
                case "ufliq.com": url = "http://www.ufliq.com/embed-" + args + "-650x400.html"; break;
                case "xvidstage.com": url = "http://xvidstage.com/embed-" + args + ".html"; break;
                case "videopp.com": url = "http://videopp.com/player.php?code=" + args; break;
                case "nowvideo.eu": url = "http://embed.nowvideo.eu/embed.php?v=" + args + "&width=650&height=510"; break;
                case "watchfreeinhd.com": url = "http://www.watchfreeinhd.com/embed/" + args; break;
                case "flashx.tv": url = "http://play.flashx.tv/player/embed.php?hash=" + args + "&width=650&height=410&autoplay=no"; break;
                case "vreer.com": url = "http://vreer.com/embed-" + args + "-650x400.html"; break;
                case "nosvideo.com": url = "http://nosvideo.com/embed/" + args + "/650x370"; break;
                case "divxbase.com": url = "http://www.divxbase.com/embed-" + args + "-650x440.html"; break;
                case "daclips.in": url = "http://daclips.in/embed-" + args + "-650x350.html"; break;
                case "movpod.in": url = "http://movpod.in/embed-" + args + "-650x350.html"; break;
                case "movreel.com": url = "http://movreel.com/embed/" + args; break;
                case "180upload.com": url = "http://180upload.com/embed-" + args + "-650x370.html"; break;
                case "mooshare.biz": url = "http://mooshare.biz/embed-" + args + "-650x400.html"; break;
                case "vidbull.com": url = "http://vidbull.com/embed-" + args + "-650x328.html"; break;
                case "glumbouploads.com": url = "http://glumbouploads.com/embed-" + args + "-650x390.html"; break;
                case "modovideo.com": url = "http://www.modovideo.com/frame.php?v=" + args; break;
                case "allmyvideos.net": url = "http://allmyvideos.net/embed-" + args + "-650x360.html"; break;
                case "vidup.me": url = "http://vidup.me/embed-" + args + "-650x350.html"; break;
                case "videobam.com": url = "http://videobam.com/widget/" + args + "/custom/650"; break;
                case "xvidstream.net": url = "http://xvidstream.net/embed-" + args + ".html"; break;
            }
            return url;
        }
    }
}