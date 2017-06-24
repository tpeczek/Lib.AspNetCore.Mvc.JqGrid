using System.Linq;
using System.Text;
using System.Collections.Generic;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridFooterDataJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static StringBuilder AppendFooterData(this StringBuilder javaScriptBuilder, JqGridOptions options)
        {
            if (!options.UserDataOnFooter && (options.FooterData != null) && options.FooterData.Any())
            {
                javaScriptBuilder.AppendLine(")").Append(".jqGrid('footerData','set',{");

                foreach (KeyValuePair<string, string> footerValue in options.FooterData)
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringField(footerValue.Key, footerValue.Value);
                }

                javaScriptBuilder.AppendJavaScriptObjectClosing();

                if (options.UseFormattersForFooterData != JqGridOptionsDefaults.UseFormattersForFooterData)
                {
                    javaScriptBuilder.Append(",").Append(options.UseFormattersForFooterData.ToString().ToLower());
                }
            }

            return javaScriptBuilder;
        }
        #endregion
    }
}
