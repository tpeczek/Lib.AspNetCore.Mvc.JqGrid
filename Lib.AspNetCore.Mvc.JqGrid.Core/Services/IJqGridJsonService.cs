using Lib.AspNetCore.Mvc.JqGrid.Core.Results;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Services
{
    /// <summary>
    /// Service which provides JSON serialization capabilities for JqGrid needs.
    /// </summary>
    public interface IJqGridJsonService
    {
        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        string SerializeObject(object value);

        /// <summary>
        /// Serializes the specified object to a JSON string with dedicated handling of jqGrid specific types.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        string SerializeJqGridObject(object value);

        /// <summary>
        /// Serializes class which represents jqGrid filters to JSON.
        /// </summary>
        /// <param name="jqGridSearchingFilters">The <see cref="JqGridSearchingFilters"/>.</param>
        /// <returns>The jqGrid filters JSON.</returns>
        string SerializeJqGridSearchingFilters(JqGridSearchingFilters jqGridSearchingFilters);

        /// <summary>
        /// Deserializes JSON which represents jqGrid filters.
        /// </summary>
        /// <param name="jqGridSearchingFilters">The jqGrid filters JSON.</param>
        /// <returns>The <see cref="JqGridSearchingFilters"/>.</returns>
        JqGridSearchingFilters DeserializeJqGridSearchingFilters(string jqGridSearchingFilters);

        /// <summary>
        /// Gets the serializer settings for <see cref="JqGridJsonResult"/>.
        /// </summary>
        /// <param name="serializerSettings">The serializer settings to be extended (can be null).</param>
        /// <returns>The serializer settings for <see cref="JqGridJsonResult"/>.</returns>
        object GetJqGridJsonResultSerializerSettings(object serializerSettings);
    }
}
