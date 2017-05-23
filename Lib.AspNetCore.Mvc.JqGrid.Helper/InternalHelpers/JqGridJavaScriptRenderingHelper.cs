using System;
using System.Text;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static string GetJqGridPagerId(this JqGridOptions options, JqGridNavigatorPagers pager = JqGridNavigatorPagers.Standard)
        {
            return options.Id + ((pager == JqGridNavigatorPagers.Standard) ? "Pager" : "_toppager");
        }

        internal static string GetJqGridPagerSelector(this JqGridOptions options, JqGridNavigatorPagers pager, bool asSubgrid)
        {
            return asSubgrid? ((pager == JqGridNavigatorPagers.Standard) ? JqGridSubgridJavaScriptRenderingHelper.SUBGRID_PAGER_ID : JqGridSubgridJavaScriptRenderingHelper.SUBGRID_TOP_PAGER_ID) : String.Format("'#{0}'", options.GetJqGridPagerId(pager));
        }

        internal static StringBuilder AppendJqGridScript(this StringBuilder javaScriptBuilder, JqGridOptions options, bool asSubgrid)
        {
            javaScriptBuilder.Append(".jqGrid({").AppendLine()
               .AppendJavaScriptObjectStringArrayField(JqGridOptionsNames.COLUMNS_NAMES_FIELD, options.ColumnsNames)
               .AppendColumnsModels(options, asSubgrid)
               .AppendOptions(options, asSubgrid)
               .AppendJavaScriptObjectClosing()
               .AppendHeaderGrouping(options)
               .AppendFilterToolbar(options.FilterToolbar)
               .AppendNavigator(options, asSubgrid)
               .AppendInlineNavigator(options, asSubgrid)
               .AppendLine(");");

            return javaScriptBuilder;
        }
        #endregion
    }
}
