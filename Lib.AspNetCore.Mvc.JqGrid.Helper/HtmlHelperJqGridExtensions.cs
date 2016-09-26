using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper
{
    /// <summary>
    /// Provides support for generating jqGrid HMTL and JavaScript.
    /// </summary>
    public static class HtmlHelperJqGridExtensions
    {
        #region IHtmlHelper Extensions Methods
        /// <summary>
        /// Returns the HTML that is used to render the table placeholder for the grid. 
        /// </summary>
        /// <returns>The HTML that represents the table placeholder for jqGrid</returns>
        public static IHtmlContent JqGridTableHtml(this IHtmlHelper htmlHelper, JqGridOptions options)
        {
            return new HtmlString(String.Format("<table id='{0}'></table>", options.Id));
        }

        /// <summary>
        /// Returns the HTML that is used to render the table placeholder for the grid with pager placeholder below it and filter grid (if enabled) placeholder above it.
        /// </summary>
        /// <returns>The HTML that represents the table placeholder for jqGrid with pager placeholder below i</returns>
        public static IHtmlContent JqGridHtml(this IHtmlHelper htmlHelper, JqGridOptions options)
        {
            return htmlHelper.JqGridTableHtml(options);
        }

        /// <summary>
        /// Return the JavaScript that is used to initialize jqGrid with given options.
        /// </summary>
        /// <returns>The JavaScript that initializes jqGrid with give options</returns>
        /// <exception cref="System.InvalidOperationException">
        /// <list type="bullet">
        /// <item><description>TreeGrid and data grouping are both enabled.</description></item>
        /// <item><description>Rows numbers and data grouping are both enabled.</description></item>
        /// <item><description>Dynamic scrolling and data grouping are both enabled.</description></item>
        /// <item><description>TreeGrid and GridView are both enabled.</description></item>
        /// <item><description>SubGrid and GridView are both enabled.</description></item>
        /// <item><description>AfterInsertRow event and GridView are both enabled.</description></item>
        /// </list> 
        /// </exception>
        public static IHtmlContent JqGridJavaScript(this IHtmlHelper htmlHelper, JqGridOptions options)
        {
            ValidateJqGridConstraints(options);

            options.EnsureColumnsMetadata(htmlHelper.MetadataProvider);

            StringBuilder javaScriptBuilder = new StringBuilder();

            javaScriptBuilder.AppendFormat("$({0}).jqGrid({{", GetJqGridGridSelector(options, false)).AppendLine()
                .AppendColumnsNames(options)
                .AppendColumnsModels(options)
                .Append("})");

            javaScriptBuilder.AppendLine(";");

            return new HtmlString(javaScriptBuilder.ToString());
        }
        #endregion

        #region Private Methods
        private static void ValidateJqGridConstraints(JqGridOptions options)
        { }

        private static string GetJqGridGridSelector(JqGridOptions options, bool asSubgrid)
        {
            return asSubgrid ? "'#' + subgridTableId" : String.Format("'#{0}'", options.Id);
        }

        private static StringBuilder AppendColumnsNames(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridJavaScriptRenderingHelper.COLUMNS_NAMES_FIELD);

            foreach (string columnName in options.ColumnsNames)
            {
                javaScriptBuilder.AppendJavaScriptArrayStringValue(columnName);
            }

            javaScriptBuilder.AppendJavaScriptArrayFieldClosing()
                .AppendLine();

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnsModels(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridJavaScriptRenderingHelper.COLUMNS_MODEL_FIELD);

            foreach(JqGridColumnModel columnModel in options.ColumnsModels)
            {
                javaScriptBuilder.AppendJavaScriptObjectOpening()
                    .AppendJavaScriptObjectStringField(JqGridJavaScriptRenderingHelper.COLUMNS_MODEL_NAME_FIELD, columnModel.Name)
                    .AppendColumnModelSortOptions(columnModel);

                javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
            }

            javaScriptBuilder.AppendJavaScriptArrayFieldClosing()
                .AppendLine();

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelSortOptions(this StringBuilder javaScriptBuilder, JqGridColumnModel columnModel)
        {
            javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridJavaScriptRenderingHelper.COLUMNS_MODEL_INDEX_FIELD, columnModel.Index)
                .AppendJavaScriptObjectEnumField(JqGridJavaScriptRenderingHelper.COLUMNS_MODEL_INITIAL_SORTING_ORDER_FIELD, columnModel.InitialSortingOrder, JqGridOptionsDefaults.InitialSortingOrder);

            if (columnModel.Sortable != JqGridOptionsDefaults.Sortable)
            {
                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridJavaScriptRenderingHelper.COLUMNS_MODEL_SORTABLE_FIELD, columnModel.Sortable);
            }
            else
            {
                if (columnModel.SortType == JqGridSortTypes.Function)
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridJavaScriptRenderingHelper.COLUMNS_MODEL_SORT_TYPE_FIELD, columnModel.SortFunction);
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridJavaScriptRenderingHelper.COLUMNS_MODEL_SORT_TYPE_FIELD, columnModel.SortType, JqGridOptionsDefaults.SortType);
                }
            }

            return javaScriptBuilder;
        }
        #endregion
    }
}
