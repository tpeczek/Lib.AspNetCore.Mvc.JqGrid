using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static StringBuilder AppendJavaScriptArrayFieldOpening(this StringBuilder javaScriptBuilder, string fieldName)
        {
            return javaScriptBuilder.AppendFormat("{0}:[", fieldName);
        }

        internal static StringBuilder AppendJavaScriptArrayFieldClosing(this StringBuilder javaScriptBuilder)
        {
            javaScriptBuilder.RemoveTrailingComma();
            return javaScriptBuilder.Append("],");
        }

        internal static StringBuilder AppendJavaScriptArrayStringValue(this StringBuilder javaScriptBuilder, string value, string defaultValue = null)
        {
            if (!String.IsNullOrEmpty(defaultValue) ? (value != defaultValue) : !String.IsNullOrEmpty(value))
            {
                javaScriptBuilder.AppendFormat("'{0}',", value);
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptArrayEnumValue<TEnum>(this StringBuilder javaScriptBuilder, TEnum value, TEnum? defaultValue = null) where TEnum : struct
        {
            if (!defaultValue.HasValue || !(value.Equals(defaultValue.Value)))
            {
                javaScriptBuilder.AppendFormat("'{0}',", value.ToString().ToLower());
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptArrayBooleanValue(this StringBuilder javaScriptBuilder, bool value, bool? defaultValue = null)
        {
            if (!defaultValue.HasValue || !(value.Equals(defaultValue.Value)))
            {
                javaScriptBuilder.AppendFormat("{0},", value.ToString().ToLower());
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptObjectOpening(this StringBuilder javaScriptBuilder)
        {
            return javaScriptBuilder.Append("{");
        }

        internal static StringBuilder AppendJavaScriptObjectFieldOpening(this StringBuilder javaScriptBuilder, string fieldName)
        {
            return javaScriptBuilder.Append("{0}:{");
        }

        internal static StringBuilder AppendJavaScriptObjectFieldClosing(this StringBuilder javaScriptBuilder)
        {
            javaScriptBuilder.RemoveTrailingComma();
            return javaScriptBuilder.Append("},");
        }

        internal static StringBuilder AppendJavaScriptObjectStringField(this StringBuilder javaScriptBuilder, string fieldName, string fieldValue, string defaultFieldValue = null)
        {
            if (!String.IsNullOrEmpty(defaultFieldValue) ? (fieldValue != defaultFieldValue) : !String.IsNullOrEmpty(fieldValue))
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

        internal static StringBuilder AppendJavaScriptObjectIntegerField(this StringBuilder javaScriptBuilder, string fieldName, int fieldValue, int? defaultFieldValue = null)
        {
            if (!defaultFieldValue.HasValue || !(fieldValue.Equals(defaultFieldValue.Value)))
            {
                javaScriptBuilder.AppendFormat("{0}:{1},", fieldName, fieldValue.ToString(CultureInfo.InvariantCulture));
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptObjectIntegerField(this StringBuilder javaScriptBuilder, string fieldName, int? fieldValue)
        {
            if (fieldValue.HasValue)
            {
                javaScriptBuilder.AppendFormat("{0}:{1},", fieldName, fieldValue.Value.ToString(CultureInfo.InvariantCulture));
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptObjectFunctionField(this StringBuilder javaScriptBuilder, string fieldName, string fieldValue)
        {
            if (!String.IsNullOrWhiteSpace(fieldValue))
            {
                javaScriptBuilder.AppendFormat("{0}:{1},", fieldName, fieldValue);
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptObjectObjectField(this StringBuilder javaScriptBuilder, string fieldName, object fieldValue)
        {
            if (fieldValue != null)
            {
                javaScriptBuilder.AppendJavaScriptObjectFunctionField(fieldName, JsonConvert.SerializeObject(fieldValue, Formatting.None));
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendJavaScriptObjectScriptOrObjectField(this StringBuilder javaScriptBuilder, string fieldName, string fieldScript, object fieldValue)
        {
            if (!String.IsNullOrWhiteSpace(fieldScript))
            {
                javaScriptBuilder.AppendJavaScriptObjectFunctionField(fieldName, fieldScript);
            }
            else if (fieldValue != null)
            {
                javaScriptBuilder.AppendJavaScriptObjectObjectField(fieldName, fieldValue);
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
