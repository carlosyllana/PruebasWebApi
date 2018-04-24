using PruebasWebApi.Business.Facade.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace PruebasWebApi.Business.Facade
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "Version2Api",
             routeTemplate: "api/v2/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );

            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector((config)));
        }
    }
}
