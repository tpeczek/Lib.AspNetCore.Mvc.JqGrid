using System;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.DataAnnotations
{
    /// <summary>
    /// Specifies the searching options for column
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class JqGridColumnSearchableAttribute : JqGridColumnElementAttribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value which defines if Clear ("X") button is available at the end of search field in jqGrid filter toolbar.
        /// </summary>
        public bool ClearSearch
        {
            get { return SearchOptions.ClearSearch; }
            set { SearchOptions.ClearSearch = value; }
        }

        /// <summary>
        /// Gets the value defining if this column can be searched.
        /// </summary>
        public bool Searchable { get; private set; }

        /// <summary>
        /// Gets or sets the value which defines if hidden column can be searched.
        /// </summary>
        public bool SearchHidden
        {
            get { return SearchOptions.SearchHidden; }
            set { SearchOptions.SearchHidden = value; }
        }

        /// <summary>
        /// Gets or sets the available search operators for the column.
        /// </summary>
        public JqGridSearchOperators SearchOperators
        {
            get { return SearchOptions.SearchOperators; }
            set { SearchOptions.SearchOperators = value; }
        }

        /// <summary>
        /// Gets or sets the type of the search field (default JqGridColumnSearchTypes.Text).
        /// </summary>
        public JqGridColumnSearchTypes SearchType { get; set; }

        /// <summary>
        /// Gets or sets if the value is required while searching.
        /// </summary>
        public bool SearchRequired
        {
            get { return Rules.Required; }
            set { Rules.Required = value; }
        }

        /// <summary>
        /// Gets options for jqGrid searchable column.
        /// </summary>
        public JqGridColumnSearchOptions SearchOptions { get; private set; }

        /// <summary>
        /// Gets the options for jqGrid editable or searchable column element.
        /// </summary>
        protected override JqGridColumnElementOptions ElementOptions { get { return SearchOptions; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the JqGridColumnSearchableAttribute class.
        /// </summary>
        public JqGridColumnSearchableAttribute()
            : this(true)
        { }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnSearchableAttribute class.
        /// </summary>
        /// <param name="searchable">If this column can be searched</param>
        public JqGridColumnSearchableAttribute(bool searchable)
            : base()
        {
            Searchable = searchable;
            SearchOptions = new JqGridColumnSearchOptions();
            SearchType = JqGridOptionsDefaults.ColumnModel.SearchType;
        }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnSearchableAttribute class.
        /// </summary>
        /// <param name="route">The name of the route to be used to generate URL to get the AJAX data for the select element (if type is JqGridColumnSearchTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes.Autocomplete).</param>
        public JqGridColumnSearchableAttribute(string route)
            : this(true)
        {
            SetDataRoute(route);
        }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnSearchableAttribute class.
        /// </summary>
        /// <param name="action">The name of the action method to get the AJAX data for the select element (if type is JqGridColumnSearchTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes.Autocomplete).</param>
        /// <param name="controller">The name of the controller to get the AJAX data for the select element (if type is JqGridColumnSearchTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnSearchTypes.Autocomplete).</param>
        public JqGridColumnSearchableAttribute(string action, string controller)
            : this(true)
        {
            SetDataAction(action, controller);
        }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnSearchableAttribute class.
        /// </summary>
        /// <param name="valueProviderType">The type of class which contains a method which will provide data for select element (if type is JqGridColumnSearchTypes.Select). This class must have public parameterless constructor.</param>
        /// <param name="valueProviderMethodName">The name of method which will provide data for select element (if type is JqGridColumnSearchTypes.Select). This method must return an object which implements IDictionary&lt;string, string&gt;.</param>
        public JqGridColumnSearchableAttribute(Type valueProviderType, string valueProviderMethodName)
            : this(true)
        {
            SetValueDictionary(valueProviderType, valueProviderMethodName);
        }
        #endregion
    }
}
