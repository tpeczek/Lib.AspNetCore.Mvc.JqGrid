using System;
using System.Text;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridColumnModelJavaScriptRenderingHelper
    {
        #region Fields
        private const string JQUERY_UI_BUTTON_FORMATTER_START = "function(cellValue,options,rowObject){setTimeout(function(){$('#' + options.rowId + '_JQueryUIButton').attr('data-cell-value',cellValue).button(";
        private const string JQUERY_UI_BUTTON_FORMATTER_ON_CLICK = ").click({0}";
        private const string JQUERY_UI_BUTTON_FORMATTER_END = ");},0);return '<button id=\"' + options.rowId + '_JQueryUIButton\" />';}";
        #endregion

        #region Extension Methods
        internal static StringBuilder AppendColumnsModels(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.COLUMNS_MODEL_FIELD);

            foreach (JqGridColumnModel columnModel in options.ColumnsModels)
            {
                javaScriptBuilder.AppendJavaScriptObjectOpening()
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.NAME_FIELD, columnModel.Name)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.ALIGNMENT, columnModel.Alignment, JqGridOptionsDefaults.ColumnModel.Alignment)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.CELL_ATTRIBUTES, columnModel.CellAttributes)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.CLASSES, columnModel.Classes)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.FIXED, columnModel.Fixed, JqGridOptionsDefaults.ColumnModel.Fixed)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.FROZEN, columnModel.Frozen, JqGridOptionsDefaults.ColumnModel.Frozen)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.HIDE_IN_DIALOG, columnModel.HideInDialog, JqGridOptionsDefaults.ColumnModel.HideInDialog)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.RESIZABLE, columnModel.Resizable, JqGridOptionsDefaults.ColumnModel.Resizable)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.TITLE, columnModel.Title, JqGridOptionsDefaults.ColumnModel.Title)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.WIDTH, columnModel.Width, JqGridOptionsDefaults.ColumnModel.Width)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.VIEWABLE, columnModel.Viewable, JqGridOptionsDefaults.ColumnModel.Viewable)
                    .AppendColumnModelSortOptions(columnModel)
                    .AppendColumnModelSummaryOptions(columnModel, options)
                    .AppendColumnModelFormatter(columnModel);

                javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
            }

            javaScriptBuilder.AppendJavaScriptArrayFieldClosing()
                .AppendLine();

            return javaScriptBuilder;
        }
        #endregion

        #region Private Methods
        private static StringBuilder AppendColumnModelSortOptions(this StringBuilder javaScriptBuilder, JqGridColumnModel columnModel)
        {
            javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.INDEX_FIELD, columnModel.Index)
                .AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.INITIAL_SORTING_ORDER_FIELD, columnModel.InitialSortingOrder, JqGridOptionsDefaults.ColumnModel.Sorting.InitialOrder);

            if (columnModel.Sortable != JqGridOptionsDefaults.ColumnModel.Sorting.Sortable)
            {
                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.SORTABLE_FIELD, columnModel.Sortable);
            }
            else
            {
                if (columnModel.SortType == JqGridSortTypes.Function)
                {
                    javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.SORT_TYPE_FIELD, columnModel.SortFunction);
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.SORT_TYPE_FIELD, columnModel.SortType, JqGridOptionsDefaults.ColumnModel.Sorting.Type);
                }
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelSummaryOptions(this StringBuilder javaScriptBuilder, JqGridColumnModel columnModel, JqGridOptions options)
        {
            if (options.GroupingEnabled)
            {
                if (columnModel.SummaryType.HasValue)
                {
                    if (columnModel.SummaryType.Value != JqGridColumnSummaryTypes.Custom)
                    {
                        javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.SUMMARY_TYPE, columnModel.SummaryType.Value);
                    }
                    else
                    {
                        javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.SUMMARY_TYPE, columnModel.SummaryFunction);
                    }
                }

                javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.SUMMARY_TEMPLATE, columnModel.SummaryTemplate, JqGridOptionsDefaults.ColumnModel.SummaryTemplate);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelFormatter(this StringBuilder javaScriptBuilder, JqGridColumnModel columnModel)
        {
            if (!String.IsNullOrWhiteSpace(columnModel.Formatter))
            {
                if (columnModel.Formatter == JqGridPredefinedFormatters.JQueryUIButton)
                {
                    javaScriptBuilder.AppendColumnModelJQueryUIButtonFormatter(columnModel.FormatterOptions);
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.FORMATTER_FIELD, columnModel.Formatter)
                        .AppendColumnModelFormatterOptions(columnModel.Formatter, columnModel.FormatterOptions)
                        .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.UNFORMATTER_FIELD, columnModel.UnFormatter);
                }
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelJQueryUIButtonFormatter(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            StringBuilder jQueryUIButtonFormatterBuilder = new StringBuilder(80);
            jQueryUIButtonFormatterBuilder.Append(JQUERY_UI_BUTTON_FORMATTER_START);

            if (!formatterOptions.AreDefault(JqGridPredefinedFormatters.JQueryUIButton))
            {
                jQueryUIButtonFormatterBuilder.AppendJavaScriptObjectOpening()
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.LABEL, formatterOptions.Label)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Formatter.TEXT, formatterOptions.Text, JqGridOptionsDefaults.ColumnModel.Formatter.Text);

                if (!String.IsNullOrEmpty(formatterOptions.PrimaryIcon) || !String.IsNullOrEmpty(formatterOptions.SecondaryIcon))
                {
                    jQueryUIButtonFormatterBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.ColumnModel.Formatter.ICONS)
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.PRIMARY, formatterOptions.PrimaryIcon)
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.SECONDARY, formatterOptions.SecondaryIcon)
                        .AppendJavaScriptObjectFieldClosing();
                }

                jQueryUIButtonFormatterBuilder.AppendJavaScriptObjectClosing();
            }

            if (!String.IsNullOrWhiteSpace(formatterOptions.OnClick))
            {
                jQueryUIButtonFormatterBuilder.AppendFormat(JQUERY_UI_BUTTON_FORMATTER_ON_CLICK, formatterOptions.OnClick);
            }
            jQueryUIButtonFormatterBuilder.Append(JQUERY_UI_BUTTON_FORMATTER_END);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.FORMATTER_FIELD, jQueryUIButtonFormatterBuilder.ToString());
        }

        private static StringBuilder AppendColumnModelFormatterOptions(this StringBuilder javaScriptBuilder, string formatter, JqGridColumnFormatterOptions formatterOptions)
        {
            if ((formatterOptions) != null && !formatterOptions.AreDefault(formatter))
            {
                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.ColumnModel.FORMATTER_OPTIONS_FIELD);

                switch (formatter)
                {
                    case JqGridPredefinedFormatters.Integer:
                        javaScriptBuilder.AppendColumnModelIntegerFormatterOptions(formatterOptions);
                        break;
                    case JqGridPredefinedFormatters.Number:
                        javaScriptBuilder.AppendColumnModelNumberFormatterOptions(formatterOptions);
                        break;
                    case JqGridPredefinedFormatters.Currency:
                        javaScriptBuilder.AppendColumnModelCurrencyFormatterOptions(formatterOptions);
                        break;
                    case JqGridPredefinedFormatters.Date:
                        javaScriptBuilder.AppendColumnModelDateFormatterOptions(formatterOptions);
                        break;
                    case JqGridPredefinedFormatters.Link:
                        javaScriptBuilder.AppendColumnModelLinkFormatterOptions(formatterOptions);
                        break;
                    case JqGridPredefinedFormatters.ShowLink:
                        javaScriptBuilder.AppendColumnModelShowLinkFormatterOptions(formatterOptions);
                        break;
                    case JqGridPredefinedFormatters.CheckBox:
                        javaScriptBuilder.AppendColumnModelCheckBoxFormatterOptions(formatterOptions);
                        break;
                    case JqGridPredefinedFormatters.Actions:
                        javaScriptBuilder.AppendColumnModelActionsFormatterOptions(formatterOptions);
                        break;
                }

                javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelIntegerFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.DEFAULT_VALUE, formatterOptions.DefaultValue, JqGridOptionsDefaults.ColumnModel.Formatter.IntegerDefaultValue)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.THOUSANDS_SEPARATOR, formatterOptions.ThousandsSeparator, JqGridOptionsDefaults.ColumnModel.Formatter.ThousandsSeparator);
        }

        private static StringBuilder AppendColumnModelNumberFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.Formatter.DECIMAL_PLACES, formatterOptions.DecimalPlaces, JqGridOptionsDefaults.ColumnModel.Formatter.DecimalPlaces)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.DECIMAL_SEPARATOR, formatterOptions.DecimalSeparator, JqGridOptionsDefaults.ColumnModel.Formatter.DecimalSeparator)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.DEFAULT_VALUE, formatterOptions.DefaultValue, JqGridOptionsDefaults.ColumnModel.Formatter.NumberDefaultValue)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.THOUSANDS_SEPARATOR, formatterOptions.ThousandsSeparator, JqGridOptionsDefaults.ColumnModel.Formatter.ThousandsSeparator);
        }

        private static StringBuilder AppendColumnModelCurrencyFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.Formatter.DECIMAL_PLACES, formatterOptions.DecimalPlaces, JqGridOptionsDefaults.ColumnModel.Formatter.DecimalPlaces)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.DECIMAL_SEPARATOR, formatterOptions.DecimalSeparator, JqGridOptionsDefaults.ColumnModel.Formatter.DecimalSeparator)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.DEFAULT_VALUE, formatterOptions.DefaultValue, JqGridOptionsDefaults.ColumnModel.Formatter.NumberDefaultValue)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.PREFIX, formatterOptions.Prefix)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.SUFFIX, formatterOptions.Suffix)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.THOUSANDS_SEPARATOR, formatterOptions.ThousandsSeparator, JqGridOptionsDefaults.ColumnModel.Formatter.ThousandsSeparator);
        }

        private static StringBuilder AppendColumnModelDateFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.SOURCE_FORMAT, formatterOptions.SourceFormat, JqGridOptionsDefaults.ColumnModel.Formatter.SourceFormat)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.OUTPUT_FORMAT, formatterOptions.OutputFormat, JqGridOptionsDefaults.ColumnModel.Formatter.OutputFormat);
        }

        private static StringBuilder AppendColumnModelLinkFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.TARGET, formatterOptions.Target);
        }

        private static StringBuilder AppendColumnModelShowLinkFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.BASE_LINK_URL, formatterOptions.BaseLinkUrl)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.SHOW_ACTION, formatterOptions.ShowAction)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.ADD_PARAM, formatterOptions.AddParam)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.TARGET, formatterOptions.Target)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Formatter.ID_NAME, formatterOptions.IdName, JqGridOptionsDefaults.ColumnModel.Formatter.IdName);
        }

        private static StringBuilder AppendColumnModelCheckBoxFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Formatter.DISABLED, formatterOptions.Disabled);
        }

        private static StringBuilder AppendColumnModelActionsFormatterOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormatterOptions formatterOptions)
        {
            javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Formatter.EDIT_BUTTON, formatterOptions.EditButton, JqGridOptionsDefaults.ColumnModel.Formatter.EditButton)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Formatter.DELETE_BUTTON, formatterOptions.DeleteButton, JqGridOptionsDefaults.ColumnModel.Formatter.DeleteButton)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Formatter.USE_FORM_EDITING, formatterOptions.UseFormEditing, JqGridOptionsDefaults.ColumnModel.Formatter.UseFormEditing);

            if (formatterOptions.EditButton)
            {
                if (formatterOptions.UseFormEditing)
                {
                    javaScriptBuilder.AppendNavigatorEditActionOptions(JqGridOptionsNames.ColumnModel.Formatter.EDIT_OPTIONS, formatterOptions.FormEditingOptions);
                }
                else
                {
                    javaScriptBuilder.AppendInlineNavigatorActionOptions(formatterOptions.InlineEditingOptions);
                }
            }

            if (formatterOptions.DeleteButton)
            {
                javaScriptBuilder.AppendNavigatorDeleteActionOptions(JqGridOptionsNames.ColumnModel.Formatter.DELETE_OPTIONS, formatterOptions.DeleteOptions);
            }

            return javaScriptBuilder;
        }
        #endregion
    }
}
