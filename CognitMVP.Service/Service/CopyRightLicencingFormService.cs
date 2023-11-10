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
    public class CopyRightLicencingFormService : BaseService<ICopyRightLicencingFormServiceManager>, ICopyRightLicencingFormService
    {
        #region //Private Properties
        private ICopyRightLicencingFormServiceManager serviceManager;
        #endregion

        public CopyRightLicencingFormService(ICopyRightLicencingFormServiceManager copyRightLicencingFormServiceManager)
            : base(copyRightLicencingFormServiceManager)
        {
            serviceManager = copyRightLicencingFormServiceManager;

        }

        #region //Public Methods

        /// <summary>
        /// Submits the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public bool Submit(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> CopyRightLicencingProductInformation, out int recordId)
        {

            return serviceManager.ProcessData(obj, CopyRightLicencingProductInformation, out recordId);
        }

        /// <summary>
        /// Saves the cookie.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void SaveCookie(CopyrightLicencingFormdata obj)
        {
            HttpCookie dacsCookies = new HttpCookie(CopyRightLicencingForm.CopyRightLicencingFormCookie);
            StringBuilder cookValue = new StringBuilder();
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Response.Cookies.Add(dacsCookies);

            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_AddressLine2 + "=" + obj.AddressLine2 + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_AddressLine3 + "=" + obj.AddressLine3 + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_City + "=" + obj.City + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_Company + "=" + obj.Company + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_Country + "=" + obj.Country + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_County_Region + "=" + obj.CountyRegion + "|*|");


            if (obj.UseContactDetails == "No")
            {
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine1 + "=" + obj.InvoiceAddressLine1 + "|*|");
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine2 + "=" + obj.InvoiceAddressLine2 + "|*|");
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine3 + "=" + obj.InvoiceAddressLine3 + "|*|");
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCity + "=" + obj.InvoiceCity + "|*|");
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCompany + "=" + obj.InvoiceCompany + "|*|");
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCountry + "=" + obj.InvoiceCountry + "|*|");
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCounty_Region + "=" + obj.InvoiceCountyRegion + "|*|");
                cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_InvoicePostCode + "=" + obj.InvoicePostCode + "|*|");
            }

            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_EmailAddress + "=" + obj.EmailAddress + "|*|");
            // cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_Fax + "=" + obj.Fax + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_FirstName + "=" + obj.Name + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_AddressLine1 + "=" + obj.AddressLine1 + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_LastName + "=" + obj.LastName + "|*|");
            // cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_Mobile + "=" + obj.Mobile + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_Phone + "=" + obj.Phone + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_PostCode + "=" + obj.PostCode + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_Title + "=" + obj.Title + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_Website + "=" + obj.Website + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_VatNumber + "=" + obj.VatNumber + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_BillingContactName + "=" + obj.BillingContactName + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_BillingEmailAddress + "=" + obj.BillingEmailAddress + "|*|");
            cookValue.Append(CopyRightLicencingForm.CopyRightLicencingForm_UseContactDetailsInvoice + "=" + obj.UseContactDetails + "|*|");
            dacsCookies.Values.Add(CopyRightLicencingForm.CopyRightLicencingFormCookie, cookValue.ToString());
            HttpContext.Current.Response.Cookies[CopyRightLicencingForm.CopyRightLicencingFormCookie].Expires = DateTime.Now.AddDays(30);


        }

        /// <summary>
        /// Loads the cookie.
        /// </summary>
        /// <returns></returns>
        public CopyrightLicencingFormdata LoadCookieObject()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[CopyRightLicencingForm.CopyRightLicencingFormCookie] != null && (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[CopyRightLicencingForm.CopyRightLicencingFormCookie].Value)))
                {
                    CopyrightLicencingFormdata obj = new CopyrightLicencingFormdata();
                    string value = HttpContext.Current.Request.Cookies[CopyRightLicencingForm.CopyRightLicencingFormCookie].Value.Replace(CopyRightLicencingForm.CopyRightLicencingFormCookie + "=", "");
                    string[] stringSeparators = new string[] { "|*|" };
                    string[] result = value.Split(stringSeparators, StringSplitOptions.None);
                    foreach (string val in result)
                    {
                        string[] objectValues = val.Split('=');
                        switch (objectValues[0])
                        {
                            case CopyRightLicencingForm.CopyRightLicencingForm_AddressLine2:
                                obj.AddressLine2 = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_AddressLine3:
                                obj.AddressLine3 = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_City:
                                obj.City = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_Company:
                                obj.Company = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_Country:
                                obj.Country = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_County_Region:
                                obj.CountyRegion = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_EmailAddress:
                                obj.EmailAddress = objectValues[1];
                                break;
                            //case CopyRightLicencingForm.CopyRightLicencingForm_Fax:
                            //    obj.Fax = objectValues[1];
                            //    break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_FirstName:
                                obj.Name = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_AddressLine1:
                                obj.AddressLine1 = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_LastName:
                                obj.LastName = objectValues[1];
                                break;
                            //case CopyRightLicencingForm.CopyRightLicencingForm_Mobile:
                            //    obj.Mobile = objectValues[1];
                            //    break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_Phone:
                                obj.Phone = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_PostCode:
                                obj.PostCode = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_Title:
                                obj.Title = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_Website:
                                obj.Website = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_VatNumber:
                                obj.VatNumber = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_BillingContactName:
                                obj.BillingContactName = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_BillingEmailAddress:
                                obj.BillingEmailAddress = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCompany:
                                obj.InvoiceCompany = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_UseContactDetailsInvoice:
                                obj.UseContactDetails = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine1:
                                obj.InvoiceAddressLine1 = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine2:
                                obj.InvoiceAddressLine2 = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine3:
                                obj.InvoiceAddressLine3 = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCity:
                                obj.InvoiceCity = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCounty_Region:
                                obj.InvoiceCountyRegion = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoicePostCode:
                                obj.InvoicePostCode = objectValues[1];
                                break;
                            case CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCountry:
                                obj.InvoiceCountry = objectValues[1];
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
                EventLogService.LogData(MessageType.Error, "CopyRightLicencingForm-GetCookie", ee.Message);
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
