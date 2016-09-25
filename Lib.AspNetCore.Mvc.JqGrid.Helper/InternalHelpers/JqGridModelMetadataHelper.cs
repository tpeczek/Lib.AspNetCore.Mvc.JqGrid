using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridModelMetadataHelper
    {
        #region Extension Methods
        internal static bool IsValidForColumn(this ModelMetadata columnMetadata)
        {
            return columnMetadata.ShowForDisplay && (!columnMetadata.IsComplexType || columnMetadata.ModelType == typeof(byte[]));
        }
        #endregion
    }
}
