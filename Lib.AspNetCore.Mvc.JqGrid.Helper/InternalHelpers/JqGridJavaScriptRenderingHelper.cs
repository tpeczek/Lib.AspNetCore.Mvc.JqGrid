using System.Text;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static string GetJqGridPagerId(this JqGridOptions options)
        {
            return options.Id + "Pager";
        }

        internal static StringBuilder AppendJqGridScript(this StringBuilder javaScriptBuilder, JqGridOptions options, bool asSubgrid)
        {
            javaScriptBuilder.Append(".jqGrid({").AppendLine()
               .AppendJavaScriptObjectStringArrayField(JqGridOptionsNames.COLUMNS_NAMES_FIELD, options.ColumnsNames)
               .AppendColumnsModels(options, asSubgrid)
               .AppendOptions(options, asSubgrid)
               .AppendJavaScriptObjectClosing()
               .AppendLine(");");

            return javaScriptBuilder;
        }
        #endregion
    }
}
