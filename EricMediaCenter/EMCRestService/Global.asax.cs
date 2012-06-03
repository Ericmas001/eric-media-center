using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using EMCRestService.Services;

namespace EMCRestService
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Edit the base address of Service1 by replacing the "Service1" string below
            RouteTable.Routes.Add(new ServiceRoute("TimeService", new WebServiceHostFactory(), typeof(TimeService)));
            RouteTable.Routes.Add(new ServiceRoute("TvSchedule", new WebServiceHostFactory(), typeof(TvScheduleService)));
            RouteTable.Routes.Add(new ServiceRoute("VideoParsing", new WebServiceHostFactory(), typeof(VideoParsingService)));
            RouteTable.Routes.Add(new ServiceRoute("User", new WebServiceHostFactory(), typeof(UserService)));
            RouteTable.Routes.Add(new ServiceRoute("WatchSeries", new WebServiceHostFactory(), typeof(WatchSeriesService)));
            RouteTable.Routes.Add(new ServiceRoute("EpGuide", new WebServiceHostFactory(), typeof(EpGuideService)));
        }
    }
}
