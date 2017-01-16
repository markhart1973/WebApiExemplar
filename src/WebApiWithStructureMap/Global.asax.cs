using StructureMap;
using System.Web.Http;
using WebApiExample.DependencyResolution;

namespace WebApiWithStructureMap
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IContainer Container;

        protected void Application_Start()
        {
            //Application_Start is called once so no need to lock.
            Container = new Container();
            Container.Configure(x =>
            {
                //Register Dependencies
                x.Scan(y =>
                {
                    y.TheCallingAssembly();
                    y.LookForRegistries();
                });
                //Optionally Register IControllerActivator
                //For<IControllerActivator>.Use<StructureMapControllerActivator>();
            });
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(Container);
        }

        protected void Application_End()
        {
            //Dispose of containers to make sure Singleton Scoped dependencies get disposed 
            Container.Dispose();
        }
    }
}
