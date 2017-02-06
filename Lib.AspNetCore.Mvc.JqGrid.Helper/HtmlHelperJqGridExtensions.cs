using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;
using Microsoft.AspNetCore.Mvc.Routing;

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
        /// Returns the HTML that is used to render the pager (div) placeholder for the grid. 
        /// </summary>
        /// <returns>The HTML that represents the pager (div) placeholder for jqGrid</returns>
        public static IHtmlContent JqGridPagerHtml(this IHtmlHelper htmlHelper, JqGridOptions options)
        {
            return new HtmlString(String.Format("<div id='{0}'></div>", options.GetJqGridPagerId()));
        }

        /// <summary>
        /// Returns the HTML that is used to render the table placeholder for the grid with pager placeholder below it and filter grid (if enabled) placeholder above it.
        /// </summary>
        /// <returns>The HTML that represents the table placeholder for jqGrid with pager placeholder below i</returns>
        public static IHtmlContent JqGridHtml(this IHtmlHelper htmlHelper, JqGridOptions options)
        {
            if (options.Pager)
                return new HtmlString(htmlHelper.JqGridTableHtml(options).ToString() + htmlHelper.JqGridPagerHtml(options).ToString());
            else
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

            IUrlHelperFactory urlHelperFactory = (IUrlHelperFactory)htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory));
            options.ApplyModelMetadata(htmlHelper.MetadataProvider, urlHelperFactory.GetUrlHelper(htmlHelper.ViewContext));

            StringBuilder javaScriptBuilder = new StringBuilder();

            javaScriptBuilder.AppendFormat("$('#{0}')", options.Id)
                .AppendJqGridScript(options, false);

            return new HtmlString(javaScriptBuilder.ToString());
        }
        #endregion

        #region Private Methods
        private static void ValidateJqGridConstraints(JqGridOptions options)
        {
            if ((options.SubgridModel != null) && (options.SubgridOptions != null))
            {
                throw new InvalidOperationException("Subgrid model and subgrid options can't be used at the same time.");
            }

            if ((options.SubgridOptions != null) && !String.IsNullOrWhiteSpace(options.SubGridRowExpanded))
            {
                throw new InvalidOperationException("Subgrid options and subGridRowExpanded can't be used at the same time.");
            }

            if (options.TreeGridEnabled && options.GroupingEnabled)
            {
                throw new InvalidOperationException("TreeGrid and data grouping can not be enabled at the same time.");
            }

            if ((options.DynamicScrollingMode != JqGridDynamicScrollingModes.Disabled) && options.GroupingEnabled)
            {
                throw new InvalidOperationException("Dynamic scrolling and data grouping can not be enabled at the same time.");
            }
        }
        #endregion
    }
}
