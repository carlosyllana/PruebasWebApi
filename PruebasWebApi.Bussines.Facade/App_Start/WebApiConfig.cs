using PruebasWebApi.Bussines.Facade.App_Start.Unity;
using PruebasWebApi.Bussines.Facade.Controllers;
using PruebasWebApi.Bussines.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unity;
using Unity.Lifetime;

namespace PruebasWebApi.Bussines.Facade
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "version1",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "version2",
                routeTemplate: "api/v2/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Estamos mirando de hacer el versionado de la API
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector((config)));


            var container = new UnityContainer();
            container.RegisterType<IUserBlAsync, UserBlAsync>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);


        }
    }
}
