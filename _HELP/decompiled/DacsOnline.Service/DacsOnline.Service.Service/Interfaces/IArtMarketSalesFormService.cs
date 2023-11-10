using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface IArtMarketSalesFormService
	{
		SalesContactDetails LoadCookieObject();

		string[] LoadTitles();

		void SaveCookie(SalesContactDetails obj);

		bool Submit(SalesContactDetails obj, List<SalesInformationData> SalesInformation, out int recordId);
	}
}