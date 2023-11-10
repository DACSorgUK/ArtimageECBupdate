using DacsOnline.Model.Business_Objects;
using System;
using System.Collections.Generic;

namespace DacsOnline.Service.Service.Interfaces
{
	public interface ICopyRightLicencingFormService
	{
		CopyrightLicencingFormdata LoadCookieObject();

		string[] LoadTitles();

		void SaveCookie(CopyrightLicencingFormdata obj);

		bool Submit(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> CopyRightLicencingProductInformation, out int recordId);
	}
}