using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace DacsOnline.Service.Service
{
	public class CopyRightLicencingFormService : BaseService<ICopyRightLicencingFormServiceManager>, ICopyRightLicencingFormService
	{
		private ICopyRightLicencingFormServiceManager serviceManager;

		public CopyRightLicencingFormService(ICopyRightLicencingFormServiceManager copyRightLicencingFormServiceManager) : base(copyRightLicencingFormServiceManager)
		{
			this.serviceManager = copyRightLicencingFormServiceManager;
		}

		public CopyrightLicencingFormdata LoadCookieObject()
		{
			CopyrightLicencingFormdata copyrightLicencingFormdatum;
			try
			{
				if ((HttpContext.Current.Request.Cookies["DacsOnline.CopyRightLicencingForm"] == null ? true : string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["DacsOnline.CopyRightLicencingForm"].Value)))
				{
					copyrightLicencingFormdatum = null;
				}
				else
				{
					CopyrightLicencingFormdata obj = new CopyrightLicencingFormdata();
					string value = HttpContext.Current.Request.Cookies["DacsOnline.CopyRightLicencingForm"].Value.Replace("DacsOnline.CopyRightLicencingForm=", "");
					string[] strArrays = new string[] { "|*|" };
					string[] strArrays1 = value.Split(strArrays, StringSplitOptions.None);
					for (int i = 0; i < (int)strArrays1.Length; i++)
					{
						string val = strArrays1[i];
						string[] objectValues = val.Split(new char[] { '=' });
						string str = objectValues[0];
						if (str != null)
						{
							switch (str)
							{
								case "AddressLine2":
								{
									obj.AddressLine2 = objectValues[1];
									break;
								}
								case "AddressLine3":
								{
									obj.AddressLine3 = objectValues[1];
									break;
								}
								case "City":
								{
									obj.City = objectValues[1];
									break;
								}
								case "Company":
								{
									obj.Company = objectValues[1];
									break;
								}
								case "Country":
								{
									obj.Country = objectValues[1];
									break;
								}
								case "CountyRegion":
								{
									obj.CountyRegion = objectValues[1];
									break;
								}
								case "EmailAddress":
								{
									obj.EmailAddress = objectValues[1];
									break;
								}
								case "Fax":
								{
									obj.Fax = objectValues[1];
									break;
								}
								case "Name":
								{
									obj.Name = objectValues[1];
									break;
								}
								case "AddressLine1":
								{
									obj.AddressLine1 = objectValues[1];
									break;
								}
								case "LastName":
								{
									obj.LastName = objectValues[1];
									break;
								}
								case "Mobile":
								{
									obj.Mobile = objectValues[1];
									break;
								}
								case "Phone":
								{
									obj.Phone = objectValues[1];
									break;
								}
								case "PostCode":
								{
									obj.PostCode = objectValues[1];
									break;
								}
								case "Title":
								{
									obj.Title = objectValues[1];
									break;
								}
								case "Website":
								{
									obj.Website = objectValues[1];
									break;
								}
								case "VatNumber":
								{
									obj.VatNumber = objectValues[1];
									break;
								}
								case "UseContactDetailsInvoice":
								{
									obj.UseContactDetails = objectValues[1];
									break;
								}
								default:
								{
									goto Label1;
								}
							}
						}
						else
						{
						}
					Label1:
					}
					copyrightLicencingFormdatum = obj;
				}
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "CopyRightLicencingForm-GetCookie", exception.Message);
				copyrightLicencingFormdatum = null;
			}
			return copyrightLicencingFormdatum;
		}

		public string[] LoadTitles()
		{
			return this.serviceManager.GetTitles();
		}

		public void SaveCookie(CopyrightLicencingFormdata obj)
		{
			HttpCookie dacsCookies = new HttpCookie("DacsOnline.CopyRightLicencingForm");
			StringBuilder cookValue = new StringBuilder();
			HttpContext.Current.Response.Cookies.Clear();
			HttpContext.Current.Response.Cookies.Add(dacsCookies);
			cookValue.Append(string.Concat("AddressLine2=", obj.AddressLine2, "|*|"));
			cookValue.Append(string.Concat("AddressLine3=", obj.AddressLine3, "|*|"));
			cookValue.Append(string.Concat("City=", obj.City, "|*|"));
			cookValue.Append(string.Concat("Company=", obj.Company, "|*|"));
			cookValue.Append(string.Concat("Country=", obj.Country, "|*|"));
			cookValue.Append(string.Concat("CountyRegion=", obj.CountyRegion, "|*|"));
			cookValue.Append(string.Concat("EmailAddress=", obj.EmailAddress, "|*|"));
			cookValue.Append(string.Concat("Fax=", obj.Fax, "|*|"));
			cookValue.Append(string.Concat("Name=", obj.Name, "|*|"));
			cookValue.Append(string.Concat("AddressLine1=", obj.AddressLine1, "|*|"));
			cookValue.Append(string.Concat("LastName=", obj.LastName, "|*|"));
			cookValue.Append(string.Concat("Mobile=", obj.Mobile, "|*|"));
			cookValue.Append(string.Concat("Phone=", obj.Phone, "|*|"));
			cookValue.Append(string.Concat("PostCode=", obj.PostCode, "|*|"));
			cookValue.Append(string.Concat("Title=", obj.Title, "|*|"));
			cookValue.Append(string.Concat("Website=", obj.Website, "|*|"));
			cookValue.Append(string.Concat("VatNumber=", obj.VatNumber, "|*|"));
			cookValue.Append(string.Concat("UseContactDetailsInvoice=", obj.UseContactDetails, "|*|"));
			dacsCookies.Values.Add("DacsOnline.CopyRightLicencingForm", cookValue.ToString());
			HttpContext.Current.Response.Cookies["DacsOnline.CopyRightLicencingForm"].Expires = DateTime.Now.AddDays(30);
		}

		public bool Submit(CopyrightLicencingFormdata obj, List<CopyRightLicencingProduct> CopyRightLicencingProductInformation, out int recordId)
		{
			return this.serviceManager.ProcessData(obj, CopyRightLicencingProductInformation, out recordId);
		}
	}
}