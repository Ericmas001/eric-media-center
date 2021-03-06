﻿using EMCMasterPluginLib.Application;
using System;

namespace WatchSeriesAppPlugin
{
    public class WatchSeriesPlugin : IEMCApplicationPlugin
    {
        #region IEMCApplicationPlugin Members

        public IApplication GetApplication()
        {
            return new WatchSeriesApp();
        }

        #endregion IEMCApplicationPlugin Members

        #region IEMCMasterPlugin Members

        public string UniqueName
        {
            get { return "WatchSeriesApp"; }
        }

        public string FullName
        {
            get { return "Application WatchSeries"; }
        }

        public Version Version
        {
            get { return new Version(0, 0, 1); }
        }

        public bool Load()
        {
            return true;
        }

        #endregion IEMCMasterPlugin Members
    }
}