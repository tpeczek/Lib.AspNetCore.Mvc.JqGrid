using System;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options.ColumnModel;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.Options
{
    /// <summary>
    /// jqGrid options
    /// </summary>
    /// <typeparam name="TModel">Type of model for grid</typeparam>
    public sealed class JqGridOptions<TModel> : JqGridOptions, IJqGridStronglyTypedOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the actions column.
        /// </summary>
        public JqGridActionsColumnOptions ActionsColumn { get; set; }

        /// <summary>
        /// Gets the type of model.
        /// </summary>
        public Type ModelType => typeof(TModel);
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
    }
}
