using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchSeriesAppPlugin.Panels.Navigation.Core;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public class TestNavInfo : NavInfo
    {
        public TestNavInfo(NavInfo[] parents, UserInfo user)
            : base(DateTime.Now.ToLongTimeString(), NavType.Test, parents, user)
        {
        }
    }
}
