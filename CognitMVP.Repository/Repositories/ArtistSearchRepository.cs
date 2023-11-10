using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Model.Utilities;
using CMS.SettingsProvider;
using System.Data;
using CMS.GlobalHelper;
using DacsOnline.Model.Manager.Interfaces;
using System.Threading;
using DacsOnline.Model.Enums;
using CMS.SiteProvider;

namespace DacsOnline.Repository.Repositories
{
    public class ArtistSearchRepository : BaseKenticoDao, IARRArtistSearchRepository
    {

        #region //Private Properties
        /// <summary>
        /// 
        /// </summary>
        private IEventLogService logService;
        private ICache artistCacahe;
        private int cacheExpiryMins;
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistSearchRepository"/> class.
        /// </summary>
        /// <param name="EventLogService">The event log service.</param>
        public ArtistSearchRepository(IEventLogService EventLogService, ICache ArtistCacahe, int CacheExpiryMins)
        {
            logService = EventLogService;
            artistCacahe = ArtistCacahe;
            cacheExpiryMins = CacheExpiryMins;
        }

        #region //Public Methods


        /// <summary>
        /// Gets the artists data.
        /// </summary>
        /// <returns></returns>
        public List<Artist> GetArtistsData()
        {
            //deleteItem();
            //GetAndUpdateCustomTableItem();
            List<Artist> list = new List<Artist>();
            string key = "ArtistSearchRepository - " + GetKey();
            while (this.artistCacahe[key + "_lock"] != null)
            {
                Thread.Sleep(1000);
            }
            list = this.artistCacahe[key] as List<Artist>;

            if (list != null)
            {
                return list;
            }
            else
            {
                this.artistCacahe.Add(key + "_lock", new object(), CacheType.ABSOLUTE, cacheExpiryMins);
                List<Artist> listnew = new List<Artist>();
                string customTableClassName = ConstantDataArtistSearch.ArtistTable;
                DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

                if (customTable != null)
                {
                    DataSet customTableItems = customTableProvider.GetItems(customTableClassName, null, null);

                    if (!DataHelper.DataSourceIsEmpty(customTableItems))
                    {
                        foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                        {
                            Artist obj = new Artist();
                            obj.ArtistId = customTableItemDr["itemId"].GetValidString();
                            obj.FirstName = customTableItemDr["FirstNames"].GetValidString();
                            obj.LastName = customTableItemDr["LastName"].GetValidString();
                            obj.AuthenticFirstNames = customTableItemDr["AuthenticFirstNames"].GetValidString();
                            obj.AuthenticLastName = customTableItemDr["AuthenticLastName"].GetValidString();
                            //obj.AuthenticPseudonym_CL = customTableItemDr["AuthenticPseudonym_CL"].GetValidString();
                            //obj.AuthenticPseudonym_ARR = customTableItemDr["AuthenticPseudonym_ARR"].GetValidString();
                            obj.Pseudonym_1 = customTableItemDr["Pseudonym_1"].GetValidString();
                            obj.Pseudonym_2 = customTableItemDr["Pseudonym_2"].GetValidString();
                            obj.Pseudonym_3 = customTableItemDr["Pseudonym_3"].GetValidString();
                            obj.Pseudonym_4 = customTableItemDr["Pseudonym_4"].GetValidString();
                            obj.Pseudonym_5 = customTableItemDr["Pseudonym_5"].GetValidString();
                            obj.Pseudonym_6 = customTableItemDr["Pseudonym_6"].GetValidString();
                            obj.Nationality1 = customTableItemDr["Nationality1"].GetValidString();
                            obj.Nationality2 = customTableItemDr["Nationality2"].GetValidString();
                            obj.Nationality3 = customTableItemDr["Nationality3"].GetValidString();
                            obj.Nationality4 = customTableItemDr["Nationality4"].GetValidString();
                            obj.DateOfBirth = customTableItemDr["DateOfBirth"].GetValidDate();
                            obj.DateOfDeath = customTableItemDr["DateOfDeath"].GetValidDate();
                            obj.YearOfBirth = customTableItemDr["YearOfBirth"].GetValidString();
                            obj.YearOfDeath = customTableItemDr["YearOfDeath"].GetValidString();
                            obj.InCopyright = customTableItemDr["InCopyright"].GetValidBoolean();
                            obj.ImageHire = customTableItemDr["ImageHire"].GetValidBoolean();
                            obj.ARRMembership = customTableItemDr["ARRMembership"].GetValidARRMember();
                            obj.ARRSisterSociety = customTableItemDr["ARRSisterSociety"].GetValidString();
                            obj.ARRPaidRoyalties = customTableItemDr["ARRPaidRoyalties"].GetValidARRPaidRoyalties();
                            obj.ARRConfirmedNationality = customTableItemDr["ARRConfirmedNationality"].GetValidARRConfirmedNationality();
                            obj.CLMemebershipType = customTableItemDr["CLMemebershipType"].GetValidCLMemebershipType();
                            obj.CLSisterSociety = customTableItemDr["CLSisterSociety"].GetValidString();
                            obj.CLRightsMultimediaOnly = customTableItemDr["CLRightsMultimediaOnly"].GetValidBoolean();
                            obj.CLRightsExcludingMultimedia = customTableItemDr["CLRightsExcludingMultimedia"].GetValidBoolean();
                            obj.CLRightsExcludingMerchandise = customTableItemDr["CLRightsExcludingMerchandise"].GetValidBoolean();
                            obj.CLRightsAuctionHouseOnly = customTableItemDr["CLRightsAuctionHouseOnly"].GetValidBoolean();
                            obj.CLFullConsultation = customTableItemDr["CLFullConsultation"].GetValidBoolean();
                            listnew.Add(obj);
                        }

                        this.artistCacahe.Add(key, listnew, CacheType.ABSOLUTE, cacheExpiryMins);
                        this.artistCacahe.Remove(key + "_lock");
                        return listnew;
                    }
                    else
                    {
                        return listnew;
                    }
                }
                else
                {
                    return listnew;
                }
            }
        }

        /// <summary>
        /// Gets the sales years.
        /// </summary>
        /// <returns></returns>
        public List<string> GetSalesYears()
        {
            string customTableClassName = ConstantDataArtistSearch.SalesTable;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);
            List<string> list = new List<string>();
            if (customTable != null)
            {
                string where = " Status=1";
                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, "Year DESC");
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

        /// <summary>
        /// Gets the nationalities.
        /// </summary>
        /// <returns></returns>
        public List<Nationality> GetNationalities()
        {
            string customTableClassName = ConstantDataArtistSearch.NationalityTable;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);
            List<Nationality> list = new List<Nationality>();
            if (customTable != null)
            {
                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, null, "Country");
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





        //private void GetAndUpdateCustomTableItem()
        //{

        //    string customTableClassName = ConstantDataArtistSearch.ArtistTable;
        //    DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

        //    if (customTable != null)
        //    {
        //        string where = "CLRightsAuctionHouseOnly LIKE '%(SCN%' OR CLRightsAuctionHouseOnly LIKE '%(Sculptor)%'";
        //        DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, null);
        //        if (!DataHelper.DataSourceIsEmpty(customTableItems))
        //        {
        //            foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
        //            {
        //                CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
        //                modifyCustomTableItem.SetValue("CLRightsAuctionHouseOnly","0");
        //                modifyCustomTableItem.Update();

        //            }


        //        }


        //        string where1 = "CLRightsAuctionHouseOnly LIKE '%(RIGHTS %' ";
        //        DataSet customTableItems1 = customTableProvider.GetItems(customTableClassName, where1, null);
        //        if (!DataHelper.DataSourceIsEmpty(customTableItems1))
        //        {
        //            foreach (DataRow customTableItemDr in customTableItems1.Tables[0].Rows)
        //            {
        //                CustomTableItem modifyCustomTableItem1 = new CustomTableItem(customTableItemDr, customTableClassName);

        //                modifyCustomTableItem1.SetValue("CLRightsAuctionHouseOnly", "1");
        //                modifyCustomTableItem1.Update();

        //            }


        //        }
        //    }

        //}


        //private bool GetAndUpdateCustomTableItem()
        //{

        //    string customTableClassName = ConstantDataArtistSearch.ArtistTable;
        //    DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

        //    if (customTable != null)
        //    {
        //        string where = "FirstNames is null OR LastName is null";
        //        DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, null);
        //        if (!DataHelper.DataSourceIsEmpty(customTableItems))
        //        {
        //            foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
        //            {
        //                CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
        //                string AuthenticFirstNames = ValidationHelper.GetString(modifyCustomTableItem.GetValue("AuthenticFirstNames"), "");
        //                string AuthenticLastName = ValidationHelper.GetString(modifyCustomTableItem.GetValue("AuthenticLastName"), "");
        //                if (!string.IsNullOrEmpty(AuthenticFirstNames))
        //                    modifyCustomTableItem.SetValue("FirstNames", Convertname(AuthenticFirstNames));
        //                if (!string.IsNullOrEmpty(AuthenticLastName))
        //                    modifyCustomTableItem.SetValue("LastName", Convertname(AuthenticLastName));
        //                modifyCustomTableItem.Update();
        //            }

        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private bool deleteItem()
        //{

        //    string customTableClassName = ConstantDataArtistSearch.ArtistTable;
        //    DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

        //    if (customTable != null)
        //    {
        //        string where = "ItemID is not null";
        //        DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, null);
        //        if (!DataHelper.DataSourceIsEmpty(customTableItems))
        //        {
        //            foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
        //            {
        //                CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);

        //                modifyCustomTableItem.Delete();
        //            }

        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private string Convertname(string value)
        //{
        //    StringBuilder newStringBuilder = new StringBuilder();
        //    newStringBuilder.Append(value.Normalize(NormalizationForm.FormKD)
        //                                    .Where(x => x < 128)
        //                                    .ToArray());
        //    return newStringBuilder.ToString();
        //}

        #endregion

        #region //Private Methods

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns></returns>
        private string GetKey()
        {
            string customTableClassName = ConstantDataArtistSearch.ArtistTable;
            string itemModifiedWhen = string.Empty;
            string itemCreatedWhen = string.Empty;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);
            if (customTable != null)
            {
                int topN = 1;
                string columns = "itemModifiedWhen";
                DataSet dataSet = customTableProvider.GetItems(customTableClassName, null, "itemModifiedWhen DESC", topN, columns);
                if (!DataHelper.DataSourceIsEmpty(dataSet))
                {
                    itemModifiedWhen = ValidationHelper.GetString(dataSet.Tables[0].Rows[0][0], string.Empty);

                }
                columns = "itemCreatedWhen";
                dataSet = customTableProvider.GetItems(customTableClassName, null, "itemCreatedWhen DESC", topN, columns);
                if (!DataHelper.DataSourceIsEmpty(dataSet))
                {
                    itemCreatedWhen = ValidationHelper.GetString(dataSet.Tables[0].Rows[0][0], string.Empty);
                }

                if (itemModifiedWhen == string.Empty)
                {
                    return itemCreatedWhen;
                }
                else
                {
                    DateTime dtM = Convert.ToDateTime(itemModifiedWhen);
                    DateTime dtC = Convert.ToDateTime(itemCreatedWhen);
                    if (dtM > dtC)
                    {
                        return itemModifiedWhen;
                    }
                    else
                    {
                        return itemCreatedWhen;
                    }
                }

            }

            return string.Empty;
        }
        #endregion
    }
}
