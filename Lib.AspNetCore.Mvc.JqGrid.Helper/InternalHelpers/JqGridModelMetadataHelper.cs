using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Options.Subgrid;
using Lib.AspNetCore.Mvc.JqGrid.DataAnnotations;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Enums;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Subgrid;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridModelMetadataHelper
    {
        #region Fields
        private static char[] _invalidDateFormatTokens = new char[] { 'N', 'S', 'w', 'W', 't', 'L', 'o' };
        private const string _ignoredDateFormatTokensRegexExpression = "[aABgGhHisueIOPTZcr]";
        private static Regex _dateFormatTokensRegex = new Regex("d|j|l|z|F|m|n|Y|U", RegexOptions.Compiled);
        private static Dictionary<string, string> _dateFormatTokensReplecements = new Dictionary<string, string> { { "d", "dd" }, { "j", "d" }, { "l", "DD" }, { "z", "o" }, { "F", "MM" }, { "m", "mm" }, { "n", "m" }, { "Y", "yy" }, { "U", "@" } };
        #endregion

        #region Extension Methods
        internal static void ApplyModelMetadata(this JqGridOptions options, IModelMetadataProvider metadataProvider, IUrlHelper urlHelper)
        {
            Type jqGridOptionsType = options.GetType();
            if (jqGridOptionsType.IsConstructedGenericType && jqGridOptionsType.GetGenericTypeDefinition() == typeof(JqGridOptions<>))
            {
                foreach (ModelMetadata columnMetadata in metadataProvider.GetMetadataForProperties(jqGridOptionsType.GenericTypeArguments[0]))
                {
                    if (IsValidForColumn(columnMetadata))
                    {
                        options.AddColumn(columnMetadata.GetDisplayName(), CreateJqGridColumnModel(columnMetadata, urlHelper));
                    }
                }
            }

            if (options.SubgridEnabled)
            {
                if (options.SubgridOptions != null)
                {
                    options.SubgridOptions.ApplyModelMetadata(metadataProvider, urlHelper);
                }
                else if (options.SubgridModel != null)
                {
                    options.SubgridModel.ApplyModelMetadata(metadataProvider);
                }
            }


        }
        #endregion

        #region Private Methods
        private static bool IsValidForColumn(ModelMetadata columnMetadata)
        {
            return columnMetadata.ShowForDisplay && (!columnMetadata.IsComplexType || columnMetadata.ModelType == typeof(byte[]));
        }

        private static JqGridColumnModel CreateJqGridColumnModel(ModelMetadata columnMetadata, IUrlHelper urlHelper)
        {
            JqGridColumnModel columnModel = new JqGridColumnModel(columnMetadata.PropertyName);

            TimestampAttribute timeStampAttribute = null;
            RangeAttribute rangeAttribute = null;
            RequiredAttribute requiredAttribute = null;
            JqGridColumnLayoutAttribute jqGridColumnLayoutAttribute = null;
            JqGridColumnSortableAttribute jqGridColumnSortableAttribute = null;
            JqGridColumnFormatterAttribute jqGridColumnFormatterAttribute = null;
            JqGridColumnSearchableAttribute jqGridColumnSearchableAttribute = null;
            JqGridColumnEditableAttribute jqGridColumnEditableAttribute = null;
            JqGridColumnSummaryAttribute jqGridColumnSummaryAttribute = null;

            foreach (Attribute customAttribute in columnMetadata.ContainerType.GetProperty(columnMetadata.PropertyName).GetCustomAttributes(true))
            {
                timeStampAttribute = (customAttribute as TimestampAttribute) ?? timeStampAttribute;
                rangeAttribute = (customAttribute as RangeAttribute) ?? rangeAttribute;
                requiredAttribute = (customAttribute as RequiredAttribute) ?? requiredAttribute;
                jqGridColumnLayoutAttribute = (customAttribute as JqGridColumnLayoutAttribute) ?? jqGridColumnLayoutAttribute;
                jqGridColumnSortableAttribute = (customAttribute as JqGridColumnSortableAttribute) ?? jqGridColumnSortableAttribute;
                jqGridColumnFormatterAttribute = (customAttribute as JqGridColumnFormatterAttribute) ?? jqGridColumnFormatterAttribute;
                jqGridColumnSearchableAttribute = (customAttribute as JqGridColumnSearchableAttribute) ?? jqGridColumnSearchableAttribute;
                jqGridColumnEditableAttribute = (customAttribute as JqGridColumnEditableAttribute) ?? jqGridColumnEditableAttribute;
                jqGridColumnSummaryAttribute = (customAttribute as JqGridColumnSummaryAttribute) ?? jqGridColumnSummaryAttribute;
            }

            if (timeStampAttribute != null)
            {
                columnModel.Editable = true;
                columnModel.Hidden = true;
            }
            else
            {
                columnModel = SetLayoutOptions(columnModel, jqGridColumnLayoutAttribute);
                columnModel = SetSortOptions(columnModel, jqGridColumnSortableAttribute);
                columnModel = SetFormatterOptions(columnModel, jqGridColumnFormatterAttribute);
                columnModel = SetSearchOptions(columnModel, urlHelper, columnMetadata.ModelType, jqGridColumnSearchableAttribute, rangeAttribute);
                columnModel = SetEditOptions(columnModel, urlHelper, columnMetadata.ModelType, jqGridColumnEditableAttribute, rangeAttribute, requiredAttribute);
                columnModel = SetDatePickerDateFormatFromFormatter(columnModel, jqGridColumnFormatterAttribute);
                columnModel = SetSummaryOptions(columnModel, jqGridColumnSummaryAttribute);
            }

            return columnModel;
        }

        private static JqGridColumnModel SetLayoutOptions(JqGridColumnModel columnModel, JqGridColumnLayoutAttribute jqGridColumnLayoutAttribute)
        {
            if (jqGridColumnLayoutAttribute != null)
            {
                columnModel.Alignment = jqGridColumnLayoutAttribute.Alignment;
                columnModel.CellAttributes = jqGridColumnLayoutAttribute.CellAttributes;
                columnModel.Classes = jqGridColumnLayoutAttribute.Classes;
                columnModel.Fixed = jqGridColumnLayoutAttribute.Fixed;
                columnModel.Frozen = jqGridColumnLayoutAttribute.Frozen;
                columnModel.HideInDialog = jqGridColumnLayoutAttribute.HideInDialog;
                columnModel.Resizable = jqGridColumnLayoutAttribute.Resizable;
                columnModel.Title = jqGridColumnLayoutAttribute.Title;
                columnModel.Width = jqGridColumnLayoutAttribute.Width;
                columnModel.Viewable = jqGridColumnLayoutAttribute.Viewable;
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

        private static JqGridColumnModel SetEditOptions(JqGridColumnModel columnModel, IUrlHelper urlHelper, Type modelType, JqGridColumnEditableAttribute jqGridColumnEditableAttribute, RangeAttribute rangeAttribute, RequiredAttribute requiredAttribute)
        {
            if (jqGridColumnEditableAttribute != null)
            {
                columnModel.DateFormat = jqGridColumnEditableAttribute.DateFormat;
                columnModel.Editable = jqGridColumnEditableAttribute.Editable;
                columnModel.EditOptions = GetElementOptions(jqGridColumnEditableAttribute.EditOptions, urlHelper, jqGridColumnEditableAttribute);
                columnModel.EditOptions.PostData = jqGridColumnEditableAttribute.PostData;
                columnModel.EditRules = GetRules(modelType, jqGridColumnEditableAttribute, rangeAttribute, requiredAttribute);
                columnModel.EditType = jqGridColumnEditableAttribute.EditType;
                columnModel.FormOptions = jqGridColumnEditableAttribute.FormOptions;
            }

            return columnModel;
        }

        private static JqGridColumnModel SetFormatterOptions(JqGridColumnModel columnModel, JqGridColumnFormatterAttribute jqGridColumnFormatterAttribute)
        {
            if (jqGridColumnFormatterAttribute != null)
            {
                columnModel.Formatter = jqGridColumnFormatterAttribute.Formatter;
                columnModel.FormatterOptions = jqGridColumnFormatterAttribute.FormatterOptions;
                columnModel.UnFormatter = jqGridColumnFormatterAttribute.UnFormatter;
            }

            return columnModel;
        }

        private static JqGridColumnModel SetSearchOptions(JqGridColumnModel columnModel, IUrlHelper urlHelper, Type modelType, JqGridColumnSearchableAttribute jqGridColumnSearchableAttribute, RangeAttribute rangeAttribute)
        {
            if (jqGridColumnSearchableAttribute != null)
            {
                columnModel.Searchable = jqGridColumnSearchableAttribute.Searchable;
                columnModel.SearchOptions = GetElementOptions(jqGridColumnSearchableAttribute.SearchOptions, urlHelper, jqGridColumnSearchableAttribute);
                columnModel.SearchRules = GetRules(modelType, jqGridColumnSearchableAttribute, rangeAttribute, null);
                columnModel.SearchType = jqGridColumnSearchableAttribute.SearchType;
            }

            return columnModel;
        }

        private static TElementOptions GetElementOptions<TElementOptions>(TElementOptions elementOptions, IUrlHelper urlHelper, JqGridColumnElementAttribute jqGridColumnElementAttribute) where TElementOptions: JqGridColumnElementOptions
        {
            elementOptions.DataEvents = jqGridColumnElementAttribute.DataEvents;

            if (!String.IsNullOrWhiteSpace(jqGridColumnElementAttribute.DataAction))
            {
                elementOptions.DataUrl = String.IsNullOrWhiteSpace(jqGridColumnElementAttribute.DataController) ? urlHelper.Action(jqGridColumnElementAttribute.DataAction) : urlHelper.Action(jqGridColumnElementAttribute.DataAction, jqGridColumnElementAttribute.DataController);
            }
            else if (!String.IsNullOrWhiteSpace(jqGridColumnElementAttribute.DataRoute))
            {
                elementOptions.DataUrl = urlHelper.RouteUrl(jqGridColumnElementAttribute.DataRoute);
            }

            elementOptions.HtmlAttributes = jqGridColumnElementAttribute.HtmlAttributes;

            return elementOptions;
        }

        private static JqGridColumnRules GetRules(Type modelType, JqGridColumnElementAttribute jqGridColumnElementAttribute, RangeAttribute rangeAttribute, RequiredAttribute requiredAttribute)
        {
            JqGridColumnRules rules = jqGridColumnElementAttribute.Rules;

            if (rules != null)
            {
                if (requiredAttribute != null)
                {
                    rules.Required = true;
                }

                if (rangeAttribute != null)
                {
                    rules.MaxValue = Convert.ToDouble(rangeAttribute.Maximum);
                    rules.MinValue = Convert.ToDouble(rangeAttribute.Minimum);
                }

                if ((modelType == typeof(Int16)) || (modelType == typeof(Int32)) || (modelType == typeof(Int64)) || (modelType == typeof(UInt16)) || (modelType == typeof(UInt32)) || (modelType == typeof(UInt32)))
                {
                    rules.Integer = true;
                }
                else if ((modelType == typeof(Decimal)) || (modelType == typeof(Double)) || (modelType == typeof(Single)))
                {
                    rules.Number = true;
                }
            }

            return rules;
        }

        private static JqGridColumnModel SetDatePickerDateFormatFromFormatter(JqGridColumnModel columnModel, JqGridColumnFormatterAttribute jqGridColumnFormatterAttribute)
        {
            bool setSearchOptionsDatePickerDateFormat = columnModel.Searchable && (columnModel.SearchType == JqGridColumnSearchTypes.JQueryUIDatepicker) && (columnModel.SearchOptions.DatePickerDateFormat == JqGridOptionsDefaults.ColumnModel.JQueryUIWidgets.DatepickerDateFormat);
            bool setEditOptionsDatePickerDateFormat = false;

            if (setSearchOptionsDatePickerDateFormat || setEditOptionsDatePickerDateFormat)
            {
                if ((jqGridColumnFormatterAttribute != null) && (jqGridColumnFormatterAttribute.Formatter == JqGridPredefinedFormatters.Date) && (jqGridColumnFormatterAttribute.OutputFormat != JqGridOptionsDefaults.ColumnModel.Formatter.OutputFormat) && (jqGridColumnFormatterAttribute.OutputFormat.IndexOfAny(_invalidDateFormatTokens) == -1))
                {
                    string datePickerDateFormat = Regex.Replace(jqGridColumnFormatterAttribute.OutputFormat, _ignoredDateFormatTokensRegexExpression, String.Empty);
                    datePickerDateFormat = _dateFormatTokensRegex.Replace(datePickerDateFormat, match => { return _dateFormatTokensReplecements[match.Value]; });

                    if (setSearchOptionsDatePickerDateFormat)
                    {
                        columnModel.SearchOptions.DatePickerDateFormat = datePickerDateFormat;
                    }

                    if (setEditOptionsDatePickerDateFormat)
                    {

                    }
                }
            }
            return columnModel;
        }

        private static JqGridColumnModel SetSummaryOptions(JqGridColumnModel columnModel, JqGridColumnSummaryAttribute jqGridColumnSummaryAttribute)
        {
            if (jqGridColumnSummaryAttribute != null)
            {
                columnModel.SummaryType = jqGridColumnSummaryAttribute.Type;
                columnModel.SummaryTemplate = jqGridColumnSummaryAttribute.Template;
                columnModel.SummaryFunction = jqGridColumnSummaryAttribute.Function;
            }

            return columnModel;
        }

        private static void ApplyModelMetadata(this JqGridSubgridModel subgridModel, IModelMetadataProvider metadataProvider)
        {
            Type jqGridsubgridModelType = subgridModel.GetType();
            if (jqGridsubgridModelType.IsConstructedGenericType && jqGridsubgridModelType.GetGenericTypeDefinition() == typeof(JqGridSubgridModel<>))
            {
                foreach (ModelMetadata columnMetadata in metadataProvider.GetMetadataForProperties(jqGridsubgridModelType.GenericTypeArguments[0]))
                {
                    if (IsValidForColumn(columnMetadata))
                    {
                        subgridModel.AddColumn(CreateJqGridSubgridColumnModel(columnMetadata));
                    }
                }
            }
        }

        private static JqGridSubgridColumnModel CreateJqGridSubgridColumnModel(ModelMetadata columnMetadata)
        {
            JqGridAlignments alignment = JqGridOptionsDefaults.ColumnModel.Alignment;
            int width = JqGridOptionsDefaults.ColumnModel.Width;

            foreach (Attribute customAttribute in columnMetadata.ContainerType.GetProperty(columnMetadata.PropertyName).GetCustomAttributes(true))
            {
                JqGridColumnLayoutAttribute jqGridColumnLayoutAttribute = (customAttribute as JqGridColumnLayoutAttribute);

                if (jqGridColumnLayoutAttribute != null)
                {
                    alignment = jqGridColumnLayoutAttribute.Alignment;
                    width = jqGridColumnLayoutAttribute.Width;
                    break;
                }
            }

            return new JqGridSubgridColumnModel(columnMetadata.GetDisplayName(), alignment, width, columnMetadata.PropertyName);
        }
        #endregion
    }
}
