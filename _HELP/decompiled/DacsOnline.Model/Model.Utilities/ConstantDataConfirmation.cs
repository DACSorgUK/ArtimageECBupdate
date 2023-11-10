using System;

namespace DacsOnline.Model.Utilities
{
	public static class ConstantDataConfirmation
	{
		public const string ARRBH = "Artist Resale Right for Beneficiaries & Heirs";

		public const string ARR = "Artist Resales Right for Artist";

		public const string BHCL = "Copyright Licensing Service for Beneficiaries & Heirs";

		public const string ACL = "Copyright Licensing Service for Artists";

		public const string AMPS = "Art Market Professionals";

		public const string CL = "Copyright Licensing Works";

		public static string GetNameForm(string name)
		{
			string str;
			string str1 = name;
			if (str1 == null)
			{
				str = "";
				return str;
			}
			else if (str1 == "ARRBH")
			{
				str = "Artist Resale Right for Beneficiaries & Heirs";
			}
			else if (str1 == "ARR")
			{
				str = "Artist Resales Right for Artist";
			}
			else if (str1 == "BHCL")
			{
				str = "Copyright Licensing Service for Beneficiaries & Heirs";
			}
			else if (str1 == "ACL")
			{
				str = "Copyright Licensing Service for Artists";
			}
			else if (str1 == "AMPS")
			{
				str = "Art Market Professionals";
			}
			else
			{
				if (str1 != "CL")
				{
					str = "";
					return str;
				}
				str = "Copyright Licensing Works";
			}
			return str;
		}
	}
}