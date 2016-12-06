using System.Text;
using Lib.AspNetCore.Mvc.JqGrid.Core.Response;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridJsonReaderJavaScriptRenderingHelper
    {
        #region Extension Methods
        internal static StringBuilder AppendJsonReader(this StringBuilder javaScriptBuilder, JqGridJsonReader jsonReader)
        {
            jsonReader = jsonReader ?? JqGridResponse.JsonReader;

            if ((jsonReader != null) && !jsonReader.IsDefault())
            {
                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.JSON_READER)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.JsonReader.PAGE_INDEX, jsonReader.PageIndex, JqGridOptionsDefaults.Response.PageIndex)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.JsonReader.RECORD_ID, jsonReader.RecordId, JqGridOptionsDefaults.Response.RecordId)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.JsonReader.TOTAL_PAGES_COUNT, jsonReader.TotalPagesCount, JqGridOptionsDefaults.Response.TotalPagesCount)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.JsonReader.TOTAL_RECORDS_COUNT, jsonReader.TotalRecordsCount, JqGridOptionsDefaults.Response.TotalRecordsCount)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.JsonReader.USER_DATA, jsonReader.UserData, JqGridOptionsDefaults.Response.UserData)
                    .AppendJsonRecordsReaderProperties(jsonReader)
                    .AppendJsonRecordsReader(jsonReader.SubgridReader)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }
        #endregion

        #region Private Methods
        private static StringBuilder AppendJsonRecordsReader(this StringBuilder javaScriptBuilder, JqGridJsonRecordsReader jsonRecordsReader)
        {
            if ((jsonRecordsReader != null) && !jsonRecordsReader.IsDefault())
            {
                javaScriptBuilder.AppendJavaScriptObjectFieldOpening(JqGridOptionsNames.JsonReader.SUBGRID)
                    .AppendJsonRecordsReaderProperties(jsonRecordsReader)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendJsonRecordsReaderProperties(this StringBuilder javaScriptBuilder, JqGridJsonRecordsReader jsonRecordsReader)
        {
            return javaScriptBuilder.AppendJavaScriptObjectStringField(JqGridOptionsNames.JsonReader.RECORDS, jsonRecordsReader.Records, JqGridOptionsDefaults.Response.Records)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.JsonReader.RECORD_VALUES, jsonRecordsReader.RecordValues, JqGridOptionsDefaults.Response.RecordValues)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.JsonReader.REPEAT_ITEMS, jsonRecordsReader.RepeatItems, JqGridOptionsDefaults.Response.RepeatItems);
        }
        #endregion
    }
}
