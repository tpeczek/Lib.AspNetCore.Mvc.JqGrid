using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator
{
    /// <summary>
    /// Class which represents options for jqGrid Navigator separator.
    /// </summary>
    public class JqGridNavigatorSeparatorOptions : JqGridNavigatorCustomElementOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the class for the separator.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets the content for the separator.
        /// </summary>
        public string Content { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridNavigatorSeparatorOptions class.
        /// </summary>
        public JqGridNavigatorSeparatorOptions()
            : base()
        {
            Class = JqGridOptionsDefaults.Navigator.SeparatorClass;
            Content = null;
        }
        #endregion
    }
}
