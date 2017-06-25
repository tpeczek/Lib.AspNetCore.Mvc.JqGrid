using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator
{
    /// <summary>
    /// Class which represents options for jqGrid Navigator button.
    /// </summary>
    public class JqGridNavigatorButtonOptions : JqGridNavigatorCustomElementOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the caption for the button.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the icon (from UI theme images) for the button. If this property is set to "none" only text will appear.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the id for TD element holding the button (optional).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the function for button click action.
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// Gets or sets the tooltip for the button.
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// Gets or sets the value which determines the cursor when user mouseover the button.
        /// </summary>
        public string Cursor { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridNavigatorButtonOptions class.
        /// </summary>
        public JqGridNavigatorButtonOptions()
            : base()
        {
            Caption = JqGridOptionsDefaults.Navigator.ButtonCaption;
            Icon = JqGridOptionsDefaults.Navigator.ButtonIcon;
            Id = null;
            OnClick = null;
            ToolTip = null;
            Cursor = JqGridOptionsDefaults.Navigator.ButtonCursor;
        }
        #endregion
    }
}
