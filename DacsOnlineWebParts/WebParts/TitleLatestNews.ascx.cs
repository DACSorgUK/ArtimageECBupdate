using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnline.Presentation.Views;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Presenters;
using WebFormsMvp;
using DacsOnline.Model.Utilities;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(NewstitlePresenter))]
    public partial class TitleLatestNews : MvpUserControl, INewsTitleView
    {

        #region event Handler
        public event EventHandler Load;
        #endregion
        #region //Public Propeties
        /// <summary>
        /// Gets the artist details URL.
        /// </summary>
        public string Category
        {
           get
            {
                if (Request.QueryString["category"] != null)
                    return Request.QueryString["category"].ToString();
                else
                    return HttpContext.GetGlobalResourceObject(ConstantDataArtistSearch.ArtistResourceFile, "DefaultCategory") as string;

            }
        }


        /// <summary>
        /// Gets the title news.
        /// </summary>
        public string TitleNews
        {
            get
            {
                if (Request.QueryString["title"] != null)
                    return Request.QueryString["title"].ToString();
                else
                    return "N";

            }
            
        }
        #endregion

        #region page events
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Load != null)
            {
                Load(sender, e);
            }

        }
        #endregion

        #region public methodsS
        /// <summary>
        /// Showtitles this instance.
        /// </summary>
        public void Showtitle()
        {
            if (!string.IsNullOrEmpty(TitleNews))
            {
                if (TitleNews == "N")
                    divtitle.Visible = false;
                else
                {
                    divtitle.Visible = true;
                    lbTitle.Text = Category;
                }
            }
            else if (!string.IsNullOrEmpty(TitleNews) && !string.IsNullOrEmpty(Category))
            {
                divtitle.Visible = true;
                lbTitle.Text = Category;
            }
               
        }

#endregion
    }
}