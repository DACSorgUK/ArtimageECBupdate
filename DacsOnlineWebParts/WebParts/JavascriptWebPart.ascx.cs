using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Presenters;
using WebFormsMvp;
using DacsOnline.Presentation.Views;
using CMS.GlobalHelper;
using CMS.PortalControls;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(JavascriptWebPartPresenter))]
    public partial class JavascriptWebPart : MvpUserControl, IJavascriptWebPartView
    {
        #region page event
        private JavascriptWebPartPresenter obj;
        public JavascriptWebPart()
        {
            obj = new JavascriptWebPartPresenter(this);
        }
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoadForm != null)
                    LoadForm(sender, e);
            }

        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the themes.
        /// </summary>
        public string themes
        {
            get { return ValidationHelper.GetString(this.GetValue("DacsOnlineTheme"), ""); }

        }
        #endregion
      
        #region EventHandler
        /// <summary>
        /// Occurs when [load form].
        /// </summary>
        public event EventHandler LoadForm;

        #endregion

        #region public methods
        /// <summary>
        /// Loads the form.
        /// </summary>
        void IJavascriptWebPartView.Display()
        {
            ClientScriptManager script = Page.ClientScript;

            if (!script.IsClientScriptBlockRegistered(this.GetType(), "cssClass"))
            {
                script.RegisterClientScriptBlock(this.GetType(), "cssClass", "addClass('" + themes + "')", true);

            }

        }
        #endregion

      
    }
}