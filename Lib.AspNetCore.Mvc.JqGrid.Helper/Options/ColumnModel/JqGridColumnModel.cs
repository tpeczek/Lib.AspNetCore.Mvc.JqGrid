using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.Options.ColumnModel
{
    /// <summary>
    /// jqGrid column parameters description.
    /// </summary>
    public class JqGridColumnModel
    {
        #region Properties
        /// <summary>
        /// Gets the unique name for the column.
        /// </summary>
        public string Name { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnModel class.
        /// </summary>
        /// <param name="name">The unique name for the column.</param>
        public JqGridColumnModel(string name)
        {
            Name = name;
        }

        internal JqGridColumnModel(ModelMetadata propertyMetadata)
            : this(propertyMetadata.PropertyName)
        { }
        #endregion
    }
}
