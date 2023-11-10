using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Enums;

using CMS.SiteProvider;
using CMS.CMSHelper;
using CMS.SettingsProvider;
using CMS.GlobalHelper;

namespace DacsOnline.Repository.Repositories
{
    public class ArtMarketSalesFormRepository :BaseKenticoDao, IArtMarketSalesFormRepository
    {
        #region //Private Properties
        /// <summary>
        /// 
        /// </summary>
        private IEventLogService logService;
        #endregion

        public ArtMarketSalesFormRepository(IEventLogService EventLogService)
        {
            logService = EventLogService;
        }


        #region //Public methods

        /// <summary>
        /// Saves the contact details.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public int SaveContactDetails(SalesContactDetails obj)
        {
            try
            {
              
                // Prepare the parameters
                string customTableClassName = ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable;
                // Check if Custom table 'Sample table' exists
                DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

                if (customTable != null)
                {
                    // Create new custom table item
                    CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, customTableProvider);

                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_AddressLine2, obj.AddressLine2);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_AddressLine3, obj.AddressLine3);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_City_Town, obj.City);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Company, obj.Company);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Country, obj.Country);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_County_Region, obj.CountyRegion);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_EmailAddress, obj.EmailAddress);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Fax, obj.Fax);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_FirstName, obj.Name);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_HouseNumber, obj.AddressLine1);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_LastName, obj.LastName);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Mobile, obj.Mobile);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Phone, obj.Phone);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_PostCode_ZipCode, obj.PostCode);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Title, obj.Title);
                    newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_Website, obj.Website);
                    newCustomTableItem.Insert();
                    object id;
                    if (newCustomTableItem.TryGetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesForm_ItemID, out id))
                    {
                        int newId=Convert.ToInt32(id);
                        //UpdateRefrence(newId);
                        return newId;
                    }
                    else
                    {
                        logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-ContactDetails", "Insert fail");
                        return -1;
                    }
                }
                else{

                    logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-ContactDetails", "Custom table Null");
                    return -1;
                }



 
            }
            catch (Exception ee)
            {
                logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-ContactDetails", ee.Message);
                return -1;
            }
        }

        /// <summary>
        /// Saves the sales information.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <param name="SalesInformation">The sales information.</param>
        /// <returns></returns>
        public bool SaveSalesInformation(int contactId, List<SalesInformationData> SalesInformation)
        {
            try
            {

                // Prepare the parameters
                string customTableClassName = ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation;
                // Check if Custom table 'Sample table' exists
                DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

                if (customTable != null)
                {
                    // Create new custom table item
                    CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, customTableProvider);

                    foreach (SalesInformationData obj in SalesInformation)
                    {
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_ContactDetailsId, contactId);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_SalesDate,obj.SalesDate);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_SalesRefrence, obj.Refrence);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_ArtistName, obj.ArtistName);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_DateOfBirth, obj.DateOfBirth);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_DateOfDeath,obj.DateOfDeath);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_Nationality, obj.Nationality);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_TitleOfWork, obj.TitleOfWork);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_Medium, obj.Medium);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_EditionNumber, obj.EditionNumber);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_Dimensions, obj.Dimensions);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_SalePrice, obj.SalesPrice);
                        newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_BoughtAsStock, obj.BoughtAsStock);
                       // newCustomTableItem.SetValue(ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable_SalesInformation_RefrenceId, "AMPS - " + contactId);
                        newCustomTableItem.Insert();
                    }

                    return true;
                   
                }
                else
                {
                    logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-SalesInformation", "Custom table Null");
                    return false;
                }


            }
            catch (Exception ee)
            {
                logService.LogData(MessageType.Error, "ArtMarketSalesFormRepository-SalesInformation", ee.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes the contact details.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <returns></returns>
        public bool DeleteContactDetails(int contactId)
        {
            string customTableClassName = ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

            if (customTable != null)
            {
                string where = ConstantDataArtMarketSalesForm.ArtMarketSalesForm_ItemID + "=" + contactId;
                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, null);

                if (!DataHelper.DataSourceIsEmpty(customTableItems))
                {
                    foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                    {
                        CustomTableItem deleteCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
                        deleteCustomTableItem.Delete();

                    }

                    return true;
                }

            }

            return false;

        }

        /// <summary>
        /// Gets the title names.
        /// </summary>
        /// <returns></returns>
        public string[] GetTitleNames()
        {
            string customTableClassName = ConstantDataForForms.TitleTable;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

            if (customTable != null)
            {

                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, null, null);

                if (!DataHelper.DataSourceIsEmpty(customTableItems))
                {
                    string[] Titles = new string[customTableItems.Tables[0].Rows.Count];
                    int i=0;
                    foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                    {

                        Titles[i] = customTableItemDr["Name"].ToString();
                        i++;
                    }
                    return Titles;

                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

            
        }
        #endregion

        #region //Private Methods

        /// <summary>
        /// Deletes the contact details.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <returns></returns>
        public bool UpdateRefrence(int contactId)
        {
            string customTableClassName = ConstantDataArtMarketSalesForm.ArtMarketSalesFormTable;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

            if (customTable != null)
            {
                string where = ConstantDataArtMarketSalesForm.ArtMarketSalesForm_ItemID + "=" + contactId;
                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, null);

                if (!DataHelper.DataSourceIsEmpty(customTableItems))
                {
                    foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                    {
                        CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
                        modifyCustomTableItem.SetValue("RefrenceId", "AMPS - " + contactId);
                        modifyCustomTableItem.Update();
                       

                    }

                    return true;
                }

            }

            return false;

        }
        #endregion



    }
}
