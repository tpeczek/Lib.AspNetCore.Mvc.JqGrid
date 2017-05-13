using System.Linq;
using System.Text;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridGroupingJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static StringBuilder AppendHeaderGrouping(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            if ((options.GroupHeaders != null) && options.GroupHeaders.Any())
            {
                javaScriptBuilder.AppendLine(")")
                    .Append(".jqGrid('setGroupHeaders',{")
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.HeaderGrouping.USE_COL_SPAN_STYLE, options.GroupHeadersUseColSpanStyle, JqGridOptionsDefaults.GroupHeadersUseColSpanStyle)
                    .AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.HeaderGrouping.GROUP_HEADERS);

                foreach(JqGridGroupHeader groupHeader in options.GroupHeaders)
                {
                    javaScriptBuilder.AppendGroupHeader(groupHeader);
                }

                javaScriptBuilder.AppendJavaScriptArrayFieldClosing()
                    .AppendJavaScriptObjectClosing();
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendGrouping(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            if (options.GroupingEnabled)
            {
                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.GROUPING_ENABLED, options.GroupingEnabled);
                if (options.GroupingView != null)
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.GROUPING_VIEW)
                        .AppendJavaScriptObjectStringArrayField(JqGridOptionsNames.GroupingView.FIELDS, options.GroupingView.Fields)
                        .AppendJavaScriptObjectEnumArrayField(JqGridOptionsNames.GroupingView.ORDERS, options.GroupingView.Orders)
                        .AppendJavaScriptObjectStringArrayField(JqGridOptionsNames.GroupingView.TEXTS, options.GroupingView.Texts)
                        .AppendJavaScriptObjectBooleanArrayField(JqGridOptionsNames.GroupingView.SUMMARY, options.GroupingView.Summary)
                        .AppendJavaScriptObjectBooleanArrayField(JqGridOptionsNames.GroupingView.COLUMN_SHOW, options.GroupingView.ColumnShow)
                        .AppendJavaScriptObjectFunctionArrayField(JqGridOptionsNames.GroupingView.IS_IN_THE_SAME_GROUP_CALLBACKS, options.GroupingView.IsInTheSameGroupCallbacks)
                        .AppendJavaScriptObjectFunctionArrayField(JqGridOptionsNames.GroupingView.FORMAT_DISPLAY_FIELD_CALLBACKS, options.GroupingView.FormatDisplayFieldCallbacks)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.GroupingView.SUMMARY_ON_HIDE, options.GroupingView.SummaryOnHide, JqGridOptionsDefaults.GroupingView.SummaryOnHide)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.GroupingView.DATA_SORTED, options.GroupingView.DataSorted, JqGridOptionsDefaults.GroupingView.DataSorted)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.GroupingView.COLLAPSE, options.GroupingView.Collapse, JqGridOptionsDefaults.GroupingView.Collapse)
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.GroupingView.PLUS_ICON, options.GroupingView.PlusIcon, JqGridOptionsDefaults.GroupingView.PlusIcon)
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.GroupingView.MINUS_ICON, options.GroupingView.MinusIcon, JqGridOptionsDefaults.GroupingView.MinusIcon)
                        .AppendJavaScriptObjectFieldClosing();
                }
            }

            return javaScriptBuilder;
        }
        #endregion

        #region Private Methods
        private static StringBuilder AppendGroupHeader(this StringBuilder javaScriptBuilder, JqGridGroupHeader groupHeader)
        {
            return javaScriptBuilder.AppendJavaScriptObjectOpening()
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.HeaderGrouping.Group.START_COLUMN_NAME, groupHeader.StartColumn)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.HeaderGrouping.Group.NUMBER_OF_COLUMNS, groupHeader.NumberOfColumns)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.HeaderGrouping.Group.TITLE_TEXT, groupHeader.Title)
                .AppendJavaScriptObjectFieldClosing();
        }
        #endregion
    }
}
