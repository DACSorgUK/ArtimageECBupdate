using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface ICopyRightLicencingFormView : IView
	{
		string AddressLine1
		{
			get;
			set;
		}

		string AddressLine2
		{
			get;
			set;
		}

		string AddressLine3
		{
			get;
			set;
		}

		string City
		{
			get;
			set;
		}

		string Company
		{
			get;
			set;
		}

		string ConfirmationUrl
		{
			get;
		}

		List<CopyRightLicencingProduct> CopyRightLicencingProductInformation
		{
			get;
		}

		string Country
		{
			get;
			set;
		}

		string CountyRegion
		{
			get;
			set;
		}

		string EmailAddress
		{
			get;
			set;
		}

		string Fax
		{
			get;
			set;
		}

		string InvoiceAddressLine1
		{
			get;
			set;
		}

		string InvoiceAddressLine2
		{
			get;
			set;
		}

		string InvoiceAddressLine3
		{
			get;
			set;
		}

		string InvoiceCity
		{
			get;
			set;
		}

		string InvoiceCompany
		{
			get;
			set;
		}

		string InvoiceCountry
		{
			get;
			set;
		}

		string InvoiceCountyRegion
		{
			get;
			set;
		}

		string InvoicePostCode
		{
			get;
			set;
		}

		string LastName
		{
			get;
			set;
		}

		string Mobile
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}

		string Phone
		{
			get;
			set;
		}

		string PostCode
		{
			get;
			set;
		}

		bool RememberDetails
		{
			get;
		}

		string Title
		{
			get;
			set;
		}

		string UseContactDetailsInvoice
		{
			get;
			set;
		}

		string VatNumber
		{
			get;
			set;
		}

		string Website
		{
			get;
			set;
		}

		void BindTitles(string[] titles);

		void RedirectForm(string url);

		void ShowError();

		event EventHandler LoadData;

		event EventHandler SubmitData;
	}
}