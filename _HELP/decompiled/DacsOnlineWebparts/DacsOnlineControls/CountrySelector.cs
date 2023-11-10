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

namespace DacsOnlineWebParts.DacsOnlineControls
{
	[PresenterBinding(typeof(CountrySelectorPresenter))]
	public class CountrySelector : MvpUserControl, ICountrySelectorView, IView
	{
		protected HtmlSelect countryselectorDacs;

		public string Country
		{
			get
			{
				return this.countryselectorDacs.Value;
			}
			set
			{
				ListItem item = this.countryselectorDacs.Items.FindByValue(value);
				int index = this.countryselectorDacs.Items.IndexOf(item);
				this.countryselectorDacs.SelectedIndex = index;
			}
		}

		public CountrySelector()
		{
		}

		public void BindCountry(List<string> CountryList)
		{
			this.countryselectorDacs.Items.Insert(0, new ListItem("Type to select Country", "Type to select Country"));
			int location = 1;
			foreach (string item in CountryList)
			{
				this.countryselectorDacs.Items.Insert(location, new ListItem(item, item));
				location++;
			}
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

		public event EventHandler LoadForm;
	}
}