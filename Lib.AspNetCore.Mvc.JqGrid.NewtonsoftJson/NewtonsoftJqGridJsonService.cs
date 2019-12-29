using System.Linq;
using Newtonsoft.Json;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;
using Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson.Serialization;

namespace Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson
{
    internal class NewtonsoftJqGridJsonService: IJqGridJsonService
    {
        #region Fields
        private readonly JqGridRequestSearchingFiltersJsonConverter _jqGridRequestSearchingFiltersJsonConverter = new JqGridRequestSearchingFiltersJsonConverter();
        #endregion

        #region Methods
        public string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None);
        }

        public string SerializeJqGridObject(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None, _jqGridRequestSearchingFiltersJsonConverter);
        }

        public string SerializeJqGridSearchingFilters(JqGridSearchingFilters jqGridSearchingFilters)
        {
            return JsonConvert.SerializeObject(jqGridSearchingFilters, Formatting.None, _jqGridRequestSearchingFiltersJsonConverter);
        }

        public JqGridSearchingFilters DeserializeJqGridSearchingFilters(string jqGridSearchingFilters)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(_jqGridRequestSearchingFiltersJsonConverter);

            return JsonConvert.DeserializeObject<JqGridSearchingFilters>(jqGridSearchingFilters, jsonSerializerSettings);
        }

        public object GetJqGridJsonResultSerializerSettings(object serializerSettings)
        {
            JsonSerializerSettings jsonSerializerSettings = (serializerSettings as JsonSerializerSettings);

            if (jsonSerializerSettings is null)
            {
                jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.Converters.Add(new JqGridResponseJsonConverter());
            }
            else if (!jsonSerializerSettings.Converters.Any(converter => converter is JqGridResponseJsonConverter))
            {
                jsonSerializerSettings.Converters.Add(new JqGridResponseJsonConverter());
            }

            return jsonSerializerSettings;
        }
        #endregion
    }
}
