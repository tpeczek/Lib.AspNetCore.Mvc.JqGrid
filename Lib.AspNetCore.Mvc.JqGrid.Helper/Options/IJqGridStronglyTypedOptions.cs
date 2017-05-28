using Lib.AspNetCore.Mvc.JqGrid.Helper.Options.ColumnModel;
using System;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.Options
{
    /// <summary>
    /// Interface which represents additional contract for strongly typed jqGrid options.
    /// </summary>
    public interface IJqGridStronglyTypedOptions
    {
        /// <summary>
        /// Gets or sets the actions column.
        /// </summary>
        JqGridActionsColumnOptions ActionsColumn { get; set; }

        /// <summary>
        /// Gets the type of model.
        /// </summary>
        Type ModelType { get; }
    }
}
