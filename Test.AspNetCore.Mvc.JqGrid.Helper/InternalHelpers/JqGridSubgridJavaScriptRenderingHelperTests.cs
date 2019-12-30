using System.Text;
using Xunit;
using Moq;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Subgrid;

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
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridEnabledOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.Contains(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridRowExpandedOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.Contains(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = new JqGridOptions(SOME_SUBGRID_ID),
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNotNullAndSubgridModelIsNotNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridUrlOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridModelOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNotNullAndSubgridModelIsNotNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridEnabledOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.Contains(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNotNullAndSubgridModelIsNotNullAndSubGridRowExpandedIsNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridUrlOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.Contains(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNotNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNull_ScriptContainsSubgridModelOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = SOME_SUBGRID_URL,
                SubgridModel = new JqGridSubgridModel(),
                SubGridRowExpanded = null
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.Contains(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridEnabledOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridDisabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridRowExpandedOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = false,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptContainsSubgridEnabledOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.Contains(SUBGRID_ENABLED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptContainsSubgridRowExpandedOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.Contains(SUBGRID_ROW_EXPANDED_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridUrlOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_URL_OPTION, javaScriptBuilder.ToString());
        }

        [Fact]
        public void AppendSubgrid_SubgridEnabledAndSubgridOptionsIsNullAndSubgridUrlIsNullAndSubgridModelIsNullAndSubGridRowExpandedIsNotNull_ScriptDoesNotContainSubgridModelOption()
        {
            IJqGridJsonService jqGridJsonServiceStub = new Mock<IJqGridJsonService>().Object;

            StringBuilder javaScriptBuilder = new StringBuilder();
            JqGridOptions options = new JqGridOptions(SOME_GRID_ID)
            {
                SubgridEnabled = true,
                SubgridOptions = null,
                SubgridUrl = null,
                SubgridModel = null,
                SubGridRowExpanded = SOME_SUBGRID_ROW_EXPANDED_FUNCTION
            };

            javaScriptBuilder = javaScriptBuilder.AppendSubgrid(options, jqGridJsonServiceStub);

            Assert.DoesNotContain(SUBGRID_MODEL_OPTION, javaScriptBuilder.ToString());
        }
        #endregion
    }
}
