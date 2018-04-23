using Autofac;
using Autofac.Integration.WebApi;
using ClassLibrary1;
using PruebasWebApi.Business.Facade.Controllers;
using PruebasWebApi.Bussines.Logic;
using PruebasWebAPi.DataAcces.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace PruebasWebApi.Business.Facade.Autofac
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(RedisDao<>))
                     .As(typeof(IDaoAsync<>))
                     .InstancePerRequest();
            builder.RegisterType<RedisDao<User>>()
            .As<IDaoAsync<User>>()
            .InstancePerRequest();

            builder.RegisterType<UserBlAsync>()
              .As<IUserBlAsync>()
              .InstancePerRequest();



                

            //builder.RegisterType<IDaoAsync<User>>()
            //    .As<IDaoAsync<User>>()
            //    .InstancePerRequest();

            //builder.RegisterGeneric(typeof(RedisDao<>))
            //        .As(typeof(IDaoAsync<>))
            //        .InstancePerRequest();



            /*  builder.RegisterType<DbFactory>()
                     .As<IDbFactory>()
                     .InstancePerRequest();

              builder.RegisterGeneric(typeof(GenericRepository<>))
                     .As(typeof(IGenericRepository<>))
                     .InstancePerRequest();*/

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}