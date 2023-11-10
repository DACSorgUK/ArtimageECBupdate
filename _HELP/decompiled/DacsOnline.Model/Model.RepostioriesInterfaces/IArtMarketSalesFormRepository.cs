using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.RepostioriesInterfaces
{
	public interface IArtMarketSalesFormRepository
	{
		bool DeleteContactDetails(int contactId);

		string[] GetTitleNames();

		int SaveContactDetails(SalesContactDetails obj);

		bool SaveSalesInformation(int contactId, List<SalesInformationData> SalesInformation);
	}
}