using System.Text;
using System.Collections.Generic;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridFilterJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static StringBuilder AppendFilterToolbar(this StringBuilder javaScriptBuilder, JqGridFilterToolbarOptions filterToolbarOptions)
        {
            if (filterToolbarOptions != null)
            {
                javaScriptBuilder.AppendLine(")").Append(".jqGrid('filterToolbar'");
                
                if (!filterToolbarOptions.AreDefault())
                {
                    javaScriptBuilder.AppendLine(",")
                        .AppendJavaScriptObjectOpening()
                        .AppendFilterOptions(filterToolbarOptions)
                        .AppendJavaScriptObjectEnumField(JqGridOptionsNames.Filter.Toolbar.DEFAULT_SEARCH, filterToolbarOptions.DefaultSearchOperator, JqGridOptionsDefaults.Filter.Toolbar.DefaultSearchOperator)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Filter.Toolbar.SEARCH_ON_ENTER, filterToolbarOptions.SearchOnEnter, JqGridOptionsDefaults.Filter.Toolbar.SearchOnEnter)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Filter.Toolbar.SEARCH_OPERATORS, filterToolbarOptions.SearchOperators, JqGridOptionsDefaults.Filter.Toolbar.SearchOperators)
                        .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Filter.Toolbar.STRING_RESULT, filterToolbarOptions.StringResult, JqGridOptionsDefaults.Filter.Toolbar.StringResult);

                    if (filterToolbarOptions.StringResult)
                    {
                        javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.Filter.Toolbar.GROUPING_OPERATOR, filterToolbarOptions.GroupingOperator.ToString().ToUpperInvariant(), JqGridOptionsDefaults.Filter.Toolbar.GroupingOperator.ToString().ToUpperInvariant());
                    }

                    if (filterToolbarOptions.SearchOperators)
                    {
                        javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.Filter.Toolbar.OPERAND_TITLE, filterToolbarOptions.OperandToolTip, JqGridOptionsDefaults.Filter.Toolbar.OperandToolTip);

                        if ((filterToolbarOptions.Operands != null) && (filterToolbarOptions.Operands.Count > 0))
                        {
                            IList<KeyValuePair<JqGridSearchOperators, string>> operands = new List<KeyValuePair<JqGridSearchOperators, string>>();
                            foreach(KeyValuePair<JqGridSearchOperators, string> operand in filterToolbarOptions.Operands)
                            {
                                if (JqGridOptionsDefaults.Filter.Toolbar.Operands.TryGetValue(operand.Key, out string defaultShortText) && (operand.Value != defaultShortText))
                                {
                                    operands.Add(operand);
                                }
                            }

                            if (operands.Count > 0)
                            {
                                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.Filter.Toolbar.OPERANDS);
                                foreach (KeyValuePair<JqGridSearchOperators, string> operand in operands)
                                {
                                    javaScriptBuilder.AppendJavaScriptObjectStringField(operand.Key.ToString().ToLower(), operand.Value);
                                }
                                javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
                            }
                        }
                    }

                    javaScriptBuilder.AppendJavaScriptObjectClosing();
                }
            }

            return javaScriptBuilder;
        }
        #endregion

        #region Private Methods
        private static StringBuilder AppendFilterOptions(this StringBuilder javaScriptBuilder, JqGridFilterOptions filterOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Filter.AFTER_CLEAR, filterOptions.AfterClear)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Filter.AFTER_SEARCH, filterOptions.AfterSearch)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Filter.AUTO_SEARCH, filterOptions.AutoSearch, JqGridOptionsDefaults.Filter.AutoSearch)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Filter.BEFORE_CLEAR, filterOptions.BeforeClear)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Filter.BEFORE_SEARCH, filterOptions.BeforeSearch);
        }
        #endregion
    }
}
