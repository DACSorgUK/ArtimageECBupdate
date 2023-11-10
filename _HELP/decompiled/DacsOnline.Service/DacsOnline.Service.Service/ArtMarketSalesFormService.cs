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
	public class ArtMarketSalesFormService : BaseService<IArtMarketSalesFormServiceManager>, IArtMarketSalesFormService
	{
		private IArtMarketSalesFormServiceManager serviceManager;

		public ArtMarketSalesFormService(IArtMarketSalesFormServiceManager artMarketSalesFormServiceManager) : base(artMarketSalesFormServiceManager)
		{
			this.serviceManager = artMarketSalesFormServiceManager;
		}

		public SalesContactDetails LoadCookieObject()
		{
			SalesContactDetails salesContactDetail;
			try
			{
				if ((HttpContext.Current.Request.Cookies["DacsOnline.ArtMarketSalesFormCookie"] == null ? true : string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["DacsOnline.ArtMarketSalesFormCookie"].Value)))
				{
					salesContactDetail = null;
				}
				else
				{
					SalesContactDetails obj = new SalesContactDetails();
					string value = HttpContext.Current.Request.Cookies["DacsOnline.ArtMarketSalesFormCookie"].Value.Replace("DacsOnline.ArtMarketSalesFormCookie=", "");
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
								case "City_Town":
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
								case "County_Region":
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
								case "FirstName":
								{
									obj.Name = objectValues[1];
									break;
								}
								case "HouseNumber":
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
								case "PostCode_ZipCode":
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
					salesContactDetail = obj;
				}
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "ArtMarketSalesForm-GetCookie", exception.Message);
				salesContactDetail = null;
			}
			return salesContactDetail;
		}

		public string[] LoadTitles()
		{
			return this.serviceManager.GetTitles();
		}

		public void SaveCookie(SalesContactDetails obj)
		{
			HttpCookie dacsCookies = new HttpCookie("DacsOnline.ArtMarketSalesFormCookie");
			StringBuilder cookValue = new StringBuilder();
			HttpContext.Current.Response.Cookies.Clear();
			HttpContext.Current.Response.Cookies.Add(dacsCookies);
			cookValue.Append(string.Concat("AddressLine2=", obj.AddressLine2, "|*|"));
			cookValue.Append(string.Concat("AddressLine3=", obj.AddressLine3, "|*|"));
			cookValue.Append(string.Concat("City_Town=", obj.City, "|*|"));
			cookValue.Append(string.Concat("Company=", obj.Company, "|*|"));
			cookValue.Append(string.Concat("Country=", obj.Country, "|*|"));
			cookValue.Append(string.Concat("County_Region=", obj.CountyRegion, "|*|"));
			cookValue.Append(string.Concat("EmailAddress=", obj.EmailAddress, "|*|"));
			cookValue.Append(string.Concat("Fax=", obj.Fax, "|*|"));
			cookValue.Append(string.Concat("FirstName=", obj.Name, "|*|"));
			cookValue.Append(string.Concat("HouseNumber=", obj.AddressLine1, "|*|"));
			cookValue.Append(string.Concat("LastName=", obj.LastName, "|*|"));
			cookValue.Append(string.Concat("Mobile=", obj.Mobile, "|*|"));
			cookValue.Append(string.Concat("Phone=", obj.Phone, "|*|"));
			cookValue.Append(string.Concat("PostCode_ZipCode=", obj.PostCode, "|*|"));
			cookValue.Append(string.Concat("Title=", obj.Title, "|*|"));
			cookValue.Append(string.Concat("Website=", obj.Website, "|*|"));
			dacsCookies.Values.Add("DacsOnline.ArtMarketSalesFormCookie", cookValue.ToString());
			HttpContext.Current.Response.Cookies["DacsOnline.ArtMarketSalesFormCookie"].Expires = DateTime.Now.AddDays(30);
		}

		public bool Submit(SalesContactDetails obj, List<SalesInformationData> SalesInformation, out int recordId)
		{
			return this.serviceManager.ProcessData(obj, SalesInformation, out recordId);
		}
	}
}