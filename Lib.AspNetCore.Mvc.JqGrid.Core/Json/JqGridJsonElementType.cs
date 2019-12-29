namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json
{
    /// <summary>
    /// Specifies the type of <see cref="IJqGridJsonElement"/>.
    /// </summary>
    public enum JqGridJsonElementType
    {
        /// <summary>
        /// The type of element is unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The element represents a JSON string.
        /// </summary>
        String = 1,
        /// <summary>
        /// The element represents a JSON array.
        /// </summary>
        Array = 2
    }
}
