using System;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel
{
    /// <summary>
    /// jqGrid column parameters description.
    /// </summary>
    public class JqGridColumnModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets the alignment of the cell in the grid body layer.
        /// </summary>
        public JqGridAlignments Alignment { get; set; }

        /// <summary>
        /// Gets or sets the function which can add attributes to the cell during the creation of the data (dynamically).
        /// </summary>
        public string CellAttributes { get; set; }

        /// <summary>
        /// Gets or sets additional CSS classes for the column (separated by space).
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        /// Gets or sets the expected date format for this column in case of date validation (default ISO date). 
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets or set the value defining if this column can be edited.
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// Gets or sets the options for editable column.
        /// </summary>
        public JqGridColumnEditOptions EditOptions { get; set; }

        /// <summary>
        /// Gets or sets the rules for editable column.
        /// </summary>
        public JqGridColumnRules EditRules { get; set; }

        /// <summary>
        /// Gets or sets the type for editable column.
        /// </summary>
        public JqGridColumnEditTypes EditType { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if internal recalculation of the width of the column is disabled (default false).
        /// </summary>
        public bool Fixed { get; set; }

        /// <summary>
        /// Gets or sets the predefined formatter type ('' delimited string) or custom JavaScript formatting function name.
        /// </summary>
        public string Formatter { get; set; }

        /// <summary>
        /// Gets or sets the options for predefined formatter (every predefined formatter uses only a subset of all options), which are overwriting the defaults from the language file.
        /// </summary>
        public JqGridColumnFormatterOptions FormatterOptions { get; set; }

        /// <summary>
        /// Get or sets additional, used in form editing, options for editable column.
        /// </summary>
        public JqGridColumnFormOptions FormOptions { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if column shouldn't scroll out of view when user is moving horizontally across the grid.
        /// </summary>
        public bool Frozen { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if column will appear in the modal dialog where users can choose which columns to show or hide.
        /// </summary>
        public bool HideInDialog { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if this column is hidden at initialization.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets the index name for sorting and searching (default String.Empty)
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Gets or sets the sorting order for first column sorting.
        /// </summary>
        public JqGridSortingOrders InitialSortingOrder { get; set; }

        /// <summary>
        /// Gets the unique name for the column.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the value which defines if column can be resized (default true).
        /// </summary>
        public bool Resizable { get; set; }

        /// <summary>
        /// Gets or sets the value defining if this column can be searched.
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// Gets or sets the options for searchable column.
        /// </summary>
        public JqGridColumnSearchOptions SearchOptions { get; set; }

        /// <summary>
        /// Gets or sets the additional conditions for validating user input in search field.
        /// </summary>
        public JqGridColumnRules SearchRules { get; set; }

        /// <summary>
        /// Gets or sets the type of the search field for the column.
        /// </summary>
        public JqGridColumnSearchTypes SearchType { get; set; }

        /// <summary>
        /// Gets or sets the value defining if this column can be sorted.
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        /// Gets or sets the custom sorting function when the SortType is set to JqGridColumnSortTypes.Function.
        /// </summary>
        public string SortFunction { get; set; }

        /// <summary>
        /// Gets or sets the type of the column for appropriate sorting when datatype is local.
        /// </summary>
        public JqGridSortTypes SortType { get; set; }

        /// <summary>
        /// Gets or sets the grouping summary type.
        /// </summary>
        public JqGridColumnSummaryTypes? SummaryType { get; set; }

        /// <summary>
        /// Gets or sets the grouping summary template.
        /// </summary>
        public string SummaryTemplate { get; set; }

        /// <summary>
        /// Gets or sets the grouping summary function for custom type.
        /// </summary>
        public string SummaryFunction { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if the title should be displayed in the column when user hovers a cell with the mouse.
        /// </summary>
        public bool Title { get; set; }

        /// <summary>
        /// Gets or sets the custom function to "unformat" a value of the cell when used in editing or client-side sorting
        /// </summary>
        public string UnFormatter { get; set; }

        /// <summary>
        /// Gets or sets the initial width in pixels of the column (default 150).
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the value which defines if the column should appear in view form.
        /// </summary>
        public bool Viewable { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnModel class.
        /// </summary>
        /// <param name="name">The unique name for the column.</param>
        public JqGridColumnModel(string name)
        {
            Name = name;

            Alignment = JqGridOptionsDefaults.ColumnModel.Alignment;
            CellAttributes = null;
            Classes = null;
            DateFormat = JqGridOptionsDefaults.ColumnModel.DateFormat;
            Editable = JqGridOptionsDefaults.ColumnModel.Editable;
            EditOptions = null;
            EditRules = null;
            EditType = JqGridOptionsDefaults.ColumnModel.EditType;
            Fixed = JqGridOptionsDefaults.ColumnModel.Fixed;
            Formatter = String.Empty;
            FormatterOptions = null;
            FormOptions = null;
            Frozen = JqGridOptionsDefaults.ColumnModel.Frozen;
            HideInDialog = JqGridOptionsDefaults.ColumnModel.HideInDialog;
            Hidden = JqGridOptionsDefaults.ColumnModel.Hidden;
            Index = String.Empty;
            InitialSortingOrder = JqGridOptionsDefaults.ColumnModel.Sorting.InitialOrder;
            Resizable = JqGridOptionsDefaults.ColumnModel.Resizable;
            Searchable = JqGridOptionsDefaults.ColumnModel.Searchable;
            SearchOptions = null;
            SearchRules = null;
            SearchType = JqGridOptionsDefaults.ColumnModel.SearchType;
            Sortable = JqGridOptionsDefaults.ColumnModel.Sorting.Sortable;
            SortFunction = String.Empty;
            SortType = JqGridOptionsDefaults.ColumnModel.Sorting.Type;
            SummaryType = null;
            SummaryTemplate = JqGridOptionsDefaults.ColumnModel.SummaryTemplate;
            SummaryFunction = null;
            Title = JqGridOptionsDefaults.ColumnModel.Title;
            UnFormatter = String.Empty;
            Width = JqGridOptionsDefaults.ColumnModel.Width;
            Viewable = JqGridOptionsDefaults.ColumnModel.Viewable;
        }
        #endregion
    }
}
