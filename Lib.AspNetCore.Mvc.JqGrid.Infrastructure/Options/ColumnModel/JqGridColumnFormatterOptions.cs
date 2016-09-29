using System;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel
{
    /// <summary>
    /// Class which represents options for predefined formatter.
    /// </summary>
    public class JqGridColumnFormatterOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the decimal places.
        /// </summary>
        public int DecimalPlaces { get; set; }

        /// <summary>
        /// Gets or sets the decimal separator.
        /// </summary>
        public string DecimalSeparator { get; set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if checkbox is disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the currency prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the currency suffix.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets the date source format.
        /// </summary>
        public string SourceFormat { get; set; }

        /// <summary>
        /// Gets or sets the date output format.
        /// </summary>
        public string OutputFormat { get; set; }

        /// <summary>
        /// Gets or sets the link for showlink formatter.
        /// </summary>
        public string BaseLinkUrl { get; set; }

        /// <summary>
        /// Gets or sets the additional value which is added after the BaseLinkUrl.
        /// </summary>
        public string ShowAction { get; set; }

        /// <summary>
        /// Gets or sets the additional parameter which can be added after the IdName property.
        /// </summary>
        public string AddParam { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the first parameter that is added after the ShowAction.
        /// </summary>
        public string IdName { get; set; }

        /// <summary>
        /// Gets or sets the thousands separator.
        /// </summary>
        public string ThousandsSeparator { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if edit button is enabled for actions formatter.
        /// </summary>
        public bool EditButton { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if delete button is enabled for actions formatter.
        /// </summary>
        public bool DeleteButton { get; set; }

        /// <summary>
        /// Gets or sets value indicating if form editing should be used instead of inline editing for actions formatter.
        /// </summary>
        public bool UseFormEditing { get; set; }

        /// <summary>
        /// Gets or sets options for inline editing (RestoreAfterError and MethodType options are ignored in this context) for actions formatter.
        /// </summary>
        public JqGridInlineNavigatorActionOptions InlineEditingOptions { get; set; }

        /// <summary>
        /// Gets or sets options for form editing for actions formatter.
        /// </summary>
        public JqGridNavigatorEditActionOptions FormEditingOptions { get; set; }

        /// <summary>
        /// Gets or sets options for deleting for actions formatter.
        /// </summary>
        public JqGridNavigatorDeleteActionOptions DeleteOptions { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes new instance of JqGridColumnFormatterOptions class.
        /// </summary>
        public JqGridColumnFormatterOptions()
        {
            DecimalPlaces = 0;
            DecimalSeparator = String.Empty;
            DefaultValue = String.Empty;
            Disabled = JqGridOptionsDefaults.Formatter.Disabled;
            ThousandsSeparator = String.Empty;
            Prefix = String.Empty;
            Suffix = String.Empty;
            SourceFormat = JqGridOptionsDefaults.Formatter.SourceFormat;
            OutputFormat = JqGridOptionsDefaults.Formatter.OutputFormat;
            BaseLinkUrl = String.Empty;
            ShowAction = String.Empty;
            AddParam = String.Empty;
            Target = String.Empty;
            IdName = JqGridOptionsDefaults.Formatter.IdName;
            EditButton = JqGridOptionsDefaults.Formatter.EditButton;
            DeleteButton = JqGridOptionsDefaults.Formatter.DeleteButton;
            UseFormEditing = JqGridOptionsDefaults.Formatter.UseFormEditing;
            InlineEditingOptions = null;
            FormEditingOptions = null;
            DeleteOptions = null;
        }

        /// <summary>
        /// Initializes new instance of JqGridColumnFormatterOptions class.
        /// </summary>
        /// <param name="formatter">Predefined formatter</param>
        public JqGridColumnFormatterOptions(string formatter)
            : this()
        {
            switch (formatter)
            {
                case JqGridPredefinedFormatters.Integer:
                    DefaultValue = JqGridOptionsDefaults.Formatter.IntegerDefaultValue;
                    ThousandsSeparator = JqGridOptionsDefaults.Formatter.ThousandsSeparator;
                    break;
                case JqGridPredefinedFormatters.Number:
                    DecimalPlaces = JqGridOptionsDefaults.Formatter.DecimalPlaces;
                    DecimalSeparator = JqGridOptionsDefaults.Formatter.DecimalSeparator;
                    DefaultValue = JqGridOptionsDefaults.Formatter.NumberDefaultValue;
                    ThousandsSeparator = JqGridOptionsDefaults.Formatter.ThousandsSeparator;
                    break;
                case JqGridPredefinedFormatters.Currency:
                    DecimalPlaces = JqGridOptionsDefaults.Formatter.DecimalPlaces;
                    DecimalSeparator = JqGridOptionsDefaults.Formatter.DecimalSeparator;
                    DefaultValue = JqGridOptionsDefaults.Formatter.CurrencyDefaultValue;
                    ThousandsSeparator = JqGridOptionsDefaults.Formatter.ThousandsSeparator;
                    break;
            }
        }
        #endregion

        #region Methods
        internal bool IsDefault(string formatter)
        {
            switch (formatter)
            {
                case JqGridPredefinedFormatters.Integer:
                    return ((DefaultValue == JqGridOptionsDefaults.Formatter.IntegerDefaultValue) && (ThousandsSeparator == JqGridOptionsDefaults.Formatter.ThousandsSeparator));
                case JqGridPredefinedFormatters.Number:
                    return ((DecimalPlaces == JqGridOptionsDefaults.Formatter.DecimalPlaces) && (DecimalSeparator == JqGridOptionsDefaults.Formatter.DecimalSeparator) && (DefaultValue == JqGridOptionsDefaults.Formatter.NumberDefaultValue) && (ThousandsSeparator == JqGridOptionsDefaults.Formatter.ThousandsSeparator));
                case JqGridPredefinedFormatters.Currency:
                    return ((DecimalPlaces == JqGridOptionsDefaults.Formatter.DecimalPlaces) && (DecimalSeparator == JqGridOptionsDefaults.Formatter.DecimalSeparator) && (DefaultValue == JqGridOptionsDefaults.Formatter.CurrencyDefaultValue) && String.IsNullOrWhiteSpace(Prefix) && String.IsNullOrWhiteSpace(Suffix) && (ThousandsSeparator == JqGridOptionsDefaults.Formatter.ThousandsSeparator));
                case JqGridPredefinedFormatters.Date:
                    return ((SourceFormat == JqGridOptionsDefaults.Formatter.SourceFormat) && (OutputFormat == JqGridOptionsDefaults.Formatter.OutputFormat));
                case JqGridPredefinedFormatters.Link:
                    return String.IsNullOrWhiteSpace(Target);
                case JqGridPredefinedFormatters.ShowLink:
                    return (String.IsNullOrWhiteSpace(BaseLinkUrl) && String.IsNullOrWhiteSpace(ShowAction) && String.IsNullOrWhiteSpace(AddParam) && String.IsNullOrWhiteSpace(Target) && (IdName == JqGridOptionsDefaults.Formatter.IdName));
                case JqGridPredefinedFormatters.CheckBox:
                    return (Disabled == JqGridOptionsDefaults.Formatter.Disabled);
                case JqGridPredefinedFormatters.Actions:
                    return ((EditButton == JqGridOptionsDefaults.Formatter.EditButton) && (DeleteButton == JqGridOptionsDefaults.Formatter.DeleteButton) && (UseFormEditing == JqGridOptionsDefaults.Formatter.UseFormEditing) && (InlineEditingOptions == null) && (FormEditingOptions == null) && (DeleteOptions == null));
                default:
                    return true;
            }
        }
        #endregion
    }
}
