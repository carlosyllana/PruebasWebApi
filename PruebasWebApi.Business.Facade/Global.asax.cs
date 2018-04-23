using PruebasWebApi.Business.Facade.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PruebasWebApi.Business.Facade
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Cargamos las dependencias.
            Bootstrapper.Run();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
