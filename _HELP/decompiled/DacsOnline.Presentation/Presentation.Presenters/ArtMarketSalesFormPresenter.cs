using DacsOnline.Model.Business_Objects;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Web;
using System.Web.SessionState;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class ArtMarketSalesFormPresenter : BasePresenter<IArtMarketSalesFormView>, IDisposable
	{
		private IArtMarketSalesFormService salesFormService;

		public ArtMarketSalesFormPresenter(IArtMarketSalesFormView view, IArtMarketSalesFormService service) : base(view)
		{
			view.SubmitData += new EventHandler(this.SaveSalesFormData);
			view.LoadData += new EventHandler(this.LoadFormData);
			this.salesFormService = service;
		}

		public void Dispose()
		{
			base.View.SubmitData -= new EventHandler(this.SaveSalesFormData);
			base.View.LoadData -= new EventHandler(this.LoadFormData);
		}

		private void LoadFormData(object sender, EventArgs e)
		{
			string[] Title = this.salesFormService.LoadTitles();
			base.View.BindTitles(Title);
			SalesContactDetails obj = this.salesFormService.LoadCookieObject();
			if (obj != null)
			{
				base.View.AddressLine1 = obj.AddressLine1;
				base.View.AddressLine2 = obj.AddressLine2;
				base.View.AddressLine3 = obj.AddressLine3;
				base.View.City = obj.City;
				base.View.Company = obj.Company;
				base.View.Country = obj.Country;
				base.View.CountyRegion = obj.CountyRegion;
				base.View.EmailAddress = obj.EmailAddress;
				base.View.Fax = obj.Fax;
				base.View.LastName = obj.LastName;
				base.View.Mobile = obj.Mobile;
				base.View.Name = obj.Name;
				base.View.Phone = obj.Phone;
				base.View.PostCode = obj.PostCode;
				base.View.Title = obj.Title;
				base.View.Website = obj.Website;
			}
		}

		private void SaveSalesFormData(object sender, EventArgs e)
		{
			int recordId;
			SalesContactDetails obj = new SalesContactDetails()
			{
				AddressLine1 = base.View.AddressLine1,
				AddressLine2 = base.View.AddressLine2,
				AddressLine3 = base.View.AddressLine3,
				City = base.View.City,
				Company = base.View.Company,
				Country = base.View.Country,
				CountyRegion = base.View.CountyRegion,
				EmailAddress = base.View.EmailAddress,
				Fax = base.View.Fax,
				LastName = base.View.LastName,
				Mobile = base.View.Mobile,
				Name = base.View.Name,
				Phone = base.View.Phone,
				PostCode = base.View.PostCode,
				Title = base.View.Title,
				Website = base.View.Website
			};
			bool status = this.salesFormService.Submit(obj, base.View.SalesInformation, out recordId);
			if ((!status ? false : base.View.RememberDetails))
			{
				this.salesFormService.SaveCookie(obj);
			}
			if (!status)
			{
				base.View.ShowError();
			}
			else
			{
				string url = string.Format(string.Concat(base.View.ConfirmationUrl, "?Id={0}&form={1}"), recordId, "AMPS");
				System.Web.HttpContext.Current.Session["emailUser"] = base.View.EmailAddress;
				base.View.RedirectForm(url);
			}
		}
	}
}