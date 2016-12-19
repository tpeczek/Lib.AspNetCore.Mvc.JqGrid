using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel
{
    /// <summary>
    /// Class which represents rules for jqGrid editable or searchable column
    /// </summary>
    public class JqGridColumnRules
    {
        #region Properties
        /// <summary>
        /// Gets or sets if the value should be validated with custom function.
        /// </summary>
        public bool Custom { get; set; }

        /// <summary>
        /// Gets or sets the name of custom validation function
        /// </summary>
        public string CustomFunction { get; set; }

        /// <summary>
        /// Gets or sets if the value should be valid date based on DateFormat property (if not set than ISO date is used).
        /// </summary>
        public bool Date { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if hidden column can be edited in form editing.
        /// </summary>
        public bool EditHidden { get; set; }

        /// <summary>
        /// Gets or sets if the value should be valid email
        /// </summary>
        public bool Email { get; set; }

        /// <summary>
        /// Gets or sets if the value should be valid integer.
        /// </summary>
        public bool Integer { get; set; }

        /// <summary>
        /// Gets or set the maximum value.
        /// </summary>
        public double? MaxValue { get; set; }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public double? MinValue { get; set; }

        /// <summary>
        /// Gets or sets if the value should be valid number
        /// </summary>
        public bool Number { get; set; }

        /// <summary>
        /// Gets or sets if the value is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets if the value should be valid time (hh:mm format and optional am/pm at the end).
        /// </summary>
        public bool Time { get; set; }

        /// <summary>
        /// Gets or sets if the value should be valid url.
        /// </summary>
        public bool Url { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnRules class.
        /// </summary>
        public JqGridColumnRules()
        {
            Custom = JqGridOptionsDefaults.ColumnModel.Rules.Custom;
            CustomFunction = null;
            Date = JqGridOptionsDefaults.ColumnModel.Rules.Date;
            EditHidden = JqGridOptionsDefaults.ColumnModel.Rules.EditHidden;
            Email = JqGridOptionsDefaults.ColumnModel.Rules.Email;
            Integer = JqGridOptionsDefaults.ColumnModel.Rules.Integer;
            MaxValue = null;
            MinValue = null;
            Number = JqGridOptionsDefaults.ColumnModel.Rules.Number;
            Required = JqGridOptionsDefaults.ColumnModel.Rules.Required;
            Time = JqGridOptionsDefaults.ColumnModel.Rules.Time;
            Url = JqGridOptionsDefaults.ColumnModel.Rules.Url;
        }
        #endregion
    }
}
