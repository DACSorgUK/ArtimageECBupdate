using CMS.GlobalHelper;
using CMS.SettingsProvider;
using CMS.SiteProvider;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Enums;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Utilities.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DacsOnline.Repository.Repositories
{
	public class ArtMarketSalesFormRepository : BaseKenticoDao, IArtMarketSalesFormRepository
	{
		private IEventLogService logService;

		public ArtMarketSalesFormRepository(IEventLogService EventLogService)
		{
			this.logService = EventLogService;
		}

		public bool DeleteContactDetails(int contactId)
		{
			bool flag;
			string customTableClassName = "customtable.ArtMarketSalesForm";
			if (DataClassInfoProvider.GetDataClass(customTableClassName) != null)
			{
				string where = string.Concat("ItemID=", contactId);
				DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, where, null);
				if (!DataHelper.DataSourceIsEmpty(customTableItems))
				{
					foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
					{
						(new CustomTableItem(customTableItemDr, customTableClassName)).Delete();
					}
					flag = true;
					return flag;
				}
			}
			flag = false;
			return flag;
		}

		public string[] GetTitleNames()
		{
			string[] strArrays;
			string customTableClassName = "customtable.Title";
			if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
			{
				strArrays = null;
			}
			else
			{
				DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, null, null);
				if (DataHelper.DataSourceIsEmpty(customTableItems))
				{
					strArrays = null;
				}
				else
				{
					string[] Titles = new string[customTableItems.Tables[0].Rows.Count];
					int i = 0;
					foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
					{
						Titles[i] = customTableItemDr["Name"].ToString();
						i++;
					}
					strArrays = Titles;
				}
			}
			return strArrays;
		}

		public int SaveContactDetails(SalesContactDetails obj)
		{
			object id = null;
			int num;
			try
			{
				string customTableClassName = "customtable.ArtMarketSalesForm";
				if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
				{
					this.logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-ContactDetails", "Custom table Null");
					num = -1;
				}
				else
				{
					CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, this.customTableProvider);
					newCustomTableItem.SetValue("AddressLine2", obj.AddressLine2);
					newCustomTableItem.SetValue("AddressLine3", obj.AddressLine3);
					newCustomTableItem.SetValue("City_Town", obj.City);
					newCustomTableItem.SetValue("Company", obj.Company);
					newCustomTableItem.SetValue("Country", obj.Country);
					newCustomTableItem.SetValue("County_Region", obj.CountyRegion);
					newCustomTableItem.SetValue("EmailAddress", obj.EmailAddress);
					newCustomTableItem.SetValue("Fax", obj.Fax);
					newCustomTableItem.SetValue("FirstName", obj.Name);
					newCustomTableItem.SetValue("HouseNumber", obj.AddressLine1);
					newCustomTableItem.SetValue("LastName", obj.LastName);
					newCustomTableItem.SetValue("Mobile", obj.Mobile);
					newCustomTableItem.SetValue("Phone", obj.Phone);
					newCustomTableItem.SetValue("PostCode_ZipCode", obj.PostCode);
					newCustomTableItem.SetValue("Title", obj.Title);
					newCustomTableItem.SetValue("Website", obj.Website);
					newCustomTableItem.Insert();
					if (!newCustomTableItem.TryGetValue("ItemID", ref id))
					{
						this.logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-ContactDetails", "Insert fail");
						num = -1;
					}
					else
					{
						num = Convert.ToInt32(id);
					}
				}
			}
			catch (Exception exception)
			{
				this.logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-ContactDetails", exception.Message);
				num = -1;
			}
			return num;
		}

		public bool SaveSalesInformation(int contactId, List<SalesInformationData> SalesInformation)
		{
			bool flag;
			try
			{
				string customTableClassName = "customtable.ArtMarketSalesForm_SalesInformation";
				if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
				{
					this.logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-SalesInformation", "Custom table Null");
					flag = false;
				}
				else
				{
					CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, this.customTableProvider);
					foreach (SalesInformationData obj in SalesInformation)
					{
						newCustomTableItem.SetValue("ContactDetailsId", contactId);
						newCustomTableItem.SetValue("SalesDate", obj.SalesDate);
						newCustomTableItem.SetValue("SalesRefrence", obj.Refrence);
						newCustomTableItem.SetValue("ArtistName", obj.ArtistName);
						newCustomTableItem.SetValue("DateOfBirth", obj.DateOfBirth);
						newCustomTableItem.SetValue("DateOfDeath", obj.DateOfDeath);
						newCustomTableItem.SetValue("Nationality", obj.Nationality);
						newCustomTableItem.SetValue("TitleOfWork", obj.TitleOfWork);
						newCustomTableItem.SetValue("Medium", obj.Medium);
						newCustomTableItem.SetValue("EditionNumber", obj.EditionNumber);
						newCustomTableItem.SetValue("SalePrice", obj.SalesPrice);
						newCustomTableItem.SetValue("BoughtAsStock", obj.BoughtAsStock);
						newCustomTableItem.Insert();
					}
					flag = true;
				}
			}
			catch (Exception exception)
			{
				this.logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-SalesInformation", exception.Message);
				flag = false;
			}
			return flag;
		}

		public bool UpdateRefrence(int contactId)
		{
			bool flag;
			string customTableClassName = "customtable.ArtMarketSalesForm";
			if (DataClassInfoProvider.GetDataClass(customTableClassName) != null)
			{
				string where = string.Concat("ItemID=", contactId);
				DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, where, null);
				if (!DataHelper.DataSourceIsEmpty(customTableItems))
				{
					foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
					{
						CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
						modifyCustomTableItem.SetValue("RefrenceId", string.Concat("AMPS - ", contactId));
						modifyCustomTableItem.Update();
					}
					flag = true;
					return flag;
				}
			}
			flag = false;
			return flag;
		}
	}
}