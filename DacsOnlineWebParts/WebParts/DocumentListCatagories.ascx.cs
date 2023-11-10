using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Views;
using WebFormsMvp;
using DacsOnline.Presentation.Presenters;
using CMS.GlobalHelper;
using System.Web.UI.HtmlControls;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(DocumentListPresenter))]
    public partial class DocumentListCatagories : MvpUserControl, IDocumentListView
    {
        #region //Page Methods
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoadData != null)
            {
                LoadData(sender, e);
            }
        }
        #endregion

        #region //Event Handlers
        /// <summary>
        /// Occurs when [load data].
        /// </summary>
        public event EventHandler LoadData;
        #endregion

        #region Public Methods

        /// <summary>
        /// Displays the specified documents that belong to a form.
        /// </summary>
        /// <param name="list">The list.</param>
        public void Display(List<string> list)
        {
            RepeterDocument.DataSource = list;
            RepeterDocument.DataBind();
        }

        #endregion

        #region //Public Propeties
        /// <summary>
        /// Gets the artist details URL.
        /// </summary>
        public string DocumentCatogeryUrl
        {
            get
            {
                return ValidationHelper.GetString(this.GetValue("DocumentCatogeryUrl"), "");
            }
        }


        /// <summary>
        /// Gets the selected document catogery.
        /// </summary>
        public string SelectedDocumentCatogery
        {
            get
            {
                if (Request.QueryString["category"] != null)
                {
                   string []arr= Request.QueryString["category"].ToString().Split('|');
                   if (arr.Count() > 0)
                   {
                       return arr[0];
                   }
                   else
                   {
                       return "Latest News";
                   }
                }
                else
                {
                    return "Latest News";
                }
            }
        }
        #endregion

        /// <summary>
        /// Handles the ItemDataBound event of the RepeterArtist control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void RepeterDocument_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string dataItem = (string)e.Item.DataItem;
            if (dataItem.Trim().Contains(SelectedDocumentCatogery.Trim()))
            {
              HtmlGenericControl ctrl=  (HtmlGenericControl) e.Item.FindControl("hrefId");
              if (ctrl != null)
              {
                  ctrl.Attributes["class"] = "highlighted"; 

              }
            }



        }
    }

      

   
}