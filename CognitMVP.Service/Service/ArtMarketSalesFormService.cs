using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Manager.Interfaces;
using System.Web;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Model.Enums;

namespace DacsOnline.Service.Service
{
    public class ArtMarketSalesFormService : BaseService<IArtMarketSalesFormServiceManager>, IArtMarketSalesFormService
    {
        #region //Private Properties
        private IArtMarketSalesFormServiceManager serviceManager;
        #endregion

        public ArtMarketSalesFormService(IArtMarketSalesFormServiceManager artMarketSalesFormServiceManager)
            : base(artMarketSalesFormServiceManager)
        {
            serviceManager = artMarketSalesFormServiceManager;
  
        }

        #region //Public Methods

        /// <summary>
        /// Submits the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public bool Submit(SalesContactDetails obj, List<SalesInformationData> SalesInformation, out int recordId)
        {
            return serviceManager.ProcessData(obj, SalesInformation, out recordId);
        }

        /// <summary>
        /// Saves the cookie.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void SaveCookie(SalesContactDetails obj)
        {
            HttpCookie dacsCookies = new HttpCookie(ConstantDataArtMarketSalesForm.ArtMarketSalesFormCookie);
            StringBuilder cookValue = new StringBuilder();
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Response.Cookies.Add(dacsCookies);

            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_AddressLine2+"="+obj.AddressLine2+"|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_AddressLine3 + "=" + obj.AddressLine3 + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_City_Town + "=" + obj.City + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Company + "=" + obj.Company + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Country + "=" + obj.Country + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_County_Region + "=" + obj.CountyRegion + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_EmailAddress + "=" + obj.EmailAddress + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Fax + "=" + obj.Fax + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_FirstName + "=" + obj.Name + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_HouseNumber + "=" + obj.AddressLine1 + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_LastName + "=" + obj.LastName + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Mobile + "=" + obj.Mobile + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Phone + "=" + obj.Phone + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_PostCode_ZipCode + "=" + obj.PostCode + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Title + "=" + obj.Title + "|*|");
            cookValue.Append(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Website + "=" + obj.Website + "|*|");
            dacsCookies.Values.Add(ConstantDataArtMarketSalesForm.ArtMarketSalesFormCookie, cookValue.ToString());
            HttpContext.Current.Response.Cookies[ConstantDataArtMarketSalesForm.ArtMarketSalesFormCookie].Expires = DateTime.Now.AddDays(30); 
            
         
        }

        /// <summary>
        /// Loads the cookie.
        /// </summary>
        /// <returns></returns>
        public SalesContactDetails LoadCookieObject()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[ConstantDataArtMarketSalesForm.ArtMarketSalesFormCookie] != null && (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[ConstantDataArtMarketSalesForm.ArtMarketSalesFormCookie].Value)))
                {
                    SalesContactDetails obj = new SalesContactDetails();
                    string value = HttpContext.Current.Request.Cookies[ConstantDataArtMarketSalesForm.ArtMarketSalesFormCookie].Value.Replace(ConstantDataArtMarketSalesForm.ArtMarketSalesFormCookie+"=","");
                    string[] stringSeparators = new string[] { "|*|" };
                    string[] result = value.Split(stringSeparators, StringSplitOptions.None);
                    foreach (string val in result)
                    {
                        string[] objectValues = val.Split('=');
                        switch (objectValues[0])
                        {
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_AddressLine2:
                                obj.AddressLine2 = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_AddressLine3:
                                obj.AddressLine3 = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_City_Town:
                                obj.City = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Company:
                                obj.Company = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Country:
                                obj.Country = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_County_Region:
                                obj.CountyRegion = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_EmailAddress:
                                obj.EmailAddress = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Fax:
                                obj.Fax = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_FirstName:
                                obj.Name = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_HouseNumber:
                                obj.AddressLine1 = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_LastName:
                                obj.LastName = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Mobile:
                                obj.Mobile = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Phone:
                                obj.Phone = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_PostCode_ZipCode:
                                obj.PostCode = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Title:
                                obj.Title = objectValues[1];
                                break;
                            case ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Website:
                                obj.Website = objectValues[1];
                                break;
                            default:
                                break;
                        }
                    }

                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ee)
            {
                EventLogService.LogData(MessageType.Error, "ArtMarketSalesForm-GetCookie", ee.Message);
                return null;
            }
        }

        /// <summary>
        /// Loads the titles.
        /// </summary>
        /// <returns></returns>
        public string[] LoadTitles()
        {
            return serviceManager.GetTitles();
        }


    
        #endregion

    }
}
