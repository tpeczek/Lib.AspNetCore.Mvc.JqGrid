using Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Constants;

namespace Lib.AspNetCore.Mvc.JqGrid.Infrastructure.Options.Navigator
{
    /// <summary>
    /// Class which represents options for jqGrid Navigator view action.
    /// </summary>
    public class JqGridNavigatorViewActionOptions : JqGridNavigatorFormActionOptions, IJqGridNavigatorPageableFormActionOptions
    {
        #region Properties
        /// <summary>
        /// Gets or sets the options for keyboard navigation.
        /// </summary>
        public JqGridFormKeyboardNavigation NavigationKeys { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the pager buttons should appear on the form.
        /// </summary>
        public bool ViewPagerButtons { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the form should be recreated every time the dialog is activeted with the new options from colModel (if they are changed).
        /// </summary>
        public bool RecreateForm { get; set; }

        /// <summary>
        /// Gets or sets the value which defines how much width is needed for the labels.
        /// </summary>
        public string LabelsWidth { get; set; }

        /// <summary>
        /// Gets or sets the icon for the close button.
        /// </summary>
        public JqGridFormButtonIcon CloseButtonIcon { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the JqGridNavigatorViewActionOptions class.
        /// </summary>
        public JqGridNavigatorViewActionOptions()
        {
            Width = JqGridOptionsDefaults.Navigator.ViewActionWidth;
            NavigationKeys = new JqGridFormKeyboardNavigation();
            ViewPagerButtons = JqGridOptionsDefaults.Navigator.ViewPagerButtons;
            RecreateForm = JqGridOptionsDefaults.Navigator.RecreateForm;
            LabelsWidth = JqGridOptionsDefaults.Navigator.LabelsWidth;
            CloseButtonIcon = JqGridFormButtonIcon.CloseIcon;
        }
        #endregion
    }
}
