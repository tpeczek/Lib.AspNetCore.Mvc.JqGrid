using System.Text;
using Xunit;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;

namespace Test.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    public class JqGridColumnModelJavaScriptRenderingHelperTests
    {
        #region Fields
        private const string SOME_GRID_ID = "grid";
        private const string SOME_COLUMN_NAME = "gridColumnName";
        private const string SOME_JSON_MAP = "gridColumnJsonMap";
        private const string SOME_XML_MAP = "gridColumnXmlMap";

        private const string JSON_MAP_OPTION = "jsonmap:";
        private const string KEY_OPTION = "key:";
        private const string XML_MAP_OPTION = "xmlmap:";
        #endregion

        #region Tests
        [Fact]
        public void AppendColumnsModels_JsonMappingIsNull_ScriptDoesNotContainJsonMapOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME));

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, false);

            Assert.DoesNotContain(JSON_MAP_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_JsonMappingIsNotNull_ScriptContainsJsonMapOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME)
            {
                JsonMapping = SOME_JSON_MAP
            });

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, false);

            Assert.Contains($"{JSON_MAP_OPTION}'{SOME_JSON_MAP}'", javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendColumnsModels_KeyIsFalse_ScriptDoesNotContainKeyOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME));

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, false);

            Assert.DoesNotContain(KEY_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_KeyIsTrue_ScriptContainsKeyOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME)
            {
                Key = true
            });

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, false);

            Assert.Contains($"{KEY_OPTION}true", javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendColumnsModels_XmlMappingIsNull_ScriptDoesNotContainXmlMapOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME));

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, false);

            Assert.DoesNotContain(XML_MAP_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_XmlMappingIsNotNull_ScriptContainsXmlMapOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME)
            {
                XmlMapping = SOME_XML_MAP
            });

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, false);

            Assert.Contains($"{XML_MAP_OPTION}'{SOME_XML_MAP}'", javaScriptBuilder.ToString());
        }
        #endregion
    }
}
