using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Lib.AspNetCore.Mvc.JqGrid.Core.Services;
using Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// The <see cref="IServiceCollection"/> extensions for adding jqGrid related services.
    /// </summary>
    public static class NewtonsoftJqGridServiceCollectionExtensions
    {
        #region Methods
        /// <summary>
        /// Registers Newtonsoft.Json based jqGrid related services.
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        /// <returns>The collection of service descriptors.</returns>
        public static IServiceCollection AddNewtonsoftJqGrid(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            ServiceDescriptor jqGridJsonServiceDescriptor = services.FirstOrDefault(service => service.ServiceType == typeof(IJqGridJsonService));
            if (jqGridJsonServiceDescriptor != null)
            {
                services.Remove(jqGridJsonServiceDescriptor);
            }

            services.TryAddSingleton<IJqGridJsonService, NewtonsoftJqGridJsonSerializer>();

            return services;
        }
        #endregion
    }
}
