using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper
{
    /// <summary>
    /// Provides support for generating jqGrid HMTL and JavaScript.
    /// </summary>
    public static class HtmlHelperJqGridExtensions
    {
        #region Fields
        private const string JQUERY_UI_BUTTON_FORMATTER_START = "function(cellValue,options,rowObject){setTimeout(function(){$('#' + options.rowId + '_JQueryUIButton').attr('data-cell-value',cellValue).button(";
        private const string JQUERY_UI_BUTTON_FORMATTER_ON_CLICK = ").click({0}";
        private const string JQUERY_UI_BUTTON_FORMATTER_END = ");},0);return '<button id=\"' + options.rowId + '_JQueryUIButton\" />';}";
        #endregion

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

            options.ApplyModelMetadata(htmlHelper.MetadataProvider);

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
            javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.COLUMNS_NAMES_FIELD);

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
            javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.COLUMNS_MODEL_FIELD);

            foreach(JqGridColumnModel columnModel in options.ColumnsModels)
            {
                javaScriptBuilder.AppendJavaScriptObjectOpening()
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.NAME_FIELD, columnModel.Name)
                    .AppendColumnModelSortOptions(columnModel)
                    .AppendColumnModelFormatter(columnModel);

                javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
            }

            javaScriptBuilder.AppendJavaScriptArrayFieldClosing()
                .AppendLine();

            return javaScriptBuilder;
        }

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

        private static StringBuilder AppendColumnModelFormatterOptions(this StringBuilder javaScriptBuilder, string formatter, JqGridColumnFormatterOptions  formatterOptions)
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

        private static StringBuilder AppendInlineNavigatorActionOptions(this StringBuilder javaScriptBuilder, JqGridInlineNavigatorActionOptions inlineNavigatorActionOptions)
        {
            if ((inlineNavigatorActionOptions != null) && !inlineNavigatorActionOptions.AreDefault())
            {
                javaScriptBuilder.AppendJavaScriptObjectScriptOrObjectField(JqGridOptionsNames.InlineNavigator.EXTRA_PARAM, inlineNavigatorActionOptions.ExtraParamScript, inlineNavigatorActionOptions.ExtraParam)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.InlineNavigator.KEYS, inlineNavigatorActionOptions.Keys, JqGridOptionsDefaults.Navigator.InlineActionKeys)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.ON_EDIT_FUNCTION, inlineNavigatorActionOptions.OnEditFunction)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.SUCCESS_FUNCTION, inlineNavigatorActionOptions.SuccessFunction)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.InlineNavigator.URL, inlineNavigatorActionOptions.Url)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.AFTER_SAVE_FUNCTION, inlineNavigatorActionOptions.AfterSaveFunction)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.ERROR_FUNCTION, inlineNavigatorActionOptions.ErrorFunction)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.AFTER_RESTORE_FUNCTION, inlineNavigatorActionOptions.AfterRestoreFunction)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.InlineNavigator.RESTORE_AFTER_ERROR, inlineNavigatorActionOptions.RestoreAfterError, JqGridOptionsDefaults.Navigator.InlineActionRestoreAfterError)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.InlineNavigator.METHOD_TYPE, inlineNavigatorActionOptions.MethodType, JqGridOptionsDefaults.Navigator.InlineActionMethodType);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendNavigatorEditActionOptions(this StringBuilder javaScriptBuilder, string fieldName, JqGridNavigatorEditActionOptions navigatorEditActionOptions)
        {
            if ((navigatorEditActionOptions != null) && !navigatorEditActionOptions.AreDefault())
            {
                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.AppendJavaScriptObjectOpening();
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldOpening(fieldName);
                }

                if ((navigatorEditActionOptions.SaveKeyEnabled != JqGridOptionsDefaults.Navigator.SaveKeyEnabled) || (navigatorEditActionOptions.SaveKey != JqGridOptionsDefaults.Navigator.SaveKey))
                {
                    javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.Navigator.SAVE_KEY)
                    .AppendJavaScriptArrayBooleanValue(navigatorEditActionOptions.SaveKeyEnabled)
                    .AppendJavaScriptArrayIntegerValue(navigatorEditActionOptions.SaveKey)
                    .AppendJavaScriptArrayFieldClosing();
                }

                javaScriptBuilder.AppendNavigatorModifyActionOptions(navigatorEditActionOptions)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.WIDTH, navigatorEditActionOptions.Width, JqGridOptionsDefaults.Navigator.EditActionWidth)
                    .AppendJavaScriptObjectObjectField(JqGridOptionsNames.Navigator.AJAX_EDIT_OPTIONS, navigatorEditActionOptions.AjaxOptions)
                    .AppendJavaScriptObjectScriptOrObjectField(JqGridOptionsNames.Navigator.EDIT_EXTRA_DATA, navigatorEditActionOptions.ExtraDataScript, navigatorEditActionOptions.ExtraData)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.SERIALIZE_EDIT_DATA, navigatorEditActionOptions.SerializeData)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.Navigator.ADDED_ROW_POSITION, navigatorEditActionOptions.AddedRowPosition, JqGridOptionsDefaults.Navigator.AddedRowPosition)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_CLICK_PG_BUTTONS, navigatorEditActionOptions.AfterClickPgButtons)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_COMPLETE, navigatorEditActionOptions.AfterComplete)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_CHECK_VALUES, navigatorEditActionOptions.BeforeCheckValues)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.BOTTOM_INFO, navigatorEditActionOptions.BottomInfo)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CHECK_ON_SUBMIT, navigatorEditActionOptions.CheckOnSubmit, JqGridOptionsDefaults.Navigator.CheckOnSubmit)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CHECK_ON_UPDATE, navigatorEditActionOptions.CheckOnUpdate, JqGridOptionsDefaults.Navigator.CheckOnUpdate)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLEAR_AFTER_ADD, navigatorEditActionOptions.ClearAfterAdd, JqGridOptionsDefaults.Navigator.ClearAfterAdd)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_AFTER_ADD, navigatorEditActionOptions.CloseAfterAdd, JqGridOptionsDefaults.Navigator.CloseAfterAdd)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_AFTER_EDIT, navigatorEditActionOptions.CloseAfterEdit, JqGridOptionsDefaults.Navigator.CloseAfterEdit)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.CLOSE_ICON, navigatorEditActionOptions.CloseButtonIcon, JqGridFormButtonIcon.CloseIcon)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ERROR_TEXT_FORMAT, navigatorEditActionOptions.ErrorTextFormat)
                    .AppendNavigatorPageableFormActionOptions(navigatorEditActionOptions)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_CLICK_PG_BUTTONS, navigatorEditActionOptions.OnClickPgButtons)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_INITIALIZE_FORM, navigatorEditActionOptions.OnInitializeForm)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.SAVE_ICON, navigatorEditActionOptions.SaveButtonIcon, JqGridFormButtonIcon.SaveIcon)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.TOP_INFO, navigatorEditActionOptions.TopInfo)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendNavigatorDeleteActionOptions(this StringBuilder javaScriptBuilder, string fieldName, JqGridNavigatorDeleteActionOptions navigatorDeleteActionOptions)
        {
            if ((navigatorDeleteActionOptions != null) && !navigatorDeleteActionOptions.AreDefault())
            {
                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.AppendJavaScriptObjectOpening();
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldOpening(fieldName);
                }

                javaScriptBuilder.AppendNavigatorModifyActionOptions(navigatorDeleteActionOptions)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.WIDTH, navigatorDeleteActionOptions.Width, JqGridOptionsDefaults.Navigator.DeleteActionWidth)
                    .AppendJavaScriptObjectObjectField(JqGridOptionsNames.Navigator.AJAX_DELETE_OPTIONS, navigatorDeleteActionOptions.AjaxOptions)
                    .AppendJavaScriptObjectScriptOrObjectField(JqGridOptionsNames.Navigator.DELETE_EXTRA_DATA, navigatorDeleteActionOptions.ExtraDataScript, navigatorDeleteActionOptions.ExtraData)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.SERIALIZE_DELETE_DATA, navigatorDeleteActionOptions.SerializeData)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.DELETE_ICON, navigatorDeleteActionOptions.DeleteButtonIcon, JqGridFormButtonIcon.DeleteIcon)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.CANCEL_ICON, navigatorDeleteActionOptions.CancelButtonIcon, JqGridFormButtonIcon.CancelIcon)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendFormButtonIcon(this StringBuilder javaScriptBuilder, string formButtonIconName, JqGridFormButtonIcon formButtonIcon, JqGridFormButtonIcon defaultFormButtonIcon)
        {
            if ((formButtonIcon != null) && !formButtonIcon.Equals(defaultFormButtonIcon))
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(formButtonIconName)
                    .AppendJavaScriptArrayBooleanValue(formButtonIcon.Enabled)
                    .AppendJavaScriptArrayEnumValue(formButtonIcon.Position)
                    .AppendJavaScriptArrayStringValue(formButtonIcon.Class)
                    .AppendJavaScriptArrayFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendNavigatorModifyActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorModifyActionOptions navigatorModifyActionOptions)
        {
            javaScriptBuilder.AppendNavigatorFormActionOptions(navigatorModifyActionOptions);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_SHOW_FORM, navigatorModifyActionOptions.AfterShowForm)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_SUBMIT, navigatorModifyActionOptions.AfterSubmit)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_SUBMIT, navigatorModifyActionOptions.BeforeSubmit)
                .AppendJavaScriptObjectEnumField(JqGridOptionsNames.Navigator.METHOD_TYPE, navigatorModifyActionOptions.MethodType, JqGridOptionsDefaults.Navigator.MethodType)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_CLICK_SUBMIT, navigatorModifyActionOptions.OnClickSubmit)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.RELOAD_AFTER_SUBMIT, navigatorModifyActionOptions.ReloadAfterSubmit, JqGridOptionsDefaults.Navigator.ReloadAfterSubmit)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.URL, navigatorModifyActionOptions.Url);
        }

        private static StringBuilder AppendNavigatorFormActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorFormActionOptions navigatorFormActionOptions)
        {
            javaScriptBuilder.AppendNavigatorActionOptions(navigatorFormActionOptions);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_INIT_DATA, navigatorFormActionOptions.BeforeInitData)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_SHOW_FORM, navigatorFormActionOptions.BeforeShowForm);
        }

        private static StringBuilder AppendNavigatorPageableFormActionOptions(this StringBuilder javaScriptBuilder, IJqGridNavigatorPageableFormActionOptions navigatorPageableFormActionOptions)
        {
            if ((navigatorPageableFormActionOptions.NavigationKeys != null)&& navigatorPageableFormActionOptions.NavigationKeys.IsDefault())
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.Navigator.NAVIGATION_KEYS)
                    .AppendJavaScriptArrayBooleanValue(navigatorPageableFormActionOptions.NavigationKeys.Enabled)
                    .AppendJavaScriptArrayIntegerValue(navigatorPageableFormActionOptions.NavigationKeys.RecordDown)
                    .AppendJavaScriptArrayIntegerValue(navigatorPageableFormActionOptions.NavigationKeys.RecordUp)
                    .AppendJavaScriptArrayFieldClosing();
            }

            return javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.VIEW_PAGER_BUTTONS, navigatorPageableFormActionOptions.ViewPagerButtons, JqGridOptionsDefaults.Navigator.ViewPagerButtons)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.RECREATE_FORM, navigatorPageableFormActionOptions.RecreateForm, JqGridOptionsDefaults.Navigator.RecreateForm);
        }

        private static StringBuilder AppendNavigatorActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorActionOptions navigatorActionOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_ON_ESCAPE, navigatorActionOptions.CloseOnEscape, JqGridOptionsDefaults.Navigator.CloseOnEscape)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.DATA_HEIGHT, navigatorActionOptions.DataHeight)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.DATA_WIDTH, navigatorActionOptions.DataWidth)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.DRAGABLE, navigatorActionOptions.Dragable, JqGridOptionsDefaults.Navigator.Dragable)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.HEIGHT, navigatorActionOptions.Height)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.LEFT, navigatorActionOptions.Left, JqGridOptionsDefaults.Navigator.Left)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.MODAL, navigatorActionOptions.Modal, JqGridOptionsDefaults.Navigator.Modal)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_CLOSE, navigatorActionOptions.OnClose)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.OVERLAY, navigatorActionOptions.Overlay, JqGridOptionsDefaults.Navigator.Overlay)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.RESIZE, navigatorActionOptions.Resizable, JqGridOptionsDefaults.Navigator.Resizable)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.TOP, navigatorActionOptions.Top, JqGridOptionsDefaults.Navigator.Top)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.USE_JQ_MODAL, navigatorActionOptions.UseJqModal, JqGridOptionsDefaults.Navigator.UseJqModal);
        }
        #endregion
    }
}
