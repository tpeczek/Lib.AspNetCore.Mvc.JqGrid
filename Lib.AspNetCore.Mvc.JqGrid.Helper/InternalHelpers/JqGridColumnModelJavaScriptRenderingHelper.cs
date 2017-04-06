using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
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

        private const string JQUERY_UI_AUTOCOMPLETE_DATA_INIT_START = "function(element){setTimeout(function(){$(element).autocomplete(";
        private const string JQUERY_UI_AUTOCOMPLETE_DATA_INIT_END = ");},0);}";

        private const string JQUERY_UI_DATEPICKER_DATA_INIT_START = "function(element){setTimeout(function(){$(element).datepicker(";
        private const string JQUERY_UI_DATEPICKER_DATA_INIT_END = ");},0);}";

        private const string JQUERY_UI_SPINNER_DATA_INIT_START = "function(element){setTimeout(function(){$(element).spinner(";
        private const string JQUERY_UI_SPINNER_DATA_INIT_END = ");},0);}";

        private readonly static IDictionary<JqGridCompatibilityModes, string> _jqueryUiDatepickerDaysNamesFunctions = new Dictionary<JqGridCompatibilityModes, string>
        {
            { JqGridCompatibilityModes.JqGrid, "$.jgrid.formatter.date.dayNames.slice(7)" },
            { JqGridCompatibilityModes.GuriddoJqGrid, "$.jgrid.getRegional({0}[0], 'formatter.date.dayNames').slice(7)" },
            { JqGridCompatibilityModes.FreeJqGrid, "{0}.jqGrid('getGridRes', 'formatter.date.dayNames').slice(7)" }
        };

        private readonly static IDictionary<JqGridCompatibilityModes, string> _jqueryUiDatepickerDaysNamesShortFunctions = new Dictionary<JqGridCompatibilityModes, string>
        {
            { JqGridCompatibilityModes.JqGrid, "$.jgrid.formatter.date.dayNames.slice(0, 7)" },
            { JqGridCompatibilityModes.GuriddoJqGrid, "$.jgrid.getRegional({0}[0], 'formatter.date.dayNames').slice(0, 7)" },
            { JqGridCompatibilityModes.FreeJqGrid, "{0}.jqGrid('getGridRes', 'formatter.date.dayNames').slice(0, 7)" }
        };

        private readonly static IDictionary<JqGridCompatibilityModes, string> _jqueryUiDatepickerMonthsNamesFunctions = new Dictionary<JqGridCompatibilityModes, string>
        {
            { JqGridCompatibilityModes.JqGrid, "$.jgrid.formatter.date.monthNames.slice(12)" },
            { JqGridCompatibilityModes.GuriddoJqGrid, "$.jgrid.getRegional({0}[0], 'formatter.date.monthNames').slice(12)" },
            { JqGridCompatibilityModes.FreeJqGrid, "{0}.jqGrid('getGridRes', 'formatter.date.monthNames').slice(12)" }
        };

        private readonly static IDictionary<JqGridCompatibilityModes, string> _jqueryUiDatepickerMonthsNamesShortFunctions = new Dictionary<JqGridCompatibilityModes, string>
        {
            { JqGridCompatibilityModes.JqGrid, "$.jgrid.formatter.date.monthNames.slice(0, 12)" },
            { JqGridCompatibilityModes.GuriddoJqGrid, "$.jgrid.getRegional({0}[0], 'formatter.date.monthNames').slice(0, 12)" },
            { JqGridCompatibilityModes.FreeJqGrid, "{0}.jqGrid('getGridRes', 'formatter.date.monthNames').slice(0, 12)" }
        };
        #endregion

        #region Extension Methods
        internal static StringBuilder AppendColumnsModels(this StringBuilder javaScriptBuilder, JqGridOptions options, bool asSubgrid)
        {
            javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.COLUMNS_MODEL_FIELD);

            foreach (JqGridColumnModel columnModel in options.ColumnsModels)
            {
                javaScriptBuilder.AppendJavaScriptObjectOpening()
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.NAME, columnModel.Name)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.ALIGNMENT, columnModel.Alignment, JqGridOptionsDefaults.ColumnModel.Alignment)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.CELL_ATTRIBUTES, columnModel.CellAttributes)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.CLASSES, columnModel.Classes)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.FIXED, columnModel.Fixed, JqGridOptionsDefaults.ColumnModel.Fixed)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.FROZEN, columnModel.Frozen, JqGridOptionsDefaults.ColumnModel.Frozen)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.HIDE_IN_DIALOG, columnModel.HideInDialog, JqGridOptionsDefaults.ColumnModel.HideInDialog)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.HIDDEN, columnModel.Hidden, JqGridOptionsDefaults.ColumnModel.Hidden)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.RESIZABLE, columnModel.Resizable, JqGridOptionsDefaults.ColumnModel.Resizable)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.TITLE, columnModel.Title, JqGridOptionsDefaults.ColumnModel.Title)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.WIDTH, columnModel.Width, JqGridOptionsDefaults.ColumnModel.Width)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.VIEWABLE, columnModel.Viewable, JqGridOptionsDefaults.ColumnModel.Viewable)
                    .AppendColumnModelEditOptions(columnModel, options, asSubgrid)
                    .AppendColumnModelSearchOptions(columnModel, options, asSubgrid)
                    .AppendColumnModelSortOptions(columnModel)
                    .AppendColumnModelSummaryOptions(columnModel, options)
                    .AppendColumnModelFormatter(columnModel);

                javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
            }

            javaScriptBuilder.AppendJavaScriptArrayFieldClosing()
                .AppendLine();

            return javaScriptBuilder;
        }
        
        internal static StringBuilder AppendSearchOperators(this StringBuilder javaScriptBuilder, JqGridSearchOperators? searchOperators)
        {
            if (searchOperators.HasValue && (searchOperators != JqGridOptionsDefaults.ColumnModel.Searching.SearchOperators))
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.ColumnModel.Searching.SEARCH_OPERATORS);
                foreach (JqGridSearchOperators searchOperator in Enum.GetValues(typeof(JqGridSearchOperators)))
                {
                    if ((searchOperator != JqGridSearchOperators.EqualOrNotEqual) && (searchOperator != JqGridSearchOperators.NoTextOperators) && (searchOperator != JqGridSearchOperators.TextOperators) && (searchOperator != JqGridSearchOperators.NullOperators) && ((searchOperators.Value & searchOperator) == searchOperator))
                    {
                        javaScriptBuilder.AppendJavaScriptArrayEnumValue(searchOperator);
                    }
                }
                javaScriptBuilder.AppendJavaScriptArrayFieldClosing();
            }

            return javaScriptBuilder;
        }
        #endregion

        #region Private Methods
        private static StringBuilder AppendColumnModelEditOptions(this StringBuilder javaScriptBuilder, JqGridColumnModel columnModel, JqGridOptions options, bool asSubgrid)
        {
            javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.EDITABLE, columnModel.Editable, JqGridOptionsDefaults.ColumnModel.Editable);

            if (columnModel.Editable)
            {
                bool isJQueryUIElement = (columnModel.EditType == JqGridColumnEditTypes.JQueryUIAutocomplete) || (columnModel.EditType == JqGridColumnEditTypes.JQueryUIDatepicker) || (columnModel.EditType == JqGridColumnEditTypes.JQueryUISpinner);
                if (!isJQueryUIElement)
                {
                    javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.EDIT_TYPE, columnModel.EditType, JqGridOptionsDefaults.ColumnModel.EditType);
                }

                if ((columnModel.EditOptions != null) && (isJQueryUIElement || !columnModel.EditOptions.AreDefault()))
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.ColumnModel.EDIT_OPTIONS)
                        .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Editing.CUSTOM_ELEMENT, columnModel.EditOptions.CustomElementFunction)
                        .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Editing.CUSTOM_VALUE, columnModel.EditOptions.CustomValueFunction)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Editing.NULL_IF_EMPTY, columnModel.EditOptions.NullIfEmpty, JqGridOptionsDefaults.ColumnModel.Editing.NullIfEmpty);

                    if (!String.IsNullOrWhiteSpace(columnModel.EditOptions.PostDataScript))
                    {
                        javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Editing.POST_DATA, columnModel.EditOptions.PostDataScript);
                    }
                    else if (columnModel.EditOptions.PostData != null)
                    {
                        javaScriptBuilder.AppendJavaScriptObjectObjectField(JqGridOptionsNames.ColumnModel.Editing.POST_DATA, columnModel.EditOptions.PostData);
                    }

                    if ((columnModel.EditOptions.HtmlAttributes != null) && (columnModel.EditOptions.HtmlAttributes.Count > 0))
                    {
                        javaScriptBuilder.AppendJavaScriptObjectObjectPropertiesFields(columnModel.EditOptions.HtmlAttributes);
                    }

                    switch (columnModel.EditType)
                    {
                        case JqGridColumnEditTypes.JQueryUIAutocomplete:
                            javaScriptBuilder.AppendColumnModelJQueryUIAutocompleteDataInit(columnModel.EditOptions);
                            break;
                        case JqGridColumnEditTypes.JQueryUIDatepicker:
                            javaScriptBuilder.AppendColumnModelJQueryUIDatepickerDataInit(columnModel.EditOptions, options, asSubgrid);
                            break;
                        case JqGridColumnEditTypes.JQueryUISpinner:
                            javaScriptBuilder.AppendColumnModelJQueryUISpinnerDataInit(columnModel.EditOptions);
                            break;
                    }

                    javaScriptBuilder.AppendColumnModelElementOptions(columnModel.EditOptions, isJQueryUIElement)
                        .AppendJavaScriptObjectFieldClosing();
                }

                javaScriptBuilder.AppendColumnModelRules(JqGridOptionsNames.ColumnModel.EDIT_RULES, columnModel.EditRules)
                    .AppendColumnModelFormOptions(columnModel.FormOptions);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelSearchOptions(this StringBuilder javaScriptBuilder, JqGridColumnModel columnModel, JqGridOptions options, bool asSubgrid)
        {
            javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.SEARCHABLE, columnModel.Searchable, JqGridOptionsDefaults.ColumnModel.Searchable);
            
            if (columnModel.Searchable)
            {
                bool isJQueryUIElement = (columnModel.SearchType == JqGridColumnSearchTypes.JQueryUIAutocomplete) || (columnModel.SearchType == JqGridColumnSearchTypes.JQueryUIDatepicker) || (columnModel.SearchType == JqGridColumnSearchTypes.JQueryUISpinner);
                if (!isJQueryUIElement)
                {
                    javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.SEARCH_TYPE, columnModel.SearchType, JqGridOptionsDefaults.ColumnModel.SearchType);
                }

                if ((columnModel.SearchOptions != null) && (isJQueryUIElement || !columnModel.SearchOptions.AreDefault()))
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.ColumnModel.SEARCH_OPTIONS)
                        .AppendJavaScriptObjectObjectField(JqGridOptionsNames.ColumnModel.Searching.HTML_ATTRIBUTES, columnModel.SearchOptions.HtmlAttributes)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Searching.CLEAR_SEARCH, columnModel.SearchOptions.ClearSearch, JqGridOptionsDefaults.ColumnModel.Searching.ClearSearch)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Searching.SEARCH_HIDDEN, columnModel.SearchOptions.SearchHidden, JqGridOptionsDefaults.ColumnModel.Searching.SearchHidden)
                        .AppendSearchOperators(columnModel.SearchOptions.SearchOperators);

                    switch(columnModel.SearchType)
                    {
                        case JqGridColumnSearchTypes.JQueryUIAutocomplete:
                            javaScriptBuilder.AppendColumnModelJQueryUIAutocompleteDataInit(columnModel.SearchOptions);
                            break;
                        case JqGridColumnSearchTypes.JQueryUIDatepicker:
                            javaScriptBuilder.AppendColumnModelJQueryUIDatepickerDataInit(columnModel.SearchOptions, options, asSubgrid);
                            break;
                        case JqGridColumnSearchTypes.JQueryUISpinner:
                            javaScriptBuilder.AppendColumnModelJQueryUISpinnerDataInit(columnModel.SearchOptions);
                            break;
                    }

                    javaScriptBuilder.AppendColumnModelElementOptions(columnModel.SearchOptions, isJQueryUIElement)
                        .AppendJavaScriptObjectFieldClosing();
                }

                javaScriptBuilder.AppendColumnModelRules(JqGridOptionsNames.ColumnModel.SEARCH_RULES, columnModel.SearchRules);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelRules(this StringBuilder javaScriptBuilder, string fieldName, JqGridColumnRules columnRules)
        {
            if ((columnRules != null) && !columnRules.AreDefault())
            {
                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(fieldName);

                if (columnRules.Custom != JqGridOptionsDefaults.ColumnModel.Rules.Custom)
                {
                    javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.CUSTOM, columnRules.Custom)
                        .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Rules.CUSTOM_FUNCTION, columnRules.CustomFunction);
                }

                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.DATE, columnRules.Date, JqGridOptionsDefaults.ColumnModel.Rules.Date)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.EDIT_HIDDEN, columnRules.EditHidden, JqGridOptionsDefaults.ColumnModel.Rules.EditHidden)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.EMAIL, columnRules.Email, JqGridOptionsDefaults.ColumnModel.Rules.Email)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.INTEGER, columnRules.Integer, JqGridOptionsDefaults.ColumnModel.Rules.Integer)
                    .AppendJavaScriptObjectDoubleField(JqGridOptionsNames.ColumnModel.Rules.MAX_VALUE, columnRules.MaxValue)
                    .AppendJavaScriptObjectDoubleField(JqGridOptionsNames.ColumnModel.Rules.MIN_VALUE, columnRules.MinValue)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.NUMBER, columnRules.Number, JqGridOptionsDefaults.ColumnModel.Rules.Number)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.REQUIRED, columnRules.Required, JqGridOptionsDefaults.ColumnModel.Rules.Required)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.TIME, columnRules.Time, JqGridOptionsDefaults.ColumnModel.Rules.Time)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.Rules.URL, columnRules.Url, JqGridOptionsDefaults.ColumnModel.Rules.Url)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelFormOptions(this StringBuilder javaScriptBuilder, JqGridColumnFormOptions formOptions)
        {
            if ((formOptions != null) && !formOptions.AreDefault())
            {
                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.ColumnModel.FORM_OPTIONS)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.FormOptions.COLUMN_POSITION, formOptions.ColumnPosition)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.FormOptions.ELEMENT_PREFIX, formOptions.ElementPrefix)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.FormOptions.ELEMENT_SUFFIX, formOptions.ElementSuffix)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.FormOptions.LABEL, formOptions.Label)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.FormOptions.ROW_POSITION, formOptions.RowPosition)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendColumnModelJQueryUIAutocompleteDataInit(this StringBuilder javaScriptBuilder, JqGridColumnElementOptions elementOptions)
        {
            StringBuilder jQueryUIAutocompleteDataInitBuilder = new StringBuilder(JQUERY_UI_AUTOCOMPLETE_DATA_INIT_START.Length + JQUERY_UI_AUTOCOMPLETE_DATA_INIT_END.Length + JqGridOptionsNames.ColumnModel.JQueryUIWidgets.AUTOCOMPLETE_SOURCE.Length + elementOptions.DataUrl.Length + 5);

            jQueryUIAutocompleteDataInitBuilder.Append(JQUERY_UI_AUTOCOMPLETE_DATA_INIT_START)
                .AppendJavaScriptObjectOpening()
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.AUTOCOMPLETE_SOURCE, elementOptions.DataUrl)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.AUTOCOMPLETE_AUTO_FOCUS, elementOptions.AutocompleteAutoFocus, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.AutocompleteAutoFocus)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.AUTOCOMPLETE_DELAY, elementOptions.AutocompleteDelay, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.AutocompleteDelay)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.AUTOCOMPLETE_MIN_LENGTH, elementOptions.AutocompleteMinLength, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.AutocompleteMinLength)
                //.AppendJavaScriptObjectStringField("appendTo", $"#searchmodfbox_{options.Id}")
                .AppendJavaScriptObjectClosing()
                .Append(JQUERY_UI_AUTOCOMPLETE_DATA_INIT_END);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Element.DATA_INIT, jQueryUIAutocompleteDataInitBuilder.ToString());
        }

        private static StringBuilder AppendColumnModelJQueryUIDatepickerDataInit(this StringBuilder javaScriptBuilder, JqGridColumnElementOptions elementOptions, JqGridOptions options, bool asSubgrid)
        {
            StringBuilder jQueryUIDatepickerDataInitBuilder = new StringBuilder(JQUERY_UI_DATEPICKER_DATA_INIT_START.Length + JQUERY_UI_DATEPICKER_DATA_INIT_END.Length);

            string jQueryGridElement = asSubgrid ? JqGridSubgridJavaScriptRenderingHelper.SUBGRID_VARIABLE : String.Format("$('#{0}')", options.Id);

            jQueryUIDatepickerDataInitBuilder.Append(JQUERY_UI_DATEPICKER_DATA_INIT_START)
                .AppendJavaScriptObjectOpening()
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_DAY_NAMES, String.Format(_jqueryUiDatepickerDaysNamesFunctions[options.CompatibilityMode], jQueryGridElement))
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_DAY_NAMES_MIN, String.Format(_jqueryUiDatepickerDaysNamesShortFunctions[options.CompatibilityMode], jQueryGridElement))
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_DAY_NAMES_SHORT, String.Format(_jqueryUiDatepickerDaysNamesShortFunctions[options.CompatibilityMode], jQueryGridElement))
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_MONTH_NAMES, String.Format(_jqueryUiDatepickerMonthsNamesFunctions[options.CompatibilityMode], jQueryGridElement))
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_MONTH_NAMES_SHORT, String.Format(_jqueryUiDatepickerMonthsNamesShortFunctions[options.CompatibilityMode], jQueryGridElement))
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_APPEND_TEXT, elementOptions.DatepickerAppendText)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_AUTO_SIZE, elementOptions.DatepickerAutoSize, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerAutoSize)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_CHANGE_MONTH, elementOptions.DatepickerChangeMonth, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerChangeMonth)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_CHANGE_YEAR, elementOptions.DatepickerChangeYear, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerChangeYear)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_CONSTRAIN_INPUT, elementOptions.DatepickerConstrainInput, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerConstrainInput)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_DATE_FORMAT, elementOptions.DatePickerDateFormat, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerDateFormat)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_FIRST_DAY, elementOptions.DatepickerFirstDay, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerFirstDay)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_GO_TO_CURRENT, elementOptions.DatepickerGotoCurrent, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerGotoCurrent)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_MAX_DATE, elementOptions.DatepickerMaxDate)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_MIN_DATE, elementOptions.DatepickerMinDate)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_NUMBER_OF_MONTHS, elementOptions.DatepickerNumberOfMonths, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerNumberOfMonths)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_SELECT_OTHER_MONTHS, elementOptions.DatepickerSelectOtherMonths, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerSelectOtherMonths)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_SHORT_YEAR_CUTOFF, elementOptions.DatepickerShortYearCutoff, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShortYearCutoff)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_SHOW_CURRENT_AT_POS, elementOptions.DatepickerShowCurrentAtPos, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowCurrentAtPos)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_SHOW_MONTH_AFTER_YEAR, elementOptions.DatepickerShowMonthAfterYear, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowMonthAfterYear)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_SHOW_OTHER_MONTHS, elementOptions.DatepickerShowOtherMonths, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowOtherMonths)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_SHOW_WEEK, elementOptions.DatepickerShowWeek, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowWeek)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_STEP_MONTHS, elementOptions.DatepickerStepMonths, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerStepMonths)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_YEAR_RANGE, elementOptions.DatepickerYearRange, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerYearRange)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.DATEPICKER_YEAR_SUFFIX, elementOptions.DatepickerYearSuffix)
                .AppendJavaScriptObjectClosing()
                .Append(JQUERY_UI_DATEPICKER_DATA_INIT_END);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Element.DATA_INIT, jQueryUIDatepickerDataInitBuilder.ToString());
        }

        private static StringBuilder AppendColumnModelJQueryUISpinnerDataInit(this StringBuilder javaScriptBuilder, JqGridColumnElementOptions elementOptions)
        {
            StringBuilder jQueryUISpinnerDataInitBuilder = new StringBuilder(JQUERY_UI_SPINNER_DATA_INIT_START.Length + JQUERY_UI_SPINNER_DATA_INIT_END.Length);
            jQueryUISpinnerDataInitBuilder.Append(JQUERY_UI_SPINNER_DATA_INIT_START);

            if (!elementOptions.IsDefaultJQueryUISpinner())
            {
                jQueryUISpinnerDataInitBuilder.AppendJavaScriptObjectOpening();

                if ((elementOptions.SpinnerDownIcon != JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerDownIcon) || (elementOptions.SpinnerUpIcon != JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerUpIcon))
                {
                    jQueryUISpinnerDataInitBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_ICONS)
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_DOWN_ICON, elementOptions.SpinnerDownIcon, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerDownIcon)
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_UP_ICON, elementOptions.SpinnerUpIcon, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerUpIcon)
                        .AppendJavaScriptObjectFieldClosing();
                }

                jQueryUISpinnerDataInitBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_CULTURE, elementOptions.SpinnerCulture)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_INCREMENTAL, elementOptions.SpinnerIncremental, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerIncremental)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_MAX, elementOptions.SpinnerMax)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_MIN, elementOptions.SpinnerMin)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_NUMBER_FORMAT, elementOptions.SpinnerNumberFormat)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_PAGE, elementOptions.SpinnerPage, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerPage)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.ColumnModel.JQueryUIWidgets.SPINNER_STEP, elementOptions.SpinnerStep, JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerStep)
                    .AppendJavaScriptObjectClosing();
            }

            jQueryUISpinnerDataInitBuilder.Append(JQUERY_UI_SPINNER_DATA_INIT_END);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Element.DATA_INIT, jQueryUISpinnerDataInitBuilder.ToString());
        }

        private static StringBuilder AppendColumnModelElementOptions(this StringBuilder javaScriptBuilder, JqGridColumnElementOptions elementOptions, bool isJQueryUIElement)
        {
            if ((elementOptions.DataEvents != null) && (elementOptions.DataEvents.Count > 0))
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.ColumnModel.Element.DATA_EVENTS);
                foreach (JqGridColumnDataEvent dataEvent in elementOptions.DataEvents)
                {
                    javaScriptBuilder.AppendJavaScriptObjectOpening()
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Element.DataEvent.TYPE, dataEvent.Type)
                        .AppendJavaScriptObjectObjectField(JqGridOptionsNames.ColumnModel.Element.DataEvent.DATA, dataEvent.Data)
                        .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Element.DataEvent.FUNCTION, dataEvent.Function)
                        .AppendJavaScriptObjectClosing();
                }
                javaScriptBuilder.AppendJavaScriptArrayFieldClosing();
            }

            if (!isJQueryUIElement)
            {
                javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Element.DATA_INIT, elementOptions.DataInit);

                if (!String.IsNullOrWhiteSpace(elementOptions.DataUrl))
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Element.DATA_URL, elementOptions.DataUrl)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.Element.BUILD_SELECT, elementOptions.BuildSelect);
                }
                else if (!String.IsNullOrEmpty(elementOptions.Value))
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Element.VALUE, elementOptions.Value);
                }
                else if (elementOptions.ValueDictionary != null)
                {
                    javaScriptBuilder.AppendJavaScriptObjectObjectField(JqGridOptionsNames.ColumnModel.Element.VALUE, elementOptions.ValueDictionary);
                }
            }
            
            return javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.Element.DEFAULT_VALUE, elementOptions.DefaultValue);
        }

        private static StringBuilder AppendColumnModelSortOptions(this StringBuilder javaScriptBuilder, JqGridColumnModel columnModel)
        {
            javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.ColumnModel.INDEX, columnModel.Index)
                .AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.INITIAL_SORTING_ORDER, columnModel.InitialSortingOrder, JqGridOptionsDefaults.ColumnModel.Sorting.InitialOrder);

            if (columnModel.Sortable != JqGridOptionsDefaults.ColumnModel.Sorting.Sortable)
            {
                javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.ColumnModel.SORTABLE, columnModel.Sortable);
            }
            else
            {
                if (columnModel.SortType == JqGridSortTypes.Function)
                {
                    javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.SORT_TYPE, columnModel.SortFunction);
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridOptionsNames.ColumnModel.SORT_TYPE, columnModel.SortType, JqGridOptionsDefaults.ColumnModel.Sorting.Type);
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
                    javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.FORMATTER, columnModel.Formatter)
                        .AppendColumnModelFormatterOptions(columnModel.Formatter, columnModel.FormatterOptions)
                        .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.UNFORMATTER, columnModel.UnFormatter);
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

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.ColumnModel.FORMATTER, jQueryUIButtonFormatterBuilder.ToString());
        }

        private static StringBuilder AppendColumnModelFormatterOptions(this StringBuilder javaScriptBuilder, string formatter, JqGridColumnFormatterOptions formatterOptions)
        {
            if ((formatterOptions != null) && !formatterOptions.AreDefault(formatter))
            {
                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.ColumnModel.FORMATTER_OPTIONS);

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
