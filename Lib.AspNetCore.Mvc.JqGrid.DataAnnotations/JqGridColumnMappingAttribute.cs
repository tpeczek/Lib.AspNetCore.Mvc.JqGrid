using System;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.DataAnnotations
{
    /// <summary>
    /// Specifies the mapping properties for the column.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class JqGridColumnMappingAttribute : Attribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets the JSON mapping for the column in the incoming JSON string.
        /// </summary>
        public string JsonMapping { get; set; }

        /// <summary>
        /// Defines if this column value should be used as unique row id (in case there is no id from the server). 
        /// </summary>
        public bool Key { get; set; }

        /// <summary>
        /// Gets or sets the XML mapping for the column in the incomming XML file.
        /// </summary>
        public string XmlMapping { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridColumnMappingAttribute class.
        /// </summary>
        public JqGridColumnMappingAttribute()
        {
            JsonMapping = null;
            Key = JqGridOptionsDefaults.ColumnModel.Key;
            XmlMapping = null;
        }
        #endregion
    }
}
