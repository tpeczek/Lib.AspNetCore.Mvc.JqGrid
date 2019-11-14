using System.Text;
using Xunit;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Subgrid;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;

namespace Test.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    public class JqGridSubgridJavaScriptRenderingHelperTests
    {
        #region Fields
        private const string SOME_GRID_ID = "grid";
        private const string SOME_SUBGRID_ID = "subgrid";
        private const string SOME_SUBGRID_URL = "https://domain.com/subgrid";
        private const string SOME_SUBGRID_ROW_EXPANDED_FUNCTION = "onSubgridRowExpanded";

        private const string SUBGRID_ENABLED_OPTION = "subGrid:true";
        private const string SUBGRID_ROW_EXPANDED_OPTION = "subGridRowExpanded:";
        private const string SUBGRID_URL_OPTION = "subGridUrl:";
        private const string SUBGRID_MODEL_OPTION = "subGridModel:[";
        #endregion

        #region Tests
        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.Contains(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridRowExpandedOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.Contains(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNotNullAndSubgridModelIsNotNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNotNullAndSubgridModelIsNotNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.Contains(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNotNullAndSubgridModelIsNotNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridUrlOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.Contains(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridModelOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.Contains(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptContainsSubgridEnabledOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.Contains(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptContainsSubgridRowExpandedOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.Contains(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridUrlOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridModelOption()
        {
            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }
        #endregion
    }
}
