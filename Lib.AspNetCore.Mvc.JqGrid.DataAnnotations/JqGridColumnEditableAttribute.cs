using System;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.DataAnnotations
{
    /// <summary>
    /// Specifies the editing options for column
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class JqGridColumnEditableAttribute : JqGridColumnElementAttribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of function which is used to create custom edit element
        /// </summary>
        public string CustomElementFunction
        {
            get { return EditOptions.CustomElementFunction; }
            set { EditOptions.CustomElementFunction = value; }
        }

        /// <summary>
        /// Gets or sets the name of function which should return the value from the custom element after the editing.
        /// </summary>
        public string CustomElementValueFunction
        {
            get { return EditOptions.CustomValueFunction; }
            set { EditOptions.CustomValueFunction = value; }
        }

        /// <summary>
        /// Gets or sets the expected date format for this column in case of date validation (default ISO date). 
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets the value defining if this column can be edited.
        /// </summary>
        public bool Editable { get; private set; }

        /// <summary>
        /// Gets or sets the value which defines if hidden column can be edited in form editing.
        /// </summary>
        public bool EditHidden
        {
            get { return Rules.EditHidden; }
            set { Rules.EditHidden = value; }
        }

        /// <summary>
        /// Gets options for jqGrid editable column.
        /// </summary>
        public JqGridColumnEditOptions EditOptions { get; private set; }

        /// <summary>
        /// Gets or sets the type of the editable field (default JqGridColumnEditTypes.Text).
        /// </summary>
        public JqGridColumnEditTypes EditType { get; set; }

        /// <summary>
        /// Gets the options for jqGrid editable or searchable column element.
        /// </summary>
        protected override JqGridColumnElementOptions ElementOptions { get { return EditOptions; } }

        /// <summary>
        /// Gets or sets the column position of the element (with the label) in form editing (one-based).
        /// </summary>
        public int FormColumnPosition
        {
            get { return FormOptions.ColumnPosition.HasValue ? FormOptions.ColumnPosition.Value : 1; }
            set { FormOptions.ColumnPosition = value; }
        }

        /// <summary>
        /// Gets or sets the text or HTML content to appear before the input element in form editing.
        /// </summary>
        public string FormElementPrefix
        {
            get { return FormOptions.ElementPrefix; }
            set { FormOptions.ElementPrefix = value; }
        }

        /// <summary>
        /// Gets or sets the text or HTML content to appear after the input element in form editing.
        /// </summary>
        public string FormElementSuffix
        {
            get { return FormOptions.ElementSuffix; }
            set { FormOptions.ElementSuffix = value; }
        }

        /// <summary>
        /// Gets or sets the text which will replace the name from ColumnNames as label in form editing.
        /// </summary>
        public string FormLabel
        {
            get { return FormOptions.Label; }
            set { FormOptions.Label = value; }
        }

        /// <summary>
        /// Gets additional options, used in form editing, for jqGrid editable column.
        /// </summary>
        public JqGridColumnFormOptions FormOptions { get; private set; }

        /// <summary>
        /// Gets or sets the row position of the element (with the label) in form editing (one-based).
        /// </summary>
        public int FormRowPosition
        {
            get { return FormOptions.RowPosition.HasValue ? FormOptions.RowPosition.Value : 1; }
            set { FormOptions.RowPosition = value; }
        }

        /// <summary>
        /// Gets or sets the value which defines if null value should be send to server if the field is empty.
        /// </summary>
        public bool NullIfEmpty
        {
            get { return EditOptions.NullIfEmpty; }
            set { EditOptions.NullIfEmpty = value; }
        }

        /// <summary>
        /// When overriden in delivered class, provides additional data which will be added to the AJAX request to get the data for the select element (if EditType is JqGridColumnEditTypes.Select).
        /// </summary>
        public virtual object PostData { get { return null; } }

        /// <summary>
        /// Gets or sets the JavaScript which will dynamically generate the additional data which will be added to the AJAX request to get the data for the select element (if EditType is JqGridColumnEditTypes.Select). This property takes precedence over PostData.
        /// </summary>
        public string PostDataScript
        {
            get { return EditOptions.PostDataScript; }
            set { EditOptions.PostDataScript = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnEditableAttribute class.
        /// </summary>
        public JqGridColumnEditableAttribute()
            : this(true)
        { }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnEditableAttribute class.
        /// </summary>
        /// <param name="editable">If this column can be edited</param>
        public JqGridColumnEditableAttribute(bool editable)
            : base()
        {
            DateFormat = JqGridOptionsDefaults.ColumnModel.DateFormat;
            Editable = editable;
            EditOptions = new JqGridColumnEditOptions();
            EditType = JqGridOptionsDefaults.ColumnModel.EditType;
            FormOptions = new JqGridColumnFormOptions();
        }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnEditableAttribute class.
        /// </summary>
        /// <param name="route">The name of the route to be used to generate URL to get the AJAX data for the select element (if type is JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnEditTypes.Autocomplete).</param>
        public JqGridColumnEditableAttribute(string route)
            : this(true)
        {
            SetDataRoute(route);
        }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnEditableAttribute class.
        /// </summary>
        /// <param name="action">The name of the action method to get the AJAX data for the select element (if type is JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnEditTypes.Autocomplete).</param>
        /// <param name="controller">The name of the controller to get the AJAX data for the select element (if type is JqGridColumnEditTypes.Select) or jQuery UI Autocomplete widget (if type is JqGridColumnEditTypes.Autocomplete).</param>
        public JqGridColumnEditableAttribute(string action, string controller)
            : this(true)
        {
            SetDataAction(action, controller);
        }

        /// <summary>
        /// Initializes a new instance of the JqGridColumnEditableAttribute class.
        /// </summary>
        /// <param name="valueProviderType">The type of class which contains a method which will provide data for select element (if type is JqGridColumnEditTypes.Select). This class must have public parameterless constructor.</param>
        /// <param name="valueProviderMethodName">The name of method which will provide data for select element (if type is JqGridColumnEditTypes.Select). This method must return an object which implements IDictionary&lt;string, string&gt;.</param>
        public JqGridColumnEditableAttribute(Type valueProviderType, string valueProviderMethodName)
            : this(true)
        {
            SetValueDictionary(valueProviderType, valueProviderMethodName);
        }
        #endregion
    }
}
