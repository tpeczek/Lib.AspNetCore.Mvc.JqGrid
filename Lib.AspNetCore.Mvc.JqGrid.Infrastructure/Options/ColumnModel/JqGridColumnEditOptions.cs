using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel
{
    /// <summary>
    /// Class which represents options for jqGrid editable column
    /// </summary>
    public class JqGridColumnEditOptions : JqGridColumnElementOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of function which is used to create custom edit element
        /// </summary>
        public string CustomElementFunction { get; set; }

        /// <summary>
        /// Gets or sets the name of function which should return the value from the custom element after the editing.
        /// </summary>
        public string CustomValueFunction { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if null value should be send to server if the field is empty.
        /// </summary>
        public bool NullIfEmpty { get; set; }

        /// <summary>
        /// Gets or sets the additional data which will be added to the AJAX request to get the data for the select element (if EditType is JqGridColumnEditTypes.Select).
        /// </summary>
        public object PostData { get; set; }

        /// <summary>
        /// Gets or sets the JavaScript which will dynamically generate the additional data which will be added to the AJAX request to get the data for the select element (if EditType is JqGridColumnEditTypes.Select). This property takes precedence over PostData.
        /// </summary>
        public string PostDataScript { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnEditOptions class.
        /// </summary>
        public JqGridColumnEditOptions()
        {
            CustomElementFunction = null;
            CustomValueFunction = null;
            NullIfEmpty = JqGridOptionsDefaults.ColumnModel.Editing.NullIfEmpty;
            PostData = null;
            PostDataScript = null;
        }
        #endregion
    }
}
