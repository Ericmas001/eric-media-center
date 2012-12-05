using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchSeriesAppPlugin.Panels.Navigation.Core;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public class UserFavsNavInfo : NavInfo
    {
        public UserFavsNavInfo(NavInfo[] parents, UserInfo user)
            : base(user.Username, NavType.UserFavs, parents, user)
        {
        }
    }
}
