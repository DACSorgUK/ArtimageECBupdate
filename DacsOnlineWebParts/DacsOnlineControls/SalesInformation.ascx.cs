using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnline.Model.Utilities;

namespace DacsOnlineWebParts.DacsOnlineControls
{
    public partial class SalesInformation : System.Web.UI.UserControl
    {
        #region //Public Properties
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
        /// Gets the sales date.
        /// </summary>
        public string SalesDate
        {
            get
            {
                return calSaleDate.Date;
                //return txtSaleDate .Text;
            }
        }

        /// <summary>
        /// Gets the refrence.
        /// </summary>
        public string Refrence
        {
            get
            {
                return txtRefrence.Text.Trim();
            }
        }

        /// <summary>
        /// Gets the name of the artist.
        /// </summary>
        /// <value>
        /// The name of the artist.
        /// </value>
        public string ArtistName
        {
            get
            {
                return txtArtistName.Text.Trim();
            }
        }

        /// <summary>
        /// Gets the date of birth.
        /// </summary>
        //public DateTime? DateOfBirth
        //{

        //    get
        //    {
        //        if (null == calDateOfBirth)
        //            return null;
        //        else
        //        {
        //            string val = calDateOfBirth.Date.Replace("dd/mm/yyyy", "");
        //            if (string.IsNullOrEmpty(val))
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                return Convert.ToDateTime(val);
        //            }
        //        }
        //    }

        //}

        ///// <summary>
        ///// Gets the date of death.
        ///// </summary>
        //public DateTime ? DateOfDeath
        //{
        //    get
        //    {
        //        if (null == calDateDeath)
        //            return null;
        //        else
        //        {
        //            string val = calDateDeath.Date.Replace("dd/mm/yyyy", "");
        //            if (string.IsNullOrEmpty(val))
        //            {
        //                return null;
        //            }
        //            else
        //            {

        //                return Convert.ToDateTime(val);
        //            }
        //        }
        //    }

        //}

        public string DateOfBirth
        {

            get
            {
                return txtDateOfBirth.Text.Trim();
            }

        }

        /// <summary>
        /// Gets the date of death.
        /// </summary>
        public string DateOfDeath
        {
            get
            {
                return txtDateDeath.Text.Trim();
            }
        }


        /// <summary>
        /// Gets the nationality.
        /// </summary>
        public string Nationality
        {
            get
            {
                return txtNationality.Text;
            }
        }

        /// <summary>
        /// Gets the title of work.
        /// </summary>
        public string TitleOfWork
        {
            get
            {
                return txtTitleOfWork.Text;
            }
        }

        /// <summary>
        /// Gets the medium.
        /// </summary>
        public string Medium
        {
            get
            {
                return txtMedium.Text;
            }
        }

        /// <summary>
        /// Gets the edition number.
        /// </summary>
        public string EditionNumber
        {
            get
            {
                return txtEditionNumber.Text;
            }
        }

        public string Dimensions
        {
            get
            {
                return txtDimensions.Text;
            }
        }

        /// <summary>
        /// Gets the sales price.
        /// </summary>
        public string SalesPrice
        {
            get
            {
                return txtSalePrice.Text;
            }
        }


        /// <summary>
        /// Gets the bought as stock.
        /// </summary>
        //public string BoughtAsStock
        //{
        //    get
        //    {
        //        return rbClaiming.SelectedValue;
        //    }
        //}
        #endregion

        #region //Form Validation
        /// <summary>
        /// Handles the ServerValidate event of the CusSaleDateValidator control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void CusSaleDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (string.IsNullOrEmpty(txtSaleDate.Text.Trim()))
            //{
            //    args.IsValid = Validation.ValidateDate(txtSaleDate.Text);
            //}
            //else
            //{
            //    args.IsValid = false;
            //}
            if (!string.IsNullOrEmpty(calSaleDate.Date.ToString()))
            {
                args.IsValid = Validation.ValidateDate(calSaleDate.Date.ToString());
            }
            else
            {
                args.IsValid = false; //Mandatory
            }
        }
        /// <summary>
        /// Handles the ServerValidate event of the cusValArtistName control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValArtistName_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (string.IsNullOrEmpty(txtArtistName.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Handles the ServerValidate event of the cusValDateOfBirth control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        //protected void cusValDateOfBirth_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true; // NOT MANDATORY

        //    if (null != txtDateOfBirth)
        //    {
        //        string val = calDateOfBirth.Date.Replace("dd/mm/yyyy", "");
        //        if (!string.IsNullOrEmpty(val))
        //        {
        //            args.IsValid = Validation.ValidateDate(val);
        //        }
        //    }
        //}

        /// <summary>
        /// Handles the ServerValidate event of the cusValDateOFDeath control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        //protected void cusValDateOFDeath_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true; // NOT MANDATORY
        //    if (null != calDateDeath)
        //    {
        //        string val = calDateDeath.Date.Replace("dd/mm/yyyy", "");
        //        if (!string.IsNullOrEmpty(val))
        //        {
        //            args.IsValid = Validation.ValidateDate(val);
        //        }
        //    }
        //}

        /// <summary>
        /// Handles the ServerValidate event of the cusValNationality control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValNationality_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(Nationality))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


        /// <summary>
        /// Handles the ServerValidate event of the cusValTitleOfWork control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValTitleOfWork_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtTitleOfWork.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


        /// <summary>
        /// Handles the ServerValidate event of the cusValSalesPrice control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValSalesPrice_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtSalePrice.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        #endregion

        #region //Public Methods
        /// <summary>
        /// Hids the panel.
        /// </summary>
        public void HidPanel()
        {
            //int count2 = i + 1;
            // LbReproduction.Text = "Reproduction " + count2;
            idProduct.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        #endregion

    }
}
