using System.Collections.Generic;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching
{
    /// <summary>
    /// Class which represents filters in request from jqGrid.
    /// </summary>
    public class JqGridSearchingFilters
    {
        #region Properties
        /// <summary>
        /// Gets the operator grouping the filters.
        /// </summary>
        public JqGridSearchGroupingOperators GroupingOperator { get; set; }

        /// <summary>
        /// Gets the list of filters.
        /// </summary>
        public List<JqGridSearchingFilter> Filters { get; set; }

        /// <summary>
        /// Gets the list of filters sub groups.
        /// </summary>
        public List<JqGridSearchingFilters> Groups { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridRequestSearchingFilters class.
        /// </summary>
        public JqGridSearchingFilters()
        {
            Filters = new List<JqGridSearchingFilter>();
            Groups = new List<JqGridSearchingFilters>();
        }
        #endregion
    }
}
