using CMS.CMSHelper;
using CMS.EmailEngine;
using CMS.GlobalHelper;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Web;

namespace DacsOnline.Model.Manager
{
	public class CopyRightLicencingFormServiceManager : BaseManager<ICopyRightLicencingFormRepository>, ICopyRightLicencingFormServiceManager
	{
		public CopyRightLicencingFormServiceManager(ICopyRightLicencingFormRepository copyRightLicencingFormRepository) : base(copyRightLicencingFormRepository)
		{
		}

		private string GetProductHTML(CopyRightLicencingProduct obj, int headingId)
		{
			DateTime dateTime;
			string str;
			string empty;
			string str1;
			string result = string.Empty;
			string[,] replacements = new string[16, 2];
			replacements[0, 0] = "ProcuctHeading";
			replacements[0, 1] = string.Concat("Product Information ", headingId);
			replacements[1, 0] = "TitleOfProcuct";
			replacements[1, 1] = obj.TitleOfProcuct;
			replacements[2, 0] = "TypeOfProduct";
			replacements[2, 1] = obj.TypeOfProduct;
			replacements[3, 0] = "PublishDate";
			string[,] strArrays = replacements;
			if (obj.PublishDate.HasValue)
			{
				dateTime = Convert.ToDateTime(obj.PublishDate);
				str = dateTime.ToString("dd/MM/yyyy");
			}
			else
			{
				str = string.Empty;
			}
			strArrays[3, 1] = str;
			replacements[4, 0] = "ProductDescription";
			replacements[4, 1] = obj.ProductDescription;
			replacements[5, 0] = "Usage_Rights_Required";
			replacements[5, 1] = obj.UsageRightsRequired;
			replacements[6, 0] = "ProductQuantity";
			replacements[6, 1] = obj.ProductQuantity;
			replacements[7, 0] = "ProductSellingPrice";
			replacements[7, 1] = obj.ProductSellingPrice;
			replacements[8, 0] = "DateLicenceNeeds";
			string[,] strArrays1 = replacements;
			if (obj.DateLicenceNeeds.HasValue)
			{
				dateTime = Convert.ToDateTime(obj.DateLicenceNeeds);
				empty = dateTime.ToString("dd/MM/yyyy");
			}
			else
			{
				empty = string.Empty;
			}
			strArrays1[8, 1] = empty;
			replacements[9, 0] = "LaunchDate";
			string[,] strArrays2 = replacements;
			if (obj.launctDate.HasValue)
			{
				dateTime = Convert.ToDateTime(obj.launctDate);
				str1 = dateTime.ToString("dd/MM/yyyy");
			}
			else
			{
				str1 = string.Empty;
			}
			strArrays2[9, 1] = str1;
			replacements[10, 0] = "TypeOfEdition";
			replacements[10, 1] = obj.TypeOfEdition;
			replacements[11, 0] = "Publishlanguage";
			replacements[11, 1] = obj.Publishlanguage;
			replacements[12, 0] = "WhereItemDistributed";
			replacements[12, 1] = obj.WhereItemDistributed;
			replacements[13, 0] = "FurtherInformation";
			replacements[13, 1] = obj.FurtherInformation;
			replacements[14, 0] = "AttachmentName";
			replacements[14, 1] = (obj.PostedFile != null ? obj.PostedFile.FileName : string.Empty);
			string reproductionHtml = string.Empty;
			int j = 1;
			foreach (CopyRightLicencingProductReproductions objReHTML in obj.ProductReproductions)
			{
				reproductionHtml = string.Concat(reproductionHtml, this.GetReproductionHTML(objReHTML, j));
				j++;
			}
			replacements[15, 0] = "ReproductionData";
			replacements[15, 1] = reproductionHtml;
			ContextResolver resolver = CMSContext.get_CurrentResolver();
			EmailTemplateInfo template = EmailTemplateProvider.GetEmailTemplate("DACSOnline_CopyRightLicencingForm_Product", SendEmail.GetSiteInfo());
			if (template != null)
			{
				resolver.set_SourceParameters(replacements);
				result = string.Concat(result, resolver.ResolveMacros(template.get_TemplateText()));
			}
			return result;
		}

		private string GetReproductionHTML(CopyRightLicencingProductReproductions obj, int headingId)
		{
			string result = string.Empty;
			string[,] replacements = new string[6, 2];
			replacements[0, 0] = "ReproductionHeading";
			replacements[0, 1] = string.Concat("Reproduction Information ", headingId);
			replacements[1, 0] = "ArtistName";
			replacements[1, 1] = obj.ArtistName;
			replacements[2, 0] = "TitleOfWork";
			replacements[2, 1] = obj.TitleOfWork;
			replacements[3, 0] = "ContextOfUse";
			replacements[3, 1] = string.Join<string>(",", obj.ContextOfUse);
			replacements[4, 0] = "DepictedWork";
			replacements[4, 1] = obj.DepictedWork;
			replacements[5, 0] = "AttachmentName";
			replacements[5, 1] = (obj.PostedFile != null ? obj.PostedFile.FileName : string.Empty);
			ContextResolver resolver = CMSContext.get_CurrentResolver();
			EmailTemplateInfo template = EmailTemplateProvider.GetEmailTemplate("DACSOnline_CopyRightLicencingForm_Product_Reproductions", SendEmail.GetSiteInfo());
			if (template != null)
			{
				resolver.set_SourceParameters(replacements);
				result = string.Concat(result, resolver.ResolveMacros(template.get_TemplateText()));
			}
			return result;
		}

		public string[] GetTitles()
		{
			return base.Repository.GetTitleNames();
		}

		public bool ProcessData(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> CopyRightLicencingInformation, out int recordId)
		{
			bool flag;
			recordId = base.Repository.SaveContactDetails(obj);
			if (recordId == -1)
			{
				flag = false;
			}
			else
			{
				bool saveStatus = base.Repository.SaveCopyRightLicencingProductInformation(recordId, CopyRightLicencingInformation);
				if (saveStatus)
				{
					string emailTemplateName = "DACSOnline_CopyRightLicencingForm";
					string[,] replacements = new string[18, 2];
					replacements[0, 0] = "Name";
					replacements[0, 1] = obj.Name;
					replacements[1, 0] = "LastName";
					replacements[1, 1] = obj.LastName;
					replacements[2, 0] = "Mobile";
					replacements[2, 1] = obj.Mobile;
					replacements[3, 0] = "Company";
					replacements[3, 1] = obj.Company;
					replacements[4, 0] = "AddressLine1";
					replacements[4, 1] = obj.AddressLine1;
					replacements[5, 0] = "AddressLine2";
					replacements[5, 1] = obj.AddressLine2;
					replacements[6, 0] = "AddressLine3";
					replacements[6, 1] = obj.AddressLine3;
					replacements[7, 0] = "City";
					replacements[7, 1] = obj.City;
					replacements[8, 0] = "CountyRegion";
					replacements[8, 1] = obj.CountyRegion;
					replacements[9, 0] = "PostCode";
					replacements[9, 1] = obj.PostCode;
					replacements[10, 0] = "Country";
					replacements[10, 1] = obj.Country;
					replacements[11, 0] = "Phone";
					replacements[11, 1] = obj.Phone;
					replacements[12, 0] = "Fax";
					replacements[12, 1] = obj.Fax;
					replacements[13, 0] = "EmailAddress";
					replacements[13, 1] = obj.EmailAddress;
					replacements[14, 0] = "Website";
					replacements[14, 1] = obj.Website;
					replacements[14, 0] = "VatNumber";
					replacements[14, 1] = obj.VatNumber;
					replacements[15, 0] = "UseContactDetailsInvoice";
					replacements[15, 1] = obj.UseContactDetails;
					replacements[16, 0] = "RefId";
					replacements[16, 1] = string.Concat("CL -", recordId);
					string addtionlHTML = string.Empty;
					int i = 1;
					foreach (CopyRightLicencingProduct objHtml in CopyRightLicencingInformation)
					{
						addtionlHTML = string.Concat(addtionlHTML, this.GetProductHTML(objHtml, i));
						i++;
					}
					replacements[17, 0] = "ProductReprodution";
					replacements[17, 1] = "|**|";
					SendEmail.SendEmailUsingTemplate(emailTemplateName, obj.EmailAddress, replacements, addtionlHTML);
				}
				flag = saveStatus;
			}
			return flag;
		}
	}
}