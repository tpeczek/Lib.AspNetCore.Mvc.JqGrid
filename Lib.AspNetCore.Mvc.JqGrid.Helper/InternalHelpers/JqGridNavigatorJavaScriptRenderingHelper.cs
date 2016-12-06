using Lib.AspNetCore.Mvc.JqGrid.Helper.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;
using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.AspNetCore.Mvc.JqGrid.Helper.InternalHelpers
{
    internal static class JqGridNavigatorJavaScriptRenderingHelper
    {
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

        internal static StringBuilder AppendNavigatorEditActionOptions(this StringBuilder javaScriptBuilder, string fieldName, JqGridNavigatorEditActionOptions navigatorEditActionOptions)
        {
            if ((navigatorEditActionOptions != null) && !navigatorEditActionOptions.AreDefault())
            {
                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.AppendJavaScriptObjectOpening();
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
                    .AppendJavaScriptObjectStringField(JqGridOptionsNames.Navigator.TOP_INFO, navigatorEditActionOptions.TopInfo)
                    .AppendJavaScriptObjectFieldClosing();
            }

            return javaScriptBuilder;
        }

        internal static StringBuilder AppendNavigatorDeleteActionOptions(this StringBuilder javaScriptBuilder, string fieldName, JqGridNavigatorDeleteActionOptions navigatorDeleteActionOptions)
        {
            if ((navigatorDeleteActionOptions != null) && !navigatorDeleteActionOptions.AreDefault())
            {
                if (String.IsNullOrWhiteSpace(fieldName))
                {
                    javaScriptBuilder.AppendJavaScriptObjectOpening();
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
                    .AppendFormButtonIcon(JqGridOptionsNames.Navigator.CANCEL_ICON, navigatorDeleteActionOptions.CancelButtonIcon, JqGridFormButtonIcon.CancelIcon)
                    .AppendJavaScriptObjectFieldClosing();
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

        private static StringBuilder AppendNavigatorFormActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorFormActionOptions navigatorFormActionOptions)
        {
            javaScriptBuilder.AppendNavigatorActionOptions(navigatorFormActionOptions);

            return javaScriptBuilder.AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_INIT_DATA, navigatorFormActionOptions.BeforeInitData)
                .AppendJavaScriptObjectFunctionField(JqGridOptionsNames.Navigator.BEFORE_SHOW_FORM, navigatorFormActionOptions.BeforeShowForm);
        }

        private static StringBuilder AppendNavigatorPageableFormActionOptions(this StringBuilder javaScriptBuilder, IJqGridNavigatorPageableFormActionOptions navigatorPageableFormActionOptions)
        {
            if ((navigatorPageableFormActionOptions.NavigationKeys != null) && navigatorPageableFormActionOptions.NavigationKeys.IsDefault())
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

        private static StringBuilder AppendNavigatorActionOptions(this StringBuilder javaScriptBuilder, JqGridNavigatorActionOptions navigatorActionOptions)
        {
            return javaScriptBuilder.AppendJavaScriptObjectBooleanField(JqGridOptionsNames.Navigator.CLOSE_ON_ESCAPE, navigatorActionOptions.CloseOnEscape, JqGridOptionsDefaults.Navigator.CloseOnEscape)
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
        #endregion
    }
}
