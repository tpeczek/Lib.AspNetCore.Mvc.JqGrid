using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using System.Collections.Generic;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel
{
    /// <summary>
    /// Base class which represents options for jqGrid editable or searchable column element
    /// </summary>
    public abstract class JqGridColumnElementOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value indicating if the first item will automatically be focused when the menu is shown.
        /// </summary>
        public bool AutocompleteAutoFocus { get; set; }

        /// <summary>
        /// Gets or sets the delay in milliseconds between when a keystroke occurs and when a search is performed.
        /// </summary>
        public int AutocompleteDelay { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of characters a user must type before a search is performed.
        /// </summary>
        public int AutocompleteMinLength { get; set; }

        /// <summary>
        /// Gets or sets the function which will build the select element in case where the server response can not build it (requires DataUrl property to be set).
        /// </summary>
        public string BuildSelect { get; set; }

        /// <summary>
        /// Gets or sets the list of events to apply to the element (jQuery UI widgets events can also be applied this way).
        /// </summary>
        public ICollection<JqGridColumnDataEvent> DataEvents { get; set; }

        /// <summary>
        /// Gets or sets the function which will be called once when the element is created. This property is ignored in case of jQuery UI widgets.
        /// </summary>
        public string DataInit { get; set; }

        /// <summary>
        /// Gets or sets the URL to get the AJAX data for the select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Autocomplete).
        /// </summary>
        public string DataUrl { get; set; }

        /// <summary>
        /// Gets or sets the text to display after each date field.
        /// </summary>
        public string DatepickerAppendText { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the input field should be automatically resize to accommodate dates in the current format.
        /// </summary>
        public bool DatepickerAutoSize { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the month should be rendered as a dropdown instead of text.
        /// </summary>
        public bool DatepickerChangeMonth { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the year should be rendered as a dropdown instead of text.
        /// </summary>
        public bool DatepickerChangeYear { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the input field should constrained to characters allowed by the current format.
        /// </summary>
        public bool DatepickerConstrainInput { get; set; }

        /// <summary>
        /// Gets or sets the format for parsed and displayed dates.
        /// </summary>
        /// <remarks>If the value for this property is not provided, but there is a JqGridColumnFormatterAttribute with JqGridColumnPredefinedFormatters.Date formatter the helper will try to provide the value based on JqGridColumnFormatterAttribute.OutputFormat.</remarks> 
        public string DatePickerDateFormat { get; set; }

        /// <summary>
        /// Gets or sets the first day of the week: Sunday is 0, Monday is 1, etc.
        /// </summary>
        public int DatepickerFirstDay { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the current day link moves to the currently selected date instead of today.
        /// </summary>
        public bool DatepickerGotoCurrent { get; set; }

        /// <summary>
        /// Gets or sets the maximum selectable date.
        /// </summary>
        /// <remarks>This string must be in the format defined by the DateFormat property, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.</remarks> 
        public string DatepickerMaxDate { get; set; }

        /// <summary>
        /// Gets or sets the minimum selectable date.
        /// </summary>
        /// <remarks>This string must be in the format defined by the DateFormat property, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.</remarks> 
        public string DatepickerMinDate { get; set; }

        /// <summary>
        /// Gets or sets the number of months to show at once.
        /// </summary>
        public int DatepickerNumberOfMonths { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether days in other months shown before or after the current month are selectable, this only applies if the ShowOtherMonths is set to true.
        /// </summary>
        public bool DatepickerSelectOtherMonths { get; set; }

        /// <summary>
        /// Gets or sets the cutoff year for determining the century for a date.
        /// </summary>
        /// <remarks>This string must be a relative number of years from the current year, e.g., "+3" or "-5".</remarks> 
        public string DatepickerShortYearCutoff { get; set; }

        /// <summary>
        /// Gets or sets the value which defines position to display the current month in, if the ShowOtherMonths is set to true.
        /// </summary>
        public int DatepickerShowCurrentAtPos { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to show the month after the year in the header.
        /// </summary>
        public bool DatepickerShowMonthAfterYear { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to display dates in other months (non-selectable) at the start or end of the current month, to make these days selectable set the SelectOtherMonths to true.
        /// </summary>
        public bool DatepickerShowOtherMonths { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to add column with the week of the year.
        /// </summary>
        public bool DatepickerShowWeek { get; set; }

        /// <summary>
        /// Gets or sets the value which defines how many months to move when clicking the previous/next links.
        /// </summary>
        public int DatepickerStepMonths { get; set; }

        /// <summary>
        /// Gets or sets the range of years displayed in the year dropdown.
        /// </summary>
        /// <remarks>This string must be either relative to today's year ("-nn:+nn"), relative to the currently selected year ("c-nn:c+nn"), absolute ("nnnn:nnnn"), or combinations of these formats ("nnnn:-nn"). Note that this option only affects what appears in the dropdown, to restrict which dates may be selected use the MinDate and/or MaxDate.</remarks> 
        public string DatepickerYearRange { get; set; }

        /// <summary>
        /// Gets or sets the additional text to display after the year in the month headers.
        /// </summary>
        public string DatepickerYearSuffix { get; set; }

        /// <summary>
        /// Gets or sets the default value in the search input element.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets a dictionary where keys should be valid attributes for the element.
        /// </summary>
        public IDictionary<string, object> HtmlAttributes { get; set; }

        /// <summary>
        /// Gets or sets the culture to use for parsing and formatting the value when Globalize plugin is included.
        /// </summary>
        public string SpinnerCulture { get; set; }

        /// <summary>
        /// Gets or sets the icon class (form UI theme icons) for down button.
        /// </summary>
        public string SpinnerDownIcon { get; set; }

        /// <summary>
        /// Gets or sets value controlling the number of steps taken when holding down a spin button.
        /// </summary>
        public bool SpinnerIncremental { get; set; }

        /// <summary>
        /// Gets or sets maximum allowed value.
        /// </summary>
        public int? SpinnerMax { get; set; }

        /// <summary>
        /// Gets or sets minimum allowed value.
        /// </summary>
        public int? SpinnerMin { get; set; }

        /// <summary>
        /// Gets or sets the format of numbers passed to Globalize plugin if it is included.
        /// </summary>
        public string SpinnerNumberFormat { get; set; }

        /// <summary>
        /// Gets or sets the number of steps to take when paging via the pageUp/pageDown JavaScript methods.
        /// </summary>
        public int SpinnerPage { get; set; }

        /// <summary>
        /// Gets or sets the size of the step to take when spinning via buttons or via the stepUp/stepDown JavaScript methods.
        /// </summary>
        public int SpinnerStep { get; set; }

        /// <summary>
        /// Gets or sets the icon class (form UI theme icons) for up button.
        /// </summary>
        public string SpinnerUpIcon { get; set; }

        /// <summary>
        /// Gets or sets the set of value:label pairs for select element (takes precedence over ValueDictionary property).
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the dictionary which will be serialized into set of value:label pairs for select element.
        /// </summary>
        public IDictionary<string, string> ValueDictionary { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnElementOptions class.
        /// </summary>
        public JqGridColumnElementOptions()
        {
            BuildSelect = null;
            DataEvents = null;
            DataInit = null;
            DataUrl = null;
            DefaultValue = null;
            HtmlAttributes = null;

            AutocompleteAutoFocus = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.AutocompleteAutoFocus;
            AutocompleteDelay = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.AutocompleteDelay;
            AutocompleteMinLength = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.AutocompleteMinLength;

            DatepickerAppendText = null;
            DatepickerAutoSize = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerAutoSize;
            DatepickerChangeMonth = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerChangeMonth;
            DatepickerChangeYear = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerChangeYear;
            DatepickerConstrainInput = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerConstrainInput;
            DatePickerDateFormat = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerDateFormat;
            DatepickerFirstDay = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerFirstDay;
            DatepickerGotoCurrent = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerGotoCurrent;
            DatepickerMaxDate = null;
            DatepickerMinDate = null;
            DatepickerNumberOfMonths = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerNumberOfMonths;
            DatepickerSelectOtherMonths = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerSelectOtherMonths;
            DatepickerShortYearCutoff = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShortYearCutoff;
            DatepickerShowCurrentAtPos = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowCurrentAtPos;
            DatepickerShowMonthAfterYear = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowMonthAfterYear;
            DatepickerShowOtherMonths = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowOtherMonths;
            DatepickerShowWeek = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerShowWeek;
            DatepickerStepMonths = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerStepMonths;
            DatepickerYearRange = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerYearRange;
            DatepickerYearSuffix = null;

            SpinnerCulture = null;
            SpinnerDownIcon = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerDownIcon;
            SpinnerIncremental = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerIncremental;
            SpinnerMax = null;
            SpinnerMin = null;
            SpinnerNumberFormat = null;
            SpinnerPage = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerPage;
            SpinnerStep = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerStep;
            SpinnerUpIcon = JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.SpinnerUpIcon;
        }
        #endregion
    }
}
