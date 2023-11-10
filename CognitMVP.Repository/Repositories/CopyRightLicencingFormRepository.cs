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
using System.Web;
using System.IO;
using CMS.MediaLibrary;
using DacsOnline.Repository.DataContext;


namespace DacsOnline.Repository.Repositories
{
    public class CopyRightLicencingFormRepository : BaseKenticoDao, ICopyRightLicencingFormRepository
    {
        #region //Private Properties
        /// <summary>
        /// 
        /// </summary>
        private IEventLogService logService;
        #endregion

        public CopyRightLicencingFormRepository(IEventLogService EventLogService)
        {
            logService = EventLogService;
        }

        #region //Public methods


        /// <summary>
        /// Saves the contact details.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public int SaveContactDetails(CopyrightLicencingFormdata obj, out string _referenceNumber, out List<string> fileDownloadPath)
        {
            try
            {
                fileDownloadPath = new List<string>();
                // Prepare the parameters
                string customTableClassName = CopyRightLicencingForm.CopyRightLicencingFormTable;
                // Check if Custom table 'Sample table' exists
                DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

                if (URLHelper.GetCurrentDomain().Contains("dev"))
                {
                    _referenceNumber = "LRDEV" + DateTime.Now.ToString("yy");
                }
                else
                    _referenceNumber = "LR" + DateTime.Now.ToString("yy");

                string where = "";
                int topN = 1;
                string columns = "ReferenceNumber";

                // Gets the data set according to the parameters

                DataSet dataSet = customTableProvider.GetItems(customTableClassName, where, "ReferenceNumber DESC", topN, columns);
                if (!DataHelper.DataSourceIsEmpty(dataSet))
                {
                    string currentReferenceNumber = ValidationHelper.GetString(dataSet.Tables[0].Rows[0][0], "");
                    if (currentReferenceNumber.StartsWith("LR"))
                    {
                        try
                        {
                            string lastpart = currentReferenceNumber.Split('-')[1];
                            _referenceNumber += "-" + (Convert.ToInt32(lastpart) + 1).ToString();
                        }
                        catch (Exception ex)
                        {
                            _referenceNumber = _referenceNumber + "-200001";
                        }
                    }
                    else
                    {
                        _referenceNumber += "-200001";
                    }
                }

                if (customTable != null)
                {
                    // Create new custom table item
                    CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, customTableProvider);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_ReferenceNumber, _referenceNumber);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_FirstName, obj.Name);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_LastName, obj.LastName);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Company, obj.Company);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_AddressLine1, obj.AddressLine1);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_AddressLine2, obj.AddressLine2);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_AddressLine3, obj.AddressLine3);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_City, obj.City);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_County_Region, obj.CountyRegion);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_PostCode, obj.PostCode);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Country, obj.Country);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_EmailAddress, obj.EmailAddress);
                    //newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Fax, obj.Fax);
                    //newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Mobile, obj.Mobile);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Phone, obj.Phone);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Title, obj.Title);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Website, obj.Website);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_VatNumber, obj.VatNumber);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_BillingContactName, obj.BillingContactName);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_BillingEmailAddress, obj.BillingEmailAddress);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_UseContactDetailsInvoice, obj.UseContactDetails);

                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCompany, obj.InvoiceCompany);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine1, obj.InvoiceAddressLine1);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine2, obj.InvoiceAddressLine2);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceAddressLine3, obj.InvoiceAddressLine3);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCity, obj.InvoiceCity);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCounty_Region, obj.InvoiceCountyRegion);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoicePostCode, obj.InvoicePostCode);
                    newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_InvoiceCountry, obj.InvoiceCountry);


                    newCustomTableItem.Insert();
                    object id;
                    if (newCustomTableItem.TryGetValue(CopyRightLicencingForm.CopyRightLicencingForm_ItemID, out id))
                    {
                        int newId = Convert.ToInt32(id);
                        string folder = ConstantDataForForms.CL_FORM_FOLDER + newId;
                        CreateFolder(folder);
                        //UpdateRefrence(newId, customTableClassName, newId);

                        if (obj.Files.Count > 0)
                        {

                            foreach (string file in obj.Files)
                            {
                                string pathSource = HttpContext.Current.Server.MapPath(ConstantDataForForms.GLOBAL_TEMP + "/" + file);

                                using (FileStream fsSource = new FileStream(pathSource,
                                            FileMode.Open, FileAccess.Read))
                                {
                                    byte[] fileBytes = new byte[fsSource.Length];
                                    fsSource.Read(fileBytes, 0, fileBytes.Length);

                                    Import(file, fileBytes, folder, out fileDownloadPath);
                                }
                            }
                        }

                        return Convert.ToInt32(newId);
                    }
                    else
                    {
                        logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", "Insert fail");
                        return -1;
                    }
                }
                else
                {
                    logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", "Custom table Null");
                    return -1;
                }
            }
            catch (Exception ee)
            {
                logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", ee.Message);
                throw ee;
            }
        }


        /// <summary>
        /// Saves the copy right licencing product information.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <param name="CopyRightLicencingProductInformation">The copy right licencing product information.</param>
        /// <returns></returns>
        public bool SaveCopyRightLicencingProductInformation(int contactId, List<CopyRightLicencingProduct> CopyRightLicencingProductInformation)
        {
            try
            {

                // Prepare the parameters
                string customTableClassName = CopyRightLicencingForm.CopyRightLicencing_Product_FormTable;
                // Check if Custom table 'Sample table' exists
                DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

                if (customTable != null)
                {
                    // Create new custom table item
                    CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, customTableProvider);

                    foreach (CopyRightLicencingProduct obj in CopyRightLicencingProductInformation)
                    {
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_CopyRightLicencingContactId, contactId);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_TitleOfProcuct, obj.TitleOfProcuct);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_TypeOfProduct, obj.TypeOfProduct);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_ISBN, obj.ISBN);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_DateLicenceNeeds, obj.DateLicenceNeeds);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_FurtherInformation, obj.FurtherInformation);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_PrintRun, obj.PrintRun);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_PrintRunDigital, obj.PrintRunDigital);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_LaunchDate, obj.launctDate);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_UsageRightsRequired, obj.UsageRightsRequired);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_WhereItemDistributed, obj.WhereItemDistributed);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_Website, obj.Website);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_LicenceDuration, obj.LicenceDuration);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_ContextOfUseCropped, obj.ContextOfUseCropped);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_ContextOfUseCover, obj.ContextOfUseCover);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_Publishlanguage, obj.Publishlanguage);

                        //newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Product_RefrenceId, "CL - " + contactId);
                        newCustomTableItem.Insert();
                        object id;
                        if (newCustomTableItem.TryGetValue(CopyRightLicencingForm.CopyRightLicencingForm_ItemID, out id))
                        {
                            int productInformationId = Convert.ToInt32(id);

                            ////string folderParent = ConstantDataForForms.CL_FORM_FOLDER + Convert.ToInt32(contactId);
                            ////string folderChild = ConstantDataForForms.CL_FORM_FOLDER_PRODUCT + productInformationId;

                            ////string folder = folderParent + "/" + folderChild;
                            ////bool fol = CreateFolder(folder);
                            ////if (obj.PostedFile.ContentLength != 0)
                            ////{
                            ////    System.IO.Stream myStream;
                            ////    Int32 fileLen;
                            ////    fileLen = obj.PostedFile.ContentLength;
                            ////    Byte[] Input = new Byte[fileLen];
                            ////    myStream = obj.PostedFile.InputStream;
                            ////    myStream.Read(Input, 0, fileLen);
                            ////    fol = CreateFolder(folder);
                            ////    Import(obj.PostedFile.FileName, Input, folder);
                            ////    string filePath = HelperClass.GetFilePath(folder, CopyRightLicencingForm.CopyRightLicencingFormName) + "/" + ReplaceFileName(obj.PostedFile.FileName) + "?ext" + Path.GetExtension(obj.PostedFile.FileName);
                            ////    GetAndUpdateFileAttachment(productInformationId, customTableClassName, filePath);
                            ////}

                            SaveCopyRightLicencingReproductionsInformation(contactId, productInformationId, obj.ProductReproductions);
                        }
                    }

                    return true;
                }
                else
                {
                    logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProduct", "Custom table Null");
                    return false;
                }
            }
            catch (Exception ee)
            {
                logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProduct", ee.Message);
                throw ee;
            }
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
                    int i = 0;
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

        #region //Private Information

        /// <summary>
        /// Saves the copy right licencing reproductions information.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <param name="CopyRightLicencingProductReproductions">The copy right licencing product reproductions.</param>
        /// <returns></returns>
        private bool SaveCopyRightLicencingReproductionsInformation(int contactId, int productId, List<CopyRightLicencingProductReproductions> CopyRightLicencingProductReproductions)
        {
            try
            {

                // Prepare the parameters
                string customTableClassName = CopyRightLicencingForm.CopyRightLicencing_Reproductions_FormTable;
                // Check if Custom table 'Sample table' exists
                DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

                if (customTable != null)
                {
                    // Create new custom table item
                    CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, customTableProvider);

                    foreach (CopyRightLicencingProductReproductions obj in CopyRightLicencingProductReproductions)
                    {
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Reproductions_CopyRightLicencing_Product_Id, productId);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Reproductions_ArtistName, obj.ArtistName);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Reproductions_TitleOfWork, obj.TitleOfWork);
                        //newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Reproductions_ContextOfUse, String.Join<string>(",", obj.ContextOfUse));
                        //newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Reproductions_ContextOfUseCropped, obj.ContextOfUseCropped);
                        //newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencing_Reproductions_ContextOfUseCover, obj.ContextOfUseCover);
                        //newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Reproductions_DepictedWork, obj.DepictedWork);
                        newCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingForm_Reproductions_RefrenceId, contactId);
                        newCustomTableItem.Insert();

                        object id;
                        if (newCustomTableItem.TryGetValue(CopyRightLicencingForm.CopyRightLicencingForm_Reproductions_ItemID, out id))
                        {

                            //if (obj.PostedFile.ContentLength != 0)
                            //{
                            //    int reproductInformationId = Convert.ToInt32(id);
                            //    string folderParent = ConstantDataForForms.CL_FORM_FOLDER + Convert.ToInt32(contactId);
                            //    string folderChild = ConstantDataForForms.CL_FORM_FOLDER_PRODUCT + productId;
                            //    string folderReproduction = ConstantDataForForms.CL_FORM_FOLDER_PRODUCT_REPRODUCTION + reproductInformationId;

                            //    string folder = folderParent + "/" + folderChild + "/" + folderReproduction;
                            //    bool fol = CreateFolder(folder);

                            //    System.IO.Stream myStream;
                            //    Int32 fileLen;
                            //    fileLen = obj.PostedFile.ContentLength;
                            //    Byte[] Input = new Byte[fileLen];
                            //    myStream = obj.PostedFile.InputStream;
                            //    myStream.Read(Input, 0, fileLen);

                            //    Import(obj.PostedFile.FileName, Input, folder);
                            //    string filePath = HelperClass.GetFilePath(folder, CopyRightLicencingForm.CopyRightLicencingFormName) + "/" + ReplaceFileName(obj.PostedFile.FileName) + "?ext" + Path.GetExtension(obj.PostedFile.FileName);
                            //    GetAndUpdateFileAttachment(reproductInformationId, customTableClassName, filePath);
                            //}

                        }
                    }
                    return true;
                }
                else
                {
                    logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProductReproductions", "Custom table Null");
                    return false;
                }


            }
            catch (Exception ee)
            {
                logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProductReproductions", ee.Message);
                throw ee;

            }
        }

        /// <summary>
        /// Replaces the name of the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private string ReplaceFileName(string fileName)
        {
            return fileName.Replace(" ", "-").Replace("&", "-").Replace("'", "-").Replace("+", "-").Replace("=", "-").Replace("[", "-").Replace("]", "-").Replace("#", "-").Replace("%", "-").Replace("\\", "-").Replace("/", "-").Replace(":", "-").Replace("*", "-").Replace("?", "-").Replace("\"", "-").Replace("<", "-").Replace(">", "-").Replace("|", "-");
        }

        /// <summary>
        /// Imports the specified library ID.
        /// </summary>
        /// <param name="libraryID">The library ID.</param>
        /// <param name="folderName">Name of the folder.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        private bool Import(string fileName, byte[] bytes, string folderName, out List<string> fileDownloadPath)
        {
            try
            {
                fileDownloadPath = new List<string>();

                SiteInfo siteInfo = HelperClass.GetSiteInfo();
                string filePath = HelperClass.GetFilePath(folderName, CopyRightLicencingForm.CopyRightLicencingFormName);
                MediaLibraryInfo libraryInfo = HelperClass.GetMediaLibraryInfo(CopyRightLicencingForm.CopyRightLicencingFormName);

                fileName = ReplaceFileName(fileName);
                bool bRetValue = false;
                filePath = HttpContext.Current.Server.MapPath(string.Format("{0}/{1}", filePath, fileName));
                FileStream newFile = new FileStream(filePath, FileMode.Create);
                newFile.Write(bytes, 0, bytes.Length);
                newFile.Close();

                if (File.Exists(filePath))
                {
                    string path = MediaLibraryHelper.EnsurePath(filePath);
                    MediaFileInfo fileInfo = new MediaFileInfo(path, libraryInfo.LibraryID, folderName);
                    fileInfo.FileSiteID = siteInfo.SiteID;
                    MediaFileInfoProvider.ImportMediaFileInfo(fileInfo);
                    bRetValue = true;
                    fileDownloadPath.Add(fileInfo.FilePath);
                }


                return bRetValue;
            }
            catch (Exception ee)
            {
                logService.LogData(MessageType.Error, "Import File to Library", ee.Message);
                throw ee;
            }
        }

        /// <summary>
        /// Creates the folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        private bool CreateFolder(string folder)
        {
            string filePath = HelperClass.GetFilePath(folder, CopyRightLicencingForm.CopyRightLicencingFormName);

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(filePath)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(filePath));
                return true; ;

            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Deletes the contact details.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <returns></returns>
        public bool UpdateRefrence(int Id, string customTableClassName, int refrenceId)
        {
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);

            if (customTable != null)
            {
                string where = CopyRightLicencingForm.CopyRightLicencingForm_ItemID + "=" + Id;
                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, null);

                if (!DataHelper.DataSourceIsEmpty(customTableItems))
                {
                    foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                    {
                        CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
                        modifyCustomTableItem.SetValue("RefrenceId", "CL - " + refrenceId);
                        modifyCustomTableItem.Update();


                    }

                    return true;
                }

            }

            return false;

        }

        ///// <summary>
        ///// Gets the file path.
        ///// </summary>
        ///// <param name="folder">The folder.</param>
        ///// <returns></returns>
        //private string GetFilePath(string folder)
        //{
        //    SiteInfo siteInfo = GetSiteInfo();
        //    MediaLibraryInfo libraryInfo = GetMediaLibraryInfo();

        //    string filePath = string.Format("~/{0}/media/{1}/{2}", siteInfo.SiteName, libraryInfo.LibraryFolder, folder);

        //    return filePath;
        //}

        ///// <summary>
        ///// Gets the media library info.
        ///// </summary>
        ///// <returns></returns>
        //private MediaLibraryInfo GetMediaLibraryInfo()
        //{
        //    return MediaLibraryInfoProvider.GetMediaLibraryInfo(CopyRightLicencingForm.CopyRightLicencingFormName, CMSContext.CurrentSiteName); ;
        //}

        ///// <summary>
        ///// Gets the site info.
        ///// </summary>
        ///// <returns></returns>
        //private SiteInfo GetSiteInfo()
        //{
        //    return SiteInfoProvider.GetCurrentSite();
        //}


        /// <summary>
        /// Gets the and update custom table item.
        /// </summary>
        /// <returns></returns>
        private bool GetAndUpdateFileAttachment(int recordId, string customTableName, string value)
        {
            try
            {

                CustomTableItemProvider customTableProvider = new CustomTableItemProvider(CMSContext.CurrentUser);
                DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableName);

                if (customTable != null)
                {
                    string where = "ItemID=" + recordId;
                    int topN = 1;
                    string columns = "ItemID";
                    DataSet dataSet = customTableProvider.GetItems(customTableName, where, null, topN, columns);
                    if (!DataHelper.DataSourceIsEmpty(dataSet))
                    {
                        int itemID = ValidationHelper.GetInteger(dataSet.Tables[0].Rows[0][0], 0);
                        CustomTableItem updateCustomTableItem = customTableProvider.GetItem(itemID, customTableName);
                        if (updateCustomTableItem != null)
                        {
                            updateCustomTableItem.SetValue(CopyRightLicencingForm.CopyRightLicencingFormName_FileAttachment, value);
                            updateCustomTableItem.Update();
                            return true;
                        }
                        else
                        {
                            logService.LogData(MessageType.Error, "GetAndUpdateCustomTableItem", "Item doesn't exsist");
                            return false;
                        }
                    }
                    else
                    {
                        logService.LogData(MessageType.Error, "GetAndUpdateCustomTableItem", "Item doesn't exsist");
                        return false;
                    }
                }
                else
                {
                    logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProduct", "Custom table Null");
                    return false;
                }
            }
            catch (Exception ee)
            {
                logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", ee.Message);
                return false;
            }

        }
        #endregion
    }
}
