using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// The <see cref="IServiceCollection"/> extensions for adding jqGrid related services.
    /// </summary>
    public static class JqGridServiceCollectionExtensions
    {
        #region Methods
        /// <summary>
        /// Registers default jqGrid related services.
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        /// <returns>The collection of service descriptors.</returns>
        public static IServiceCollection AddJqGrid(this IServiceCollection services)
        {
            services.TryAddSingleton<IJqGridJsonService, JqGridJsonService>();

            return services;
        }
        #endregion
    }
}
