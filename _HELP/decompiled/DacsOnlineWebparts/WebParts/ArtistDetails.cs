using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Model.Models;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(ArtistDetailsPresenter))]
	public class ArtistDetails : MvpUserControl, IArtistDetailsView, IView
	{
		protected Label lbLastName;

		protected Label lbFirstName;

		protected Label lbLastName2;

		protected Label lbFirstName2;

		protected Label lbPseudonyms;

		protected Label lbNationality;

		protected Label lblDateOfBirth;

		protected Label lblDateofDeath;

		protected Literal ltlCLRepresentationMessage;

		protected HtmlGenericControl liCLOnlyMessage;

		protected Literal ltlCLOnlyMessage;

		protected HtmlGenericControl liServiceDurationMessage;

		protected Literal ltlCLServiceDurationMessage;

		protected HtmlGenericControl liCLConsultMessage;

		protected Literal ltlCLConsultMessage;

		protected HtmlGenericControl liCLContextMessage;

		protected Literal ltlCLContextMessage;

		protected HtmlGenericControl liCLImageMessage;

		protected Literal ltlCLImageMessage;

		protected HtmlGenericControl divhrefCLApply;

		protected HtmlAnchor hrefCLApply;

		protected Literal ltlEligibilityMessage;

		protected HtmlGenericControl liMandateMessage;

		protected Literal ltlMandateMessage;

		protected HtmlGenericControl liPaymentMessage;

		protected Literal ltlPaymentMessage;

		protected HtmlGenericControl liWarningMessage;

		protected Literal ltlWarningMessage;

		protected HtmlGenericControl divhrefARRApply;

		protected HtmlAnchor hrefARRApply;

		public string ApplyARR_URL
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ApplyARR_URL"), "");
			}
		}

		public string ApplyCL_URL
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("ApplyCL_URL"), "");
			}
		}

		public string idArtist
		{
			get
			{
				string str;
				str = (!string.IsNullOrEmpty(base.Request.QueryString["ArtistId"]) ? base.Request.QueryString["ArtistId"].ToString() : string.Empty);
				return str;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string YearSale
		{
			get
			{
				string str;
				str = (!string.IsNullOrEmpty(base.Request.QueryString["YearSale"]) ? base.Request.QueryString["YearSale"].ToString() : DateTime.Now.Year.ToString());
				return str;
			}
			set
			{
				this.YearSale = value;
			}
		}

		public ArtistDetails()
		{
		}

		public void Load(ArtistCombined artist)
		{
			if (artist != null)
			{
				this.lbFirstName.Text = artist.FirstName;
				this.lbFirstName2.Text = artist.FirstName;
				this.lbLastName.Text = string.Concat(artist.LastName, (artist.FirstName.Trim() == "" || artist.LastName.ToString().Trim() == "" ? "" : ","));
				this.lbLastName2.Text = string.Concat(artist.LastName, (artist.FirstName.Trim() == "" || artist.LastName.ToString().Trim() == "" ? "" : ","));
				this.lbPseudonyms.Text = artist.Pseudonyms;
				this.lbNationality.Text = artist.Nationality;
				this.lblDateOfBirth.Text = (artist.DateOfBirth == string.Empty ? "Not Defined - " : string.Concat(artist.DateOfBirth, " - "));
				this.lblDateofDeath.Text = (artist.DateOfDeath == string.Empty ? "Not Defined" : artist.DateOfDeath);
				this.ltlCLRepresentationMessage.Text = artist.CLRepresentationMessage;
				this.ltlCLServiceDurationMessage.Text = artist.CLServiceDurationMessage;
				this.liServiceDurationMessage.Visible = (string.IsNullOrEmpty(artist.CLServiceDurationMessage) ? false : true);
				this.ltlCLConsultMessage.Text = artist.CLMoreInfoMessage_1;
				this.liCLConsultMessage.Visible = (string.IsNullOrEmpty(artist.CLMoreInfoMessage_1) ? false : true);
				this.ltlCLContextMessage.Text = artist.CLMoreInfoMessage_2;
				this.liCLContextMessage.Visible = (string.IsNullOrEmpty(artist.CLMoreInfoMessage_2) ? false : true);
				this.ltlCLImageMessage.Text = artist.CLImageHireMessage;
				this.liCLImageMessage.Visible = (string.IsNullOrEmpty(artist.CLImageHireMessage) ? false : true);
				this.hrefCLApply.Visible = artist.CLShowApplyFor;
				if (!artist.CLShowApplyFor)
				{
					this.ltlCLOnlyMessage.Text = artist.CLArtistDetailsMessage;
					this.hrefCLApply.Visible = false;
					this.divhrefCLApply.Visible = false;
				}
				else
				{
					this.ltlCLOnlyMessage.Text = artist.CLArtistDetailsMessage.Replace("*url*", this.ApplyCL_URL);
					this.hrefCLApply.Visible = true;
					this.divhrefCLApply.Visible = true;
				}
				this.liCLOnlyMessage.Visible = (string.IsNullOrEmpty(artist.CLArtistDetailsMessage) ? false : true);
				this.ltlEligibilityMessage.Text = artist.ARREligibilityMessage;
				this.ltlMandateMessage.Text = artist.ARRMandateMessage;
				this.liMandateMessage.Visible = (string.IsNullOrEmpty(artist.ARRMandateMessage) ? false : true);
				this.ltlPaymentMessage.Text = artist.ARRPaymentMessage;
				this.liPaymentMessage.Visible = (string.IsNullOrEmpty(artist.ARRPaymentMessage) ? false : true);
				if (!artist.DisplayArr)
				{
					this.hrefARRApply.Visible = false;
					this.divhrefARRApply.Visible = false;
				}
				else
				{
					this.hrefARRApply.Visible = true;
					this.divhrefARRApply.Visible = true;
				}
				this.ltlWarningMessage.Text = artist.WarningMesssage;
				this.liWarningMessage.Visible = (string.IsNullOrEmpty(artist.WarningMesssage) ? false : true);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.PageOnLoad != null)
			{
				this.PageOnLoad(sender, e);
			}
		}

		public event EventHandler PageOnLoad;
	}
}