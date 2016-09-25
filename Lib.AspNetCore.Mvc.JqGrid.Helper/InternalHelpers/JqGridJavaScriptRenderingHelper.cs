using System.Text;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridJavaScriptRenderingHelper
    {
        #region Constants
        internal const string COLUMNS_NAMES_FIELD = "colNames";
        internal const string COLUMNS_MODEL_FIELD = "colModel";
        #endregion

        #region Extension Methods
        internal static StringBuilder AppendJavaScriptArrayFieldOpening(this StringBuilder javaScriptBuilder, string fieldName)
        {
            return javaScriptBuilder.AppendFormat("{0}: [", fieldName);
        }

        internal static StringBuilder AppendJavaScriptArrayFieldClosing(this StringBuilder javaScriptBuilder)
        {
            if (javaScriptBuilder[javaScriptBuilder.Length - 1] == ',')
                javaScriptBuilder.Length -= 1;

            return javaScriptBuilder.Append("],");
        }

        internal static StringBuilder AppendJavaScriptArrayStringValue(this StringBuilder javaScriptBuilder, string value)
        {
            return javaScriptBuilder.AppendFormat("'{0}',", value);
        }
        #endregion
    }
}
