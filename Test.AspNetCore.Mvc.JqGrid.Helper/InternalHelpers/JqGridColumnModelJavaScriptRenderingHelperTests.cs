using System.Text;
using Xunit;
using Moq;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json;

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
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME));

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, jqGridJsonServiceStub, false);

            Assert.DoesNotContain(JSON_MAP_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_JsonMappingIsNotNull_ScriptContainsJsonMapOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME)
            {
                JsonMapping = SOME_JSON_MAP
            });

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, jqGridJsonServiceStub, false);

            Assert.Contains($"{JSON_MAP_OPTION}'{SOME_JSON_MAP}'", javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendColumnsModels_KeyIsFalse_ScriptDoesNotContainKeyOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME));

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, jqGridJsonServiceStub, false);

            Assert.DoesNotContain(KEY_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_KeyIsTrue_ScriptContainsKeyOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME)
            {
                Key = true
            });

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, jqGridJsonServiceStub, false);

            Assert.Contains($"{KEY_OPTION}true", javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendColumnsModels_XmlMappingIsNull_ScriptDoesNotContainXmlMapOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME));

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, jqGridJsonServiceStub, false);

            Assert.DoesNotContain(XML_MAP_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_XmlMappingIsNotNull_ScriptContainsXmlMapOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);
            options.AddColumn(SOME_COLUMN_NAME, new JqGridColumnModel(SOME_COLUMN_NAME)
            {
                XmlMapping = SOME_XML_MAP
            });

            javaScriptBuilder = javaScriptBuilder.AppendColumnsModels(options, jqGridJsonServiceStub, false);

            Assert.Contains($"{XML_MAP_OPTION}'{SOME_XML_MAP}'", javaScriptBuilder.ToString());
        }
        #endregion
    }
}
