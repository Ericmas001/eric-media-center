using EMCRestService.Services;
using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace EMCRestService
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Old Services => Soon to be deleted
            RouteTable.Routes.Add(new ServiceRoute("TimeService", new WebServiceHostFactory(), typeof(TimeService)));
            RouteTable.Routes.Add(new ServiceRoute("TvSchedule", new WebServiceHostFactory(), typeof(TvScheduleService)));
            RouteTable.Routes.Add(new ServiceRoute("VideoParsing", new WebServiceHostFactory(), typeof(VideoParsingService)));
            RouteTable.Routes.Add(new ServiceRoute("User", new WebServiceHostFactory(), typeof(UserService)));
            RouteTable.Routes.Add(new ServiceRoute("WatchSeries", new WebServiceHostFactory(), typeof(WatchSeriesService)));
            RouteTable.Routes.Add(new ServiceRoute("TubePlus", new WebServiceHostFactory(), typeof(TubePlusService)));
            RouteTable.Routes.Add(new ServiceRoute("Automated", new WebServiceHostFactory(), typeof(AutomatedService)));


            RouteTable.Routes.Add(new ServiceRoute("EpGuide", new WebServiceHostFactory(), typeof(EpGuideService)));
            RouteTable.Routes.Add(new ServiceRoute("TvRage", new WebServiceHostFactory(), typeof(TvRageService)));

            // New Services
            RouteTable.Routes.Add(new ServiceRoute("Tv", new WebServiceHostFactory(), typeof(TvService)));
            RouteTable.Routes.Add(new ServiceRoute("Users", new WebServiceHostFactory(), typeof(UsersService)));
            RouteTable.Routes.Add(new ServiceRoute("Bot", new WebServiceHostFactory(), typeof(BotService)));
        }
    }
}