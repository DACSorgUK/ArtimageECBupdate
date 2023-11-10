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
	[PresenterBinding(typeof(ArrthresholdCalculatorPresenter))]
	public class ArrThresholdCalculator : MvpUserControl, IThresholdCalculatorView, IView
	{
		protected TextBox txtDate;

		protected RequiredFieldValidator reqValTxtPrice;

		protected Button Button2;

		protected HtmlGenericControl TextResult;

		protected Label lbdateToday;

		protected Label LbResult;

		protected Label lbdateToday2;

		protected Label LbpriceGBP;

		protected HtmlGenericControl ECBSource;

		protected Label lbdateToday3;

		protected Label LbExchangeEuro;

		protected Label LbExchangeEuro2;

		protected Label LbResult1;

		protected HtmlGenericControl TxtErrortoofar;

		public string Date
		{
			get
			{
				return this.txtDate.Text;
			}
		}

		public ArrThresholdCalculator()
		{
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (this.CalculateThreshold != null)
			{
				this.TextResult.Visible = true;
				if (!(DateTime.Parse(this.Date) >= DateTime.Today))
				{
					this.ECBSource.Visible = false;
				}
				else
				{
					this.ECBSource.Visible = true;
				}
				this.CalculateThreshold(sender, e);
			}
		}

		public void DefaultDate()
		{
			TextBox textBox = this.txtDate;
			object[] day = new object[5];
			DateTime today = DateTime.Today;
			day[0] = today.Day;
			day[1] = " ";
			day[2] = string.Format("{0:MMMM}", DateTime.Today);
			day[3] = " ";
			today = DateTime.Today;
			day[4] = today.Year;
			textBox.Text = string.Concat(day);
		}

		public void ExchangeEuro(string result)
		{
			this.LbExchangeEuro.Text = result;
			this.LbExchangeEuro2.Text = result;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (this.LoadForm != null)
				{
					this.LoadForm(sender, e);
				}
			}
		}

		public void ShowDate()
		{
			DateTime date = DateTime.Parse(this.txtDate.Text);
			Label label = this.lbdateToday;
			object[] day = new object[] { date.Day, " ", string.Format("{0:MMMM}", date), " ", date.Year };
			label.Text = string.Concat(day);
			Label label1 = this.lbdateToday2;
			day = new object[] { date.Day, " ", string.Format("{0:MMMM}", date), " ", date.Year };
			label1.Text = string.Concat(day);
			Label label2 = this.lbdateToday3;
			day = new object[] { date.Day, " ", string.Format("{0:MMMM}", date), " ", date.Year };
			label2.Text = string.Concat(day);
		}

		public void ShowPrice(string result)
		{
			if (result == "0.00")
			{
				this.TextResult.Visible = false;
				this.TxtErrortoofar.Visible = true;
				this.LbResult.Text = result;
				this.LbResult1.Text = result;
				this.LbpriceGBP.Text = result;
			}
			else if (!(result == "-1000"))
			{
				this.TextResult.Visible = true;
				this.TxtErrortoofar.Visible = false;
				this.LbResult.Text = result;
				this.LbResult1.Text = result;
				this.LbpriceGBP.Text = result;
			}
			else
			{
				this.TextResult.Visible = false;
				this.TxtErrortoofar.Visible = true;
				this.LbResult.Text = result;
				this.LbResult1.Text = result;
				this.LbpriceGBP.Text = result;
			}
		}

		public event EventHandler CalculateThreshold;

		public event EventHandler LoadForm;
	}
}