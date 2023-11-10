using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DacsOnlineWebParts.WebParts.DacsOnlineControls
{
	public class Calendar : UserControl
	{
		protected TextBox Txtdate;

		public string Date
		{
			get
			{
				return this.Txtdate.Text.Trim();
			}
			set
			{
				this.Txtdate.Text = value.ToString();
			}
		}

		public Calendar()
		{
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}
	}
}