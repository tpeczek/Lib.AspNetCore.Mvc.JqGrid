using System;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Lib.AspNetCore.Mvc.JqGrid.Core.Services;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Request.ModelBinders
{
    /// <summary>
    /// An IModelBinder which binds JqGridRequest
    /// </summary>
    internal sealed class JqGridRequestModelBinder : IModelBinder
    {
        #region Fields
        private const string SEARCH_FILTERS_BINDING_KEY = "filters";
        private const string SEARCH_NAME_BINDING_KEY = "searchField";
        private const string SEARCH_VALUE_BINDING_KEY = "searchString";
        private const string SEARCH_OPERATOR_BINDING_KEY = "searchOper";

        private static readonly Type INT32_TYPE = typeof(Int32);
        private static readonly Type BOOLEAN_TYPE = typeof(Boolean);
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

            string key = (bindingContext.IsTopLevelObject) ? (bindingContext.BinderModelName ?? String.Empty) : bindingContext.ModelName;

            if (bindingContext.ModelType == typeof(JqGridRequest))
            {
                JqGridRequest model = new JqGridRequest();
                model = BindPagingProperties(model, bindingContext);
                model = BindSortingProperties(model, bindingContext);
                model = BindSearchingProperties(model, bindingContext);

                bindingContext.Result = ModelBindingResult.Success(model);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }

        private JqGridRequest BindPagingProperties(JqGridRequest model, ModelBindingContext bindingContext)
        {
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParametersNames.PageIndex))
            {
                model.PageIndex = ConvertToInt32(bindingContext.ValueProvider.GetValue(JqGridRequest.ParametersNames.PageIndex).FirstValue) - 1;
            }
            else
            {
                model.PageIndex = 0;
            }

            model.PagesCount = 1;
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParametersNames.PagesCount))
            {
                ValueProviderResult pagesCountValueResult = bindingContext.ValueProvider.GetValue(JqGridRequest.ParametersNames.PagesCount);
                if (pagesCountValueResult != ValueProviderResult.None)
                {
                    model.PagesCount = ConvertToInt32(pagesCountValueResult.FirstValue);
                }
            }

            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParametersNames.RecordsCount))
            {
                model.RecordsCount = ConvertToInt32(bindingContext.ValueProvider.GetValue(JqGridRequest.ParametersNames.RecordsCount).FirstValue);
            }

            return model;
        }

        private JqGridRequest BindSortingProperties(JqGridRequest model, ModelBindingContext bindingContext)
        {
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParametersNames.SortingName))
            {
                string sortingName = bindingContext.ValueProvider.GetValue(JqGridRequest.ParametersNames.SortingName).FirstValue;

                if (!String.IsNullOrWhiteSpace(sortingName))
                {
                    model.SortingName = sortingName;
                }
            }

            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParametersNames.SortingOrder))
            {
                JqGridSortingOrders sortingOrder = JqGridSortingOrders.Asc;
                string sortingOrderAsString = bindingContext.ValueProvider.GetValue(JqGridRequest.ParametersNames.SortingOrder).FirstValue;

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
            if (!String.IsNullOrWhiteSpace(JqGridRequest.ParametersNames.Searching))
            {
                ValueProviderResult searchingValueResult = bindingContext.ValueProvider.GetValue(JqGridRequest.ParametersNames.Searching);
                if (searchingValueResult != ValueProviderResult.None)
                {
                    model.Searching = ConvertToBoolean(searchingValueResult.FirstValue);
                }
            }

            model.SearchingFilter = null;
            model.SearchingFilters = null;

            if (model.Searching)
            {
                ValueProviderResult searchingFiltersValueResult = bindingContext.ValueProvider.GetValue(SEARCH_FILTERS_BINDING_KEY);
                if ((searchingFiltersValueResult != ValueProviderResult.None) && !String.IsNullOrWhiteSpace(searchingFiltersValueResult.FirstValue))
                {
                    IJqGridJsonService jqGridJsonService = bindingContext.HttpContext.RequestServices.GetRequiredService<IJqGridJsonService>();

                    model.SearchingFilters = jqGridJsonService.DeserializeJqGridSearchingFilters(searchingFiltersValueResult.FirstValue);
                }
                else
                {
                    string searchingName = bindingContext.ValueProvider.GetValue(SEARCH_NAME_BINDING_KEY).FirstValue;
                    string searchingValue = bindingContext.ValueProvider.GetValue(SEARCH_VALUE_BINDING_KEY).FirstValue;

                    JqGridSearchOperators searchingOperator = JqGridSearchOperators.Eq;
                    Enum.TryParse(bindingContext.ValueProvider.GetValue(SEARCH_OPERATOR_BINDING_KEY).FirstValue, true, out searchingOperator);

                    if (!String.IsNullOrWhiteSpace(searchingName) && (!String.IsNullOrWhiteSpace(searchingValue) || ((searchingOperator & JqGridSearchOperators.NullOperators) != 0)))
                    {
                        model.SearchingFilter = new JqGridSearchingFilter() { SearchingName = searchingName, SearchingOperator = searchingOperator, SearchingValue = searchingValue };
                    }
                }
            }

            return model;
        }

        public static int ConvertToInt32(object value)
        {
            if (value == null)
            {
                return (Int32)Activator.CreateInstance(INT32_TYPE);

            }

            if (INT32_TYPE.IsAssignableFrom(value.GetType()))
            {
                return (Int32)value;
            }

            object converted = UnwrapPossibleArrayType(value, INT32_TYPE);

            return (converted == null) ? default(Int32) : (Int32)converted;
        }

        public static bool ConvertToBoolean(object value)
        {
            if (value == null)
            {
                return (Boolean)Activator.CreateInstance(BOOLEAN_TYPE);

            }

            if (BOOLEAN_TYPE.IsAssignableFrom(value.GetType()))
            {
                return (Boolean)value;
            }

            object converted = UnwrapPossibleArrayType(value, BOOLEAN_TYPE);

            return (converted == null) ? default(Boolean) : (Boolean)converted;
        }

        private static object UnwrapPossibleArrayType(object value, Type destinationType)
        {
            var valueAsArray = value as Array;
            if (destinationType.IsArray)
            {
                var destinationElementType = destinationType.GetElementType();
                if (valueAsArray != null)
                {
                    var converted = (IList)Array.CreateInstance(destinationElementType, valueAsArray.Length);
                    for (var i = 0; i < valueAsArray.Length; i++)
                    {
                        converted[i] = ConvertSimpleType(valueAsArray.GetValue(i), destinationElementType);
                    }
                    return converted;
                }
                else
                {
                    var element = ConvertSimpleType(value, destinationElementType);
                    var converted = (IList)Array.CreateInstance(destinationElementType, 1);
                    converted[0] = element;
                    return converted;
                }
            }
            else if (valueAsArray != null)
            {
                if (valueAsArray.Length > 0)
                {
                    value = valueAsArray.GetValue(0);
                    return ConvertSimpleType(value, destinationType);
                }
                else
                {
                    return null;
                }
            }

            return ConvertSimpleType(value, destinationType);
        }

        private static object ConvertSimpleType(object value, Type destinationType)
        {
            if (value == null || destinationType.IsAssignableFrom(value.GetType()))
            {
                return value;
            }

            if (value is string valueAsString && string.IsNullOrWhiteSpace(valueAsString))
            {
                return null;
            }

            var converter = TypeDescriptor.GetConverter(destinationType);
            var canConvertFrom = converter.CanConvertFrom(value.GetType());
            if (!canConvertFrom)
            {
                converter = TypeDescriptor.GetConverter(value.GetType());
            }
            if (!(canConvertFrom || converter.CanConvertTo(destinationType)))
            {
                if (destinationType.GetTypeInfo().IsEnum &&
                    (value is int ||
                    value is uint ||
                    value is long ||
                    value is ulong ||
                    value is short ||
                    value is ushort ||
                    value is byte ||
                    value is sbyte))
                {
                    return Enum.ToObject(destinationType, value);
                }

                throw new InvalidOperationException();
            }

            try
            {
                return canConvertFrom
                    ? converter.ConvertFrom(null, CultureInfo.InvariantCulture, value)
                    : converter.ConvertTo(null, CultureInfo.InvariantCulture, value, destinationType);
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    throw;
                }
                else
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();

                    throw;
                }
            }
        }
        #endregion
    }
}
