using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DacsOnline.Presentation.Views;
using DacsOnline.Presentation.Presenters;
using WebFormsMvp;
using WebFormsMvp.Web;
using CMS.GlobalHelper;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Models;

namespace DacsOnlineWebParts.WebParts
{
    [PresenterBinding(typeof(ArtistDetailsPresenter))]
    public partial class ArtistDetails : MvpUserControl, IArtistDetailsView
    {
        public string ImageHireMessage { get; set; }

        #region // PageEvents
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageOnLoad != null)
            {
                PageOnLoad(sender, e);
            }

        }
        #endregion

        #region //Public Properties
        
        public new void Load(ArtistCombined artist)
        {
            if (artist != null)
            {
                lbFirstName.Text = artist.FirstName;  //  artist.FirstName;
                lbFirstName2.Text = artist.FirstName;
                lbLastName.Text = artist.LastName + (artist.FirstName.Trim() == "" || artist.LastName.ToString().Trim() == "" ? "" : ",");
                lbLastName2.Text = artist.LastName + (artist.FirstName.Trim() == "" || artist.LastName.ToString().Trim() == "" ? "" : ",");
                lbPseudonyms.Text = artist.Pseudonyms;

                if (string.IsNullOrWhiteSpace(artist.Nationality))
                {
                    lbNationality.Text = "Unknown";
                }
                else
                {
                    lbNationality.Text = artist.Nationality;
                }

                if (!string.IsNullOrWhiteSpace(artist.DateOfDeath))
                {
                    lblDateOfBirth.Text = artist.DateOfBirth == string.Empty ? "Not Defined - " : artist.DateOfBirth;
                    lblDateofDeath.Text = artist.DateOfDeath == string.Empty ? " - Not Defined" : "- " + artist.DateOfDeath;
                }
                else
                {
                    phLived.Visible = false;
                }


                ltlCLRepresentationMessage.Text = artist.CLRepresentationMessage;
                ltlCLServiceDurationMessage.Text = artist.CLServiceDurationMessage;
                liServiceDurationMessage.Visible = String.IsNullOrEmpty(artist.CLServiceDurationMessage) ? false : true;
                ltlCLConsultMessage.Text = artist.CLMoreInfoMessage_1;
                liCLConsultMessage.Visible = String.IsNullOrEmpty(artist.CLMoreInfoMessage_1) ? false : true;
                ltlCLContextMessage.Text = artist.CLMoreInfoMessage_2;
                liCLContextMessage.Visible = String.IsNullOrEmpty(artist.CLMoreInfoMessage_2) ? false : true;
                ImageHireMessage = artist.CLImageHireMessage;
                //ltlCLImageMessage.Text = artist.CLImageHireMessage;
                //liCLImageMessage.Visible = String.IsNullOrEmpty(artist.CLImageHireMessage) ? false : true;
                hrefCLApply.Visible = artist.CLShowApplyFor;

                if (artist.CLShowApplyFor)
                {
                    ltlCLOnlyMessage.Text = artist.CLArtistDetailsMessage.Replace("*url*", ApplyCL_URL);
                    hrefCLApply.Visible = true;
                    divhrefCLApply.Visible = true;
                }
                else
                {
                    ltlCLOnlyMessage.Text = artist.CLArtistDetailsMessage;
                    hrefCLApply.Visible = false;
                    divhrefCLApply.Visible = false;
                }

                liCLOnlyMessage.Visible = String.IsNullOrEmpty(artist.CLArtistDetailsMessage) ? false : true;
                ltlEligibilityMessage.Text = artist.ARREligibilityMessage;
                ltlMandateMessage.Text = artist.ARRMandateMessage;
                liMandateMessage.Visible = String.IsNullOrEmpty(artist.ARRMandateMessage) ? false : true;
                ltlPaymentMessage.Text = artist.ARRPaymentMessage;
                liPaymentMessage.Visible = String.IsNullOrEmpty(artist.ARRPaymentMessage) ? false : true;
                if (artist.DisplayArr)
                {
                    hrefARRApply.Visible = true;
                    divhrefARRApply.Visible = true;
                }
                else
                {
                    hrefARRApply.Visible = false;
                    divhrefARRApply.Visible = false;
                }
            }
        }

        #endregion

        #region //Event Handler
        public event EventHandler PageOnLoad;
        #endregion

        #region //Properties
        public string idArtist
        {

            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["ArtistId"]))
                    return string.Empty;
                else
                {
                    return Request.QueryString["ArtistId"].ToString();

                }

            }
            set
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Gets the artist details URL.
        /// </summary>
        public string ApplyCL_URL
        {
            get { return ValidationHelper.GetString(this.GetValue("ApplyCL_URL"), ""); }
        }


        /// <summary>
        /// Gets the CL calculator URL.
        /// </summary>
        public string ApplyARR_URL
        {
            get { return ValidationHelper.GetString(this.GetValue("ApplyARR_URL"), ""); }
        }

        #endregion
    }
}