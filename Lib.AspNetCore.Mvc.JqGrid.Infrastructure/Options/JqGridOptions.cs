using System.Collections.Generic;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using System;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options
{
    /// <summary>
    /// jqGrid options
    /// </summary>
    public class JqGridOptions
    {
        #region Fields
        private readonly IList<JqGridColumnModel> _columnsModels = new List<JqGridColumnModel>();
        private readonly IList<string> _columnsNames = new List<string>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the grid identifier which will be used for table (id='{0}'), pager div (id='{0}Pager') and in JavaScript.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the list of columns parameters descriptions.
        /// </summary>
        public IReadOnlyList<JqGridColumnModel> ColumnsModels { get { return (IReadOnlyList<JqGridColumnModel>)_columnsModels; } }

        /// <summary>
        /// Gets the list of columns names.
        /// </summary>
        public IReadOnlyList<string> ColumnsNames { get { return (IReadOnlyList<string>)_columnsNames; } }
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
        /// <summary>
        /// Adds column to options.
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <param name="columnModel">The column model.</param>
        /// <exception cref="System.ArgumentNullException">
        /// The column name or model haven't been provided. 
        /// </exception>
        public void AddColumn(string columnName, JqGridColumnModel columnModel)
        {
            if (String.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException(nameof(columnName));
            }

            if (columnModel == null)
            {
                throw new ArgumentNullException(nameof(columnModel));
            }

            _columnsModels.Add(columnModel);
            _columnsNames.Add(columnName);
        }
        #endregion
    }
}
