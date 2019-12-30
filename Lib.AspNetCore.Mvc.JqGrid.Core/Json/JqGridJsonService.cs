using System.Linq;
using System.Text.Json;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json.Serialization;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json
{
    internal class JqGridJsonService : IJqGridJsonService
    {
        #region Fields
        private readonly JsonSerializerOptions _jqGridSearchingFiltersJsonSerializerOptions;
        #endregion

        #region Constructor
        public JqGridJsonService()
        {
            _jqGridSearchingFiltersJsonSerializerOptions = new JsonSerializerOptions();
            _jqGridSearchingFiltersJsonSerializerOptions.Converters.Add(new JqGridRequestSearchingFiltersJsonConverter());
        }
        #endregion

        #region Methods
        public string SerializeObject(object value)
        {
            return JsonSerializer.Serialize(value);
        }

        public string SerializeJqGridObject(object value)
        {
            return JsonSerializer.Serialize(value, _jqGridSearchingFiltersJsonSerializerOptions);
        }

        public string SerializeJqGridSearchingFilters(JqGridSearchingFilters jqGridSearchingFilters)
        {
            return JsonSerializer.Serialize(jqGridSearchingFilters, _jqGridSearchingFiltersJsonSerializerOptions);
        }

        public JqGridSearchingFilters DeserializeJqGridSearchingFilters(string jqGridSearchingFilters)
        {
            return JsonSerializer.Deserialize<JqGridSearchingFilters>(jqGridSearchingFilters, _jqGridSearchingFiltersJsonSerializerOptions);
        }

        public object GetJqGridJsonResultSerializerSettings(object serializerSettings)
        {
            JsonSerializerOptions jsonSerializerOptions = (serializerSettings as JsonSerializerOptions);

            if (jsonSerializerOptions is null)
            {
                jsonSerializerOptions = new JsonSerializerOptions();
                jsonSerializerOptions.Converters.Add(new JqGridResponseJsonConverter());
            }
            else if (!jsonSerializerOptions.Converters.Any(converter => converter is JqGridResponseJsonConverter))
            {
                jsonSerializerOptions.Converters.Add(new JqGridResponseJsonConverter());
            }

            return jsonSerializerOptions;
        }
        #endregion
    }
}
