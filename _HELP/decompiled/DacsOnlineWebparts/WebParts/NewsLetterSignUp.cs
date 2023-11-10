using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(NewsLetterSignUpPresenter))]
	public class NewsLetterSignUp : MvpUserControl, INewsLetterSignUpView, IView
	{
		protected HtmlGenericControl signup;

		protected TextBox TxtFirstName;

		protected TextBox TxtSecondName;

		protected TextBox Txtemail;

		protected Button BtnSignup;

		protected RequiredFieldValidator ReqValFirstName;

		protected RequiredFieldValidator ReqValLastName;

		protected RegularExpressionValidator RegExpEmail;

		protected HtmlGenericControl confirmation;

		public string EmailAddress
		{
			get
			{
				return this.Txtemail.Text;
			}
		}

		public string FirstName
		{
			get
			{
				return this.TxtFirstName.Text;
			}
		}

		public string LastName
		{
			get
			{
				return this.TxtSecondName.Text;
			}
		}

		public NewsLetterSignUp()
		{
		}

		protected void BtnSignup_Click(object sender, EventArgs e)
		{
			this.Page.Validate("ValGroupNewsLetterSignUp");
			if (this.Page.IsValid)
			{
				if (this.ClickButton != null)
				{
					this.ClickButton(sender, e);
				}
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public void SingUp(bool result)
		{
			if (!result)
			{
				this.confirmation.Visible = false;
				this.signup.Visible = true;
			}
			else
			{
				this.confirmation.Visible = true;
				this.signup.Visible = false;
			}
		}

		public event EventHandler ClickButton;
	}
}