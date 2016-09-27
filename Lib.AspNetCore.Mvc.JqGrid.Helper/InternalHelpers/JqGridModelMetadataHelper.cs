using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options;
using Lib.AspNetCore.Mvc.JqGrid.DataAnnotations;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridModelMetadataHelper
    {
        #region Extension Methods
        internal static void ApplyModelMetadata(this JqGridOptions options, IModelMetadataProvider metadataProvider)
        {
            Type jqGridOptionsType = options.GetType();
            if (jqGridOptionsType.IsConstructedGenericType && jqGridOptionsType.GetGenericTypeDefinition() == typeof(JqGridOptions<>))
            {
                options.ColumnsModels.Clear();
                options.ColumnsNames.Clear();

                foreach (ModelMetadata columnMetadata in metadataProvider.GetMetadataForProperties(jqGridOptionsType.GenericTypeArguments[0]))
                {
                    if (IsValidForColumn(columnMetadata))
                    {
                        options.ColumnsModels.Add(CreateJqGridColumnModel(columnMetadata));
                        options.ColumnsNames.Add(columnMetadata.GetDisplayName());
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        private static bool IsValidForColumn(ModelMetadata columnMetadata)
        {
            return columnMetadata.ShowForDisplay && (!columnMetadata.IsComplexType || columnMetadata.ModelType == typeof(byte[]));
        }

        private static JqGridColumnModel CreateJqGridColumnModel(ModelMetadata columnMetadata)
        {
            JqGridColumnModel columnModel = new JqGridColumnModel(columnMetadata.PropertyName);

            TimestampAttribute timeStampAttribute = null;
            JqGridColumnSortableAttribute jqGridColumnSortableAttribute = null;

            foreach (Attribute customAttribute in columnMetadata.ContainerType.GetProperty(columnMetadata.PropertyName).GetCustomAttributes(true))
            {
                timeStampAttribute = (customAttribute as TimestampAttribute) ?? timeStampAttribute;
                jqGridColumnSortableAttribute = (customAttribute as JqGridColumnSortableAttribute) ?? jqGridColumnSortableAttribute;
            }

            if (timeStampAttribute != null)
            { }
            else
            {
                columnModel = SetSortOptions(columnModel, jqGridColumnSortableAttribute);
            }

            return columnModel;
        }

        private static JqGridColumnModel SetSortOptions(JqGridColumnModel columnModel, JqGridColumnSortableAttribute jqGridColumnSortableAttribute)
        {
            if (jqGridColumnSortableAttribute != null)
            {
                columnModel.Index = jqGridColumnSortableAttribute.Index;
                columnModel.InitialSortingOrder = jqGridColumnSortableAttribute.InitialSortingOrder;
                columnModel.Sortable = jqGridColumnSortableAttribute.Sortable;
                columnModel.SortType = jqGridColumnSortableAttribute.SortType;
                columnModel.SortFunction = jqGridColumnSortableAttribute.SortFunction;
            }

            return columnModel;
        }
        #endregion
    }
}
