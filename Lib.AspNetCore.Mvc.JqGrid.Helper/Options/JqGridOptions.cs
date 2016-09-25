using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options.ColumnModel;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.Options
{
    /// <summary>
    /// jqGrid options
    /// </summary>
    public class JqGridOptions
    {
        #region Properties
        /// <summary>
        /// Gets the grid identifier which will be used for table (id='{0}'), pager div (id='{0}Pager') and in JavaScript.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the list of columns parameters descriptions.
        /// </summary>
        public IList<JqGridColumnModel> ColumnsModels { get; } = new List<JqGridColumnModel>();

        /// <summary>
        /// Gets the list of columns names.
        /// </summary>
        public IList<string> ColumnsNames { get; } = new List<string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridOptions class.
        /// </summary>
        /// <param name="id">Identifier, which will be used for table (id='{0}'), pager div (id='{0}Pager'), filter grid div (id='{0}Search') and in JavaScript.</param>
        public JqGridOptions(string id)
        {
            Id = id;
        }
        #endregion

        #region Methods
        internal virtual void EnsureColumnsMetadata(IModelMetadataProvider metadataProvider)
        { }
        #endregion
    }

    /// <summary>
    /// jqGrid options
    /// </summary>
    /// <typeparam name="TModel">Type of model for grid</typeparam>
    public sealed class JqGridOptions<TModel> : JqGridOptions
    {
        #region Fields
        private bool _columnsMetadataEnsured = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridOptions class.
        /// </summary>
        /// <param name="id">Identifier, which will be used for table (id='{0}'), pager div (id='{0}Pager'), filter grid div (id='{0}Search') and in JavaScript.</param>
        public JqGridOptions(string id)
            : base(id)
        { }
        #endregion

        #region Methods
        internal override void EnsureColumnsMetadata(IModelMetadataProvider metadataProvider)
        {
            if (!_columnsMetadataEnsured)
            {
                foreach (ModelMetadata columnMetadata in metadataProvider.GetMetadataForProperties(typeof(TModel)))
                {
                    if (columnMetadata.IsValidForColumn())
                    {
                        ColumnsModels.Add(new JqGridColumnModel(columnMetadata));
                        ColumnsNames.Add(columnMetadata.GetDisplayName());
                    }
                }

                _columnsMetadataEnsured = true;
            }
        }
        #endregion
    }
}
