using System;
using System.Text;
using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Searching;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridNavigatorJavaScriptRenderingHelper
    {
        #region Fields
        private const string NULL_NAVIGATOR_OPTIONS = ",null";
        #endregion

        #region Extension Methods
        internal static StringBuilder AppendInlineNavigatorActionOptions(this StringBuilder javaScriptBuilder, JqGridInlineNavigatorActionOptions inlineNavigatorActionOptions)
        {
            if ((inlineNavigatorActionOptions != null) && !inlineNavigatorActionOptions.AreDefault())
            {
                javaScriptBuilder.AppendJavaScriptObjectScriptOrObjectField(JqGridOptionsNames.InlineNavigator.EXTRA_PARAM, inlineNavigatorActionOptions.ExtraParamScript, inlineNavigatorActionOptions.ExtraParam)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.InlineNavigator.KEYS, inlineNavigatorActionOptions.Keys, JqGridOptionsDefaults.Navigator.InlineActionKeys)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.ON_EDIT_FUNCTION, inlineNavigatorActionOptions.OnEditFunction)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.SUCCESS_FUNCTION, inlineNavigatorActionOptions.SuccessFunction)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.InlineNavigator.URL, inlineNavigatorActionOptions.Url)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.AFTER_SAVE_FUNCTION, inlineNavigatorActionOptions.AfterSaveFunction)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.ERROR_FUNCTION, inlineNavigatorActionOptions.ErrorFunction)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.InlineNavigator.AFTER_RESTORE_FUNCTION, inlineNavigatorActionOptions.AfterRestoreFunction)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.InlineNavigator.RESTORE_AFTER_ERROR, inlineNavigatorActionOptions.RestoreAfterError, JqGridOptionsDefaults.Navigator.InlineActionRestoreAfterError)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.InlineNavigator.METHOD_TYPE, inlineNavigatorActionOptions.MethodType, JqGridOptionsDefaults.Navigator.InlineActionMethodType);
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendNavigator(this StringBuilder javaScriptBuilder, JqGridOptions options, bool asSubgrid)
        {
            if (options.Navigator != null)
            {
                javaScriptBuilder.AppendLine(")")
                    .AppendFormat(".jqGrid('navGrid',{0}", options.GetJqGridPagerSelector(options.Navigator.Pager, asSubgrid))
                    .AppendNavigatorOptions(options.Navigator)
                    .AppendNavigatorEditActionOptions(null, options.Navigator.EditOptions)
                    .AppendNavigatorEditActionOptions(null, options.Navigator.AddOptions)
                    .AppendNavigatorDeleteActionOptions(null, options.Navigator.DeleteOptions)
                    .AppendNavigatorSearchActionOptions(options.Navigator.SearchOptions)
                    .AppendNavigatorViewActionOptions(options.Navigator.ViewOptions);
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendNavigatorOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorOptions navigatorOptions)
        {
            if ((navigatorOptions != null) && !navigatorOptions.AreDefault())
            {
                javaScriptBuilder.Append(",")
                    .AppendJavaScriptObjectOpening()
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.ALERT_CAPTION, navigatorOptions.AlertCaption, JqGridOptionsDefaults.Navigator.AlertCaption)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.ALERT_TEXT, navigatorOptions.AlertText, JqGridOptionsDefaults.Navigator.AlertText)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLONE_TO_TOP, navigatorOptions.CloneToTop, JqGridOptionsDefaults.Navigator.CloneToTop)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_ON_ESCAPE, navigatorOptions.CloseOnEscape, JqGridOptionsDefaults.Navigator.CloseOnEscape)
                    .AppendBaseNavigatorOptions(navigatorOptions)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ADD_FUNCTION, navigatorOptions.AddFunction)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.EDIT_FUNCTION, navigatorOptions.EditFunction)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.DELETE, navigatorOptions.Delete, JqGridOptionsDefaults.Navigator.Delete)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.DELETE_ICON, navigatorOptions.DeleteIcon, JqGridOptionsDefaults.Navigator.DeleteIcon)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.DELETE_TEXT, navigatorOptions.DeleteText)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.DELETE_TITLE, navigatorOptions.DeleteToolTip, JqGridOptionsDefaults.Navigator.DeleteToolTip)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.DELETE_FUNCTION, navigatorOptions.DeleteFunction)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.REFRESH, navigatorOptions.Refresh, JqGridOptionsDefaults.Navigator.Refresh)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.REFRESH_ICON, navigatorOptions.RefreshIcon, JqGridOptionsDefaults.Navigator.RefreshIcon)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.REFRESH_TEXT, navigatorOptions.RefreshText)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.REFRESH_TITLE, navigatorOptions.RefreshToolTip, JqGridOptionsDefaults.Navigator.RefreshToolTip)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.Navigator.REFRESH_STATE, navigatorOptions.RefreshMode, JqGridOptionsDefaults.Navigator.RefreshMode)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_REFRESH, navigatorOptions.AfterRefresh)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_REFRESH, navigatorOptions.BeforeRefresh)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.SEARCH, navigatorOptions.Search, JqGridOptionsDefaults.Navigator.Search)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.SEARCH_ICON, navigatorOptions.SearchIcon, JqGridOptionsDefaults.Navigator.SearchIcon)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.SEARCH_TEXT, navigatorOptions.SearchText)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.SEARCH_TITLE, navigatorOptions.SearchToolTip, JqGridOptionsDefaults.Navigator.SearchToolTip)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.VIEW, navigatorOptions.View, JqGridOptionsDefaults.Navigator.View)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.VIEW_ICON, navigatorOptions.ViewIcon, JqGridOptionsDefaults.Navigator.ViewIcon)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.VIEW_TEXT, navigatorOptions.ViewText)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.VIEW_TITLE, navigatorOptions.ViewToolTip, JqGridOptionsDefaults.Navigator.ViewToolTip)
                    .AppendJavaScriptObjectClosing();
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendBaseNavigatorOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorOptionsBase navigatorOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectEnumField(JqGridOptionsNames.Navigator.POSITION, navigatorOptions.Position, JqGridOptionsDefaults.Navigator.Position)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.ADD, navigatorOptions.Add, JqGridOptionsDefaults.Navigator.Add)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.ADD_ICON, navigatorOptions.AddIcon, JqGridOptionsDefaults.Navigator.AddIcon)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.ADD_TEXT, navigatorOptions.AddText)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.ADD_TITLE, navigatorOptions.AddToolTip, JqGridOptionsDefaults.Navigator.AddToolTip)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.EDIT, navigatorOptions.Edit, JqGridOptionsDefaults.Navigator.Edit)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.EDIT_ICON, navigatorOptions.EditIcon, JqGridOptionsDefaults.Navigator.EditIcon)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.EDIT_TEXT, navigatorOptions.EditText)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.EDIT_TITLE, navigatorOptions.EditToolTip, JqGridOptionsDefaults.Navigator.EditToolTip);
        }

        internal static StringBuilder AppendNavigatorEditActionOptions(this StringBuilder javaScriptBuilder, string fieldName, JqGridNavigatorEditActionOptions navigatorEditActionOptions)
        {
            if ((navigatorEditActionOptions != null) && !navigatorEditActionOptions.AreDefault())
            {
                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.Append(",").AppendJavaScriptObjectOpening();
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldOpening(fieldName);
                }

                if ((navigatorEditActionOptions.SaveKeyEnabled != JqGridOptionsDefaults.Navigator.SaveKeyEnabled) || (navigatorEditActionOptions.SaveKey != JqGridOptionsDefaults.Navigator.SaveKey))
                {
                    javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.Navigator.SAVE_KEY)
                    .AppendJavaScriptArrayBooleanValue(navigatorEditActionOptions.SaveKeyEnabled)
                    .AppendJavaScriptArrayIntegerValue(navigatorEditActionOptions.SaveKey)
                    .AppendJavaScriptArrayFieldClosing();
                }

                javaScriptBuilder.AppendNavigatorModifyActionOptions(navigatorEditActionOptions)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.WIDTH, navigatorEditActionOptions.Width, JqGridOptionsDefaults.Navigator.EditActionWidth)
                    .AppendJavaScriptObjectObjectField(JqGridOptionsNames.Navigator.AJAX_EDIT_OPTIONS, navigatorEditActionOptions.AjaxOptions)
                    .AppendJavaScriptObjectScriptOrObjectField(JqGridOptionsNames.Navigator.EDIT_EXTRA_DATA, navigatorEditActionOptions.ExtraDataScript, navigatorEditActionOptions.ExtraData)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.SERIALIZE_EDIT_DATA, navigatorEditActionOptions.SerializeData)
                    .AppendJavaScriptObjectEnumField(JqGridOptionsNames.Navigator.ADDED_ROW_POSITION, navigatorEditActionOptions.AddedRowPosition, JqGridOptionsDefaults.Navigator.AddedRowPosition)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_CLICK_PG_BUTTONS, navigatorEditActionOptions.AfterClickPgButtons)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_COMPLETE, navigatorEditActionOptions.AfterComplete)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_CHECK_VALUES, navigatorEditActionOptions.BeforeCheckValues)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.BOTTOM_INFO, navigatorEditActionOptions.BottomInfo)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CHECK_ON_SUBMIT, navigatorEditActionOptions.CheckOnSubmit, JqGridOptionsDefaults.Navigator.CheckOnSubmit)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CHECK_ON_UPDATE, navigatorEditActionOptions.CheckOnUpdate, JqGridOptionsDefaults.Navigator.CheckOnUpdate)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLEAR_AFTER_ADD, navigatorEditActionOptions.ClearAfterAdd, JqGridOptionsDefaults.Navigator.ClearAfterAdd)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_AFTER_ADD, navigatorEditActionOptions.CloseAfterAdd, JqGridOptionsDefaults.Navigator.CloseAfterAdd)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_AFTER_EDIT, navigatorEditActionOptions.CloseAfterEdit, JqGridOptionsDefaults.Navigator.CloseAfterEdit)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.CLOSE_ICON, navigatorEditActionOptions.CloseButtonIcon, JqGridFormButtonIcon.CloseIcon)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ERROR_TEXT_FORMAT, navigatorEditActionOptions.ErrorTextFormat)
                    .AppendNavigatorPageableFormActionOptions(navigatorEditActionOptions)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_CLICK_PG_BUTTONS, navigatorEditActionOptions.OnClickPgButtons)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_INITIALIZE_FORM, navigatorEditActionOptions.OnInitializeForm)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.SAVE_ICON, navigatorEditActionOptions.SaveButtonIcon, JqGridFormButtonIcon.SaveIcon)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.TOP_INFO, navigatorEditActionOptions.TopInfo);

                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.AppendJavaScriptObjectClosing();
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
                }
            }
            else if (String.IsNullOrWhiteSpace(fieldName))
            {
                javaScriptBuilder.Append(NULL_NAVIGATOR_OPTIONS);
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendNavigatorDeleteActionOptions(this StringBuilder javaScriptBuilder, string fieldName, JqGridNavigatorDeleteActionOptions navigatorDeleteActionOptions)
        {
            if ((navigatorDeleteActionOptions != null) && !navigatorDeleteActionOptions.AreDefault())
            {
                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.Append(",").AppendJavaScriptObjectOpening();
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldOpening(fieldName);
                }

                javaScriptBuilder.AppendNavigatorModifyActionOptions(navigatorDeleteActionOptions)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.WIDTH, navigatorDeleteActionOptions.Width, JqGridOptionsDefaults.Navigator.DeleteActionWidth)
                    .AppendJavaScriptObjectObjectField(JqGridOptionsNames.Navigator.AJAX_DELETE_OPTIONS, navigatorDeleteActionOptions.AjaxOptions)
                    .AppendJavaScriptObjectScriptOrObjectField(JqGridOptionsNames.Navigator.DELETE_EXTRA_DATA, navigatorDeleteActionOptions.ExtraDataScript, navigatorDeleteActionOptions.ExtraData)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.SERIALIZE_DELETE_DATA, navigatorDeleteActionOptions.SerializeData)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.DELETE_ICON, navigatorDeleteActionOptions.DeleteButtonIcon, JqGridFormButtonIcon.DeleteIcon)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.CANCEL_ICON, navigatorDeleteActionOptions.CancelButtonIcon, JqGridFormButtonIcon.CancelIcon);

                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.AppendJavaScriptObjectClosing();
                }
                else
                {
                    javaScriptBuilder.AppendJavaScriptObjectFieldClosing();
                }
            }
            else if (String.IsNullOrWhiteSpace(fieldName))
            {
                javaScriptBuilder.Append(NULL_NAVIGATOR_OPTIONS);
            }

            return javaScriptBuilder;
        }
        #endregion

        #region Private Methods
        private static StringBuilder AppendFormButtonIcon(this StringBuilder javaScriptBuilder, string formButtonIconName, JqGridFormButtonIcon formButtonIcon, JqGridFormButtonIcon defaultFormButtonIcon)
        {
            if ((formButtonIcon != null) && !formButtonIcon.Equals(defaultFormButtonIcon))
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(formButtonIconName)
                    .AppendJavaScriptArrayBooleanValue(formButtonIcon.Enabled)
                    .AppendJavaScriptArrayEnumValue(formButtonIcon.Position)
                    .AppendJavaScriptArrayStringValue(formButtonIcon.Class)
                    .AppendJavaScriptArrayFieldClosing();
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendNavigatorModifyActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorModifyActionOptions navigatorModifyActionOptions)
        {
            javaScriptBuilder.AppendNavigatorFormActionOptions(navigatorModifyActionOptions);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_SHOW_FORM, navigatorModifyActionOptions.AfterShowForm)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_SUBMIT, navigatorModifyActionOptions.AfterSubmit)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_SUBMIT, navigatorModifyActionOptions.BeforeSubmit)
                .AppendJavaScriptObjectEnumField(JqGridOptionsNames.Navigator.METHOD_TYPE, navigatorModifyActionOptions.MethodType, JqGridOptionsDefaults.Navigator.MethodType)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_CLICK_SUBMIT, navigatorModifyActionOptions.OnClickSubmit)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.RELOAD_AFTER_SUBMIT, navigatorModifyActionOptions.ReloadAfterSubmit, JqGridOptionsDefaults.Navigator.ReloadAfterSubmit)
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.URL, navigatorModifyActionOptions.Url);
        }

        private static StringBuilder AppendNavigatorViewActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorViewActionOptions navigatorViewActionOptions)
        {
            if ((navigatorViewActionOptions != null) && !navigatorViewActionOptions.AreDefault())
            {
                javaScriptBuilder.Append(",")
                    .AppendJavaScriptObjectOpening()
                    .AppendNavigatorFormActionOptions(navigatorViewActionOptions)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.WIDTH, navigatorViewActionOptions.Width, JqGridOptionsDefaults.Navigator.ViewActionWidth)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.LABELS_WIDTH, navigatorViewActionOptions.LabelsWidth, JqGridOptionsDefaults.Navigator.LabelsWidth)
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.CLOSE_ICON, navigatorViewActionOptions.CloseButtonIcon, JqGridFormButtonIcon.CloseIcon)
                    .AppendNavigatorPageableFormActionOptions(navigatorViewActionOptions)
                    .AppendJavaScriptObjectClosing();
            }
            else
            {
                javaScriptBuilder.Append(NULL_NAVIGATOR_OPTIONS);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendNavigatorFormActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorFormActionOptions navigatorFormActionOptions)
        {
            javaScriptBuilder.AppendNavigatorActionOptions(navigatorFormActionOptions);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_INIT_DATA, navigatorFormActionOptions.BeforeInitData)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_SHOW_FORM, navigatorFormActionOptions.BeforeShowForm);
        }

        private static StringBuilder AppendNavigatorPageableFormActionOptions(this StringBuilder javaScriptBuilder, IJqGridNavigatorPageableFormActionOptions navigatorPageableFormActionOptions)
        {
            if ((navigatorPageableFormActionOptions.NavigationKeys != null) && !navigatorPageableFormActionOptions.NavigationKeys.IsDefault())
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.Navigator.NAVIGATION_KEYS)
                    .AppendJavaScriptArrayBooleanValue(navigatorPageableFormActionOptions.NavigationKeys.Enabled)
                    .AppendJavaScriptArrayIntegerValue(navigatorPageableFormActionOptions.NavigationKeys.RecordDown)
                    .AppendJavaScriptArrayIntegerValue(navigatorPageableFormActionOptions.NavigationKeys.RecordUp)
                    .AppendJavaScriptArrayFieldClosing();
            }

            return javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.VIEW_PAGER_BUTTONS, navigatorPageableFormActionOptions.ViewPagerButtons, JqGridOptionsDefaults.Navigator.ViewPagerButtons)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.RECREATE_FORM, navigatorPageableFormActionOptions.RecreateForm, JqGridOptionsDefaults.Navigator.RecreateForm);
        }

        private static StringBuilder AppendNavigatorSearchActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorSearchActionOptions navigatorSearchActionOptions)
        {
            if ((navigatorSearchActionOptions != null) && !navigatorSearchActionOptions.AreDefault())
            {
                javaScriptBuilder.Append(",")
                    .AppendJavaScriptObjectOpening()
                    .AppendNavigatorActionOptions(navigatorSearchActionOptions)
                    .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.WIDTH, navigatorSearchActionOptions.Width, JqGridOptionsDefaults.Navigator.SearchActionWidth)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_REDRAW, navigatorSearchActionOptions.AfterRedraw)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.AFTER_SHOW_SEARCH, navigatorSearchActionOptions.AfterShowSearch)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_SHOW_SEARCH, navigatorSearchActionOptions.BeforeShowSearch)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.CAPTION, navigatorSearchActionOptions.Caption)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_AFTER_SEARCH, navigatorSearchActionOptions.CloseAfterSearch, JqGridOptionsDefaults.Navigator.CloseAfterSearch)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_AFTER_RESET, navigatorSearchActionOptions.CloseAfterReset, JqGridOptionsDefaults.Navigator.CloseAfterReset)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.ERROR_CHECK, navigatorSearchActionOptions.ErrorCheck, JqGridOptionsDefaults.Navigator.ErrorCheck)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.SEARCH_BUTTON_TEXT, navigatorSearchActionOptions.SearchText)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.ADVANCED_SEARCHING, navigatorSearchActionOptions.AdvancedSearching, JqGridOptionsDefaults.Navigator.AdvancedSearching)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.ADVANCED_SEARCHING_WITH_GROUPS, navigatorSearchActionOptions.AdvancedSearchingWithGroups, JqGridOptionsDefaults.Navigator.AdvancedSearchingWithGroups)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLONE_SEARCH_ROW_ON_ADD, navigatorSearchActionOptions.CloneSearchRowOnAdd, JqGridOptionsDefaults.Navigator.CloneSearchRowOnAdd)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_INITIALIZE_SEARCH, navigatorSearchActionOptions.OnInitializeSearch)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_RESET, navigatorSearchActionOptions.OnReset)
                    .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_SEARCH, navigatorSearchActionOptions.OnSearch)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.RECREATE_FILTER, navigatorSearchActionOptions.RecreateFilter, JqGridOptionsDefaults.Navigator.RecreateFilter)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.RESET_BUTTON_TEXT, navigatorSearchActionOptions.ResetText)
                    .AppendSearchOperators(navigatorSearchActionOptions.SearchOperators)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.SHOW_ON_LOAD, navigatorSearchActionOptions.ShowOnLoad, JqGridOptionsDefaults.Navigator.ShowOnLoad)
                    .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.SHOW_QUERY, navigatorSearchActionOptions.ShowQuery, JqGridOptionsDefaults.Navigator.ShowQuery)
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.LAYER, navigatorSearchActionOptions.Layer);

                if ((navigatorSearchActionOptions.Templates != null) && (navigatorSearchActionOptions.Templates.Count > 0))
                {
                    javaScriptBuilder.AppendJavaScriptObjectStringArrayField(JqGridOptionsNames.Navigator.TEMPLATES_NAMES, navigatorSearchActionOptions.Templates.Keys);

                    javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.Navigator.TEMPLATES_FILTERS);
                    foreach(string templateName in navigatorSearchActionOptions.Templates.Keys)
                    {
                        javaScriptBuilder.AppendSearchingFilters(navigatorSearchActionOptions.Templates[templateName]);
                    }
                    javaScriptBuilder.AppendJavaScriptArrayFieldClosing();
                }

                javaScriptBuilder.AppendJavaScriptObjectClosing();
            }
            else
            {
                javaScriptBuilder.Append(NULL_NAVIGATOR_OPTIONS);
            }

            return javaScriptBuilder;
        }

        private static StringBuilder AppendNavigatorActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorActionOptions navigatorActionOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_ON_ESCAPE, navigatorActionOptions.CloseOnEscape, JqGridOptionsDefaults.Navigator.ActionCloseOnEscape)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.DATA_HEIGHT, navigatorActionOptions.DataHeight)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.DATA_WIDTH, navigatorActionOptions.DataWidth)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.DRAGABLE, navigatorActionOptions.Dragable, JqGridOptionsDefaults.Navigator.Dragable)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.HEIGHT, navigatorActionOptions.Height)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.LEFT, navigatorActionOptions.Left, JqGridOptionsDefaults.Navigator.Left)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.MODAL, navigatorActionOptions.Modal, JqGridOptionsDefaults.Navigator.Modal)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.ON_CLOSE, navigatorActionOptions.OnClose)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.OVERLAY, navigatorActionOptions.Overlay, JqGridOptionsDefaults.Navigator.Overlay)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.RESIZE, navigatorActionOptions.Resizable, JqGridOptionsDefaults.Navigator.Resizable)
                .AppendJavaScriptObjectIntegerField(JqGridOptionsNames.Navigator.TOP, navigatorActionOptions.Top, JqGridOptionsDefaults.Navigator.Top)
                .AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.USE_JQ_MODAL, navigatorActionOptions.UseJqModal, JqGridOptionsDefaults.Navigator.UseJqModal);
        }
        
        private static StringBuilder AppendSearchingFilters(this StringBuilder javaScriptBuilder, JqGridSearchingFilters searchingFilters)
        {
            javaScriptBuilder.AppendJavaScriptObjectOpening()
                .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.TEMPLATES_FILTERS_GROUPING_OPERATOR, searchingFilters.GroupingOperator.ToString().ToUpperInvariant());

            if ((searchingFilters.Filters != null) && (searchingFilters.Filters.Count > 0))
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.Navigator.TEMPLATES_FILTERS_RULES);
                foreach(JqGridSearchingFilter searchingFilter in searchingFilters.Filters)
                {
                    javaScriptBuilder.AppendJavaScriptObjectOpening()
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.TEMPLATES_FILTERS_RULE_FIELD, searchingFilter.SearchingName)
                        .AppendJavaScriptObjectEnumField(JqGridOptionsNames.Navigator.TEMPLATES_FILTERS_RULE_OPERATOR, searchingFilter.SearchingOperator)
                        .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.TEMPLATES_FILTERS_RULE_VALUE, searchingFilter.SearchingValue)
                        .AppendJavaScriptObjectFieldClosing();
                }
                javaScriptBuilder.AppendJavaScriptArrayFieldClosing();
            }

            if ((searchingFilters.Groups != null) && (searchingFilters.Groups.Count > 0))
            {
                javaScriptBuilder.AppendJavaScriptArrayFieldOpening(JqGridOptionsNames.Navigator.TEMPLATES_FILTERS_GROUPS);
                foreach (JqGridSearchingFilters innerSearchingFilters in searchingFilters.Groups)
                {
                    javaScriptBuilder.AppendSearchingFilters(innerSearchingFilters);
                }
                javaScriptBuilder.AppendJavaScriptArrayFieldClosing();
            }

            javaScriptBuilder.AppendJavaScriptObjectFieldClosing();

            return javaScriptBuilder;
        }
        #endregion
    }
}
