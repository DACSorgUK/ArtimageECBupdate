using System;
using System.Web;

namespace DacsOnline.Model.Utilities
{
	public class DACSOnlineUtiles
	{
		public DACSOnlineUtiles()
		{
		}

		public static string GetMessage(string key)
		{
			return HttpContext.GetGlobalResourceObject("DACSOnlineResources", key) as string;
		}
	}
}