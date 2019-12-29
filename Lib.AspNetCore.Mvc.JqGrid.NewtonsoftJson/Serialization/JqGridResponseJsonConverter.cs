using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Lib.AspNetCore.Mvc.JqGrid.Core.Response;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json.Serialization;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;

namespace Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson.Serialization
{
    /// <summary>
    /// Converts JqGridResponse to JSON. 
    /// </summary>
    internal sealed class JqGridResponseJsonConverter : JsonConverter
    {
        #region Fields
        private Type _jqGridResponseType = typeof(JqGridResponse);
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether this JsonConverter can read JSON.
        /// </summary>
        public override bool CanRead
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this JsonConverter can write JSON.
        /// </summary>
        public override bool CanWrite
        {
            get { return true; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>True if this instance can convert the specified object type, otherwise false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == _jqGridResponseType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JqGridResponse jqGridResponse = value as JqGridResponse;

            if (!(jqGridResponse is null))
            {
                JqGridJsonConverter.WriteJqGridResponse(new NewtonsoftJqGridJsonWriter(writer, serializer), jqGridResponse);
            }
        }
        #endregion
    }
}
