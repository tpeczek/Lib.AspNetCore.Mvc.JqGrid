using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options
{
    /// <summary>
    /// Abstract class which represents options for jqGrid filter toolbar and grid.
    /// </summary>
    public abstract class JqGridFilterOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the function for event which is raised after clearing entered values.
        /// </summary>
        public string AfterClear { get; set; }

        /// <summary>
        /// Gets or sets the name of the function for event which is raised after searching.
        /// </summary>
        public string AfterSearch { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if searching is performed automatically.
        /// </summary>
        public bool AutoSearch { get; set; }

        /// <summary>
        /// Gets or sets the name of the function for event which is raised before clearing entered values.
        /// </summary>
        public string BeforeClear { get; set; }

        /// <summary>
        /// Gets or sets the name of the function for event which is raised before searching.
        /// </summary>
        public string BeforeSearch { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridFilterOptions class.
        /// </summary>
        protected JqGridFilterOptions()
        {
            AfterClear = null;
            AfterSearch = null;
            AutoSearch = JqGridOptionsDefaults.Filter.AutoSearch;
            BeforeClear = null;
            BeforeSearch = null;
        }
        #endregion
    }
}
