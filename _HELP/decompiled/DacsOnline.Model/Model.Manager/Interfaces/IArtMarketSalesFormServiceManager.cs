using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface IArtMarketSalesFormServiceManager
	{
		string[] GetTitles();

		bool ProcessData(SalesContactDetails obj, List<SalesInformationData> SalesInformation, out int recordId);
	}
}