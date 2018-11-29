namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums
{
    /// <summary>
    /// jgGrid icon sets
    /// </summary>
    public enum JqGridIconSets
    {
        /// <summary>
        /// jQuery UI icon set
        /// </summary>
        JQueryUI,
        /// <summary>
        /// Font Awesome icon set
        /// </summary>
        /// <remarks>This icon set is supported only for <see cref="JqGridCompatibilityModes.FreeJqGrid"/> and <see cref="JqGridCompatibilityModes.GuriddoJqGrid"/>.</remarks>
        FontAwesome,
        /// <summary>
        /// Font Awesome 5 icon set
        /// </summary>
        /// <remarks>This icon set is supported only for <see cref="JqGridCompatibilityModes.FreeJqGrid"/>.</remarks>
        FontAwesome5,
        /// <summary>
        /// Octicons icon set
        /// </summary>
        /// <remarks>This icon set is supported only for <see cref="JqGridCompatibilityModes.GuriddoJqGrid"/>.</remarks>
        Octicons,
        /// <summary>
        /// Iconic icon set
        /// </summary>
        /// <remarks>This icon set is supported only for <see cref="JqGridCompatibilityModes.GuriddoJqGrid"/>.</remarks>
        Iconic,
        /// <summary>
        /// Glyph icon set
        /// </summary>
        /// <remarks>This icon set is supported only for <see cref="JqGridCompatibilityModes.FreeJqGrid"/>.</remarks>
        Glyph
    }
}
