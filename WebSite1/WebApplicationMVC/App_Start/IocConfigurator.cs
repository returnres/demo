using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WebApplicationMVC.Controllers;

namespace WebApplicationMVC.App_Start
{
    public class IocConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // ...or you can register individual controlllers manually.
            builder.RegisterType<HomeController>().InstancePerRequest();

            // OPTIONAL: Register model binders that require DI.
            //builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            //builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            //builder.RegisterFilterProvider();

            //builder.RegisterType<IService>().As<ServiceA>();
            var conn = System.Configuration.ConfigurationManager.
                ConnectionStrings["DefaultConnection"].ConnectionString;

            builder.RegisterType<ServiceA>().As<IService>().InstancePerDependency();
            builder.RegisterType<ServiceB>().As<IServiceB>().WithParameter("conn", conn).InstancePerDependency();

            //builder.RegisterType<Repository<Student>>().As<IRepository<Student>>();
            //builder.RegisterType<SchoolContext>().InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}