using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json.Serialization;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson.Serialization
{
    /// <summary>
    /// Converts JqGridRequestSearchingFilters from JSON. 
    /// </summary>
    internal sealed class JqGridRequestSearchingFiltersJsonConverter : JsonConverter
    {
        #region Fields
        private Type _jqGridRequestSearchingFiltersType = typeof(JqGridSearchingFilters);
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether this JsonConverter can read JSON.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
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
            return (objectType == _jqGridRequestSearchingFiltersType);
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
            JObject jsonObject = JObject.Load(reader);

            return JqGridJsonConverter.ReadJqGridSearchingFilters(new NewtonsoftJqGridJsonElement(jsonObject));
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JqGridSearchingFilters jqGridRequestSearchingFilters = value as JqGridSearchingFilters;

            if (!(jqGridRequestSearchingFilters is null))
            {
                JqGridJsonConverter.WriteJqGridSearchingFilters(new NewtonsoftJqGridJsonWriter(writer, serializer), jqGridRequestSearchingFilters);
            }
        }
        #endregion
    }
}
