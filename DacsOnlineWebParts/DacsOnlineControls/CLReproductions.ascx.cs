using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DacsOnlineWebParts.DacsOnlineControls
{
    public partial class CLReproductions : System.Web.UI.UserControl
    {
        #region //Public Properties
        /// <summary>
        /// Sets the link title.
        /// </summary>
        /// <value>
        /// The link title.
        /// </value>
        //public string LinkTitleReproductions
        //{
        //    set
        //    {
        //        nypEdit.Text = "Reproduction " + value + " Edit";
        //    }
        //}
        public string ArtistId
        {
            get
            {

                //return hdnddlAtistname.Value.Trim();
                // return ddlAtistname.SelectedValue.Trim();
                return hdnddlAtistId.Value.Trim();
            }

        }

        public string ArtistName
        {
            get
            {

                return hdnddlAtistname.Value.Trim();
               // return ddlAtistname.SelectedValue.Trim();
            }

        }

        /// <summary>
        /// Gets or sets the title of work.
        /// </summary>
        /// <value>
        /// The title of work.
        /// </value>
        public string TitleOfWork
        {
            get
            {

                return txtTitleOfWork.Text.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the context of use.
        /// </summary>
        /// <value>
        /// The context of use.
        /// </value>
        //public List<string> ContextOfUse
        //{

        //    get
        //    {
        //        List<string> obj = new List<string>();
        //        foreach (ListItem item in chkContextofWork.Items)
        //        {
        //            if (item.Selected)
        //            {
        //                obj.Add(item.Value);
        //            }
        //        }

        //        return obj;
        //    }
        //}

        /// <summary>
        /// Gets the posted file.
        /// </summary>btOpenFileUploadReproductions
        //public HttpPostedFile PostedFile
        //{
        //    get
        //    {
        //        if (FileUploadReproduction.PostedFile != null)
        //            return FileUploadReproduction.PostedFile;
        //        else
        //            return null;
        //    }
        //}

        //public string ContextOfUseCropped
        //{
        //    get
        //    {
        //        return ddContextOfUseCropped.SelectedItem.Value;
        //    }
        //}

        //public string ContextOfUseCover
        //{
        //    get
        //    {
        //        return ddContextOfUseCover.SelectedItem.Value;
        //    }
        //}

        /// <summary>
        /// Gets the depicted work.
        /// </summary>
        ////public string DepictedWork
        ////{
        ////    get
        ////    {
        ////        return txtDepictedWork.Text.Trim();
        ////    }
        ////}
        #endregion

        #region //Form Vlaidation
        /// <summary>
        /// Handles the ServerValidate event of the cusValtxtAtistname control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValtxtAtistname_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (lvReproducctionList.Items.Count == 0)
                if (string.IsNullOrEmpty(ddlAtistname.SelectedValue.Trim()))
                {
                    args.IsValid = false;
                }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValtxtTitleOfWork control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValtxtTitleOfWork_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (lvReproducctionList.Items.Count == 0)
                if (string.IsNullOrEmpty(txtTitleOfWork.Text.Trim()))
                {
                    args.IsValid = false;
                }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValFileValidator control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        //protected void cusValFileValidator_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (PostedFile.ContentLength > (1024 * 1024 * 10))
        //    {
        //        args.IsValid = false;
        //    }

        //}


        #endregion

        #region //Form Methods
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    //If first time page is submitted and we have file in FileUpload control but not in session 
        //    // Store the values to SEssion Object 
        //    if (Session[this.ID] == null && FileUploadReproduction.HasFile)
        //    {
        //        Session[this.ID] = FileUploadReproduction;
        //        FileUploadReproduction = (FileUpload)Session[this.ID];
        //    }
        //    // Next time submit and Session has values but FileUpload is Blank 
        //    // Return the values from session to FileUpload 
        //    else if (Session[this.ID] != null && (!FileUploadReproduction.HasFile))
        //    {
        //        FileUploadReproduction = (FileUpload)Session[this.ID];

        //    }
        //    // Now there could be another sictution when Session has File but user want to change the file 
        //    // In this case we have to change the file in session object 
        //    else if (FileUploadReproduction.HasFile)
        //    {
        //        Session[this.ID] = FileUploadReproduction;
        //        FileUploadReproduction = (FileUpload)Session[this.ID];
        //    }
        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Session["SessionKeyReproducctionList"] != null)
                {
                    var reproducctionList = (List<CopyRightLicencingProductReproductions>)Session["SessionKeyReproducctionList"];
                    lvReproducctionList.DataSource = reproducctionList;
                    lvReproducctionList.DataBind();
                    divHeader.Visible = true;
                }
            }

        }

        protected void lvReproducctionList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("DeleteArtwork"):
                    string reproducctionId = e.CommandArgument.ToString();

                    if (Session["SessionKeyReproducctionList"] != null)
                    {
                        var reproducctionList = (List<CopyRightLicencingProductReproductions>)Session["SessionKeyReproducctionList"];

                        var removeItem = reproducctionList.Where(x => x.Id == reproducctionId).SingleOrDefault();
                        if (removeItem != null)
                        {
                            reproducctionList.Remove(removeItem);
                            lvReproducctionList.DataSource = reproducctionList;
                            lvReproducctionList.DataBind();
                            divHeader.Visible = true;
                        }
                    }

                    break;
            }
        }

        #endregion

        #region //Public Method
        /// <summary>
        /// Hids the panel.
        /// </summary>
        /// <param name="i">The i.</param>
        //public void HidPanel()
        //{
        //    //int count2 = i + 1;
        //    // LbReproduction.Text = "Reproduction " + count2;
        //    reproductionBig.Style.Add(HtmlTextWriterStyle.Display, "none");
        //    lbArtistName.Text = ArtistName;
        //    LbTitlework.Text = TitleOfWork;
        //    //lbReproductionNumber.Text = "Reproduction " + count2;
        //    reproducctionsmall.Style.Add(HtmlTextWriterStyle.Display, "block");

        //}
        #endregion





    }
}

