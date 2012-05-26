using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

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
            RouteTable.Routes.Add(new ServiceRoute("TimeService2", new WebServiceHostFactory(), typeof(TimeService)));
            RouteTable.Routes.Add(new ServiceRoute("TvSchedule", new WebServiceHostFactory(), typeof(TvScheduleService)));
            RouteTable.Routes.Add(new ServiceRoute("VideoParsing", new WebServiceHostFactory(), typeof(VideoParsingService)));
            RouteTable.Routes.Add(new ServiceRoute("User", new WebServiceHostFactory(), typeof(UserService)));
        }
    }
}
