using System.Text;
using Xunit;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;

namespace Test.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    public class JqGridOptionsJavaScriptRenderingHelperTests
    {
        #region Fields
        private const string SOME_GRID_ID = "grid";
        private const string SOME_GRID_COMPLETE_FUNCTION = "onGridComplete";
        private const string SOME_LOAD_COMPLETE_FUNCTION = "onLoadComplete";
        private const string SOME_ON_SELECT_ROW_FUNCTION = "onOnSelectRow";

        private const string GRID_COMPLETE_OPTION = "gridComplete:";
        private const string LOAD_COMPLETE_OPTION = "loadComplete:";
        private const string ON_SELECT_ROW_OPTION = "onSelectRow:";
        #endregion

        #region Tests
        [Fact]
        public void AppendOptions_GridCompleteIsNull_ScriptDoesNotContainGridCompleteOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);

            javaScriptBuilder = javaScriptBuilder.AppendOptions(options, false);

            Assert.DoesNotContain(GRID_COMPLETE_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_GridCompleteIsNotNull_ScriptContainsGridCompleteOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                GridComplete = SOME_GRID_COMPLETE_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendOptions(options, false);

            Assert.Contains($"{GRID_COMPLETE_OPTION}{SOME_GRID_COMPLETE_FUNCTION},", javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_LoadCompleteIsNull_ScriptDoesNotContainLoadCompleteOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);

            javaScriptBuilder = javaScriptBuilder.AppendOptions(options, false);

            Assert.DoesNotContain(LOAD_COMPLETE_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_LoadCompleteIsNotNull_ScriptContainsLoadCompleteOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                LoadComplete = SOME_LOAD_COMPLETE_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendOptions(options, false);

            Assert.Contains($"{LOAD_COMPLETE_OPTION}{SOME_LOAD_COMPLETE_FUNCTION},", javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_OnSelectRowIsNull_ScriptDoesNotContainOnSelectRowOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID);

            javaScriptBuilder = javaScriptBuilder.AppendOptions(options, false);

            Assert.DoesNotContain(ON_SELECT_ROW_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendOptions_OnSelectRowIsNotNull_ScriptContainsOnSelectRowOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                OnSelectRow = SOME_ON_SELECT_ROW_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendOptions(options, false);

            Assert.Contains($"{ON_SELECT_ROW_OPTION}{SOME_ON_SELECT_ROW_FUNCTION},", javaScriptBuilder.ToString());
        }
        #endregion
    }
}
