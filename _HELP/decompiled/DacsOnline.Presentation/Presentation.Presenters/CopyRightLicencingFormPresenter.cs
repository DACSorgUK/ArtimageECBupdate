using DacsOnline.Model.Business_Objects;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Web;
using System.Web.SessionState;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class CopyRightLicencingFormPresenter : BasePresenter<ICopyRightLicencingFormView>, IDisposable
	{
		private ICopyRightLicencingFormService copyrightFormService;

		public CopyRightLicencingFormPresenter(ICopyRightLicencingFormView view, ICopyRightLicencingFormService service) : base(view)
		{
			view.SubmitData += new EventHandler(this.SaveCopyrightFormData);
			view.LoadData += new EventHandler(this.LoadFormData);
			this.copyrightFormService = service;
		}

		public void Dispose()
		{
			base.View.SubmitData -= new EventHandler(this.SaveCopyrightFormData);
			base.View.LoadData -= new EventHandler(this.LoadFormData);
		}

		private void LoadFormData(object sender, EventArgs e)
		{
			string[] Title = this.copyrightFormService.LoadTitles();
			base.View.BindTitles(Title);
			CopyrightLicencingFormdata obj = this.copyrightFormService.LoadCookieObject();
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
				base.View.VatNumber = obj.VatNumber;
				base.View.UseContactDetailsInvoice = obj.UseContactDetails;
			}
		}

		private void SaveCopyrightFormData(object sender, EventArgs e)
		{
			int recordId;
			CopyrightLicencingFormdata obj = new CopyrightLicencingFormdata()
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
				Website = base.View.Website,
				VatNumber = base.View.VatNumber,
				UseContactDetails = base.View.UseContactDetailsInvoice
			};
			if (base.View.UseContactDetailsInvoice == "No")
			{
				obj.InvoiceCompany = base.View.InvoiceCompany;
				obj.InvoiceAddressLine1 = base.View.InvoiceAddressLine1;
				obj.InvoiceAddressLine2 = base.View.InvoiceAddressLine2;
				obj.InvoiceAddressLine3 = base.View.InvoiceAddressLine3;
				obj.InvoiceCity = base.View.InvoiceCity;
				obj.InvoiceCountyRegion = base.View.InvoiceCountyRegion;
				obj.InvoicePostCode = base.View.InvoicePostCode;
				obj.InvoiceCountry = base.View.InvoiceCountry;
			}
			bool status = this.copyrightFormService.Submit(obj, base.View.CopyRightLicencingProductInformation, out recordId);
			if ((!status ? false : base.View.RememberDetails))
			{
				this.copyrightFormService.SaveCookie(obj);
			}
			if (!status)
			{
				System.Web.HttpContext.Current.Session.Clear();
				base.View.ShowError();
			}
			else
			{
				string url = string.Format(string.Concat(base.View.ConfirmationUrl, "?Id={0}&form={1}"), recordId, "CL");
				System.Web.HttpContext.Current.Session.Clear();
				System.Web.HttpContext.Current.Session["emailUser"] = base.View.EmailAddress;
				base.View.RedirectForm(url);
			}
		}
	}
}