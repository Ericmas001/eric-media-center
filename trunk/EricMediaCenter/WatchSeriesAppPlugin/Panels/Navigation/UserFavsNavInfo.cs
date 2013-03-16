using WatchSeriesAppPlugin.Entities;
using WatchSeriesAppPlugin.Panels.Navigation.Core;

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