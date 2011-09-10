﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCMasterPluginLib
{
    public class ParsedWebsite
    {
        public enum Extension
        {
            Unknown, 
            Flv,
            Avi
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

        public ParsedWebsite(string url)
        {
            m_Url = url;
            m_Success = false;
        }

        public ParsedWebsite(string url, Extension ext,string video)
        {
            m_Success = true;
            m_Url = url;
            m_VideoUrl = video;
        }

        public ParsedWebsite(string url, Extension ext, string video, string download)
        {
            m_Success = true;
            m_Url = url;
            m_VideoUrl = video;
            m_DownloadUrl = download;
        }
    }
}
