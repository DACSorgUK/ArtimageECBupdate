using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Business_Objects;
using CMS.GlobalHelper;
using System.Web.UI.HtmlControls;

namespace DacsOnlineWebParts.DacsOnlineControls
{

    public partial class CLProduct : System.Web.UI.UserControl
    {
        #region //Public properties

        string SESSION_KEY_ReproducctionList = "SessionKeyReproducctionList";


        /// <summary>
        /// Sets the link title.
        /// </summary>
        /// <value>
        /// The link title.
        /// </value>
        public string LinkTitle
        {
            set
            {
                nypEdit.Text = "Product " + value + " Show/Hide";
            }
        }

        /// <summary>
        /// Gets the title of procuct.
        /// </summary>
        public string TitleOfProcuct
        {
            get
            {
                return txtTitleOFProduct.Text.Trim();
            }

        }

        /// <summary>
        /// Gets the type of product.
        /// </summary>
        public string TypeOfProduct
        {
            get
            {
                return ddTypeOfproduct.SelectedItem.Text;
            }
        }

        /// <summary>
        /// Gets the date licence needs.
        /// </summary>
        public DateTime? DateLicenceNeeds
        {
            get
            {
                string val = txtDateLicence.Text.Replace("dd/mm/yyyy", "");
                if (string.IsNullOrEmpty(val))
                {
                    return null;
                }
                else
                {

                    return Convert.ToDateTime(val);
                }
            }
        }


        /// <summary>
        /// Gets the further information.
        /// </summary>
        public string FurtherInformation
        {
            get
            {
                return txtFutherInformation.Text.Trim();
            }
        }



        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        /// <value>
        /// The product quantity.
        /// </value>
        public string PrintRun
        {
            get
            {
                return txtPrintRun.Text.Trim();
            }
        }

        public string PrintRunDigital
        {
            get
            {
                return txtPrintRunDigital.Text.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the launct date.
        /// </summary>
        /// <value>
        /// The launct date.
        /// </value>
        public DateTime? PlannedDateOfIssue
        {
            get
            {
                string val = txtPlannedDateOfIssue.Text.Replace("dd/mm/yyyy", "");
                if (string.IsNullOrEmpty(val))
                {
                    return null;
                }
                else
                {

                    return Convert.ToDateTime(val);
                }
            }

        }


        public string UsageRightsRequired
        {
            get
            {
                //string selectedItems = String.Join(",",
                //  ckbTVRelevantRights.Items.OfType<ListItem>().Where(r => r.Selected)
                // .Select(r => r.Value));
                string selectedItems = "";
                if (ckbAllTVrights.Checked)
                {
                    selectedItems += "All TV rights,";
                }
                if (ckbStandardTV.Checked)
                {
                    selectedItems += "Standard TV,";
                }
                if (ckbNonStandardTV.Checked)
                {
                    selectedItems += "Non standard TV,";
                }
                if (ckbVideoOnDemand.Checked)
                {
                    selectedItems += "Video on demand,";
                }
                if (ckbVideogramAndDTO.Checked)
                {
                    selectedItems += "Videogram and DTO,";
                }
                if (ckbNonTheatric.Checked)
                {
                    selectedItems += "Non-theatric,";
                }


                return selectedItems.TrimEnd(',');
            }
        }

        /// <summary>
        /// Gets or sets the where item distributes.
        /// </summary>
        /// <value>
        /// The where item distributes.
        /// </value>
        public string WhereItemDistributed
        {
            get
            {
                return ddlDistributed.SelectedValue;
            }
        }

        public string Language
        {
            get
            {
                return ddlLanguage.SelectedValue;
            }
        }

        /// <summary>
        /// Gets the reproductions.
        /// </summary>
        public List<CopyRightLicencingProductReproductions> Reproductions
        {
            get
            {
                return GetReproductions();
            }
        }

        /// <summary>
        /// Gets the posted file.
        /// </summary>
        //public HttpPostedFile PostedFile
        //{
        //    get
        //    {
        //        if (FileUploadProduct.PostedFile != null)
        //            return FileUploadProduct.PostedFile;
        //        else
        //            return null;
        //    }
        //}

        public string ISBN
        {
            get
            {
                return txtISBN.Text.Trim();
            }
        }

        public string LicenceDuration
        {
            get
            {
                return ddlLicenceDuration.SelectedValue;
            }
        }

        public string Website
        {
            get
            {
                return txtWebSite.Text.Trim();
            }
        }

        public string ContextOfUseCropped
        {
            get
            {
                return ddContextOfUseCropped.SelectedItem.Value;
            }
        }

        public string ContextOfUseCover
        {
            get
            {
                return ddContextOfUseCover.SelectedItem.Value;
            }
        }


        #endregion

        #region //Page Methods

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //AddUserControal();

            }
            else
            {
                // LoadControal();

            }

            //If first time page is submitted and we have file in FileUpload control but not in session 
            // Store the values to SEssion Object 
            //if (Session[this.ID] == null && FileUploadProduct.HasFile)
            //{
            //    Session[this.ID] = FileUploadProduct;
            //    FileUploadProduct = (FileUpload)Session[this.ID];
            //}
            //// Next time submit and Session has values but FileUpload is Blank 
            //// Return the values from session to FileUpload 
            //else if (Session[this.ID] != null && (!FileUploadProduct.HasFile))
            //{
            //    FileUploadProduct = (FileUpload)Session[this.ID];

            //}
            //// Now there could be another sictution when Session has File but user want to change the file 
            //// In this case we have to change the file in session object 
            //else if (FileUploadProduct.HasFile)
            //{
            //    Session[this.ID] = FileUploadProduct;
            //    FileUploadProduct = (FileUpload)Session[this.ID];
            //}
        }
        /// <summary>
        /// Handles the Click event of the btAddReproduction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btAddReproduction_Click(object sender, EventArgs e)
        {
            //Page.Validate("ValGroupCLForm");
            if (Page.IsValid)
            {
                //this.Page.MaintainScrollPositionOnPostBack = false;
                //int i = 1;
                //foreach (Control ctrl in plcProductReproductions.Controls)
                //{
                //    CLReproductions objCtrl = (CLReproductions)ctrl;
                //    objCtrl.HidPanel();
                //    objCtrl.LinkTitleReproductions = i.ToString();
                //    i++;
                //}
                //AddUserControal();


                //  this.Page.SetFocus(btAddReproduction);

                //target.Focus();

                List<CopyRightLicencingProductReproductions> _ReproducctionList = new List<CopyRightLicencingProductReproductions>();

                foreach (Control ctrl in plcProductReproductions.Controls)
                {
                    CLReproductions objCtrl = (CLReproductions)ctrl;

                    ((HtmlGenericControl)objCtrl.FindControl("divHeader")).Visible = true;

                    ListView lvReproducctionList = (ListView)objCtrl.FindControl("lvReproducctionList");
                    //TextBox txtAtistname = (TextBox)objCtrl.FindControl("txtAtistname");
                    // DropDownList ddlAtistname = (DropDownList)objCtrl.FindControl("ddlAtistname");
                    HiddenField hdnddlAtistname = (HiddenField)objCtrl.FindControl("hdnddlAtistname");
                    HiddenField hdnddlAtistId = (HiddenField)objCtrl.FindControl("hdnddlAtistId");
                    TextBox txtTitleOfWork = (TextBox)objCtrl.FindControl("txtTitleOfWork");
                    Label lblReproductionErrorMessage = (Label)objCtrl.FindControl("lblReproductionErrorMessage");

                    //foreach (ListViewItem obj in lvReproducctionList.Items)
                    //{

                    //    if (obj.ItemType == ListViewItemType.DataItem)
                    //    {
                    //        CopyRightLicencingProductReproductions data = new CopyRightLicencingProductReproductions
                    //        {
                    //            ArtistName = ((Label)obj.FindControl("lblAtistname")).Text,
                    //            TitleOfWork = ((Label)obj.FindControl("lblTitleOfWork")).Text
                    //        };

                    //        _ReproducctionList.Add(data);
                    //    }

                    //}

                    if (Session[SESSION_KEY_ReproducctionList] != null)
                    {
                        _ReproducctionList = (List<CopyRightLicencingProductReproductions>)Session[SESSION_KEY_ReproducctionList];
                    }

                    CopyRightLicencingProductReproductions item = new CopyRightLicencingProductReproductions
                    {
                        Id = hdnddlAtistId.Value,
                        ArtistName = hdnddlAtistname.Value,
                        TitleOfWork = txtTitleOfWork.Text.Trim()
                    };

                   // var alreadyExist = _ReproducctionList.Where(x => x.ArtistName == item.ArtistName).SingleOrDefault();

                    if (!string.IsNullOrEmpty(item.ArtistName) && !string.IsNullOrEmpty(item.TitleOfWork))
                    {
                       // if (alreadyExist == null)
                        {
                            _ReproducctionList.Add(item);
                            Session[SESSION_KEY_ReproducctionList] = _ReproducctionList;

                            lvReproducctionList.DataSource = _ReproducctionList;
                            lvReproducctionList.DataBind();

                            txtTitleOfWork.Text = hdnddlAtistname.Value = "";
                            lblReproductionErrorMessage.Text = "";
                        }
                        //else
                        //{
                        //    lblReproductionErrorMessage.Text = "Already added in the list.";
                        //}
                    }
                    else
                    {
                        lblReproductionErrorMessage.Text = "Please select artist / enter artwork from the list.";
                    }
                }
            }
            else
            {
                // SetScrollPosition(); //Comented the Code Need to Set default error message
            }

        }

        protected void ddTypeOfproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valSelected = ddTypeOfproduct.SelectedValue;

            divISBN.Visible = false;
            divPrintRun.Visible = false;
            divPrintRunDigital.Visible = false;
            divWebSite.Visible = false;
            divLicenceDuration.Visible = false;
            divUsage.Visible = false;
            divLanguage.Visible = false;

            if (valSelected == "Advertisment")
            {
                divWebSite.Visible = true;
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
            }
            else if (valSelected == "Book")
            {
                divISBN.Visible = true;
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
                divLanguage.Visible = true;

            }
            else if (valSelected == "Catalogue")
            {
                divISBN.Visible = true;
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
                divLanguage.Visible = true;
            }
            else if (valSelected == "DigitalProducts")
            {
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
                divWebSite.Visible = true;
            }
            else if (valSelected == "Magazine")
            {
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
                divWebSite.Visible = true;
            }
            else if (valSelected == "MLP")
            {
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
                divWebSite.Visible = true;
            }
            else if (valSelected == "Merchandise")
            {
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
            }
            else if (valSelected == "Newspaper")
            {
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
                divWebSite.Visible = true;
            }
            else if (valSelected == "Other")
            {
                divPrintRun.Visible = true;
                divPrintRunDigital.Visible = true;
                divWebSite.Visible = true;
            }
            else if (valSelected == "TFV")
            {
                divWebSite.Visible = true;
                divLicenceDuration.Visible = true;
                divUsage.Visible = true;
                divLanguage.Visible = true;
            }
            else if (valSelected == "Website")
            {
                divWebSite.Visible = true;
            }
        }

        #endregion

        #region //Form Validation
        /// <summary>
        /// Handles the ServerValidate event of the cusValtxtTitleOFProduct control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValtxtTitleOFProduct_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtTitleOFProduct.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        protected void cusvalPrintRun_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string val = txtPrintRun.Text.Trim();
            if (!string.IsNullOrEmpty(val))
            {
                if (!val.All(c => "0123456789".Contains(c)))
                    args.IsValid = false;
            }
        }

        protected void cusvalPrintRunDigital_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string val = txtPrintRunDigital.Text.Trim();
            if (!string.IsNullOrEmpty(val))
            {
                if (!val.All(c => "0123456789".Contains(c)))
                    args.IsValid = false;
            }
        }

        protected void cusvalDateLicence_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string val = txtDateLicence.Text.Replace("dd/mm/yyyy", "");
            if (!string.IsNullOrEmpty(txtDateLicence.Text))
            {

                args.IsValid = Validation.ValidateDate(val);
            }
            else
            {
                args.IsValid = false;//Mandatory
            }



        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValPlanneddate control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValPlanneddate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string valSelected = ddTypeOfproduct.SelectedValue;
            string val = txtPlannedDateOfIssue.Text.Replace("dd/mm/yyyy", "");
            if (valSelected == "Website" || valSelected == "AGD" || valSelected == "Live Event" ||
                  valSelected == "Advertisment")
            {
                if (!string.IsNullOrEmpty(val))
                {
                    args.IsValid = Validation.ValidateDate(val);
                }
                else
                {
                    args.IsValid = true;//not Mandatory
                }
            }
            else
            {
                args.IsValid = true;//not Mandatory
            }


        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValddTypeOfproduct control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValddTypeOfproduct_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddTypeOfproduct.SelectedValue == "-1")
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

        protected void cusValtxtISBN_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtISBN.Text.Trim().Length != 13)
            {
                args.IsValid = false;
            }
        }

        protected void cusValWebSite_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtWebSite.Text.Trim()))
            {
                args.IsValid = Validation.ValidateWebsite(txtWebSite.Text.Trim());
            }
        }

        protected void cusValLicenceDuration_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (ddTypeOfproduct.SelectedValue == "TFV")
                if (ddlLicenceDuration.SelectedValue == "-1")
                {
                    args.IsValid = false;
                }

        }

        protected void cusValddContextOfUseCropped_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddContextOfUseCropped.SelectedValue == "-1")
            {
                args.IsValid = false;
            }

        }
        protected void cusValddContextOfUseCover_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddContextOfUseCover.SelectedValue == "-1")
            {
                args.IsValid = false;
            }

        }
        #endregion

        #region //LoadDynamicControl
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        private int count
        {
            set
            {
                ViewState[this.ID] = value;
            }
            get
            {
                if (ViewState[this.ID] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)ViewState[this.ID];
                }
            }
        }

        /// <summary>
        /// Adds the user controal.
        /// </summary>
        //private void AddUserControal()
        //{
        //    CLReproductions con = (CLReproductions)LoadControl("~/CMSWebParts/DacsOnlineControls/CLReproductions.ascx");
        //    con.ID = count + "CLProductReproductions";
        //    //TextBox artistName = (TextBox)con.FindControl("txtAtistname");
        //    //TextBox title = (TextBox)con.FindControl("txtTitleOfWork");
        //    int count2 = count + 1;
        //    //Label lbReproduction = new Label();
        //    //lbReproduction.ID = count2 + "lbReproduction";
        //    //lbReproduction.Text = "Reproduction " + count2;
        //    //plcProductReproductions.Controls.Add(lbReproduction);
        //    con.LinkTitleReproductions = (count2 + 1).ToString();
        //    plcProductReproductions.Controls.Add(con);
        //    count = count + 1;

        //}


        /// <summary>
        /// Loads the controal.
        /// </summary>
        //private void LoadControal()
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        CLReproductions con = (CLReproductions)LoadControl("~/CMSWebParts/DacsOnlineControls/CLReproductions.ascx");
        //        con.ID = i + "CLProductReproductions";
        //        con.LinkTitleReproductions = (i + 2).ToString();
        //        plcProductReproductions.Controls.Add(con);

        //    }
        //}


        #endregion

        #region //Private Methods

        /// <summary>
        /// Sets the scroll position.
        /// </summary>
        private void SetScrollPosition()
        {
            this.Page.MaintainScrollPositionOnPostBack = false;
            // find the first validator that failed
            foreach (IValidator validator in this.Page.GetValidators("ValGroupCLForm"))
            {
                if (validator is BaseValidator && !validator.IsValid)
                {
                    BaseValidator bv = (BaseValidator)validator;

                    // look up the control that failed validation
                    Control target =
                        bv.NamingContainer.FindControl(bv.ControlToValidate);

                    // set the focus to it
                    if (target != null)
                    {
                        this.Page.SetFocus(target);

                        //target.Focus();
                    }

                    break;
                }
            }

            //this.Page.MaintainScrollPositionOnPostBack = true;
        }
        /// <summary>
        /// Gets the reproductions.
        /// </summary>
        /// <returns></returns>
        //private List<CopyRightLicencingProductReproductions> GetReproductions()
        //{
        //    List<CopyRightLicencingProductReproductions> list = new List<CopyRightLicencingProductReproductions>();
        //    foreach (Control ctrl in plcProductReproductions.Controls)
        //    {
        //        CLReproductions objCtrl = (CLReproductions)ctrl;
        //        CopyRightLicencingProductReproductions obj = new CopyRightLicencingProductReproductions();
        //        obj.ArtistName = objCtrl.ArtistName;
        //        //obj.ContextOfUse = objCtrl.ContextOfUse;
        //        //ContextOfUseCropped = objCtrl.ContextOfUseCropped;
        //        //ContextOfUseCover = objCtrl.ContextOfUseCover;
        //        obj.TitleOfWork = objCtrl.TitleOfWork;
        //       // obj.PostedFile = objCtrl.PostedFile;
        //        //// obj.DepictedWork = objCtrl.DepictedWork;
        //        list.Add(obj);
        //    }

        //    return list;
        //}
        #endregion

        #region //Public Method
        /// <summary>
        /// Hids the panel.
        /// </summary>
        public void HidPanel()
        {
            // int count2 = count + 1;
            // Lbproduct.Text = "Product " + count2;           
            idProduct.Style.Add(HtmlTextWriterStyle.Display, "none");

        }

        private List<CopyRightLicencingProductReproductions> GetReproductions()
        {
            List<CopyRightLicencingProductReproductions> list = new List<CopyRightLicencingProductReproductions>();

            foreach (Control ctrl in plcProductReproductions.Controls)
            {
                CLReproductions objCtrl = (CLReproductions)ctrl;

                //ListView lvReproducctionList = (ListView)objCtrl.FindControl("lvReproducctionList");
                string txtAtistname = objCtrl.ArtistName;// (TextBox)objCtrl.FindControl("txtAtistname");
                TextBox txtTitleOfWork = (TextBox)objCtrl.FindControl("txtTitleOfWork");
                string txtAtistId = objCtrl.ArtistId;

                //foreach (ListViewItem obj in lvReproducctionList.Items)
                //{

                //    if (obj.ItemType == ListViewItemType.DataItem)
                //    {
                //        CopyRightLicencingProductReproductions data = new CopyRightLicencingProductReproductions
                //        {
                //            ArtistName = ((Label)obj.FindControl("lblAtistname")).Text,
                //            TitleOfWork = ((Label)obj.FindControl("lblTitleOfWork")).Text
                //        };

                //        list.Add(data);
                //    }
                //}

                if (Session[SESSION_KEY_ReproducctionList] != null)
                {
                    list = (List<CopyRightLicencingProductReproductions>)Session[SESSION_KEY_ReproducctionList];
                }

                if (list.Count == 0)
                {
                    CopyRightLicencingProductReproductions item = new CopyRightLicencingProductReproductions
                    {
                        ArtistName = txtAtistname.Trim(),
                        TitleOfWork = txtTitleOfWork.Text.Trim(),
                        Id = txtAtistId.Trim()
                    };

                    list.Add(item);
                }

            }






            return list;
        }



        #endregion


    }
}

