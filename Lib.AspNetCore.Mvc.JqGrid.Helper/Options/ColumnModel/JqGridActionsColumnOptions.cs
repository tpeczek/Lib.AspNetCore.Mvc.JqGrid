using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.Options.ColumnModel
{
    /// <summary>
    /// Class which represent options for actions column.
    /// </summary>
    public class JqGridActionsColumnOptions : JqGridColumnInlineEditingOptions
    {
        #region Fields
        private int _position;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the unique name for the column.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the position of the column (default 0).
        /// </summary>
        public int Position
        {
            get { return _position; }

            set { _position = (value > 0) ? value : 0; }
        }

        /// <summary>
        /// Gets or sets the initial width in pixels of the column (default 60).
        /// </summary>
        public int Width { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes new instance of JqGridActionsColumnOptions class.
        /// </summary>
        public JqGridActionsColumnOptions(string name)
            : base()
        {
            Name = name;

            Position = 0;
            Width = 60;

            InlineEditingOptions = new JqGridInlineNavigatorActionOptions();
            DeleteOptions = new JqGridNavigatorDeleteActionOptions();
        }
        #endregion
    }
}
