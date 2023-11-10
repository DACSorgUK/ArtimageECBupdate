using System;
using System.Text.RegularExpressions;

namespace DacsOnline.Model.Utilities
{
	public class Validation
	{
		public Validation()
		{
		}

		public static bool ValidateDate(string date)
		{
			DateTime temp;
			bool flag;
			flag = (!DateTime.TryParse(date, out temp) ? false : true);
			return flag;
		}

		public static bool ValidateEmailAddress(string email)
		{
			return (new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")).IsMatch(email);
		}

		public static bool ValidatePhoneNumber(string mobile)
		{
			return (new Regex("(^(\\+?\\-? *[0-9]+)([,0-9 ]*)([0-9 ])*$)|(^ *$)")).IsMatch(mobile);
		}

		public static bool ValidateWebsite(string website)
		{
			return (new Regex("(([\\w]+:)?\\/\\/)?(([\\d\\w]|%[a-fA-f\\d]{2,2})+(:([\\d\\w]|%[a-fA-f\\d]{2,2})+)?@)?([\\d\\w][-\\d\\w]{0,253}[\\d\\w]\\.)+[\\w]{2,4}(:[\\d]+)?(\\/([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)*(\\?(&?([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})=?)*)?(#([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)?$")).IsMatch(website);
		}
	}
}