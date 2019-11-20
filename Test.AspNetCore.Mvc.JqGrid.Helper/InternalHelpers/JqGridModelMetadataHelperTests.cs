using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Xunit;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options;
using Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers;
using Lib.AspNetCore.Mvc.JqGrid.DataAnnotations;

namespace Test.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    public class JqGridModelMetadataHelperTests
    {
        #region Classes
        private class SomeGridModel
        {
            public string DefaultColumn { get; set; }

            [JqGridColumnMapping(JsonMapping = SOME_JSON_MAP, Key = true, XmlMapping = SOME_XML_MAP)]
            public string MappedColumn { get; set; }
        };
        #endregion

        #region Fields
        private const string SOME_GRID_ID = "grid";
        private const string SOME_JSON_MAP = "gridColumnJsonMap";
        private const string SOME_XML_MAP = "gridColumnXmlMap";

        private static readonly Type SOME_GRID_MODEL_TYPE = typeof(SomeGridModel);
        private static readonly Type SOME_GRID_COLUMN_TYPE = typeof(String);
        #endregion

        #region Tests
        [Fact]
        public void ApplyModelMetadata_DefaultColumn_JsonMappingIsNull()
        {
            Mock<IModelMetadataProvider> metadataProviderStub = new Mock<IModelMetadataProvider>();
            metadataProviderStub.Setup(m => m.GetMetadataForProperties(SOME_GRID_MODEL_TYPE)).Returns(new []
            {
                (ModelMetadata)new JqGridColumnModelMetadata(SOME_GRID_COLUMN_TYPE, nameof(SomeGridModel.DefaultColumn), SOME_GRID_MODEL_TYPE)
            });

            Mock<IUrlHelper> urlHelperStub = new Mock<IUrlHelper>();
            JqGridOptions<SomeGridModel> options = new JqGridOptions<SomeGridModel>(SOME_GRID_ID);
            

            options.ApplyModelMetadata(metadataProviderStub.Object, urlHelperStub.Object);

            Assert.Null(options.ColumnsModels.Single(c => c.Name == nameof(SomeGridModel.DefaultColumn)).JsonMapping);
        }

        [Fact]
        public void ApplyModelMetadata_DefaultColumn_KeyIsFalse()
        {
            Mock<IModelMetadataProvider> metadataProviderStub = new Mock<IModelMetadataProvider>();
            metadataProviderStub.Setup(m => m.GetMetadataForProperties(SOME_GRID_MODEL_TYPE)).Returns(new[]
            {
                (ModelMetadata)new JqGridColumnModelMetadata(SOME_GRID_COLUMN_TYPE, nameof(SomeGridModel.DefaultColumn), SOME_GRID_MODEL_TYPE)
            });

            Mock<IUrlHelper> urlHelperStub = new Mock<IUrlHelper>();
            JqGridOptions<SomeGridModel> options = new JqGridOptions<SomeGridModel>(SOME_GRID_ID);


            options.ApplyModelMetadata(metadataProviderStub.Object, urlHelperStub.Object);

            Assert.False(options.ColumnsModels.Single(c => c.Name == nameof(SomeGridModel.DefaultColumn)).Key);
        }

        [Fact]
        public void ApplyModelMetadata_DefaultColumn_XmlMappingIsNull()
        {
            Mock<IModelMetadataProvider> metadataProviderStub = new Mock<IModelMetadataProvider>();
            metadataProviderStub.Setup(m => m.GetMetadataForProperties(SOME_GRID_MODEL_TYPE)).Returns(new[]
            {
                (ModelMetadata)new JqGridColumnModelMetadata(SOME_GRID_COLUMN_TYPE, nameof(SomeGridModel.DefaultColumn), SOME_GRID_MODEL_TYPE)
            });

            Mock<IUrlHelper> urlHelperStub = new Mock<IUrlHelper>();
            JqGridOptions<SomeGridModel> options = new JqGridOptions<SomeGridModel>(SOME_GRID_ID);


            options.ApplyModelMetadata(metadataProviderStub.Object, urlHelperStub.Object);

            Assert.Null(options.ColumnsModels.Single(c => c.Name == nameof(SomeGridModel.DefaultColumn)).XmlMapping);
        }

        [Fact]
        public void ApplyModelMetadata_MappedColumn_JsonMappingIsSet()
        {
            Mock<IModelMetadataProvider> metadataProviderStub = new Mock<IModelMetadataProvider>();
            metadataProviderStub.Setup(m => m.GetMetadataForProperties(SOME_GRID_MODEL_TYPE)).Returns(new[]
            {
                (ModelMetadata)new JqGridColumnModelMetadata(SOME_GRID_COLUMN_TYPE, nameof(SomeGridModel.MappedColumn), SOME_GRID_MODEL_TYPE)
            });

            Mock<IUrlHelper> urlHelperStub = new Mock<IUrlHelper>();
            JqGridOptions<SomeGridModel> options = new JqGridOptions<SomeGridModel>(SOME_GRID_ID);


            options.ApplyModelMetadata(metadataProviderStub.Object, urlHelperStub.Object);

            Assert.Equal(SOME_JSON_MAP, options.ColumnsModels.Single(c => c.Name == nameof(SomeGridModel.MappedColumn)).JsonMapping);
        }

        [Fact]
        public void ApplyModelMetadata_MappedColumn_KeyIsTrue()
        {
            Mock<IModelMetadataProvider> metadataProviderStub = new Mock<IModelMetadataProvider>();
            metadataProviderStub.Setup(m => m.GetMetadataForProperties(SOME_GRID_MODEL_TYPE)).Returns(new[]
            {
                (ModelMetadata)new JqGridColumnModelMetadata(SOME_GRID_COLUMN_TYPE, nameof(SomeGridModel.MappedColumn), SOME_GRID_MODEL_TYPE)
            });

            Mock<IUrlHelper> urlHelperStub = new Mock<IUrlHelper>();
            JqGridOptions<SomeGridModel> options = new JqGridOptions<SomeGridModel>(SOME_GRID_ID);


            options.ApplyModelMetadata(metadataProviderStub.Object, urlHelperStub.Object);

            Assert.True(options.ColumnsModels.Single(c => c.Name == nameof(SomeGridModel.MappedColumn)).Key);
        }

        [Fact]
        public void ApplyModelMetadata_MappedColumn_XmlMappingIsSet()
        {
            Mock<IModelMetadataProvider> metadataProviderStub = new Mock<IModelMetadataProvider>();
            metadataProviderStub.Setup(m => m.GetMetadataForProperties(SOME_GRID_MODEL_TYPE)).Returns(new[]
            {
                (ModelMetadata)new JqGridColumnModelMetadata(SOME_GRID_COLUMN_TYPE, nameof(SomeGridModel.MappedColumn), SOME_GRID_MODEL_TYPE)
            });

            Mock<IUrlHelper> urlHelperStub = new Mock<IUrlHelper>();
            JqGridOptions<SomeGridModel> options = new JqGridOptions<SomeGridModel>(SOME_GRID_ID);


            options.ApplyModelMetadata(metadataProviderStub.Object, urlHelperStub.Object);

            Assert.Equal(SOME_XML_MAP, options.ColumnsModels.Single(c => c.Name == nameof(SomeGridModel.MappedColumn)).XmlMapping);
        }
        #endregion
    }
}
