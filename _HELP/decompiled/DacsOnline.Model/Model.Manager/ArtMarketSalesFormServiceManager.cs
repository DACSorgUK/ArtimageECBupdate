using CMS.CMSHelper;
using CMS.EmailEngine;
using CMS.GlobalHelper;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Utilities;
using System;
using System.Collections.Generic;

namespace DacsOnline.Model.Manager
{
	public class ArtMarketSalesFormServiceManager : BaseManager<IArtMarketSalesFormRepository>, IArtMarketSalesFormServiceManager
	{
		public ArtMarketSalesFormServiceManager(IArtMarketSalesFormRepository artMarketSalesFormRepository) : base(artMarketSalesFormRepository)
		{
		}

		public string[] GetTitles()
		{
			return base.Repository.GetTitleNames();
		}

		public string HtmlSalesInformation(List<SalesInformationData> SalesInformation)
		{
			string str;
			string result = string.Empty;
			string[,] replacements = new string[11, 2];
			int i = 1;
			foreach (SalesInformationData sales in SalesInformation)
			{
				replacements[0, 0] = "SalesDate";
				string[,] strArrays = replacements;
				if (sales.SalesDate.HasValue)
				{
					DateTime dateTime = Convert.ToDateTime(sales.SalesDate);
					str = dateTime.ToString("dd/MM/yyyy");
				}
				else
				{
					str = string.Empty;
				}
				strArrays[0, 1] = str;
				replacements[1, 0] = "Reference";
				replacements[1, 1] = sales.Refrence;
				replacements[2, 0] = "ArtistName";
				replacements[2, 1] = sales.ArtistName;
				replacements[3, 0] = "ArtistBirth";
				replacements[3, 1] = sales.DateOfBirth;
				replacements[4, 0] = "Artistdeath";
				replacements[4, 1] = sales.DateOfDeath;
				replacements[5, 0] = "Nationality";
				replacements[5, 1] = (string.IsNullOrEmpty(sales.Nationality) ? string.Empty : sales.Nationality.ToString());
				replacements[6, 0] = "TitleOfWork";
				replacements[6, 1] = (string.IsNullOrEmpty(sales.TitleOfWork) ? string.Empty : sales.TitleOfWork.ToString());
				replacements[7, 0] = "Medium";
				replacements[7, 1] = (string.IsNullOrEmpty(sales.Medium) ? string.Empty : sales.Medium.ToString());
				replacements[8, 0] = "editionNumber";
				replacements[8, 1] = (string.IsNullOrEmpty(sales.EditionNumber) ? string.Empty : sales.EditionNumber.ToString());
				replacements[9, 0] = "SalePrice";
				replacements[9, 1] = sales.SalesPrice.ToString();
				replacements[10, 0] = "SalesHeading";
				replacements[10, 1] = string.Concat("Sales Information ", i);
				i++;
				ContextResolver resolver = CMSContext.get_CurrentResolver();
				EmailTemplateInfo template = EmailTemplateProvider.GetEmailTemplate("DACSOnline_SalesInformation", SendEmail.GetSiteInfo());
				if (template != null)
				{
					resolver.set_SourceParameters(replacements);
					result = string.Concat(result, resolver.ResolveMacros(template.get_TemplateText()));
				}
			}
			return result;
		}

		public bool ProcessData(SalesContactDetails obj, List<SalesInformationData> SalesInformation, out int recordId)
		{
			bool flag;
			recordId = base.Repository.SaveContactDetails(obj);
			if (recordId == -1)
			{
				flag = false;
			}
			else
			{
				bool saveStatus = base.Repository.SaveSalesInformation(recordId, SalesInformation);
				if (!saveStatus)
				{
					base.Repository.DeleteContactDetails(recordId);
				}
				if (saveStatus)
				{
					string[,] replacements = new string[17, 2];
					replacements[0, 0] = "Name";
					replacements[0, 1] = obj.Name;
					replacements[1, 0] = "Last Name";
					replacements[1, 1] = obj.LastName;
					replacements[2, 0] = "Title";
					replacements[2, 1] = obj.Title;
					replacements[3, 0] = "Company";
					replacements[3, 1] = obj.Company;
					replacements[4, 0] = "AddressLine1";
					replacements[4, 1] = obj.AddressLine1;
					replacements[5, 0] = "AddressLine2";
					replacements[5, 1] = obj.AddressLine2;
					replacements[6, 0] = "AddressLine3";
					replacements[6, 1] = obj.AddressLine3;
					replacements[7, 0] = "city";
					replacements[7, 1] = obj.City;
					replacements[8, 0] = "County";
					replacements[8, 1] = obj.Country;
					replacements[9, 0] = "PostCode";
					replacements[9, 1] = obj.PostCode;
					replacements[10, 0] = "Country";
					replacements[10, 1] = obj.Country;
					replacements[11, 0] = "Phone";
					replacements[11, 1] = obj.Phone;
					replacements[12, 0] = "Fax";
					replacements[12, 1] = obj.Fax;
					replacements[13, 0] = "Email";
					replacements[13, 1] = obj.EmailAddress;
					replacements[14, 0] = "Website";
					replacements[14, 1] = obj.Website;
					replacements[14, 0] = "SalesInfo";
					replacements[14, 1] = "|**|";
					replacements[15, 0] = "RefId";
					replacements[15, 1] = string.Concat("AMPS - ", recordId);
					SendEmail.SendEmailUsingTemplate("DACSOnline_SalesFormEmailTemplate", obj.EmailAddress, replacements, this.HtmlSalesInformation(SalesInformation));
				}
				flag = saveStatus;
			}
			return flag;
		}
	}
}