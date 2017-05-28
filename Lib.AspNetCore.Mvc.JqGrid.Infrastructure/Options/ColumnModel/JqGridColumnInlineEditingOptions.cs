using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel
{
    /// <summary>
    /// Class which represent options for inline editing from column level.
    /// </summary>
    public class JqGridColumnInlineEditingOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets value indicating if keys interaction is enabled (like saving a record with pressing a Enter key).
        /// </summary>
        public bool Keys { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if edit button is enabled.
        /// </summary>
        public bool EditButton { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if delete button is enabled.
        /// </summary>
        public bool DeleteButton { get; set; }

        /// <summary>
        /// Gets or sets value indicating if form editing should be used instead of inline editing.
        /// </summary>
        public bool UseFormEditing { get; set; }

        /// <summary>
        /// Gets or sets options for inline editing (RestoreAfterError and MethodType options are ignored in this context).
        /// </summary>
        public JqGridInlineNavigatorActionOptions InlineEditingOptions { get; set; }

        /// <summary>
        /// Gets or sets options for form editing.
        /// </summary>
        public JqGridNavigatorEditActionOptions FormEditingOptions { get; set; }

        /// <summary>
        /// Gets or sets options for deleting.
        /// </summary>
        public JqGridNavigatorDeleteActionOptions DeleteOptions { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes new instance of JqGridColumnInlineEditingOptions class.
        /// </summary>
        public JqGridColumnInlineEditingOptions()
        {
            Keys = JqGridOptionsDefaults.ColumnModel.Formatter.Keys;
            EditButton = JqGridOptionsDefaults.ColumnModel.Formatter.EditButton;
            DeleteButton = JqGridOptionsDefaults.ColumnModel.Formatter.DeleteButton;
            UseFormEditing = JqGridOptionsDefaults.ColumnModel.Formatter.UseFormEditing;
            InlineEditingOptions = null;
            FormEditingOptions = null;
            DeleteOptions = null;
        }
        #endregion
    }
}
