using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;

namespace DacsOnline.Model.Business_Objects
{
	public class CopyRightLicencingProductReproductions
	{
		public string ArtistName
		{
			get;
			set;
		}

		public List<string> ContextOfUse
		{
			get;
			set;
		}

		public string DepictedWork
		{
			get;
			set;
		}

		public HttpPostedFile PostedFile
		{
			get;
			set;
		}

		public string TitleOfWork
		{
			get;
			set;
		}

		public CopyRightLicencingProductReproductions()
		{
		}
	}
}