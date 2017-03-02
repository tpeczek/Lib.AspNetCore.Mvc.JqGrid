using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator
{
    /// <summary>
    /// Class which represents base options for jqGrid navigators.
    /// </summary>
    public abstract class JqGridNavigatorOptionsBase
    {
        #region Properties
        /// <summary>
        /// Gets or set the value which defines if add action is enabled (default true).
        /// </summary>
        public bool Add { get; set; }

        /// <summary>
        /// Gets or sets the icon (form UI theme images) for add action.
        /// </summary>
        public string AddIcon { get; set; }

        /// <summary>
        /// Gets or sets the text for add action.
        /// </summary>
        public string AddText { get; set; }

        /// <summary>
        /// Gets or sets the tooltip for add action.
        /// </summary>
        public string AddToolTip { get; set; }

        /// <summary>
        /// Gets or set the value which defines if edit action is enabled (default true).
        /// </summary>
        public bool Edit { get; set; }

        /// <summary>
        /// Gets or sets the icon (form UI theme images) for edit action.
        /// </summary>
        public string EditIcon { get; set; }

        /// <summary>
        /// Gets or sets the text for edit action.
        /// </summary>
        public string EditText { get; set; }

        /// <summary>
        /// Gets or sets the tooltip for edit action.
        /// </summary>
        public string EditToolTip { get; set; }

        /// <summary>
        /// Gets or sets the position of the Navigator buttons in the pager.
        /// </summary>
        public JqGridAlignments Position { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridNavigatorOptionsBase class.
        /// </summary>
        public JqGridNavigatorOptionsBase()
        {
            Add = JqGridOptionsDefaults.Navigator.Add;
            AddIcon = JqGridOptionsDefaults.Navigator.AddIcon;
            AddText = null;
            AddToolTip = JqGridOptionsDefaults.Navigator.AddToolTip;
            Edit = JqGridOptionsDefaults.Navigator.Edit;
            EditIcon = JqGridOptionsDefaults.Navigator.EditIcon;
            EditText = null;
            EditToolTip = JqGridOptionsDefaults.Navigator.EditToolTip;
            Position = JqGridOptionsDefaults.Navigator.Position;
        }
        #endregion
    }
}
