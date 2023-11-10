using System;
using System.Collections.Specialized;
using System.Configuration;

namespace DacsOnline.Model.Utilities
{
	public static class ConstantDataForForms
	{
		public const string TitleTable = "customtable.Title";

		public const string CL_FORM_FOLDER = "CRL_Form_";

		public const string CL_FORM_FOLDER_PRODUCT = "CRL_Product_";

		public const string CL_FORM_FOLDER_PRODUCT_REPRODUCTION = "CRL_Reproduction_";

		public static string SubmitUrl;

		static ConstantDataForForms()
		{
			ConstantDataForForms.SubmitUrl = ConfigurationManager.AppSettings["SubmitURL"].ToString();
		}
	}
}