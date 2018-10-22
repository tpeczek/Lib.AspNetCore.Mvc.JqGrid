using Newtonsoft.Json;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json.Converters;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json
{
    /// <summary>
    /// Provides support for converting some of jqGrid specific types to JSON.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Converts class which represents jqGrid filters to JSON
        /// </summary>
        /// <param name="jqGridSearchingFilters">The jqGrid filters.</param>
        /// <returns>The JSON.</returns>
        public static string ToJson(this JqGridSearchingFilters jqGridSearchingFilters)
        {
            return JsonConvert.SerializeObject(jqGridSearchingFilters, Formatting.None, new JqGridRequestSearchingFiltersJsonConverter());
            
        }
    }
}
