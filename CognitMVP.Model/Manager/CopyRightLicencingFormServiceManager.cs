using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.RepostioriesInterfaces;

using DacsOnline.Model.Utilities;
using CMS.CMSHelper;
using CMS.EmailEngine;




namespace DacsOnline.Model.Manager
{
    public class CopyRightLicencingFormServiceManager : BaseManager<ICopyRightLicencingFormRepository>, ICopyRightLicencingFormServiceManager
    {

        #region //Constructor

        public CopyRightLicencingFormServiceManager(ICopyRightLicencingFormRepository copyRightLicencingFormRepository)
            : base(copyRightLicencingFormRepository)
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
        public bool ProcessData(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> CopyRightLicencingInformation, out int recordId)
        {
            List<string> fileDownloadPath;
            string _referenceNumber = null;
            recordId = this.Repository.SaveContactDetails(obj, out _referenceNumber, out fileDownloadPath);
            if (recordId != -1)
            {

                bool saveStatus = this.Repository.SaveCopyRightLicencingProductInformation(recordId, CopyRightLicencingInformation);
                if (saveStatus)
                {
                    try
                    {
                        obj.ReferenceNumber = _referenceNumber;
                        SAPApi _sapApi = new SAPApi();
                        string response = _sapApi.SendSalesQuotation(obj, CopyRightLicencingInformation, fileDownloadPath);
                        //bool _isError = false;
                        if (response.Contains("ErrorMessage"))
                        {
                            SendEmail.SendSimpleEmail("licensing@dacs.org.uk", "lance.dev2@gmail.com", "SAP POST api response ERROR " + _referenceNumber, response);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    string emailTemplateName = CopyRightLicencingForm.CopyRightLicencingFormName_EmailTemplate;

                    string[,] replacements = new string[28, 2];

                    replacements[0, 0] = CopyRightLicencingForm.CopyRightLicencingForm_FirstName;
                    replacements[0, 1] = obj.Name;
                    replacements[1, 0] = CopyRightLicencingForm.CopyRightLicencingForm_LastName;
                    replacements[1, 1] = obj.LastName;
                    //replacements[2, 0] = "CopyRightLicencingForm.CopyRightLicencingForm_Mobile-DEV";
                    //replacements[2, 1] = "obj.Mobile-DEV";
                    replacements[3, 0] = CopyRightLicencingForm.CopyRightLicencingForm_Company;
                    replacements[3, 1] = obj.Company;
                    replacements[4, 0] = CopyRightLicencingForm.CopyRightLicencingForm_AddressLine1;
                    replacements[4, 1] = obj.AddressLine1;
                    replacements[5, 0] = CopyRightLicencingForm.CopyRightLicencingForm_AddressLine2;
                    replacements[5, 1] = obj.AddressLine2;
                    replacements[6, 0] = CopyRightLicencingForm.CopyRightLicencingForm_AddressLine3;
                    replacements[6, 1] = obj.AddressLine3;
                    replacements[7, 0] = CopyRightLicencingForm.CopyRightLicencingForm_City;
                    replacements[7, 1] = obj.City;
                    replacements[8, 0] = CopyRightLicencingForm.CopyRightLicencingForm_County_Region;
                    replacements[8, 1] = obj.CountyRegion;
                    replacements[9, 0] = CopyRightLicencingForm.CopyRightLicencingForm_PostCode;
                    replacements[9, 1] = obj.PostCode;
                    replacements[10, 0] = CopyRightLicencingForm.CopyRightLicencingForm_Country;
                    replacements[10, 1] = obj.Country;
                    replacements[11, 0] = CopyRightLicencingForm.CopyRightLicencingForm_Phone;
                    replacements[11, 1] = obj.Phone;
                    //replacements[12, 0] = "CopyRightLicencingForm.CopyRightLicencingForm_Fax-DEV";
                    //replacements[12, 1] = "obj.Fax-DEV";
                    replacements[13, 0] = CopyRightLicencingForm.CopyRightLicencingForm_EmailAddress;
                    replacements[13, 1] = obj.EmailAddress;
                    replacements[14, 0] = CopyRightLicencingForm.CopyRightLicencingForm_Website;
                    replacements[14, 1] = obj.Website;
                    replacements[15, 0] = CopyRightLicencingForm.CopyRightLicencingForm_VatNumber;
                    replacements[15, 1] = obj.VatNumber;
                    replacements[16, 0] = CopyRightLicencingForm.CopyRightLicencingForm_BillingContactName;
                    replacements[16, 1] = obj.BillingContactName;
                    replacements[17, 0] = CopyRightLicencingForm.CopyRightLicencingForm_BillingEmailAddress;
                    replacements[17, 1] = obj.BillingEmailAddress;
                    replacements[18, 0] = CopyRightLicencingForm.CopyRightLicencingForm_UseContactDetailsInvoice;
                    replacements[18, 1] = obj.UseContactDetails;
                    replacements[19, 0] = CopyRightLicencingForm.CopyRightLicencingForm_RefId;
                    replacements[19, 1] = _referenceNumber;// "CL -" + recordId;

                    replacements[22, 0] = "InvoiceCompany";
                    replacements[22, 1] = obj.InvoiceCompany;
                    replacements[23, 0] = "PostalAddress";
                    replacements[23, 1] = obj.InvoiceAddressLine1 + " " + obj.InvoiceAddressLine2 + " " + obj.InvoiceAddressLine3;
                    replacements[24, 0] = "InvoiceCity";
                    replacements[24, 1] = obj.InvoiceCity;
                    replacements[25, 0] = "InvoiceCountyRegion";
                    replacements[25, 1] = obj.InvoiceCountyRegion;
                    replacements[26, 0] = "InvoicePostCode";
                    replacements[26, 1] = obj.InvoicePostCode;
                    replacements[27, 0] = "InvoiceCountry";
                    replacements[27, 1] = obj.InvoiceCountry;

                    string addtionlHTML = string.Empty;
                    int i = 1;

                    foreach (CopyRightLicencingProduct objHtml in CopyRightLicencingInformation)
                    {
                        addtionlHTML = addtionlHTML + GetProductHTML(objHtml, i, fileDownloadPath);
                        i++;
                    }

                    replacements[20, 0] = CopyRightLicencingForm.CopyRightLicencingForm_ProductReprodution;
                    replacements[20, 1] = "|**|";


                    // SendEmail.SendEmailUsingTemplate(emailTemplateName, obj.EmailAddress, replacements);  

                    SendEmail.SendEmailUsingTemplate(emailTemplateName, obj.EmailAddress, replacements, addtionlHTML);

                }

                return saveStatus;
            }
            else
            {
                return false;
            }
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

        #region //Private Methods
        /// <summary>
        /// Gets the product HTML.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="headingId">The heading id.</param>
        /// <returns></returns>
        private string GetProductHTML(CopyRightLicencingProduct obj, int headingId, List<string> fileList)
        {
            string result = string.Empty;
            string[,] replacements = new string[21, 2];

            replacements[0, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_ProcuctHeading;
            replacements[0, 1] = "Product Information " + headingId;

            replacements[1, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_TypeOfProduct;
            replacements[1, 1] = obj.TypeOfProduct;

            replacements[2, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_TitleOfProcuct;
            replacements[2, 1] = obj.TitleOfProcuct;

            replacements[3, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_Website;
            replacements[3, 1] = obj.Website;

            replacements[4, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_LicenceDuration;
            replacements[4, 1] = obj.LicenceDuration;

            replacements[5, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_UsageRightsRequired;
            replacements[5, 1] = obj.UsageRightsRequired;

            replacements[6, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_PrintRun;
            replacements[6, 1] = obj.PrintRun;

            replacements[7, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_ISBN;
            replacements[7, 1] = obj.ISBN;

            replacements[8, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_DateLicenceNeeds;
            replacements[8, 1] = obj.DateLicenceNeeds != null ? Convert.ToDateTime(obj.DateLicenceNeeds).ToString("dd/MM/yyyy") : string.Empty;

            replacements[9, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_LaunchDate;
            replacements[9, 1] = obj.launctDate != null ? Convert.ToDateTime(obj.launctDate).ToString("dd/MM/yyyy") : string.Empty;

            replacements[10, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_PrintRunDigital;
            replacements[10, 1] = obj.PrintRunDigital;

            //replacements[11, 0] = "CopyRightLicencingForm.CopyRightLicencing_Product_Publishlanguage";
            //replacements[11, 1] = "";// obj.Publishlanguage;

            replacements[11, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_ContextOfUseCropped;
            replacements[11, 1] = obj.ContextOfUseCropped;

            replacements[12, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_ContextOfUseCover;
            replacements[12, 1] = obj.ContextOfUseCover;

            replacements[13, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_WhereItemDistributed;
            replacements[13, 1] = obj.WhereItemDistributed;

            replacements[14, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_Website;
            replacements[14, 1] = obj.Website;

            replacements[15, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_LicenceDuration;
            replacements[15, 1] = obj.LicenceDuration;

            replacements[16, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_FurtherInformation;
            replacements[16, 1] = obj.FurtherInformation;

            ////replacements[14, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_AttachmentName;
            ////replacements[14, 1] = obj.PostedFile != null ? obj.PostedFile.FileName : string.Empty;

            replacements[19, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_Publishlanguage;
            replacements[19, 1] = obj.Publishlanguage;


            string reproductionHtml = string.Empty;
            int j = 1;
            foreach (CopyRightLicencingProductReproductions objReHTML in obj.ProductReproductions)
            {
                reproductionHtml = reproductionHtml + GetReproductionHTML(objReHTML, j);
                j++;
            }

            replacements[17, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_ReproductionData;
            replacements[17, 1] = reproductionHtml;

            string fileAttachment = "";

            foreach (string file in fileList)
            {
                fileAttachment += file;
            }

            replacements[18, 0] = CopyRightLicencingForm.CopyRightLicencingFormName_FileAttachment;
            replacements[18, 1] = fileAttachment;



            ContextResolver resolver = CMSContext.CurrentResolver;
            var template = EmailTemplateProvider.GetEmailTemplate(CopyRightLicencingForm.CopyRightLicencingFormName_Product_EmailTemplate, SendEmail.GetSiteInfo());
            if (template != null)
            {
                resolver.SourceParameters = replacements;
                result = result + resolver.ResolveMacros(template.TemplateText);
            }


            return result;
        }

        /// <summary>
        /// Gets the reproduction HTML.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="headingId">The heading id.</param>
        /// <returns></returns>
        private string GetReproductionHTML(CopyRightLicencingProductReproductions obj, int headingId)
        {

            string result = string.Empty;
            string[,] replacements = new string[7, 2];

            replacements[0, 0] = CopyRightLicencingForm.CopyRightLicencingForm_Reproductions_ReproductionHeading;
            replacements[0, 1] = "Reproduction Information " + headingId;

            replacements[1, 0] = CopyRightLicencingForm.CopyRightLicencing_Reproductions_ArtistName;
            replacements[1, 1] = obj.ArtistName;


            replacements[2, 0] = CopyRightLicencingForm.CopyRightLicencing_Reproductions_TitleOfWork;
            replacements[2, 1] = obj.TitleOfWork;

            //replacements[3, 0] = CopyRightLicencingForm.CopyRightLicencing_Reproductions_ContextOfUse;
            //replacements[3, 1] = String.Join<string>(",", obj.ContextOfUse);
            //replacements[3, 0] = CopyRightLicencingForm.CopyRightLicencing_Reproductions_ContextOfUseCropped;
            //replacements[3, 1] = obj.ContextOfUseCropped;

            //replacements[4, 0] = CopyRightLicencingForm.CopyRightLicencing_Reproductions_ContextOfUseCover;
            //replacements[4, 1] = obj.ContextOfUseCover;


            //replacements[5, 0] = CopyRightLicencingForm.CopyRightLicencingForm_Reproductions_DepictedWork;
            //replacements[5, 1] = obj.DepictedWork;

            //replacements[6, 0] = CopyRightLicencingForm.CopyRightLicencing_Product_AttachmentName;
            //replacements[6, 1] = obj.PostedFile != null ? obj.PostedFile.FileName : string.Empty;

            ContextResolver resolver = CMSContext.CurrentResolver;
            var template = EmailTemplateProvider.GetEmailTemplate(CopyRightLicencingForm.CopyRightLicencingFormName_Product_Reproduction_EmailTemplate, SendEmail.GetSiteInfo());
            if (template != null)
            {
                resolver.SourceParameters = replacements;
                result = result + resolver.ResolveMacros(template.TemplateText);
            }


            return result;
        }
        #endregion


    }
}
