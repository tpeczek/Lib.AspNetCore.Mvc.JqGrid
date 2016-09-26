using System;
using System.Text;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridJavaScriptRenderingHelper
    {
        #region Constants
        internal const string COLUMNS_NAMES_FIELD = "colNames";

        internal const string COLUMNS_MODEL_FIELD = "colModel";
        internal const string COLUMNS_MODEL_NAME_FIELD = "name";
        internal const string COLUMNS_MODEL_INDEX_FIELD = "index";
        internal const string COLUMNS_MODEL_INITIAL_SORTING_ORDER_FIELD = "firstsortorder";
        internal const string COLUMNS_MODEL_SORTABLE_FIELD = "sortable";
        internal const string COLUMNS_MODEL_SORT_TYPE_FIELD = "sorttype";
        #endregion

        #region Extension Methods
        internal static StringBuilder AppendJavaScriptArrayFieldOpening(this StringBuilder javaScriptBuilder, string fieldName)
        {
            return javaScriptBuilder.AppendFormat("{0}: [", fieldName);
        }

        internal static StringBuilder AppendJavaScriptArrayFieldClosing(this StringBuilder javaScriptBuilder)
        {
            javaScriptBuilder.RemoveTrailingComma();
            return javaScriptBuilder.Append("],");
        }

        internal static StringBuilder AppendJavaScriptArrayStringValue(this StringBuilder javaScriptBuilder, string value)
        {
            return javaScriptBuilder.AppendFormat("'{0}',", value);
        }

        internal static StringBuilder AppendJavaScriptObjectOpening(this StringBuilder javaScriptBuilder)
        {
            return javaScriptBuilder.Append("{");
        }

        internal static StringBuilder AppendJavaScriptObjectFieldClosing(this StringBuilder javaScriptBuilder)
        {
            javaScriptBuilder.RemoveTrailingComma();
            return javaScriptBuilder.Append("},");
        }

        internal static StringBuilder AppendJavaScriptObjectStringField(this StringBuilder javaScriptBuilder, string fieldName, string fieldValue)
        {
            if (!String.IsNullOrWhiteSpace(fieldValue))
            {
                javaScriptBuilder.AppendFormat("{0}:'{1}',", fieldName, fieldValue);
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptObjectEnumField<TEnum>(this StringBuilder javaScriptBuilder, string fieldName, TEnum fieldValue, TEnum? defaultFieldValue = null) where TEnum : struct
        {
            if (!defaultFieldValue.HasValue || !(fieldValue.Equals(defaultFieldValue.Value)))
            {
                javaScriptBuilder.AppendFormat("{0}:'{1}',", fieldName, fieldValue.ToString().ToLower());
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptObjectBooleanField(this StringBuilder javaScriptBuilder, string fieldName, bool fieldValue, bool? defaultFieldValue = null)
        {
            if (!defaultFieldValue.HasValue || (fieldValue != defaultFieldValue.Value))
            {
                javaScriptBuilder.AppendFormat("{0}:{1},", fieldName, fieldValue.ToString().ToLower());
            }

            return javaScriptBuilder;
        }

        private static StringBuilder RemoveTrailingComma(this StringBuilder javaScriptBuilder)
        {
            if (javaScriptBuilder[javaScriptBuilder.Length - 1] == ',')
            {
                javaScriptBuilder.Length -= 1;
            }

            return javaScriptBuilder;
        }
        #endregion
    }
}
