using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json.Serialization
{
    internal class JqGridRequestSearchingFiltersJsonConverter : JsonConverter<JqGridSearchingFilters>
    {
        #region Methods
        public override JqGridSearchingFilters Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                return JqGridJsonConverter.ReadJqGridSearchingFilters(new JqGridJsonElement(jsonDocument.RootElement));
            }
        }

        public override void Write(Utf8JsonWriter writer, JqGridSearchingFilters value, JsonSerializerOptions options)
        {
            JqGridJsonConverter.WriteJqGridSearchingFilters(new JqGridJsonWriter(writer, options), value);
        }
        #endregion
    }
}
