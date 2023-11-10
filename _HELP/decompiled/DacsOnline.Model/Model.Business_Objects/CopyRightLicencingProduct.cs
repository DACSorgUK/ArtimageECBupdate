using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;

namespace DacsOnline.Model.Business_Objects
{
	public class CopyRightLicencingProduct
	{
		public DateTime? DateLicenceNeeds
		{
			get;
			set;
		}

		public string FurtherInformation
		{
			get;
			set;
		}

		public DateTime? launctDate
		{
			get;
			set;
		}

		public HttpPostedFile PostedFile
		{
			get;
			set;
		}

		public string ProductDescription
		{
			get;
			set;
		}

		public string ProductQuantity
		{
			get;
			set;
		}

		public List<CopyRightLicencingProductReproductions> ProductReproductions
		{
			get;
			set;
		}

		public string ProductSellingPrice
		{
			get;
			set;
		}

		public DateTime? PublishDate
		{
			get;
			set;
		}

		public string Publishlanguage
		{
			get;
			set;
		}

		public string TitleOfProcuct
		{
			get;
			set;
		}

		public string TypeOfEdition
		{
			get;
			set;
		}

		public string TypeOfProduct
		{
			get;
			set;
		}

		public string UsageRightsRequired
		{
			get;
			set;
		}

		public string WhereItemDistributed
		{
			get;
			set;
		}

		public CopyRightLicencingProduct()
		{
		}
	}
}