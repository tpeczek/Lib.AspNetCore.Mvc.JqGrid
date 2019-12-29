using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lib.AspNetCore.Mvc.JqGrid.Core.Response;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json.Serialization
{
    internal class JqGridResponseJsonConverter : JsonConverter<JqGridResponse>
    {
        #region Methods
        public override JqGridResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }

        public override void Write(Utf8JsonWriter writer, JqGridResponse value, JsonSerializerOptions options)
        {
            JqGridJsonConverter.WriteJqGridResponse(new JqGridJsonWriter(writer, options), value);
        }
        #endregion
    }
}
