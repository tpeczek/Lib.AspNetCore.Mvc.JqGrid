using Lib.AspNetCore.Mvc.JqGrid.Core.Json.Converters;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Microsoft.AspNet.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Request.ModelBinders
{
    /// <summary>
    /// An IModelBinder which binds JqGridRequest
    /// </summary>
    internal sealed class JqGridRequestModelBinder : IModelBinder
    {
        #region Methods
        /// <summary>
        /// Attempts to bind a model.
        /// </summary>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The result of the model binding process.</returns>
        public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            string key = (bindingContext.IsTopLevelObject) ? (bindingContext.BinderModelName ?? String.Empty) : bindingContext.ModelName;

            Task<ModelBindingResult> jqGridRequestModelBindingResult;
            if (bindingContext.ModelType == typeof(JqGridRequest))
            {
                JqGridRequest model = new JqGridRequest();
                model = BindPagingProperties(model, bindingContext);
                model = BindSortingProperties(model, bindingContext);
                model = BindSearchingProperties(model, bindingContext);

                jqGridRequestModelBindingResult = ModelBindingResult.SuccessAsync(key, model);
            }
            else
            {
                jqGridRequestModelBindingResult = ModelBindingResult.FailedAsync(key);
            }

            return jqGridRequestModelBindingResult;
        }

        private JqGridRequest BindPagingProperties(JqGridRequest model, ModelBindingContext bindingContext)
        {
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParameterNames.PageIndex))
            {
                model.PageIndex = (int)bindingContext.ValueProvider.GetValue(JqGridRequest.ParameterNames.PageIndex).ConvertTo(typeof(Int32)) - 1;
            }
            else
            {
                model.PageIndex = 0;
            }

            model.PagesCount = 1;
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParameterNames.PagesCount))
            {
                ValueProviderResult pagesCountValueResult = bindingContext.ValueProvider.GetValue(JqGridRequest.ParameterNames.PagesCount);
                if (pagesCountValueResult.Length == 1)
                {
                    model.PagesCount = (int)pagesCountValueResult.ConvertTo(typeof(Int32));
                }
            }

            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParameterNames.RecordsCount))
            {
                model.RecordsCount = (int)bindingContext.ValueProvider.GetValue(JqGridRequest.ParameterNames.RecordsCount).ConvertTo(typeof(Int32));
            }

            return model;
        }

        private JqGridRequest BindSortingProperties(JqGridRequest model, ModelBindingContext bindingContext)
        {
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParameterNames.SortingName))
            {
                string sortingName = (string)bindingContext.ValueProvider.GetValue(JqGridRequest.ParameterNames.SortingName).ConvertTo(typeof(String));

                if (!String.IsNullOrWhiteSpace(sortingName))
                {
                    model.SortingName = sortingName;
                }
            }

            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParameterNames.SortingOrder))
            {
                JqGridSortingOrders sortingOrder = JqGridSortingOrders.Asc;
                string sortingOrderAsString = (string)bindingContext.ValueProvider.GetValue(JqGridRequest.ParameterNames.SortingOrder).ConvertTo(typeof(String));

                if (!String.IsNullOrWhiteSpace(sortingOrderAsString) && Enum.TryParse(sortingOrderAsString, true, out sortingOrder))
                {
                    model.SortingOrder = sortingOrder;
                }
            }

            return model;
        }

        private JqGridRequest BindSearchingProperties(JqGridRequest model, ModelBindingContext bindingContext)
        {
            model.Searching = false;
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParameterNames.Searching))
            {
                ValueProviderResult searchingValueResult = bindingContext.ValueProvider.GetValue(JqGridRequest.ParameterNames.Searching);
                if (searchingValueResult.Length == 1)
                {
                    model.Searching = (bool)searchingValueResult.ConvertTo(typeof(Boolean));
                }
            }

            model.SearchingFilter = null;
            model.SearchingFilters = null;

            if (model.Searching)
            {
                ValueProviderResult searchingFiltersValueResult = bindingContext.ValueProvider.GetValue("filters");
                if ((searchingFiltersValueResult.Length == 1) && !String.IsNullOrWhiteSpace(searchingFiltersValueResult.FirstValue))
                {
                    JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
                    jsonSerializerSettings.Converters.Add(new JqGridRequestSearchingFiltersJsonConverter());

                    model.SearchingFilters = JsonConvert.DeserializeObject<JqGridRequestSearchingFilters>((string)searchingFiltersValueResult.ConvertTo(typeof(String)), jsonSerializerSettings);
                }
                else
                {
                    string searchingName = (string)bindingContext.ValueProvider.GetValue("searchField").ConvertTo(typeof(String));
                    string searchingValue = (string)bindingContext.ValueProvider.GetValue("searchString").ConvertTo(typeof(String));

                    JqGridSearchOperators searchingOperator = JqGridSearchOperators.Eq;
                    Enum.TryParse((string)bindingContext.ValueProvider.GetValue("searchOper").ConvertTo(typeof(String)), true, out searchingOperator);

                    if (!String.IsNullOrWhiteSpace(searchingName) && (!String.IsNullOrWhiteSpace(searchingValue) || ((searchingOperator & JqGridSearchOperators.NullOperators) != 0)))
                    {
                        model.SearchingFilter = new JqGridRequestSearchingFilter() { SearchingName = searchingName, SearchingOperator = searchingOperator, SearchingValue = searchingValue };
                    }
                }
            }

            return model;
        }
        #endregion
    }
}
