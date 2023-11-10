using CMS.SettingsProvider;
using CMS.SiteProvider;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Dto;
using DacsOnline.Model.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace DacsOnline.Model.Manager
{
    public class SAPApi
    {
        //string baseURL = SettingsKeyProvider.GetStringValue("BaseURL1");//"https://dacs-api.sapphire-cloud.net/SapWebAPI/api/1234/";
        //string userName = SettingsKeyProvider.GetStringValue("UserName"); //"sapphire";
        //string password = SettingsKeyProvider.GetStringValue("Password");//"sapphire";

        string baseURL = ConfigurationManager.AppSettings["SAPBaseURL"].ToString();
        string userName = ConfigurationManager.AppSettings["SAPUserName"].ToString();
        string password = ConfigurationManager.AppSettings["SAPPassword"].ToString();


        public SearchAllArtistResult SearchAllArtistResult(string ArtistFirstName, string ArtistLastName, string CLMan, string ArrEli, int page, int pageSize)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(baseURL);
            string uri = "/Artists/?PageNum=" + page.ToString() + "&PageSize=" + pageSize.ToString();

            if (!string.IsNullOrEmpty(ArtistFirstName))
                uri = string.Concat(uri, "&", "FName=", ArtistFirstName);
            if (!string.IsNullOrEmpty(ArtistLastName))
            {
                uri = string.Concat(uri, "&", "SName=", ArtistLastName);
                uri = string.Concat(uri, "&", "Pseudo=", ArtistLastName);
            }
            else
            {
                uri = string.Concat(uri, "&", "Pseudo=", ArtistFirstName);
            }


            if (!string.IsNullOrEmpty(CLMan))
                uri = string.Concat(uri, "&", "CLMan=", CLMan);
            if (!string.IsNullOrEmpty(ArrEli))
                uri = string.Concat(uri, "&", "ArrEli=", ArrEli);

            //if (!string.IsNullOrEmpty(ArtistFirstName))
            //    uri = string.Concat(uri, "&", "FName=", "%25" + ArtistFirstName + "%25");
            //if (!string.IsNullOrEmpty(ArtistLastName))
            //    uri = string.Concat(uri, "&", "SName=", "%25" + ArtistLastName + "%25");


            var request = new RestRequest(uri, Method.GET);

            // request.Method = Method.GET;
            string token = Base64Encode(userName + ";" + password);
            request.AddHeader("authorization", "Basic " + token);

            // request.AddUrlSegment("contactID", contactID);
            //request.Resource = "/api/v1/user/{contactID}";
            //request.AddQueryParameter("PageNum", page.ToString());
            //request.AddQueryParameter("PageSize", pageSize.ToString());
            //if (!string.IsNullOrEmpty(ArtistFirstName))
            //    request.AddQueryParameter("FName", "%" + ArtistFirstName + "%");
            //if (!string.IsNullOrEmpty(ArtistLastName))
            //    request.AddQueryParameter("LName", "%" + ArtistLastName + "%");
            //request.Resource = "/Artists?FName" + ArtistFirstName + "%";

            var response = client.Execute<SearchAllArtistResult>(request);

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return response.Data;
            }

            return null;
        }
        public SearchAllArtistResult SearchAlphabeticalArtist(string ArtistFirstName, string ArtistLastName, int page, int pageSize)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;

            RestClient client = new RestClient();
            client.BaseUrl = new Uri(baseURL);
            string uri = "/Artists/?PageNum=" + page.ToString() + "&PageSize=" + pageSize.ToString();

            if (!string.IsNullOrEmpty(ArtistLastName))
                uri = string.Concat(uri, "&", "SName=", ArtistLastName);

            var request = new RestRequest(uri, Method.GET);

            string token = Base64Encode(userName + ";" + password);
            request.AddHeader("authorization", "Basic " + token);

            var response = client.Execute<SearchAllArtistResult>(request);

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return response.Data;
            }

            return null;
        }
        public string SalesQuotationTypeOfProductMapping(CopyRightLicencingProduct product)
        {
            string type = "";

            if (product.TypeOfProduct == "Advertisement")
                type = "AD";
            else if (product.TypeOfProduct == "Book / eBook")
                type = "BE";
            else if (product.TypeOfProduct == "Catalogue")
                type = "CA";
            else if (product.TypeOfProduct == "Digital Products")
                type = "DP";
            else if (product.TypeOfProduct == "Magazine")
                type = "MA";
            else if (product.TypeOfProduct == "Marketing Literature / Promotional Material")
                type = "LP";
            else if (product.TypeOfProduct == "Merchandise")
                type = "ME";
            else if (product.TypeOfProduct == "Newspaper")
                type = "NE";
            else if (product.TypeOfProduct == "Other")
                type = "OT";
            else if (product.TypeOfProduct == "TV, Film or Video")
                type = "TV";
            else if (product.TypeOfProduct == "Website")
                type = "WE";



            return " <U_SPHRE_ProdType>" + type + @"</U_SPHRE_ProdType>";
        }
        public string SalesQuotationTVMapping(CopyRightLicencingProduct product)
        {
            string[] usage_Rights_Required = product.UsageRightsRequired.Split(',');

            string xml = " <U_SPHRE_TVAllTVRgt>" + (usage_Rights_Required.Contains("All TV rights") ? "Y" : "N") + @"</U_SPHRE_TVAllTVRgt>
	                        <U_SPHRE_TVStd>" + (usage_Rights_Required.Contains("Standard TV") ? "Y" : "N") + @"</U_SPHRE_TVStd>
	                        <U_SPHRE_TVNonStd>" + (usage_Rights_Required.Contains("Non standard TV") ? "Y" : "N") + @"</U_SPHRE_TVNonStd>
	                        <U_SPHRE_TVVOD>" + (usage_Rights_Required.Contains("Video on demand") ? "Y" : "N") + @"</U_SPHRE_TVVOD>
	                        <U_SPHRE_TVVDTO>" + (usage_Rights_Required.Contains("Videogram and DTO") ? "Y" : "N") + @"</U_SPHRE_TVVDTO>
	                        <U_SPHRE_TVNonT>" + (usage_Rights_Required.Contains("Non-theatric") ? "Y" : "N") + @"</U_SPHRE_TVNonT>";

            return xml;
        }
        //public string SalesQuotationTypeOfProductMapping(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> product)
        //{
        //    string xml = "";


        //    return xml;
        //}
        public string SendSalesQuotation(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> product, List<string> fileDownloadPath)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;

            RestClient client = new RestClient();
            client.BaseUrl = new Uri(baseURL);
            string uri = "/SalesQuotation/";

            //if (!string.IsNullOrEmpty(ArtistFirstName))
            //    uri = string.Concat(uri, "&", "FName=", ArtistFirstName + "%");
            //if (!string.IsNullOrEmpty(ArtistLastName))
            //    uri = string.Concat(uri, "&", "SName=", ArtistLastName + "%");


            var request = new RestRequest(uri, Method.POST);

            string ProductReproductionsXml = "<DocumentLines>";
            foreach (var item in product[0].ProductReproductions)
            {
                // <U_SPHRE_Artist>" + item.ArtistName + @"</U_SPHRE_Artist>
                // <U_SPHRE_ArtistName>" + item.ArtistName + @"</U_SPHRE_ArtistName>
                ProductReproductionsXml += @"
		                        <Line>
                                     <U_SPHRE_Artist>" + item.Id + @"</U_SPHRE_Artist>
                                    <ItemDescription>" + ReplaceSpecialCharacter(item.TitleOfWork) + @"</ItemDescription>
                                    <FreeText>" + ReplaceSpecialCharacter(item.TitleOfWork) + @"</FreeText>
                                    <CostingCode3>CL_BS</CostingCode3>
		                        </Line>
	                        ";
            }

            ProductReproductionsXml += "</DocumentLines>";


            string attachmentXml = "<Attachments>";
            foreach (var item in fileDownloadPath)
            {
                //String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                //String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                //var folderPath = strUrl+"DACSO/media/CopyRightLicencingForm/";

                var filePath = HttpContext.Current.Server.MapPath("~/DACSO/media/CopyRightLicencingForm/" + item);

                Byte[] bytes = File.ReadAllBytes(filePath);
                String fileContent = Convert.ToBase64String(bytes);

                attachmentXml += @"
		                        <Attachment>
                                    <base64>" + fileContent + @"</base64> 
                                    <FileName>" + item.Replace('/', '_') + @"</FileName>
                                </Attachment>
	                        ";
            }

            attachmentXml += "</Attachments>";


            string rawXml = @"<SalesQuotation>
                            <NumAtCard>" + obj.ReferenceNumber + @"</NumAtCard>
                            <U_SPHRE_UCOM>" + (product[0].ContextOfUseCover.Contains("Yes") ? "Y" : "N") + @"</U_SPHRE_UCOM>
                            <U_SPHRE_UCU>" + (product[0].ContextOfUseCropped.Contains("Yes") ? "Y" : "N") + @"</U_SPHRE_UCU> 
                            <U_SPHRE_CFN>" + obj.Name + @"</U_SPHRE_CFN>
                            <U_SPHRE_CLN>" + obj.LastName + @"</U_SPHRE_CLN>
                            <U_SPHRE_CEmail>" + obj.EmailAddress + @"</U_SPHRE_CEmail>
	                        <U_SPHRE_CCP>" + ReplaceSpecialCharacter(obj.Company) + @"</U_SPHRE_CCP>
	                        <U_SPHRE_CAddr1>" + ReplaceSpecialCharacter(obj.AddressLine1) + @"</U_SPHRE_CAddr1>
	                        <U_SPHRE_CAddr2>" + ReplaceSpecialCharacter(obj.AddressLine2) + @"</U_SPHRE_CAddr2>
	                        <U_SPHRE_CAddr3>" + ReplaceSpecialCharacter(obj.AddressLine3) + @"</U_SPHRE_CAddr3>
	                        <U_SPHRE_CCity>" + obj.City + @"</U_SPHRE_CCity>
                            <U_SPHRE_CPhone>" + obj.Phone + @"</U_SPHRE_CPhone>
                            <U_SPHRE_CMobile>" + obj.Phone + @"</U_SPHRE_CMobile>
                            <U_SPHRE_CCounty>" + obj.CountyRegion + @"</U_SPHRE_CCounty>
	                        <U_SPHRE_CPC>" + obj.PostCode + @"</U_SPHRE_CPC>
	                        <U_SPHRE_CCountry>" + obj.Country + @"</U_SPHRE_CCountry>
	                        <U_SPHRE_CVATN>" + obj.VatNumber + @"</U_SPHRE_CVATN>
                             <U_SPHRE_Website>" + ReplaceSpecialCharacter(obj.Website) + @"</U_SPHRE_Website>
	                        <U_SPHRE_BName>" + obj.BillingContactName + @"</U_SPHRE_BName>
	                        <U_SPHRE_BEmail>" + obj.BillingEmailAddress + @"</U_SPHRE_BEmail>
	                        <U_SPHRE_BCP>" + obj.InvoiceCompany + @"</U_SPHRE_BCP>
	                        <U_SPHRE_BAddr1>" + obj.InvoiceAddressLine1 + @"</U_SPHRE_BAddr1>
	                        <U_SPHRE_BAddr2>" + obj.InvoiceAddressLine2 + @"</U_SPHRE_BAddr2>
	                        <U_SPHRE_BAddr3>" + obj.InvoiceAddressLine3 + @"</U_SPHRE_BAddr3>
	                        <U_SPHRE_BCity>" + obj.InvoiceCity + @"</U_SPHRE_BCity>
	                        <U_SPHRE_BPC>" + obj.InvoicePostCode + @"</U_SPHRE_BPC>
                            <U_SPHRE_BCounty>" + obj.InvoiceCountyRegion + @"</U_SPHRE_BCounty>
	                        <U_SPHRE_BCountry>" + obj.InvoiceCountry + @"</U_SPHRE_BCountry>
	                        " + SalesQuotationTypeOfProductMapping(product[0]) + @"
	                        <U_SPHRE_ProdTitle>" + ReplaceSpecialCharacter(product[0].TitleOfProcuct) + @"</U_SPHRE_ProdTitle>
                            <U_SPHRE_EnqName>" + ReplaceSpecialCharacter(product[0].TitleOfProcuct) + @"</U_SPHRE_EnqName>
	                        <U_SPHRE_ISBN>" + product[0].ISBN + @"</U_SPHRE_ISBN>
	                        <U_SPHRE_LicSD>" + (product[0].DateLicenceNeeds != null ? ((DateTime)product[0].DateLicenceNeeds).ToString("yyyy-MM-dd") : "") + @"</U_SPHRE_LicSD>
	                        <U_SPHRE_Deadline>" + (product[0].launctDate != null ? ((DateTime)product[0].launctDate).ToString("yyyy-MM-dd") : "") + @"</U_SPHRE_Deadline>
	                        <U_SPHRE_ProdDist>" + product[0].WhereItemDistributed + @"</U_SPHRE_ProdDist>
                            <U_SPHRE_Language>" + product[0].Publishlanguage + @"</U_SPHRE_Language>
	                        <U_SPHRE_PrintRun>" + product[0].PrintRun + @"</U_SPHRE_PrintRun>
	                        <U_SPHRE_PrintRunD>" + product[0].PrintRunDigital + @"</U_SPHRE_PrintRunD>
	                        <U_SPHRE_AddInfo>" + ReplaceSpecialCharacter(product[0].FurtherInformation) + @"</U_SPHRE_AddInfo>
	                        " + (product[0].LicenceDuration != "-1" ? "<U_SPHRE_TVLicDur>" + product[0].LicenceDuration + @"</U_SPHRE_TVLicDur>" : "") + @"
	                      " + SalesQuotationTVMapping(product[0]) + @"
                            <U_SPHRE_ProdWebS>" + product[0].Website + @"</U_SPHRE_ProdWebS>
                            <U_SPHRE_Dim3_BStream>CL_BS</U_SPHRE_Dim3_BStream>
                            " + ProductReproductionsXml + @"
                            " + attachmentXml + @"
                        </SalesQuotation>";

            request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);


            // request.Method = Method.GET;
            string token = Base64Encode(userName + ";" + password);
            request.AddHeader("authorization", "Basic " + token);

            var response = client.Execute<SearchAllArtistResult>(request);


            string responseData = "<br/>-- -- -- -- -- -- -- -- API REQUEST -- -- -- -- -- -- -- -- -- -- --<br/>";
            responseData += System.Web.HttpUtility.HtmlEncode(rawXml);
            responseData += "<br/>-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --><br/><br/>";

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                responseData += "<br/>-- -- -- -- -- -- -- -- API RESPONSE -- -- -- -- -- -- -- -- -- -- --<br/>";
                responseData += System.Web.HttpUtility.HtmlEncode(response.Content);
                responseData += "<br/>-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --><br/><br/>";

                return responseData;
            }

            //if (response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    return response.Content;
            //}

            return null;
        }
        public SearchAllArtistResult GetArtistByCode(string code)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(baseURL);
            var request = new RestRequest();

            request.Method = Method.GET;
            string token = Base64Encode(userName + ";" + password);
            request.AddHeader("authorization", "Basic " + token);
            // request.AddUrlSegment("contactID", contactID);
            request.Resource = "/Artists/";
            request.AddQueryParameter("Code", code);
            // request.Resource = "/Artists";

            var response = client.Execute<SearchAllArtistResult>(request);

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                return response.Data;
            }

            return null;
        }
        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        private IRestResponse Execute<T>(RestRequest request) where T : new()
        {

            var client = new RestClient();
            client.BaseUrl = new Uri("https://www.textvertising.co.uk/_admin/api", UriKind.Absolute);

            var response = client.Execute<T>(request);

            return response;
        }

        private string  ReplaceSpecialCharacter(string data)
        {
            string tempData = data;

            if(!string.IsNullOrEmpty(tempData))
            {
                tempData = tempData.Replace(">", " greater than ").Replace("<", " less than ");
            }

            return tempData;
        }
    }
}

namespace DacsOnline.Model.Dto
{
    public class SearchAllArtistResult
    {
        //  [XmlElement("ArtistList")]
        public ArtistList ArtistList { get; set; }
        public int TotalArtist { get; set; }

    }

    public class ArtistList
    {
        //  [XmlElement("DACSArtist")]
        public List<DACSArtist> DACSArtistList { get; set; }

    }
    public class DACSArtist
    {
        public string ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthenticFirstNames { get; set; }
        public string AuthenticLastName { get; set; }
        public string Pseudonym_1 { get; set; }
        public string Pseudonym_2 { get; set; }
        public string Pseudonym_3 { get; set; }
        public string Pseudonym_4 { get; set; }
        public string Pseudonym_5 { get; set; }
        public string Pseudonym_6 { get; set; }
        public string Nationality1 { get; set; }
        public string Nationality2 { get; set; }
        public string Nationality3 { get; set; }
        public string Nationality4 { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string YearOfBirth { get; set; }

        public string YearOfDeath { get; set; }

        public string InCopyright { get; set; }

        public string ImageHire { get; set; }

        public string ARRMembership { get; set; }

        public string ARRMembershipType { get; set; }

        public string ARRSisterSociety { get; set; }

        public ARRPaidRoyalties ARRPaidRoyalties { get; set; }

        public string ARRConfirmedNationality { get; set; }

        public string CLMemebershipType { get; set; }

        public string CLSisterSociety { get; set; }

        public string CLRightsMultimediaOnly { get; set; }

        public string CLRightsExcludingMultimedia { get; set; }

        public string CLRightsExcludingMerchandise { get; set; }

        public string CLRightsAuctionHouseOnly { get; set; }

        public string CLFullConsultation { get; set; }

        public string ArtistWebsite { get; set; }

        public string Relevence { get; set; }
        public string CardName { get; set; }
    }
}
