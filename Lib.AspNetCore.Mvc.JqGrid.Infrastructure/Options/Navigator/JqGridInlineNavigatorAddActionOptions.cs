using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator
{
    /// <summary>
    /// Class which represents options for jqGrid Inline Navigator add action.
    /// </summary>
    public class JqGridInlineNavigatorAddActionOptions : JqGridInlineNavigatorActionOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the id for the new row
        /// </summary>
        public string RowId { get; set; }

        /// <summary>
        /// Gets or sets the initial values for the new row.
        /// </summary>
        public object InitData { get; set; }

        /// <summary>
        /// Gets or sets the new row position.
        /// </summary>
        public JqGridNewRowPositions NewRowPosition { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if the DefaultValue from ColumnsModel should be used.
        /// </summary>
        public bool UseDefaultValues { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if formatters should be used.
        /// </summary>
        public bool UseFormatter { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridInlineNavigatorAddActionOptions class.
        /// </summary>
        public JqGridInlineNavigatorAddActionOptions()
        {
            RowId = JqGridOptionsDefaults.Navigator.NewRowId;
            InitData = null;
            NewRowPosition = JqGridOptionsDefaults.Navigator.NewRowPosition;
            UseDefaultValues = JqGridOptionsDefaults.Navigator.UseDefaultValues;
            UseFormatter = JqGridOptionsDefaults.Navigator.UseFormatter;
        }
        #endregion
    }
}
