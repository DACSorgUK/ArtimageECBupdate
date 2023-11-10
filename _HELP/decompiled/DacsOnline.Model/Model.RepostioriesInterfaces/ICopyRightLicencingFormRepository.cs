using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.RepostioriesInterfaces
{
	public interface ICopyRightLicencingFormRepository
	{
		string[] GetTitleNames();

		int SaveContactDetails(CopyrightLicencingFormdata obj);

		bool SaveCopyRightLicencingProductInformation(int contactId, List<CopyRightLicencingProduct> CopyRightLicencingProductInformation);
	}
}