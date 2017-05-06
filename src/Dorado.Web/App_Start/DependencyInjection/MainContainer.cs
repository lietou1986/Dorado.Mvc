using Dorado.Components.Logging;
using Dorado.Components.Mail;
using Dorado.Components.Mvc;
using Dorado.Components.Security;
using Dorado.Controllers;
using Dorado.Data.Core;
using Dorado.Data.Logging;
using Dorado.Services;
using Dorado.Validators;
using LightInject;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Hosting;

namespace Dorado.Web.DependencyInjection
{
    public class MainContainer : ServiceContainer
    {
        public void RegisterServices()
        {
            Register<DbContext, Context>();
            Register<IUnitOfWork, UnitOfWork>();
            Register<IAuditLogger, AuditLogger>();

            RegisterInstance<ILogger, Logger>();

            RegisterInstance<IHasher, BCrypter>();
            RegisterInstance<IMailClient, SmtpMailClient>();

            RegisterInstance<IRouteConfig, RouteConfig>();
            RegisterInstance<IBundleConfig, BundleConfig>();

            RegisterInstance<IMvcSiteMapParser, MvcSiteMapParser>();
            RegisterInstance<IMvcSiteMapProvider>(factory => new MvcSiteMapProvider(
                HostingEnvironment.MapPath("~/Mvc.sitemap"), this.GetInstance<IMvcSiteMapParser>()));

            RegisterInstance<ILanguages>(factory => new Languages(HostingEnvironment.MapPath("~/Languages.config")));
            RegisterInstance<IAuthorizationProvider>(factory => new AuthorizationProvider(typeof(BaseController).Assembly));

            RegisterImplementations<IService>();
            RegisterImplementations<IValidator>();
        }

        private Boolean Implements<T>(Type type)
        {
            return typeof(T).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;
        }

        private void RegisterImplementations<T>()
        {
            foreach (Type type in typeof(T).Assembly.GetTypes().Where(Implements<T>))
                Register(type.GetInterface("I" + type.Name), type);
        }

        private void RegisterInstance<TService>(Func<IServiceFactory, TService> factory)
        {
            Register(factory, new PerContainerLifetime());
        }

        private void RegisterInstance<TService, TImplementation>() where TImplementation : TService
        {
            Register<TService, TImplementation>(new PerContainerLifetime());
        }
    }
}