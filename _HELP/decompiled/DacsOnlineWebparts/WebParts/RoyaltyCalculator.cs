using CMS.GlobalHelper;
using CMS.PortalControls;
using DacsOnline.Model.Enums;
using DacsOnline.Presentation.Presenters;
using DacsOnline.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnlineWebParts.WebParts
{
	[PresenterBinding(typeof(RoyaltyCalculatorPresenter))]
	public class RoyaltyCalculator : MvpUserControl, IRoyaltyCalculatorView, IView
	{
		protected RadioButton AlreadySold;

		protected RadioButton salenotoccured;

		protected TextBox txtDate;

		protected DropDownList ddlCurrency;

		protected TextBox TxtPrice;

		protected RequiredFieldValidator reqValTxtPrice;

		protected Button Button1;

		protected HtmlGenericControl TextResult;

		protected Label LbResult;

		protected Label lblSalePricePounds;

		protected Label lblSalePriceEuro;

		protected HtmlGenericControl ECBSource;

		protected Label lbDate;

		protected Label lbExchangeEuro;

		protected HtmlGenericControl TxtErrortoofar;

		protected HtmlGenericControl TxtErrorLess1000;

		public string currency
		{
			get
			{
				string str;
				if (!(this.ddlCurrency.Text == "GBP: £"))
				{
					str = (!(this.ddlCurrency.Text == "EUR: €") ? CurrancyType.GBP.ToString() : CurrancyType.Euro.ToString());
				}
				else
				{
					str = CurrancyType.GBP.ToString();
				}
				return str;
			}
		}

		public string HowIsCalculated
		{
			get
			{
				return ValidationHelper.GetString(this.GetValue("HowIsCalculated"), "");
			}
		}

		public decimal price
		{
			get
			{
				return decimal.Parse(this.TxtPrice.Text);
			}
		}

		public string SaleDate
		{
			get
			{
				return this.txtDate.Text;
			}
		}

		public RoyaltyCalculator()
		{
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (this.CalculateRoyalty != null)
			{
				if (!string.IsNullOrEmpty(this.TxtPrice.Text))
				{
					this.TextResult.Visible = true;
					if (!(DateTime.Parse(this.SaleDate) >= DateTime.Today))
					{
						this.ECBSource.Visible = false;
					}
					else
					{
						this.ECBSource.Visible = true;
					}
					this.TxtErrortoofar.Visible = false;
					this.CalculateRoyalty(sender, e);
				}
				else
				{
					this.TextResult.Visible = false;
					this.TxtErrortoofar.Visible = true;
				}
			}
		}

		public void DateSale()
		{
			DateTime date = Convert.ToDateTime(this.txtDate.Text);
			Label label = this.lbDate;
			object[] day = new object[] { date.Day, " ", string.Format("{0:MMMM}", date), " ", date.Year };
			label.Text = string.Concat(day);
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

		public void Display(List<string> items)
		{
			this.ddlCurrency.DataSource = items;
			this.ddlCurrency.DataBind();
		}

		public void GetExchangeryEuro(string result)
		{
			this.lbExchangeEuro.Text = result;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.LoadForm != null)
			{
				if (!base.IsPostBack)
				{
					this.LoadForm(sender, e);
				}
			}
		}

		public void ShowPrice(string result, string currency, string salepriceGBP, string salepriceEUR)
		{
			if (result == "0.00")
			{
				this.TextResult.Visible = false;
				this.TxtErrorLess1000.Visible = true;
				this.TxtErrortoofar.Visible = false;
			}
			else if (!(result == "-1.00"))
			{
				this.lblSalePricePounds.Text = salepriceGBP;
				this.lblSalePriceEuro.Text = salepriceEUR;
				this.TextResult.Visible = true;
				this.TxtErrortoofar.Visible = false;
				this.TxtErrorLess1000.Visible = false;
				if (currency == "GBP")
				{
					this.LbResult.Text = string.Concat("£ ", result);
				}
				else if (currency == "Euro")
				{
					this.LbResult.Text = string.Concat("€ ", result);
				}
			}
			else
			{
				this.TxtErrorLess1000.Visible = false;
				this.TextResult.Visible = false;
				this.TxtErrortoofar.Visible = true;
			}
		}

		public void ShowPrice(decimal p)
		{
			this.lblSalePricePounds.Text = p.ToString();
		}

		public event EventHandler CalculateRoyalty;

		public event EventHandler LoadForm;
	}
}