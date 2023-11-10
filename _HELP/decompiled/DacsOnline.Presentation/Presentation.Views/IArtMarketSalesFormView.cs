using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
	public interface IArtMarketSalesFormView : IView
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

		List<SalesInformationData> SalesInformation
		{
			get;
		}

		string Title
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