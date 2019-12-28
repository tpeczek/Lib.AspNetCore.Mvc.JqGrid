using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson.Converters
{
    /// <summary>
    /// Converts JqGridRequestSearchingFilters from JSON. 
    /// </summary>
    internal sealed class JqGridRequestSearchingFiltersJsonConverter : JsonConverter
    {
        #region Fields
        private const string GROUPING_OPERATOR_FIELD_NAME = "groupOp";
        private const string FILTERS_FIELD_NAME = "rules";
        private const string GROUP_FIELD_NAME = "groups";

        private const string SEARCHING_NAME_FIELD_NAME = "field";
        private const string SEARCHING_OPERATOR_FIELD_NAME = "op";
        private const string SEARCHING_VALUE_FIELD_NAME = "data";

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

            return ReadJqGridRequestSearchingFilters(jsonObject);
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
                WriteJqGridRequestSearchingFilters(writer, jqGridRequestSearchingFilters);
            }
        }

        private static JqGridSearchingFilters ReadJqGridRequestSearchingFilters(JToken filtersToken)
        {
            JqGridSearchingFilters jqGridRequestSearchingFilters = new JqGridSearchingFilters();

            jqGridRequestSearchingFilters.GroupingOperator = ReadEnum(filtersToken, GROUPING_OPERATOR_FIELD_NAME, JqGridSearchGroupingOperators.And);
            if ((filtersToken[FILTERS_FIELD_NAME] != null) && (filtersToken[FILTERS_FIELD_NAME].Type == JTokenType.Array))
            {
                foreach(JToken filterToken in filtersToken[FILTERS_FIELD_NAME].ToList())
                {
                    jqGridRequestSearchingFilters.Filters.Add(ReadJqGridRequestSearchingFilter(filterToken));
                }
            }

            if ((filtersToken[GROUP_FIELD_NAME] != null) && (filtersToken[GROUP_FIELD_NAME].Type == JTokenType.Array))
            {
                foreach (JToken groupToken in filtersToken[GROUP_FIELD_NAME].ToList())
                {
                    jqGridRequestSearchingFilters.Groups.Add(ReadJqGridRequestSearchingFilters(groupToken));
                }
            }

            return jqGridRequestSearchingFilters;
        }

        private static JqGridSearchingFilter ReadJqGridRequestSearchingFilter(JToken jqGridRequestSearchingFilterToken)
        {
            JqGridSearchingFilter jqGridRequestSearchingFilter = new JqGridSearchingFilter();

            jqGridRequestSearchingFilter.SearchingName = ReadString(jqGridRequestSearchingFilterToken, SEARCHING_NAME_FIELD_NAME);
            jqGridRequestSearchingFilter.SearchingOperator = ReadEnum(jqGridRequestSearchingFilterToken, SEARCHING_OPERATOR_FIELD_NAME, JqGridSearchOperators.Eq);
            jqGridRequestSearchingFilter.SearchingValue = ReadString(jqGridRequestSearchingFilterToken, SEARCHING_VALUE_FIELD_NAME);

            return jqGridRequestSearchingFilter;
        }

        private static TEnum ReadEnum<TEnum>(JToken valueToken, string key, TEnum defaultValue) where TEnum : struct
        {
            TEnum value = defaultValue;
            if ((valueToken[key] != null) && Enum.TryParse<TEnum>(valueToken[key].Value<String>(), true, out value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

        private static string ReadString(JToken valueToken, string key, string defaultValue = null)
        {
            if ((valueToken[key] != null) && (valueToken[key].Type == JTokenType.String))
            {
                return valueToken[key].Value<String>();
            }
            else
            {
                return defaultValue;
            }
        }

        private void WriteJqGridRequestSearchingFilters(JsonWriter writer, JqGridSearchingFilters jqGridRequestSearchingFilters)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(GROUPING_OPERATOR_FIELD_NAME);
            writer.WriteValue(jqGridRequestSearchingFilters.GroupingOperator.ToString().ToUpperInvariant());

            if ((jqGridRequestSearchingFilters.Filters != null) && (jqGridRequestSearchingFilters.Filters.Count > 0))
            {
                writer.WritePropertyName(FILTERS_FIELD_NAME);
                writer.WriteStartArray();
                foreach (JqGridSearchingFilter jqGridRequestSearchingFilter in jqGridRequestSearchingFilters.Filters)
                {
                    WriteJqGridRequestSearchingFilter(writer, jqGridRequestSearchingFilter);
                }
                writer.WriteEndArray();
            }

            if ((jqGridRequestSearchingFilters.Groups != null) && (jqGridRequestSearchingFilters.Groups.Count > 0))
            {
                writer.WritePropertyName(GROUP_FIELD_NAME);
                writer.WriteStartArray();
                foreach (JqGridSearchingFilters innerSearchingFilters in jqGridRequestSearchingFilters.Groups)
                {
                    WriteJqGridRequestSearchingFilters(writer, jqGridRequestSearchingFilters);
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }

        private void WriteJqGridRequestSearchingFilter(JsonWriter writer, JqGridSearchingFilter jqGridRequestSearchingFilter)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(SEARCHING_NAME_FIELD_NAME);
            writer.WriteValue(jqGridRequestSearchingFilter.SearchingName);

            writer.WritePropertyName(SEARCHING_OPERATOR_FIELD_NAME);
            writer.WriteValue(jqGridRequestSearchingFilter.SearchingOperator.ToString().ToLowerInvariant());

            writer.WritePropertyName(SEARCHING_VALUE_FIELD_NAME);
            writer.WriteValue(jqGridRequestSearchingFilter.SearchingValue);

            writer.WriteEndObject();
        }
        #endregion
    }
}
