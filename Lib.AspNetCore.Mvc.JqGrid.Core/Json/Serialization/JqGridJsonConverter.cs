using System;
using System.Linq;
using System.Collections.Generic;
using Lib.AspNetCore.Mvc.JqGrid.Core.Response;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json.Serialization
{
    /// <summary>
    /// Provides methods for converting a jqGrid specific object to and from JSON.
    /// </summary>
    public static class JqGridJsonConverter
    {
        #region Fields
        private const string GROUPING_OPERATOR_FIELD_NAME = "groupOp";
        private const string FILTERS_FIELD_NAME = "rules";
        private const string GROUP_FIELD_NAME = "groups";

        private const string SEARCHING_NAME_FIELD_NAME = "field";
        private const string SEARCHING_OPERATOR_FIELD_NAME = "op";
        private const string SEARCHING_VALUE_FIELD_NAME = "data";
        #endregion

        #region Methods
        /// <summary>
        /// Reads the JSON representation of the <see cref="JqGridSearchingFilters"/>.
        /// </summary>
        /// <param name="filtersElement">The <see cref="IJqGridJsonElement"/>.</param>
        /// <returns>The <see cref="JqGridSearchingFilters"/>.</returns>
        public static JqGridSearchingFilters ReadJqGridSearchingFilters(IJqGridJsonElement filtersElement)
        {
            JqGridSearchingFilters jqGridSearchingFilters = new JqGridSearchingFilters();

            jqGridSearchingFilters.GroupingOperator = ReadEnum(filtersElement, GROUPING_OPERATOR_FIELD_NAME, JqGridSearchGroupingOperators.And);
            if ((filtersElement[FILTERS_FIELD_NAME] != null) && (filtersElement[FILTERS_FIELD_NAME].Type == JqGridJsonElementType.Array))
            {
                foreach (IJqGridJsonElement filterElement in filtersElement[FILTERS_FIELD_NAME].EnumerateArray())
                {
                    jqGridSearchingFilters.Filters.Add(ReadJqGridSearchingFilter(filterElement));
                }
            }

            if ((filtersElement[GROUP_FIELD_NAME] != null) && (filtersElement[GROUP_FIELD_NAME].Type == JqGridJsonElementType.Array))
            {
                foreach (IJqGridJsonElement groupElement in filtersElement[GROUP_FIELD_NAME].EnumerateArray())
                {
                    jqGridSearchingFilters.Groups.Add(ReadJqGridSearchingFilters(groupElement));
                }
            }

            return jqGridSearchingFilters;
        }

        /// <summary>
        /// Writes the JSON representation of the <see cref="JqGridSearchingFilters"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IJqGridJsonWriter"/>.</param>
        /// <param name="jqGridSearchingFilters">The <see cref="JqGridSearchingFilters"/>.</param>
        public static void WriteJqGridSearchingFilters(IJqGridJsonWriter writer, JqGridSearchingFilters jqGridSearchingFilters)
        {
            writer.WriteStartObject();

            writer.WriteProperty(GROUPING_OPERATOR_FIELD_NAME, jqGridSearchingFilters.GroupingOperator.ToString().ToUpperInvariant());

            if ((jqGridSearchingFilters.Filters != null) && (jqGridSearchingFilters.Filters.Count > 0))
            {
                writer.WriteStartArray(FILTERS_FIELD_NAME);
                foreach (JqGridSearchingFilter jqGridRequestSearchingFilter in jqGridSearchingFilters.Filters)
                {
                    WriteJqGridSearchingFilter(writer, jqGridRequestSearchingFilter);
                }
                writer.WriteEndArray();
            }

            if ((jqGridSearchingFilters.Groups != null) && (jqGridSearchingFilters.Groups.Count > 0))
            {
                writer.WriteStartArray(GROUP_FIELD_NAME);
                foreach (JqGridSearchingFilters innerSearchingFilters in jqGridSearchingFilters.Groups)
                {
                    WriteJqGridSearchingFilters(writer, innerSearchingFilters);
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Writes the JSON representation of the <see cref="JqGridResponse"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IJqGridJsonWriter"/>.</param>
        /// <param name="response">The <see cref="JqGridResponse"/>.</param>
        public static void WriteJqGridResponse(IJqGridJsonWriter writer, JqGridResponse response)
        {
            JqGridJsonReader jsonReader = (response.Reader == null) ? JqGridResponse.JsonReader : response.Reader;

            writer.WriteStartObject();

            if (!response.IsSubgridResponse)
            {
                WritePagingProperties(writer, jsonReader, response);
                WrtieUserData(writer, jsonReader, response);
            }

            WriteJqGridRecords(writer, response.IsSubgridResponse, jsonReader, response.Records);

            writer.WriteEndObject();
        }

        private static JqGridSearchingFilter ReadJqGridSearchingFilter(IJqGridJsonElement jqGridSearchingFilterElement)
        {
            JqGridSearchingFilter jqGridRequestSearchingFilter = new JqGridSearchingFilter
            {
                SearchingName = ReadString(jqGridSearchingFilterElement, SEARCHING_NAME_FIELD_NAME),
                SearchingOperator = ReadEnum(jqGridSearchingFilterElement, SEARCHING_OPERATOR_FIELD_NAME, JqGridSearchOperators.Eq),
                SearchingValue = ReadString(jqGridSearchingFilterElement, SEARCHING_VALUE_FIELD_NAME)
            };

            return jqGridRequestSearchingFilter;
        }

        private static TEnum ReadEnum<TEnum>(IJqGridJsonElement valueElement, string key, TEnum defaultValue) where TEnum : struct
        {
            TEnum value = defaultValue;
            if ((valueElement[key] != null) && Enum.TryParse<TEnum>(valueElement[key].GetString(), true, out value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

        private static string ReadString(IJqGridJsonElement valueElement, string key, string defaultValue = null)
        {
            if ((valueElement[key] != null) && (valueElement[key].Type == JqGridJsonElementType.String))
            {
                return valueElement[key].GetString();
            }
            else
            {
                return defaultValue;
            }
        }

        private static void WriteJqGridSearchingFilter(IJqGridJsonWriter writer, JqGridSearchingFilter jqGridSearchingFilter)
        {
            writer.WriteStartObject();

            writer.WriteProperty(SEARCHING_NAME_FIELD_NAME, jqGridSearchingFilter.SearchingName);

            writer.WriteProperty(SEARCHING_OPERATOR_FIELD_NAME, jqGridSearchingFilter.SearchingOperator.ToString().ToLowerInvariant());

            writer.WriteProperty(SEARCHING_VALUE_FIELD_NAME, jqGridSearchingFilter.SearchingValue);

            writer.WriteEndObject();
        }

        private static void WritePagingProperties(IJqGridJsonWriter writer, JqGridJsonReader jsonReader, JqGridResponse response)
        {
            writer.WriteProperty(jsonReader.PageIndex, response.PageIndex + 1);

            writer.WriteProperty(jsonReader.TotalRecordsCount, response.TotalRecordsCount);

            writer.WriteProperty(jsonReader.TotalPagesCount, response.TotalPagesCount);
        }

        private static void WrtieUserData(IJqGridJsonWriter writer, JqGridJsonReader jsonReader, JqGridResponse response)
        {
            if (response.UserData != null)
            {
                writer.WriteProperty(jsonReader.UserData, response.UserData);
            }
        }

        private static void WriteJqGridRecords(IJqGridJsonWriter writer, bool isSubgridResponse, JqGridJsonReader jsonReader, IList<JqGridRecord> records)
        {
            int recordIdIndex = 0;
            bool isRecordIndexInt = Int32.TryParse(jsonReader.RecordId, out recordIdIndex);
            bool isRecordValuesEmpty = String.IsNullOrWhiteSpace(jsonReader.RecordValues);
            bool repeatItems = isSubgridResponse ? jsonReader.SubgridReader.RepeatItems : jsonReader.RepeatItems;

            if (!isSubgridResponse)
            {
                if (repeatItems && isRecordValuesEmpty && !isRecordIndexInt)
                {
                    throw new InvalidOperationException("JqGridJsonReader.RecordId must be a number when JqGridJsonReader.RepeatItems is set to true and JqGridJsonReader.RecordValues is set to empty string.");
                }

                if (repeatItems && !isRecordValuesEmpty && isRecordIndexInt)
                {
                    throw new InvalidOperationException("JqGridJsonReader.RecordValues can't be an empty string when JqGridJsonReader.RepeatItems is set to true and JqGridJsonReader.RecordId is a number.");
                }
            }

            Func<JqGridJsonReader, JqGridRecord, bool, int, bool, object> serializeRecordFunction = ChooseSerializeFunction(repeatItems, isRecordValuesEmpty);
            IList<object> serializedRecords = new List<object>(records.Select(record => serializeRecordFunction(jsonReader, record, isRecordIndexInt, recordIdIndex, isSubgridResponse)));

            writer.WriteProperty(isSubgridResponse ? jsonReader.SubgridReader.Records : jsonReader.Records, serializedRecords);
        }

        private static Func<JqGridJsonReader, JqGridRecord, bool, int, bool, object> ChooseSerializeFunction(bool repeatItems, bool isRecordValuesEmpty)
        {
            Func<JqGridJsonReader, JqGridRecord, bool, int, bool, object> serializeRecordFunction = null;

            if (repeatItems)
            {
                if (isRecordValuesEmpty)
                {
                    serializeRecordFunction = SerializeValuesRecordAsList;
                }
                else
                {

                    serializeRecordFunction = SerializeValuesRecordAsDictionary;
                }
            }
            else
            {
                serializeRecordFunction = SerializeValueRecordAsDictionary;
            }

            return serializeRecordFunction;

        }

        private static IList<object> SerializeValuesRecordAsList(JqGridJsonReader jsonReader, JqGridRecord record, bool isRecordIndexInt, int recordIdIndex, bool isSubgridResponse)
        {
            IList<object> recordValues = new List<object>();

            if (!isSubgridResponse && Convert.ToString(recordValues[recordIdIndex]) != record.Id)
            {
                recordValues.Add(record.Id);
            }

            return AppendValuesToValuesList(recordValues, record, isSubgridResponse);
        }

        private static IDictionary<string, object> SerializeValuesRecordAsDictionary(JqGridJsonReader jsonReader, JqGridRecord record, bool isRecordIndexInt, int recordIdIndex, bool isSubgridResponse)
        {
            IDictionary<string, object> recordValues = new Dictionary<string, object>();

            if (!isSubgridResponse)
            {
                recordValues.Add(jsonReader.RecordId, record.Id);
            }

            recordValues.Add(isSubgridResponse ? jsonReader.SubgridReader.RecordValues : jsonReader.RecordValues, AppendValuesToValuesList(new List<object>(), record, isSubgridResponse));

            return recordValues;
        }

        private static IList<object> AppendValuesToValuesList(IList<object> valuesList, JqGridRecord record, bool isSubgridResponse)
        {
            foreach (object value in record.Values)
            {
                valuesList.Add(value);
            }

            if (!isSubgridResponse)
            {
                valuesList = AppendTreeGridValuesToValuesList(valuesList, record);
            }

            return valuesList;
        }

        private static IList<object> AppendTreeGridValuesToValuesList(IList<object> valuesList, JqGridRecord record)
        {
            JqGridAdjacencyTreeRecord adjacencyTreeRecord = record as JqGridAdjacencyTreeRecord;
            JqGridNestedSetTreeRecord nestedSetTreeRecord = record as JqGridNestedSetTreeRecord;

            if (adjacencyTreeRecord != null)
            {
                valuesList.Add(adjacencyTreeRecord.Level);
                valuesList.Add(adjacencyTreeRecord.ParentId);
                valuesList.Add(adjacencyTreeRecord.Leaf);
                valuesList.Add(adjacencyTreeRecord.Expanded);
            }
            else if (nestedSetTreeRecord != null)
            {
                valuesList.Add(nestedSetTreeRecord.Level);
                valuesList.Add(nestedSetTreeRecord.LeftField);
                valuesList.Add(nestedSetTreeRecord.RightField);
                valuesList.Add(nestedSetTreeRecord.Leaf);
                valuesList.Add(nestedSetTreeRecord.Expanded);
            }

            return valuesList;
        }

        private static IDictionary<string, object> SerializeValueRecordAsDictionary(JqGridJsonReader jsonReader, JqGridRecord record, bool isRecordIndexInt, int recordIdIndex, bool isSubgridResponse)
        {
            if (record.Value == null)
            {
                throw new InvalidOperationException("JqGridRecord.Value can't be null when JqGridJsonReader.RepeatItems is set to false.");
            }

            IDictionary<string, object> recordValues = record.GetValueAsDictionary();

            if (!isSubgridResponse && !isRecordIndexInt && !recordValues.ContainsKey(jsonReader.RecordId))
            {
                recordValues.Add(jsonReader.RecordId, record.Id);
            }

            if (!isSubgridResponse)
            {
                recordValues = AppendTreeGridValuesToValuesDictionary(recordValues, record);
            }

            return recordValues;
        }

        private static IDictionary<string, object> AppendTreeGridValuesToValuesDictionary(IDictionary<string, object> valuesDictionary, JqGridRecord record)
        {
            JqGridAdjacencyTreeRecord adjacencyTreeRecord = record as JqGridAdjacencyTreeRecord;
            JqGridNestedSetTreeRecord nestedSetTreeRecord = record as JqGridNestedSetTreeRecord;

            if (adjacencyTreeRecord != null)
            {
                valuesDictionary.Add("level", adjacencyTreeRecord.Level);
                valuesDictionary.Add("parent", adjacencyTreeRecord.ParentId);
                valuesDictionary.Add("isLeaf", adjacencyTreeRecord.Leaf);
                valuesDictionary.Add("expanded", adjacencyTreeRecord.Expanded);
            }
            else if (nestedSetTreeRecord != null)
            {
                valuesDictionary.Add("level", nestedSetTreeRecord.Level);
                valuesDictionary.Add("lft", nestedSetTreeRecord.LeftField);
                valuesDictionary.Add("rgt", nestedSetTreeRecord.RightField);
                valuesDictionary.Add("isLeaf", nestedSetTreeRecord.Leaf);
                valuesDictionary.Add("expanded", nestedSetTreeRecord.Expanded);
            }

            return valuesDictionary;
        }
        #endregion
    }
}
