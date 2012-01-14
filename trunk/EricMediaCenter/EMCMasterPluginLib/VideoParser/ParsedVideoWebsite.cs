using System;
using System.Collections.Generic;
using System.Text;

namespace EMCMasterPluginLib.VideoParser
{
    public class ParsedVideoWebsite
    {
        public enum Extension
        {
            Unknown, 
            Flv,
            Avi,
            Mov,
            Mp4
        }
        private readonly string m_Url;
        public string Url { get { return m_Url; } }

        private bool m_Success = false;
        public bool Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_VideoUrl = null;
        public string VideoUrl
        {
            get
            {
                if (!m_Success || m_VideoUrl == null)
                    return Url;
                return m_VideoUrl;
            }
            set { m_VideoUrl = value; }
        }

        private string m_DownloadUrl = null;
        public string DownloadUrl
        {
            get
            {
                if (m_DownloadUrl == null)
                    return VideoUrl;
                return m_VideoUrl;
            }
            set { m_DownloadUrl = value; }
        }

        public ParsedVideoWebsite(string url)
        {
            m_Url = url;
            m_Success = false;
        }

        public ParsedVideoWebsite(string url, Extension ext,string video)
        {
            m_Success = true;
            m_Url = url;
            m_VideoUrl = video;
        }

        public ParsedVideoWebsite(string url, Extension ext, string video, string download)
        {
            m_Success = true;
            m_Url = url;
            m_VideoUrl = video;
            m_DownloadUrl = download;
        }
    }
}
