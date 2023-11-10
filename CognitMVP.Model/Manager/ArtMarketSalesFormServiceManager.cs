using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.RepostioriesInterfaces;

using CMS.GlobalHelper;
using CMS.CMSHelper;
using CMS.EmailEngine;
using CMS.SiteProvider;
using DacsOnline.Model.Utilities;
using System.Web;




namespace DacsOnline.Model.Manager
{
    public class ArtMarketSalesFormServiceManager : BaseManager<IArtMarketSalesFormRepository>, IArtMarketSalesFormServiceManager
    {

        #region //Constructor

        public ArtMarketSalesFormServiceManager(IArtMarketSalesFormRepository artMarketSalesFormRepository)
            : base(artMarketSalesFormRepository)
        {

        }
        #endregion

        #region //Public Methods

        /// <summary>
        /// Processes the data.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="SalesInformation">The sales information.</param>
        /// <returns></returns>
        public bool ProcessData(SalesContactDetails obj, List<SalesInformationData> SalesInformation, out int recordId)
        {

            recordId = this.Repository.SaveContactDetails(obj);
            if (recordId != -1)
            {
                // this.Repository.DeleteContactDetails(1);
                bool saveStatus = this.Repository.SaveSalesInformation(recordId, SalesInformation);
                if (!saveStatus)
                    this.Repository.DeleteContactDetails(recordId);
                if (saveStatus)
                {

                    string[,] replacements = new string[18, 2];

                    replacements[0, 0] = "Name";
                    replacements[0, 1] = obj.Name;
                    replacements[1, 0] = "LastName";
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
                    replacements[12, 0] = "Mobile";
                    replacements[12, 1] = obj.Mobile;
                    replacements[13, 0] = "Fax";
                    replacements[13, 1] = obj.Fax;
                    replacements[14, 0] = "Email";
                    replacements[14, 1] = obj.EmailAddress;
                    replacements[15, 0] = "Website";
                    replacements[15, 1] = obj.Website;
                    replacements[16, 0] = "SalesInfo";
                    replacements[16, 1] = "|**|";
                    replacements[17, 0] = "RefId";
                    replacements[17, 1] = "AMPS - " + recordId;
                    
                    SendEmail.SendEmailUsingTemplate(ConstantDataArtMarketSalesForm.ArtMarketSalesFormEmailTemplate, obj.EmailAddress, replacements,HtmlSalesInformation(SalesInformation));

               
                }

                return saveStatus;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// HTMLs the sales information.
        /// </summary>
        /// <param name="SalesInformation">The sales information.</param>
        /// <returns></returns>
        public string HtmlSalesInformation(List<SalesInformationData> SalesInformation)
        {
            string result = string.Empty;
            string[,] replacements = new string[11, 2];
            int i = 1;
            foreach (var sales in SalesInformation)
            {
                replacements[0, 0] = "SalesDate";
                replacements[0, 1] = sales.SalesDate != null ? Convert.ToDateTime(sales.SalesDate).ToString("dd/MM/yyyy") : string.Empty;
                replacements[1, 0] = "Reference";
                replacements[1, 1] = sales.Refrence;
                replacements[2, 0] = "ArtistName";
                replacements[2, 1] = sales.ArtistName;
                replacements[3, 0] = "ArtistBirth";
                replacements[3, 1] = sales.DateOfBirth !=null? sales.DateOfBirth : string.Empty;
                replacements[4, 0] = "Artistdeath";
                replacements[4, 1] = sales.DateOfDeath != null ? sales.DateOfDeath : string.Empty;
                replacements[5, 0] = "Nationality";
                replacements[5, 1] = string.IsNullOrEmpty(sales.Nationality) ? string.Empty : sales.Nationality.ToString();
                replacements[6, 0] = "TitleOfWork";
                replacements[6, 1] = string.IsNullOrEmpty(sales.TitleOfWork) ? string.Empty : sales.TitleOfWork.ToString();
                replacements[7, 0] = "Medium";
                replacements[7, 1] = string.IsNullOrEmpty(sales.Medium) ? string.Empty : sales.Medium.ToString();
                replacements[8, 0] = "editionNumber";
                replacements[8, 1] = string.IsNullOrEmpty(sales.EditionNumber) ? string.Empty : sales.EditionNumber.ToString();
                replacements[9, 0] = "SalePrice";
                replacements[9, 1] = sales.SalesPrice.ToString();
                replacements[10, 0] = "SalesHeading";
                replacements[10, 1] = "Sales Information " + i;
                i++;

                ContextResolver resolver = CMSContext.CurrentResolver;
                var template = EmailTemplateProvider.GetEmailTemplate(ConstantDataArtMarketSalesForm.ArtMarketSalesFormEmailTemplate_SalesInformation, SendEmail.GetSiteInfo());
                if (template != null)
                {
                    resolver.SourceParameters = replacements;
                    result =result+ resolver.ResolveMacros(template.TemplateText);
                }
            
            }


           
            return result;
        }

        /// <summary>
        /// Gets the titles.
        /// </summary>
        /// <returns></returns>
        public string[] GetTitles()
        {
            return this.Repository.GetTitleNames();
        }

        #endregion

    }
}
