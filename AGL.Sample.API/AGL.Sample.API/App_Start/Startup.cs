using System.Reflection;
using System.Web.Http;
using AGL.Sample.API;
using AGL.Sample.API.Features.Numeric;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace AGL.Sample.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            var config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //Register items here
            builder.RegisterType<Calculator>().AsImplementedInterfaces();



            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.MapHttpAttributeRoutes();

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
