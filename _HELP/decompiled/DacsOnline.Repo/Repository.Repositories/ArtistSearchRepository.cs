using CMS.GlobalHelper;
using CMS.SettingsProvider;
using CMS.SiteProvider;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Utilities.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace DacsOnline.Repository.Repositories
{
	public class ArtistSearchRepository : BaseKenticoDao, IARRArtistSearchRepository
	{
		private IEventLogService logService;

		private ICache artistCacahe;

		private int cacheExpiryMins;

		public ArtistSearchRepository(IEventLogService EventLogService, ICache ArtistCacahe, int CacheExpiryMins)
		{
			this.logService = EventLogService;
			this.artistCacahe = ArtistCacahe;
			this.cacheExpiryMins = CacheExpiryMins;
		}

		private string Convertname(string value)
		{
			StringBuilder newStringBuilder = new StringBuilder();
			value.Normalize(NormalizationForm.FormKD);
			newStringBuilder.Append((
				from x in value.Normalize(NormalizationForm.FormKD)
				where x < '\u0080'
				select x).ToArray<char>());
			return newStringBuilder.ToString();
		}

		public List<Artist> GetArtistsData()
		{
			List<Artist> artists;
			List<Artist> list = new List<Artist>();
			string key = string.Concat("ArtistSearchRepository - ", this.GetKey());
			while (this.artistCacahe[string.Concat(key, "_lock")] != null)
			{
				Thread.Sleep(1000);
			}
			list = this.artistCacahe[key] as List<Artist>;
			if (list == null)
			{
				this.artistCacahe.Add(string.Concat(key, "_lock"), new object(), CacheType.ABSOLUTE, this.cacheExpiryMins);
				List<Artist> listnew = new List<Artist>();
				string customTableClassName = "customtable.ArtistDetails";
				if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
				{
					artists = listnew;
				}
				else
				{
					DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, null, null);
					if (DataHelper.DataSourceIsEmpty(customTableItems))
					{
						artists = listnew;
					}
					else
					{
						foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
						{
							Artist obj = new Artist()
							{
								ArtistId = customTableItemDr["itemId"].GetValidString(),
								FirstName = customTableItemDr["FirstNames"].GetValidString(),
								LastName = customTableItemDr["LastName"].GetValidString(),
								AuthenticFirstNames = customTableItemDr["AuthenticFirstNames"].GetValidString(),
								AuthenticLastName = customTableItemDr["AuthenticLastName"].GetValidString(),
								Pseudonym_1 = customTableItemDr["Pseudonym_1"].GetValidString(),
								Pseudonym_2 = customTableItemDr["Pseudonym_2"].GetValidString(),
								Pseudonym_3 = customTableItemDr["Pseudonym_3"].GetValidString(),
								Pseudonym_4 = customTableItemDr["Pseudonym_4"].GetValidString(),
								Pseudonym_5 = customTableItemDr["Pseudonym_5"].GetValidString(),
								Pseudonym_6 = customTableItemDr["Pseudonym_6"].GetValidString(),
								Nationality1 = customTableItemDr["Nationality1"].GetValidString(),
								Nationality2 = customTableItemDr["Nationality2"].GetValidString(),
								Nationality3 = customTableItemDr["Nationality3"].GetValidString(),
								Nationality4 = customTableItemDr["Nationality4"].GetValidString(),
								DateOfBirth = customTableItemDr["DateOfBirth"].GetValidDate(),
								DateOfDeath = customTableItemDr["DateOfDeath"].GetValidDate(),
								YearOfBirth = customTableItemDr["YearOfBirth"].GetValidString(),
								YearOfDeath = customTableItemDr["YearOfDeath"].GetValidString(),
								InCopyright = customTableItemDr["InCopyright"].GetValidBoolean(),
								ImageHire = customTableItemDr["ImageHire"].GetValidBoolean(),
								ARRMembership = customTableItemDr["ARRMembership"].GetValidARRMember(),
								ARRSisterSociety = customTableItemDr["ARRSisterSociety"].GetValidString(),
								ARRPaidRoyalties = customTableItemDr["ARRPaidRoyalties"].GetValidARRPaidRoyalties(),
								ARRConfirmedNationality = customTableItemDr["ARRConfirmedNationality"].GetValidARRConfirmedNationality(),
								CLMemebershipType = customTableItemDr["CLMemebershipType"].GetValidCLMemebershipType(),
								CLSisterSociety = customTableItemDr["CLSisterSociety"].GetValidString(),
								CLRightsMultimediaOnly = customTableItemDr["CLRightsMultimediaOnly"].GetValidBoolean(),
								CLRightsExcludingMultimedia = customTableItemDr["CLRightsExcludingMultimedia"].GetValidBoolean(),
								CLRightsExcludingMerchandise = customTableItemDr["CLRightsExcludingMerchandise"].GetValidBoolean(),
								CLRightsAuctionHouseOnly = customTableItemDr["CLRightsAuctionHouseOnly"].GetValidBoolean(),
								CLFullConsultation = customTableItemDr["CLFullConsultation"].GetValidBoolean()
							};
							listnew.Add(obj);
						}
						this.artistCacahe.Add(key, listnew, CacheType.ABSOLUTE, this.cacheExpiryMins);
						this.artistCacahe.Remove(string.Concat(key, "_lock"));
						artists = listnew;
					}
				}
			}
			else
			{
				artists = list;
			}
			return artists;
		}

		private string GetKey()
		{
			string empty;
			string customTableClassName = "customtable.ArtistDetails";
			string itemModifiedWhen = string.Empty;
			string itemCreatedWhen = string.Empty;
			if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
			{
				empty = string.Empty;
			}
			else
			{
				int topN = 1;
				string columns = "itemModifiedWhen";
				DataSet dataSet = this.customTableProvider.GetItems(customTableClassName, null, "itemModifiedWhen DESC", topN, columns);
				if (!DataHelper.DataSourceIsEmpty(dataSet))
				{
					itemModifiedWhen = ValidationHelper.GetString(dataSet.Tables[0].Rows[0][0], string.Empty);
				}
				columns = "itemCreatedWhen";
				dataSet = this.customTableProvider.GetItems(customTableClassName, null, "itemCreatedWhen DESC", topN, columns);
				if (!DataHelper.DataSourceIsEmpty(dataSet))
				{
					itemCreatedWhen = ValidationHelper.GetString(dataSet.Tables[0].Rows[0][0], string.Empty);
				}
				if (!(itemModifiedWhen == string.Empty))
				{
					empty = (!(Convert.ToDateTime(itemModifiedWhen) > Convert.ToDateTime(itemCreatedWhen)) ? itemCreatedWhen : itemModifiedWhen);
				}
				else
				{
					empty = itemCreatedWhen;
				}
			}
			return empty;
		}

		public List<Nationality> GetNationalities()
		{
			string customTableClassName = "customtable.Nationality";
			DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);
			List<Nationality> list = new List<Nationality>();
			if (customTable != null)
			{
				DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, null, "Country");
				if (!DataHelper.DataSourceIsEmpty(customTableItems))
				{
					foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
					{
						Nationality obj = new Nationality();
						CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
						obj.Country = ValidationHelper.GetString(modifyCustomTableItem.GetValue("Country"), "");
						obj.Person = ValidationHelper.GetString(modifyCustomTableItem.GetValue("Person"), "");
						obj.EEA = ValidationHelper.GetBoolean(modifyCustomTableItem.GetValue("EEA"), false);
						list.Add(obj);
					}
				}
			}
			return list;
		}

		public List<string> GetSalesYears()
		{
			string customTableClassName = "customtable.SalesYears";
			DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);
			List<string> list = new List<string>();
			if (customTable != null)
			{
				DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, " Status=1", "Year DESC");
				if (!DataHelper.DataSourceIsEmpty(customTableItems))
				{
					foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
					{
						CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
						string Year = ValidationHelper.GetString(modifyCustomTableItem.GetValue("Year"), "");
						list.Add(Year);
					}
				}
			}
			return list;
		}
	}
}