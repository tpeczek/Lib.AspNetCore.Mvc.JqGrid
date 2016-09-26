using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Lib.AspNetCore.Mvc.JqGrid.DataAnnotations;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.Options.ColumnModel
{
    /// <summary>
    /// jqGrid column parameters description.
    /// </summary>
    public class JqGridColumnModel
    {
        #region Properties
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
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnModel class.
        /// </summary>
        /// <param name="name">The unique name for the column.</param>
        public JqGridColumnModel(string name)
        {
            Name = name;
            
            InitialSortingOrder = JqGridOptionsDefaults.InitialSortingOrder;
            Sortable = JqGridOptionsDefaults.Sortable;
            SortType = JqGridOptionsDefaults.SortType;
            SortFunction = String.Empty;
            Index = String.Empty;
        }

        internal JqGridColumnModel(ModelMetadata propertyMetadata)
            : this(propertyMetadata.PropertyName)
        {
            TimestampAttribute timeStampAttribute = null;
            JqGridColumnSortableAttribute jqGridColumnSortableAttribute = null;

            foreach (Attribute customAttribute in propertyMetadata.ContainerType.GetProperty(propertyMetadata.PropertyName).GetCustomAttributes(true))
            {
                timeStampAttribute = (customAttribute as TimestampAttribute) ?? timeStampAttribute;
                jqGridColumnSortableAttribute = (customAttribute as JqGridColumnSortableAttribute) ?? jqGridColumnSortableAttribute;
            }

            if (timeStampAttribute != null)
            { }
            else
            {
                SetSortOptions(jqGridColumnSortableAttribute);
            }
        }
        #endregion

        #region Methods
        private void SetSortOptions(JqGridColumnSortableAttribute jqGridColumnSortableAttribute)
        {
            if (jqGridColumnSortableAttribute != null)
            {
                Index = jqGridColumnSortableAttribute.Index;
                InitialSortingOrder = jqGridColumnSortableAttribute.InitialSortingOrder;
                Sortable = jqGridColumnSortableAttribute.Sortable;
                SortType = jqGridColumnSortableAttribute.SortType;
                SortFunction = jqGridColumnSortableAttribute.SortFunction;
            }
        }
        #endregion
    }
}
