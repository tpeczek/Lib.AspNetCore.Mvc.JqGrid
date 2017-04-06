namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums
{
    /// <summary>
    /// jqGrid cell editing submit modes
    /// </summary>
    public enum JqGridCellEditingSubmitModes
    {
        /// <summary>
        /// The change is immediately saved to the server.
        /// </summary>
        Remote,
        /// <summary>
        /// No ajax request is made and the content of the changed cell can be obtained via the JavaScript jqGrid method getChangedCells 
        /// </summary>
        ClientArray
    }
}
