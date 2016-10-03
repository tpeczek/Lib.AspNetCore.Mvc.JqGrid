using System;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.ColumnModel;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridOptionsHelper
    {
        #region Extension Methods
        internal static bool AreDefault(this JqGridColumnFormatterOptions formatterOptions, string formatter)
        {
            switch (formatter)
            {
                case JqGridPredefinedFormatters.Integer:
                    return (formatterOptions.DefaultValue == JqGridOptionsDefaults.ColumnModel.Formatter.IntegerDefaultValue)
                        && (formatterOptions.ThousandsSeparator == JqGridOptionsDefaults.ColumnModel.Formatter.ThousandsSeparator);
                case JqGridPredefinedFormatters.Number:
                    return (formatterOptions.DecimalPlaces == JqGridOptionsDefaults.ColumnModel.Formatter.DecimalPlaces)
                        && (formatterOptions.DecimalSeparator == JqGridOptionsDefaults.ColumnModel.Formatter.DecimalSeparator)
                        && (formatterOptions.DefaultValue == JqGridOptionsDefaults.ColumnModel.Formatter.NumberDefaultValue)
                        && (formatterOptions.ThousandsSeparator == JqGridOptionsDefaults.ColumnModel.Formatter.ThousandsSeparator);
                case JqGridPredefinedFormatters.Currency:
                    return (formatterOptions.DecimalPlaces == JqGridOptionsDefaults.ColumnModel.Formatter.DecimalPlaces)
                        && (formatterOptions.DecimalSeparator == JqGridOptionsDefaults.ColumnModel.Formatter.DecimalSeparator)
                        && (formatterOptions.DefaultValue == JqGridOptionsDefaults.ColumnModel.Formatter.CurrencyDefaultValue)
                        && String.IsNullOrWhiteSpace(formatterOptions.Prefix)
                        && String.IsNullOrWhiteSpace(formatterOptions.Suffix)
                        && (formatterOptions.ThousandsSeparator == JqGridOptionsDefaults.ColumnModel.Formatter.ThousandsSeparator);
                case JqGridPredefinedFormatters.Date:
                    return (formatterOptions.SourceFormat == JqGridOptionsDefaults.ColumnModel.Formatter.SourceFormat)
                        && (formatterOptions.OutputFormat == JqGridOptionsDefaults.ColumnModel.Formatter.OutputFormat);
                case JqGridPredefinedFormatters.Link:
                    return String.IsNullOrWhiteSpace(formatterOptions.Target);
                case JqGridPredefinedFormatters.ShowLink:
                    return (String.IsNullOrWhiteSpace(formatterOptions.BaseLinkUrl)
                        && String.IsNullOrWhiteSpace(formatterOptions.ShowAction)
                        && String.IsNullOrWhiteSpace(formatterOptions.AddParam)
                        && String.IsNullOrWhiteSpace(formatterOptions.Target)
                        && (formatterOptions.IdName == JqGridOptionsDefaults.ColumnModel.Formatter.IdName));
                case JqGridPredefinedFormatters.CheckBox:
                    return (formatterOptions.Disabled == JqGridOptionsDefaults.ColumnModel.Formatter.Disabled);
                case JqGridPredefinedFormatters.Actions:
                    return (formatterOptions.EditButton == JqGridOptionsDefaults.ColumnModel.Formatter.EditButton)
                        && (formatterOptions.UseFormEditing == JqGridOptionsDefaults.ColumnModel.Formatter.UseFormEditing)
                        && ((formatterOptions.InlineEditingOptions == null) || formatterOptions.InlineEditingOptions.AreDefault())
                        && (formatterOptions.DeleteButton == JqGridOptionsDefaults.ColumnModel.Formatter.DeleteButton)
                        && ((formatterOptions.DeleteOptions == null) || formatterOptions.DeleteOptions.AreDefault());
                default:
                    return true;
            }
        }

        internal static bool AreDefault(this JqGridInlineNavigatorActionOptions inlineNavigatorActionOptions)
        {
            return (inlineNavigatorActionOptions.Keys == JqGridOptionsDefaults.Navigator.InlineActionKeys)
                && (String.IsNullOrWhiteSpace(inlineNavigatorActionOptions.OnEditFunction))
                && (String.IsNullOrWhiteSpace(inlineNavigatorActionOptions.SuccessFunction))
                && (String.IsNullOrEmpty(inlineNavigatorActionOptions.Url))
                && (inlineNavigatorActionOptions.ExtraParam == null)
                && (String.IsNullOrWhiteSpace(inlineNavigatorActionOptions.ExtraParamScript))
                && (String.IsNullOrWhiteSpace(inlineNavigatorActionOptions.AfterSaveFunction))
                && (String.IsNullOrWhiteSpace(inlineNavigatorActionOptions.ErrorFunction))
                && (String.IsNullOrWhiteSpace(inlineNavigatorActionOptions.AfterRestoreFunction))
                && (inlineNavigatorActionOptions.RestoreAfterError == JqGridOptionsDefaults.Navigator.InlineActionRestoreAfterError)
                && (inlineNavigatorActionOptions.MethodType == JqGridOptionsDefaults.Navigator.InlineActionMethodType);
        }

        internal static bool AreDefault(this JqGridNavigatorEditActionOptions navigatorEditActionOptions)
        {
            return true;
        }

        internal static bool AreDefault(this JqGridNavigatorDeleteActionOptions navigatorDeleteActionOptions)
        {
            return true;
        }
        #endregion
    }
}
