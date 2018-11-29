namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums
{
    /// <summary>
    /// Defines available types of search fields for jqGrid
    /// </summary>
    public enum JqGridColumnSearchTypes
    {
        /// <summary>
        /// Input element of type text.
        /// </summary>
        Text,
        /// <summary>
        /// Input element of type date.
        /// </summary>
        Date,
        /// <summary>
        /// Select element
        /// </summary>
        Select,
        /// <summary>
        /// jQuery UI Autocomplete widget
        /// </summary>
        JQueryUIAutocomplete,
        /// <summary>
        /// jQuery UI Datepicker widget
        /// </summary>
        JQueryUIDatepicker,
        /// <summary>
        /// jQuery UI Spinner widget
        /// </summary>
        JQueryUISpinner
    }
}
