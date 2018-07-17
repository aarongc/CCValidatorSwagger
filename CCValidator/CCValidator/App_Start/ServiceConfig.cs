using CCValidator.Models;
using System;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity;
using Unity.Lifetime;

namespace CCValidator.App_Start
{
    /// <summary>
    /// Represents configuration for <see cref="IExceptionHandler"/> and <see cref="IExceptionLogger"/>.
    /// </summary>
    public static class ServiceConfig
    {
        /// <summary>
        /// Configures custom implementations for: <see cref="IExceptionHandler"/> and <see cref="IExceptionLogger"/>.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var container = new UnityContainer();
            container.RegisterType<ICreditCardRepository, CreditCardRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICreditCardService, CreditCardService>(new HierarchicalLifetimeManager());
            configuration.DependencyResolver = new UnityResolver(container);

            configuration.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());
            configuration.Services.Add(typeof(IExceptionLogger), new ApiExceptionLogger());
        }
    }
}