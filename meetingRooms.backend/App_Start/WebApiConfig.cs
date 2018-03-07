using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using meetingRooms.backend.Services;
using Unity;
using ProductStore.Resolver;
using Unity.Lifetime;

namespace meetingRooms.backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            var container = new UnityContainer();
            container.RegisterType<IExchangeSharedService, ExchageSharedService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
