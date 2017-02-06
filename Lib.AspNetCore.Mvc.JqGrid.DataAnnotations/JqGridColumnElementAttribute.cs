using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lib.AspNetCore.Mvc.JqGrid.DataAnnotations
{
    /// <summary>
    /// Base class which specifies the options for jqGrid editable or searchable column element
    /// </summary>
    public abstract class JqGridColumnElementAttribute : Attribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value indicating if the first item will automatically be focused when the menu is shown.
        /// </summary>
        public bool AutocompleteAutoFocus
        {
            get { return ElementOptions.AutocompleteAutoFocus; }

            set { ElementOptions.AutocompleteAutoFocus = value; }
        }

        /// <summary>
        /// Gets or sets the delay in milliseconds between when a keystroke occurs and when a search is performed.
        /// </summary>
        public int AutocompleteDelay
        {
            get { return ElementOptions.AutocompleteDelay; }

            set { ElementOptions.AutocompleteDelay = value; }
        }

        /// <summary>
        /// Gets or sets the minimum number of characters a user must type before a search is performed.
        /// </summary>
        public int AutocompleteMinLength
        {
            get { return ElementOptions.AutocompleteMinLength; }

            set { ElementOptions.AutocompleteMinLength = value; }
        }

        /// <summary>
        /// Gets or sets the function which will build the select element in case where the server response can not build it (requires DataUrl property to be set).
        /// </summary>
        public string BuildSelect
        {
            get { return ElementOptions.BuildSelect; }

            set { ElementOptions.BuildSelect = value; }
        }

        /// <summary>
        /// When overriden in delivered class, provides the list of events to apply to the element (jQuery UI widgets events can also be applied this way).
        /// </summary>
        public virtual ICollection<JqGridColumnDataEvent> DataEvents { get { return null; } }

        /// <summary>
        /// Gets or sets the function which will be called once when the element is created. This property is ignored in case of jQuery UI widgets.
        /// </summary>
        public string DataInit
        {
            get { return ElementOptions.DataInit; }

            set { ElementOptions.DataInit = value; }
        }

        /// <summary>
        /// Gets the name of the action method to get the AJAX data for the select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Autocomplete).
        /// </summary>
        public string DataAction { get; private set; }

        /// <summary>
        /// Gets the name of the controller to get the AJAX data for the select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Autocomplete).
        /// </summary>
        public string DataController { get; private set; }

        /// <summary>
        /// Gets the name of the route to be used to generate URL to get the AJAX data for the select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Autocomplete).
        /// </summary>
        public string DataRoute { get; private set; }

        /// <summary>
        /// Gets or sets the text to display after each date field.
        /// </summary>
        public string DatepickerAppendText
        {
            get { return ElementOptions.DatepickerAppendText; }

            set { ElementOptions.DatepickerAppendText = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating if the input field should be automatically resize to accommodate dates in the current format.
        /// </summary>
        public bool DatepickerAutoSize
        {
            get { return ElementOptions.DatepickerAutoSize; }

            set { ElementOptions.DatepickerAutoSize = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating if the month should be rendered as a dropdown instead of text.
        /// </summary>
        public bool DatepickerChangeMonth
        {
            get { return ElementOptions.DatepickerChangeMonth; }

            set { ElementOptions.DatepickerChangeMonth = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating if the year should be rendered as a dropdown instead of text.
        /// </summary>
        public bool DatepickerChangeYear
        {
            get { return ElementOptions.DatepickerChangeYear; }

            set { ElementOptions.DatepickerChangeYear = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating if the input field should constrained to characters allowed by the current format.
        /// </summary>
        public bool DatepickerConstrainInput
        {
            get { return ElementOptions.DatepickerConstrainInput; }

            set { ElementOptions.DatepickerConstrainInput = value; }
        }

        /// <summary>
        /// Gets or sets the format for parsed and displayed dates.
        /// </summary>
        /// <remarks>If the value for this property is not provided, but there is a JqGridColumnFormatterAttribute with JqGridColumnPredefinedFormatters.Date formatter the helper will try to provide the value based on JqGridColumnFormatterAttribute.OutputFormat.</remarks> 
        public string DatePickerDateFormat
        {
            get { return ElementOptions.DatePickerDateFormat; }

            set { ElementOptions.DatePickerDateFormat = value; }
        }

        /// <summary>
        /// Gets or sets the first day of the week: Sunday is 0, Monday is 1, etc.
        /// </summary>
        public int DatepickerFirstDay
        {
            get { return ElementOptions.DatepickerFirstDay; }

            set { ElementOptions.DatepickerFirstDay = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating if the current day link moves to the currently selected date instead of today.
        /// </summary>
        public bool DatepickerGotoCurrent
        {
            get { return ElementOptions.DatepickerGotoCurrent; }

            set { ElementOptions.DatepickerGotoCurrent = value; }
        }

        /// <summary>
        /// Gets or sets the maximum selectable date.
        /// </summary>
        /// <remarks>This string must be in the format defined by the DateFormat property, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.</remarks> 
        public string DatepickerMaxDate
        {
            get { return ElementOptions.DatepickerMaxDate; }

            set { ElementOptions.DatepickerMaxDate = value; }
        }

        /// <summary>
        /// Gets or sets the minimum selectable date.
        /// </summary>
        /// <remarks>This string must be in the format defined by the DateFormat property, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.</remarks> 
        public string DatepickerMinDate
        {
            get { return ElementOptions.DatepickerMinDate; }

            set { ElementOptions.DatepickerMinDate = value; }
        }

        /// <summary>
        /// Gets or sets the number of months to show at once.
        /// </summary>
        public int DatepickerNumberOfMonths
        {
            get { return ElementOptions.DatepickerNumberOfMonths; }

            set { ElementOptions.DatepickerNumberOfMonths = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating whether days in other months shown before or after the current month are selectable, this only applies if the ShowOtherMonths is set to true.
        /// </summary>
        public bool DatepickerSelectOtherMonths
        {
            get { return ElementOptions.DatepickerSelectOtherMonths; }

            set { ElementOptions.DatepickerSelectOtherMonths = value; }
        }

        /// <summary>
        /// Gets or sets the cutoff year for determining the century for a date.
        /// </summary>
        /// <remarks>This string must be a relative number of years from the current year, e.g., "+3" or "-5".</remarks> 
        public string DatepickerShortYearCutoff
        {
            get { return ElementOptions.DatepickerShortYearCutoff; }

            set { ElementOptions.DatepickerShortYearCutoff = value; }
        }

        /// <summary>
        /// Gets or sets the value which defines position to display the current month in, if the ShowOtherMonths is set to true.
        /// </summary>
        public int DatepickerShowCurrentAtPos
        {
            get { return ElementOptions.DatepickerShowCurrentAtPos; }

            set { ElementOptions.DatepickerShowCurrentAtPos = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to show the month after the year in the header.
        /// </summary>
        public bool DatepickerShowMonthAfterYear
        {
            get { return ElementOptions.DatepickerShowMonthAfterYear; }

            set { ElementOptions.DatepickerShowMonthAfterYear = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to display dates in other months (non-selectable) at the start or end of the current month, to make these days selectable set the SelectOtherMonths to true.
        /// </summary>
        public bool DatepickerShowOtherMonths
        {
            get { return ElementOptions.DatepickerShowOtherMonths; }

            set { ElementOptions.DatepickerShowOtherMonths = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to add column with the week of the year.
        /// </summary>
        public bool DatepickerShowWeek
        {
            get { return ElementOptions.DatepickerShowWeek; }

            set { ElementOptions.DatepickerShowWeek = value; }
        }

        /// <summary>
        /// Gets or sets the value which defines how many months to move when clicking the previous/next links.
        /// </summary>
        public int DatepickerStepMonths
        {
            get { return ElementOptions.DatepickerStepMonths; }

            set { ElementOptions.DatepickerStepMonths = value; }
        }

        /// <summary>
        /// Gets or sets the range of years displayed in the year dropdown.
        /// </summary>
        /// <remarks>This string must be either relative to today's year ("-nn:+nn"), relative to the currently selected year ("c-nn:c+nn"), absolute ("nnnn:nnnn"), or combinations of these formats ("nnnn:-nn"). Note that this option only affects what appears in the dropdown, to restrict which dates may be selected use the MinDate and/or MaxDate.</remarks> 
        public string DatepickerYearRange
        {
            get { return ElementOptions.DatepickerYearRange; }

            set { ElementOptions.DatepickerYearRange = value; }
        }

        /// <summary>
        /// Gets or sets the additional text to display after the year in the month headers.
        /// </summary>
        public string DatepickerYearSuffix
        {
            get { return ElementOptions.DatepickerYearSuffix; }

            set { ElementOptions.DatepickerYearSuffix = value; }
        }

        /// <summary>
        /// Gets or sets the default value in the search input element.
        /// </summary>
        public string DefaultValue
        {
            get { return ElementOptions.DefaultValue; }

            set { ElementOptions.DefaultValue = value; }
        }

        /// <summary>
        /// Gets or sets a dictionary where keys should be valid attributes for the element.
        /// </summary>
        public virtual IDictionary<string, object> HtmlAttributes { get { return null; } }

        /// <summary>
        /// Gets or sets the culture to use for parsing and formatting the value when Globalize plugin is included.
        /// </summary>
        public string SpinnerCulture
        {
            get { return ElementOptions.SpinnerCulture; }

            set { ElementOptions.SpinnerCulture = value; }
        }

        /// <summary>
        /// Gets or sets the icon class (form UI theme icons) for down button.
        /// </summary>
        public string SpinnerDownIcon
        {
            get { return ElementOptions.SpinnerDownIcon; }

            set { ElementOptions.SpinnerDownIcon = value; }
        }

        /// <summary>
        /// Gets or sets value controlling the number of steps taken when holding down a spin button.
        /// </summary>
        public bool SpinnerIncremental
        {
            get { return ElementOptions.SpinnerIncremental; }

            set { ElementOptions.SpinnerIncremental = value; }
        }

        /// <summary>
        /// Gets or sets maximum allowed value.
        /// </summary>
        public int? SpinnerMax
        {
            get { return ElementOptions.SpinnerMax; }

            set { ElementOptions.SpinnerMax = value; }
        }

        /// <summary>
        /// Gets or sets minimum allowed value.
        /// </summary>
        public int? SpinnerMin
        {
            get { return ElementOptions.SpinnerMin; }

            set { ElementOptions.SpinnerMin = value; }
        }

        /// <summary>
        /// Gets or sets the format of numbers passed to Globalize plugin if it is included.
        /// </summary>
        public string SpinnerNumberFormat
        {
            get { return ElementOptions.SpinnerNumberFormat; }

            set { ElementOptions.SpinnerNumberFormat = value; }
        }

        /// <summary>
        /// Gets or sets the number of steps to take when paging via the pageUp/pageDown JavaScript methods.
        /// </summary>
        public int SpinnerPage
        {
            get { return ElementOptions.SpinnerPage; }

            set { ElementOptions.SpinnerPage = value; }
        }

        /// <summary>
        /// Gets or sets the size of the step to take when spinning via buttons or via the stepUp/stepDown JavaScript methods.
        /// </summary>
        public int SpinnerStep
        {
            get { return ElementOptions.SpinnerStep; }

            set { ElementOptions.SpinnerStep = value; }
        }

        /// <summary>
        /// Gets or sets the icon class (form UI theme icons) for up button.
        /// </summary>
        public string SpinnerUpIcon
        {
            get { return ElementOptions.SpinnerUpIcon; }

            set { ElementOptions.SpinnerUpIcon = value; }
        }

        /// <summary>
        /// Gets or sets the set of value:label pairs for select element (takes precedence over ValueDictionary property).
        /// </summary>
        public string Value
        {
            get { return ElementOptions.Value; }

            set
            {
                DataAction = null;
                DataController = null;
                DataRoute = null;
                ElementOptions.Value = value;
                ElementOptions.ValueDictionary = null;
            }
        }

        /// <summary>
        /// Gets the options for jqGrid editable or searchable column element.
        /// </summary>
        protected abstract JqGridColumnElementOptions ElementOptions { get; }

        /// <summary>
        /// Gets or sets if the value should be validated with custom function.
        /// </summary>
        public bool CustomRule
        {
            get { return Rules.Custom; }

            set { Rules.Custom = value; }
        }

        /// <summary>
        /// Gets or sets the name of custom validation function.
        /// </summary>
        public string CustomRuleFunction
        {
            get { return Rules.CustomFunction; }

            set { Rules.CustomFunction = value; }
        }

        /// <summary>
        /// Gets or sets if the value should be valid date.
        /// </summary>
        public bool DateRule
        {
            get { return Rules.Date; }

            set { Rules.Date = value; }
        }

        /// <summary>
        /// Gets or sets if the value should be valid email.
        /// </summary>
        public bool EmailRule
        {
            get { return Rules.Email; }

            set { Rules.Email = value; }
        }

        /// <summary>
        /// Gets or sets if the value should be valid time (hh:mm format and optional am/pm at the end).
        /// </summary>
        public bool TimeRule
        {
            get { return Rules.Time; }

            set { Rules.Time = value; }
        }

        /// <summary>
        /// Gets or sets if the value should be valid url.
        /// </summary>
        public bool UrlRule
        {
            get { return Rules.Url; }

            set { Rules.Url = value; }
        }

        /// <summary>
        /// Gets the rules for jqGrid editable or searchable column
        /// </summary>
        public JqGridColumnRules Rules { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnElementAttribute class.
        /// </summary>
        protected JqGridColumnElementAttribute()
        {
            Rules = new JqGridColumnRules();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the action to get the AJAX data for the select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Autocomplete).
        /// </summary>
        /// <param name="action">The name of the action method.</param>
        /// <param name="controller">The name of the controller.</param>
        protected void SetDataAction(string action, string controller = null)
        {
            if (String.IsNullOrWhiteSpace(action))
            {
                throw new ArgumentNullException(nameof(action));
            }

            SetDataRouteOrAction(null, action, controller);
        }

        /// <summary>
        /// Sets the name of the route to be used to generate URL to get the AJAX data for the select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Autocomplete).
        /// </summary>
        /// <param name="route">The name of the route.</param>
        protected void SetDataRoute(string route)
        {
            if (String.IsNullOrWhiteSpace(route))
            {
                throw new ArgumentNullException(nameof(route));
            }

            SetDataRouteOrAction(route, null, null);
        }

        /// <summary>
        /// Sets data for select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select)
        /// </summary>
        /// <param name="valueProviderType">The type of class which contains a method which will provide data for select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes.Select). This class must have public parameterless constructor.</param>
        /// <param name="valueProviderMethodName">The name of method which will provide data for select element (if type is JqGridColumnSearchTypes/JqGridColumnEditTypes..Select). This method must return an object which implements IDictionary&lt;string, string&gt;.</param>
        protected void SetValueDictionary(Type valueProviderType, string valueProviderMethodName)
        {
            if (valueProviderType == null)
            {
                throw new ArgumentNullException(nameof(valueProviderType));
            }

            if (String.IsNullOrWhiteSpace(valueProviderMethodName))
            {
                throw new ArgumentNullException(nameof(valueProviderMethodName));
            }

            TypeInfo valueProviderTypeInfo = valueProviderType.GetTypeInfo();
            MethodInfo valueProviderMethodInfo = valueProviderTypeInfo.GetMethod(valueProviderMethodName);
            if (valueProviderMethodInfo == null)
            {
                throw new InvalidOperationException($"The method specified by {nameof(valueProviderType)} and {nameof(valueProviderMethodName)} could not be found.");
            }

            ConstructorInfo valueProviderConstructorInfo = valueProviderTypeInfo.GetConstructor(Type.EmptyTypes);
            if (valueProviderConstructorInfo == null)
            {
                throw new InvalidOperationException($"The type specified by {nameof(valueProviderType)} does not have parameterless constructor.");
            }

            object valueProvider = valueProviderConstructorInfo.Invoke(null);
            if (typeof(IDictionary<string, string>).GetTypeInfo().IsAssignableFrom(valueProviderMethodInfo.ReturnType))
            {
                DataRoute = null;
                DataAction = null;
                DataController = null;
                ElementOptions.Value = null;
                ElementOptions.ValueDictionary = (IDictionary<string, string>)valueProviderMethodInfo.Invoke(valueProvider, null);
            }
            else
            {
                throw new InvalidOperationException($"The method specified by {nameof(valueProviderType)} and {nameof(valueProviderMethodName)} does not return IDictionary<string, string>.");
            }
        }

        private void SetDataRouteOrAction(string route, string action, string controller)
        {
            DataRoute = route;
            DataAction = action;
            DataController = controller;
            ElementOptions.Value = null;
            ElementOptions.ValueDictionary = null;
        }
        #endregion
    }
}
