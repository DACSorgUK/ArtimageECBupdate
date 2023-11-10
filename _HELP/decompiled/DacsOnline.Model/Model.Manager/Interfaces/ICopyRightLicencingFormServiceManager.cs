using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface ICopyRightLicencingFormServiceManager
	{
		string[] GetTitles();

		bool ProcessData(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> SalesInformation, out int recordId);
	}
}