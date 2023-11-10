using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DacsOnline.Model.Utilities
{
    /// <summary>
    /// Constant for calculate the royalty
    /// </summary>
    public class ConstantData
    {

        #region //Calculators
        public const decimal MaxRoyalty = 12500;
        public const decimal MinElegibility = 1000;
        public const decimal Percent4 = 4;
        public const decimal Percent3 = 3;
        public const decimal Percent1 = 1;
        public const decimal Percent05 = 0.5M;
        public const decimal Percent025 = 0.25M;
        public const int interval0 = 0;
        public const decimal interval50000 = 50000.00M;
        public const decimal interval50001 = 50000.01M;
        public const decimal interval200000 = 200000.00M;
        public const decimal interval200001 = 200000.01M;
        public const decimal interval350000 = 350000.00M;
        public const decimal interval350001 = 350000.01M;
        public const decimal interval500000 = 500000.00M;
        public const decimal interval500001 = 500000.01M;

       
        #endregion


    }
    public static class ConstantDataForForms
    {
        #region //Constants
        public static string SubmitUrl = ConfigurationManager.AppSettings["SubmitURL"].ToString();
        public const string TitleTable = "customtable.Title";
        public const string CL_FORM_FOLDER = "CRL_Form_";
        public const string CL_FORM_FOLDER_PRODUCT = "CRL_Product_";
        public const string CL_FORM_FOLDER_PRODUCT_REPRODUCTION = "CRL_Reproduction_";
        public const string GLOBAL_TEMP = "~/DACSO/TEMP";
        #endregion
    }

    public static class DocumentList
    {

        public const string DocumentListTable = "customtable.NewsCategories";
    }


    public static class CopyRightLicencingForm
    {
        #region CopyRightLicencingForm
        public const string CopyRightLicencingFormCookie = "DacsOnline.CopyRightLicencingForm";
        public const string CopyRightLicencingFormTable = "customtable.CopyRightLicencing_ContactDetails";
        public const string CopyRightLicencingFormName = "CopyRightLicencingForm";
        public const string CopyRightLicencingFormName_FileAttachment = "AttachFile";
        public const string CopyRightLicencingFormName_EmailTemplate = "DACSOnline_CopyRightLicencingForm";
        public const string CopyRightLicencingFormName_Product_EmailTemplate = "DACSOnline_CopyRightLicencingForm_Product";
        public const string CopyRightLicencingFormName_Product_Reproduction_EmailTemplate = "DACSOnline_CopyRightLicencingForm_Product_Reproductions";

        public const string CopyRightLicencingForm_ReferenceNumber = "ReferenceNumber";
        public const string CopyRightLicencingForm_Title = "Title";
        public const string CopyRightLicencingForm_FirstName = "Name";
        public const string CopyRightLicencingForm_LastName = "LastName";
        public const string CopyRightLicencingForm_Company = "Company";
        public const string CopyRightLicencingForm_AddressLine1 = "AddressLine1";
        public const string CopyRightLicencingForm_AddressLine2 = "AddressLine2";
        public const string CopyRightLicencingForm_AddressLine3 = "AddressLine3";
        public const string CopyRightLicencingForm_City = "City";
        public const string CopyRightLicencingForm_County_Region = "CountyRegion";
        public const string CopyRightLicencingForm_PostCode = "PostCode";
        public const string CopyRightLicencingForm_Country = "Country";

        public const string CopyRightLicencingForm_InvoiceCompany = "InvoiceCompany";
        public const string CopyRightLicencingForm_InvoiceAddressLine1 = "InvoiceAddressLine1";
        public const string CopyRightLicencingForm_InvoiceAddressLine2 = "InvoiceAddressLine2";
        public const string CopyRightLicencingForm_InvoiceAddressLine3 = "InvoiceAddressLine3";
        public const string CopyRightLicencingForm_InvoiceCity = "InvoiceCity";
        public const string CopyRightLicencingForm_InvoiceCounty_Region = "InvoiceCountyRegion";
        public const string CopyRightLicencingForm_InvoicePostCode = "InvoicePostCode";
        public const string CopyRightLicencingForm_InvoiceCountry = "InvoiceCountry";

        public const string CopyRightLicencingForm_Phone = "Phone";
       // public const string CopyRightLicencingForm_Mobile = "Mobile";
       // public const string CopyRightLicencingForm_Fax = "Fax";
        public const string CopyRightLicencingForm_EmailAddress = "EmailAddress";
        public const string CopyRightLicencingForm_Website = "Website";
        public const string CopyRightLicencingForm_VatNumber = "VatNumber";
        public const string CopyRightLicencingForm_BillingEmailAddress = "BillingEmailAddress";
        public const string CopyRightLicencingForm_BillingContactName = "BillingContactName";
        public const string CopyRightLicencingForm_UseContactDetailsInvoice = "UseContactDetailsInvoice";
        public const string CopyRightLicencingForm_ItemID = "ItemID";
        public const string CopyRightLicencingForm_RefId = "RefId";
        public const string CopyRightLicencingForm_ProductReprodution = "ProductReprodution";

        public const string CopyRightLicencing_Product_FormTable = "customtable.CopyRightLicencing_Product";
        public const string CopyRightLicencing_Product_CopyRightLicencingContactId = "CopyRightLicencingContactId";
        public const string CopyRightLicencing_Product_TitleOfProcuct = "TitleOfProduct";
        public const string CopyRightLicencing_Product_ISBN = "ISBN";
        public const string CopyRightLicencing_Product_TypeOfProduct = "TypeOfProduct";
        public const string CopyRightLicencing_Product_DateLicenceNeeds = "DateLicenceNeeds";
        public const string CopyRightLicencing_Product_FurtherInformation = "FurtherInformation";
        public const string CopyRightLicencing_Product_PrintRun = "PrintRun";
        public const string CopyRightLicencing_Product_PrintRunDigital = "PrintRunDigital";
        public const string CopyRightLicencing_Product_LaunchDate = "LaunchDate";
        public const string CopyRightLicencing_Product_UsageRightsRequired = "Usage_Rights_Required";
        public const string CopyRightLicencing_Product_WhereItemDistributed = "WhereItemDistributed";
        public const string CopyRightLicencing_Product_RefrenceId = "RefrenceId";
        public const string CopyRightLicencing_Product_AttachmentName = "AttachmentName";
        public const string CopyRightLicencing_Product_ReproductionData = "ReproductionData";
        public const string CopyRightLicencing_Product_ProcuctHeading = "ProcuctHeading";
        public const string CopyRightLicencing_Product_Website = "Website";
        public const string CopyRightLicencing_Product_LicenceDuration = "LicenceDuration";
        public const string CopyRightLicencing_Product_ContextOfUseCropped = "ContextOfUseCropped";
        public const string CopyRightLicencing_Product_ContextOfUseCover = "ContextOfUseCover";

        public const string CopyRightLicencing_Reproductions_FormTable = "customtable.CopyRightLicencing_Product_Reproductions";
        public const string CopyRightLicencing_Reproductions_CopyRightLicencing_Product_Id = "CopyRightLicencing_Product_Id";
        public const string CopyRightLicencing_Reproductions_ArtistName = "ArtistName";
        public const string CopyRightLicencing_Reproductions_TitleOfWork = "TitleOfWork";
        //public const string CopyRightLicencing_Reproductions_ContextOfUse = "ContextOfUse";
        //public const string CopyRightLicencing_Reproductions_ContextOfUseCropped = "ContextOfUseCropped";
        //public const string CopyRightLicencing_Reproductions_ContextOfUseCover = "ContextOfUseCover";
        public const string CopyRightLicencingForm_Reproductions_ItemID = "ItemID";
        public const string CopyRightLicencingForm_Reproductions_DepictedWork = "DepictedWork";
        public const string CopyRightLicencingForm_Reproductions_RefrenceId = "RefrenceId";
        public const string CopyRightLicencingForm_Reproductions_ReproductionHeading = "ReproductionHeading";
        public const string CopyRightLicencing_Product_Publishlanguage = "Language";
        #endregion
    }

    public static class ConstantDataArtMarketSalesForm
    {
        #region ArtMarketSalesForm

        public const string ArtMarketSalesFormEmailTemplate = "DACSOnline_SalesFormEmailTemplate";
        public const string ArtMarketSalesFormEmailTemplate_SalesInformation = "DACSOnline_SalesInformation";
        public const string ArtMarketSalesFormCookie = "DacsOnline.ArtMarketSalesFormCookie";
        public  const string ArtMarketSalesFormTable = "customtable.ArtMarketSalesForm";
       

        public const string ArtMarketSalesForm_Title = "Title";
        public const string ArtMarketSalesForm_FirstName = "FirstName";
        public const string ArtMarketSalesForm_LastName = "LastName";
        public const string ArtMarketSalesForm_Company = "Company";
        public const string ArtMarketSalesForm_HouseNumber = "HouseNumber";
        public const string ArtMarketSalesForm_AddressLine2 = "AddressLine2";
        public const string ArtMarketSalesForm_AddressLine3 = "AddressLine3";
        public const string ArtMarketSalesForm_City_Town = "City_Town";
        public const string ArtMarketSalesForm_County_Region = "County_Region";
        public const string ArtMarketSalesForm_PostCode_ZipCode = "PostCode_ZipCode";
        public const string ArtMarketSalesForm_Country = "Country";
        public const string ArtMarketSalesForm_Phone = "Phone";
        public const string ArtMarketSalesForm_Mobile = "Mobile";
        public const string ArtMarketSalesForm_Fax = "Fax";
        public const string ArtMarketSalesForm_EmailAddress = "EmailAddress";
        public const string ArtMarketSalesForm_Website = "Website";
        public const string ArtMarketSalesForm_ItemID = "ItemID";

        //Coloumn Names
        #endregion

        #region ArtMarketSalesForm-SalesInformation
        public const string ArtMarketSalesFormTable_SalesInformation = "customtable.ArtMarketSalesForm_SalesInformation";

        public const string ArtMarketSalesFormTable_SalesInformation_ContactDetailsId = "ContactDetailsId";
        public const string ArtMarketSalesFormTable_SalesInformation_SalesDate = "SalesDate";
        public const string ArtMarketSalesFormTable_SalesInformation_SalesRefrence = "SalesRefrence";
        public const string ArtMarketSalesFormTable_SalesInformation_ArtistName = "ArtistName";
        public const string ArtMarketSalesFormTable_SalesInformation_DateOfBirth = "DateOfBirth";
        public const string ArtMarketSalesFormTable_SalesInformation_DateOfDeath = "DateOfDeath";
        public const string ArtMarketSalesFormTable_SalesInformation_Nationality = "Nationality";
        public const string ArtMarketSalesFormTable_SalesInformation_TitleOfWork = "TitleOfWork";
        public const string ArtMarketSalesFormTable_SalesInformation_Medium = "Medium";
        public const string ArtMarketSalesFormTable_SalesInformation_EditionNumber = "EditionNumber";
        public const string ArtMarketSalesFormTable_SalesInformation_Dimensions = "Dimensions";
        public const string ArtMarketSalesFormTable_SalesInformation_SalePrice = "SalePrice";
        public const string ArtMarketSalesFormTable_SalesInformation_BoughtAsStock = "BoughtAsStock";
        public const string ArtMarketSalesFormTable_SalesInformation_RefrenceId = "RefrenceId";
        #endregion

    }

    public static class ConstantDataConfirmation
    {
        #region confirmation

        public const string ARRBH = "Artist Resale Right for Beneficiaries & Heirs";
        public const string ARR = "Artist Resales Right for Artist";
        public const string BHCL = "Copyright Licensing Service for Beneficiaries & Heirs";
        public const string ACL = "Copyright Licensing Service for Artists";
        public const string AMPS = "Art Market Professionals";
        public const string CL = "Copyright Licensing Works";
        public const string CAA = " Copyright Advice for Artists";
        #endregion

        #region functions
        public static string GetNameForm(string name)
        {
            switch (name)
            {
                case "ARRBH":
                    return ARRBH;
                case "ARR":
                    return ARR;
                case "BHCL":
                    return BHCL;
                case "ACL":
                    return ACL;
                case "AMPS":
                    return AMPS;
                case "CL":
                    return CL;
                case "CAA":
                    return CAA;
            }
            return "";
        }

        #endregion
    }

    public static class ConstantDataArtistSearch
    {
        #region //Constants
        public const string ArtistTable = "customtable.ArtistDetails";
        public const string SalesTable = "customtable.SalesYears";
        public const string ArtistResourceFile = "DACSOnlineResources";
        public const string NationalityTable = "customtable.Nationality";

        public const string EligibilityMessage_1 = "EligibilityMessage_1";
        public const string EligibilityMessage_2 = "EligibilityMessage_2";
        public const string EligibilityMessage_3 = "EligibilityMessage_3";
        public const string EligibilityMessage_4 = "EligibilityMessage_4";

        public const string EligibilityMessage_5 = "EligibilityMessage_5";
        public const string EligibilityMessage_6 = "EligibilityMessage_6";

        public const string MandateMessage_1 = "MandateMessage_1";
        public const string MandateMessage_2 = "MandateMessage_2";

        public const string PaymentMessage_1 = "PaymentMessage_1";
        public const string PaymentMessage_2 = "PaymentMessage_2";
        public const string PaymentMessage_3 = "PaymentMessage_3";
        public const string PaymentMessage_4 = "PaymentMessage_4";


        public const string RepresentationMessage_1 = "RepresentationMessage_1";
        public const string RepresentationMessage_2 = "RepresentationMessage_2";


        public const string ServiceDurationMessage_1 = "ServiceDurationMessage_1";
        public const string ServiceDurationMessage_2 = "ServiceDurationMessage_2";


        public const string ImageHireMessage_1 = "ImageHireMessage_1";


        public const string MoreInfoMessage_1 = "MoreInfoMessage_1";
        public const string MoreInfoMessage_2 = "MoreInfoMessage_2";
        public const string MoreInfoMessage_3 = "MoreInfoMessage_3";
        public const string MoreInfoMessage_4 = "MoreInfoMessage_4";
        public const string MoreInfoMessage_5 = "MoreInfoMessage_5";
        public const string MoreInfoMessage_6 = "MoreInfoMessage_6";

 

        public const string CLArtistDetailsMessage_DACS = "CLArtistDetailsMessage_DACS";
        public const string CLArtistDetailsMessage_NOT_DACS = "CLArtistDetailsMessage_NOT_DACS";
        

        public const string ARRSearchFormCookie = "DacsOnline.ARRSearchFormCookie";
       
        
        //public static string[] EEACountries = new string[] { "Austria", "Belgium", "Bulgaria", 
        //                                    "Cyprus", "Czech Republic", "Denmark", 
        //                                    "Estonia", "Finland", "France", "Germany", 
        //                                    "Greece", "Hungary", "Iceland", "Ireland", 
        //                                    "Italy", "Latvia", "Liechtenstein", 
        //                                    "Lithuania", "Luxembourg", "Malta", 
        //                                    "Netherlands", "Norway", "Poland", 
        //                                    "Portugal", "Romania", "Slovakia", 
        //                                    "Slovenia", "Spain", "Sweden","United Kingdom" }; 
        #endregion
    }



}
