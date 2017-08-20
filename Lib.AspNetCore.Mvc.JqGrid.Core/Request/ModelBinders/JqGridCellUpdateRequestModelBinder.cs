using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Internal;
using Lib.AspNetCore.Mvc.JqGrid.Core.Helpers;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Request.ModelBinders
{
    /// <summary>
    /// A base IModelBinder which binds JqGridCellUpdateReques.
    /// </summary>
    public abstract class JqGridCellUpdateRequestModelBinder : IModelBinder
    {
        #region Properties
        /// <summary>
        /// Gets the dictionary of supported cells.
        /// </summary>
        protected abstract IDictionary<string, Type> SupportedCells { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Attempts to bind a model.
        /// </summary>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The result of the model binding process.</returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (bindingContext.ModelType == typeof(JqGridCellUpdateRequest))
            {
                JqGridCellUpdateRequest model = new JqGridCellUpdateRequest
                {
                    Id = bindingContext.ValueProvider.GetValue("id").FirstValue
                };

                foreach (KeyValuePair<string, Type> supportedCell in SupportedCells)
                {
                    if (BindCellProperties(model, bindingContext, supportedCell.Key, supportedCell.Value))
                    {
                        break;
                    }
                }

                bindingContext.Result = ModelBindingResult.Success(model);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return CompatibilityHelper.CompletedTask;
        }

        private bool BindCellProperties(JqGridCellUpdateRequest model, ModelBindingContext bindingContext, string cellName, Type cellType)
        {
            bool cellBinded = false;

            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(cellName);
            if ((valueProviderResult != ValueProviderResult.None) && (valueProviderResult.Values.Count > 0))
            {
                model.CellName = cellName;
                model.CellValue = (valueProviderResult.Values.Count == 1) ? (object)valueProviderResult.FirstValue : valueProviderResult.Values.ToArray();
            }

            return cellBinded;
        }
        #endregion
    }
}
