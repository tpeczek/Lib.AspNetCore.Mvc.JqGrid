using System;
using System.Text;
using Lib.AspNetCore.Mvc.JqGrid.Core.Request;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridOptionsJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static StringBuilder AppendOptions(this StringBuilder javaScriptBuilder, JqGridOptions options, bool asSubgrid)
        {
            javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.CAPTION, options.Caption)
                .AppendCellEditing(options)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.EDITITNG_URL, options.EditingUrl)
                .AppendJavaScriptObjectEnumField(JqGridOptionsNames.DATA_TYPE, options.DataType, JqGridOptionsDefaults.DataType)
                .AppendDataSource(options, asSubgrid)
                .AppendGrouping(options)
                .AppendParametersNames(options.ParametersNames)
                .AppendJsonReader(options.JsonReader)
                .AppendPager(options, asSubgrid)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.TOP_PAGER, options.TopPager, JqGridOptionsDefaults.TopPager)
                .AppendSubgrid(options)
                .AppendTreeGrid(options)
                .AppendDynamicScrolling(options)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.SORTING_NAME, options.SortingName)
                .AppendJavaScriptObjectEnumField(JqGridOptionsNames.SORTING_ORDER, options.SortingOrder, JqGridOptionsDefaults.SortingOrder)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.FOOTER_ENABLED, options.FooterEnabled, JqGridOptionsDefaults.FooterEnabled)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.USER_DATA_ON_FOOTER, options.UserDataOnFooter, JqGridOptionsDefaults.UserDataOnFooter)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.HEIGHT, options.Height);

            if (!options.Height.HasValue)
            {
                javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.HEIGHT, JqGridOptionsDefaults.Height);
            }

            return javaScriptBuilder;
        }
        #endregion

        #region Private Methods
        internal static string GetJqGridPager(JqGridOptions options, bool asSubgrid)
        {
            return asSubgrid ? "$subgridPager" : String.Format("'#{0}'", options.GetJqGridPagerId());
        }

        private static StringBuilder AppendCellEditing(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            if (options.CellEditingEnabled)
            {
                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.CELL_EDITING, true);

                if (options.CellEditingSubmitMode == JqGridCellEditingSubmitModes.ClientArray)
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.CELL_EDITING_SUBMIT_MODE, "clientArray");
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.CELL_EDITITNG_URL, options.CellEditingUrl);
                }
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendDataSource(this StringBuilder javaScriptBuilder, JqGridOptions options, bool asSubgrid)
        {
            if (options.DataType.IsDataStringDataType())
            {
                javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.DATA_STRING, options.DataString);
            }
            else
            {
                if (asSubgrid)
                {
                    if (options.Url.Contains("?"))
                    {
                        javaScriptBuilder.AppendFormat("{0}:'{1}&rowId=' + encodeURIComponent(rowId),", JqGridOptionsNames.URL, options.Url);
                    }
                    else
                    {
                        javaScriptBuilder.AppendFormat("{0}:'{1}?rowId=' + encodeURIComponent(rowId),", JqGridOptionsNames.URL, options.Url);
                    }
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.URL, options.Url);
                }

                javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridOptionsNames.METHOD_TYPE, options.MethodType, JqGridOptionsDefaults.MethodType);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendDynamicScrolling(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            if (options.DynamicScrollingMode == JqGridDynamicScrollingModes.HoldAllRows)
            {
                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.DYNAMIC_SCROLLING_MODE, true);
            }
            else if (options.DynamicScrollingMode == JqGridDynamicScrollingModes.HoldVisibleRows)
            {
                javaScriptBuilder.AppendJavaScriptObjectIntegerField(JqGridOptionsNames.DYNAMIC_SCROLLING_MODE, 10)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.DYNAMIC_SCROLLING_TIMEOUT, options.DynamicScrollingTimeout, JqGridOptionsDefaults.DynamicScrollingTimeout);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendTreeGrid(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            if (options.TreeGridEnabled)
            {
                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.TREE_GRID_ENABLED, options.TreeGridEnabled)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.TREE_GRID_MODEL, options.TreeGridModel, JqGridOptionsDefaults.TreeGridModel)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.EXPAND_COLUMN_CLICK, options.ExpandColumnClick, JqGridOptionsDefaults.ExpandColumnClick)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.EXPAND_COLUMN, options.ExpandColumn);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendPager(this StringBuilder javaScriptBuilder, JqGridOptions options, bool asSubgrid)
        {
            if (options.Pager)
            {
                javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.PAGER, GetJqGridPager(options, asSubgrid))
                    .AppendJavaScriptObjectIntegerArrayField(JqGridOptionsNames.ROWS_LIST, options.RowsList)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ROWS_NUMBER, options.RowsNumber, JqGridOptionsDefaults.RowsNumber)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.VIEW_RECORDS, options.ViewRecords, JqGridOptionsDefaults.ViewRecords);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendParametersNames(this StringBuilder javaScriptBuilder, JqGridParametersNames parametersNames)
        {
            parametersNames = parametersNames ?? JqGridRequest.ParametersNames;

            if ((parametersNames != null) && !parametersNames.AreDefault())
            {
                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.PARAMETERS_NAMES)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.PAGE_INDEX, parametersNames.PageIndex, JqGridOptionsDefaults.Request.PageIndex)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.RECORDS_COUNT, parametersNames.RecordsCount, JqGridOptionsDefaults.Request.RecordsCount)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.SORTING_NAME, parametersNames.SortingName, JqGridOptionsDefaults.Request.SortingName)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.SORTING_ORDER, parametersNames.SortingOrder, JqGridOptionsDefaults.Request.SortingOrder)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.SEARCHING, parametersNames.Searching, JqGridOptionsDefaults.Request.Searching)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.ID, parametersNames.Id, JqGridOptionsDefaults.Request.Id)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.OPERATOR, parametersNames.Operator, JqGridOptionsDefaults.Request.Operator)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.EDIT_OPERATOR, parametersNames.EditOperator, JqGridOptionsDefaults.Request.EditOperator)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.ADD_OPERATOR, parametersNames.AddOperator, JqGridOptionsDefaults.Request.AddOperator)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.DELETE_OPERATOR, parametersNames.DeleteOperator, JqGridOptionsDefaults.Request.DeleteOperator)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.SUBGRID_ID, parametersNames.SubgridId, JqGridOptionsDefaults.Request.SubgridId)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.PAGES_COUNT, parametersNames.PagesCount)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ParametersNames.TOTAL_ROWS, parametersNames.TotalRows, JqGridOptionsDefaults.Request.TotalRows)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }
        #endregion
    }
}
