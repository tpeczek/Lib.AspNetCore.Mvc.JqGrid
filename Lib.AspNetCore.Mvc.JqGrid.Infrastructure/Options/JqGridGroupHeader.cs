using System;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options
{
    /// <summary>
    /// Represents options for jqGrid grouping header.
    /// </summary>
    public struct JqGridGroupHeader
    {
        #region Properties
        /// <summary>
        /// Gets the name from colModel from which the grouping header begin, including the same field.
        /// </summary>
        public string StartColumn { get; }

        /// <summary>
        /// Gets the number of columns which are included for this group.
        /// </summary>
        public int NumberOfColumns { get; }

        /// <summary>
        /// Gets the text for this group (can contain HTML tags).
        /// </summary>
        public string Title { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes new JqGridGroupHeader.
        /// <param name="startColumn">The name from colModel from which the grouping header begin, including the same field.</param>
        /// <param name="numberOfColumns">The number of columns which are included for this group.</param>
        /// <param name="title">The text for this group (can contain HTML tags).</param>
        /// </summary>
        public JqGridGroupHeader(string startColumn, int numberOfColumns, string title = null)
        {
            if (String.IsNullOrWhiteSpace(startColumn))
            {
                throw new ArgumentNullException(nameof(startColumn));
            }

            if (numberOfColumns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfColumns));
            }

            StartColumn = startColumn;
            NumberOfColumns = numberOfColumns;
            Title = title ?? String.Empty;
        }
        #endregion
    }
}
