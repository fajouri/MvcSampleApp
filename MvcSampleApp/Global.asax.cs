namespace MvcSampleApp
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Data.Entity;
    using Data;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<MusicStoreContext>(null);
        }
    }
}
