using CMS.CMSHelper;
using CMS.GlobalHelper;
using CMS.MediaLibrary;
using CMS.SettingsProvider;
using CMS.SiteProvider;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Enums;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Repository.DataContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;

namespace DacsOnline.Repository.Repositories
{
	public class CopyRightLicencingFormRepository : BaseKenticoDao, ICopyRightLicencingFormRepository
	{
		private IEventLogService logService;

		public CopyRightLicencingFormRepository(IEventLogService EventLogService)
		{
			this.logService = EventLogService;
		}

		private bool CreateFolder(string folder)
		{
			bool flag;
			string filePath = HelperClass.GetFilePath(folder, "CopyRightLicencingForm");
			if (Directory.Exists(HttpContext.Current.Server.MapPath(filePath)))
			{
				flag = false;
			}
			else
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(filePath));
				flag = true;
			}
			return flag;
		}

		private bool GetAndUpdateFileAttachment(int recordId, string customTableName, string value)
		{
			bool flag;
			try
			{
				CustomTableItemProvider customTableProvider = new CustomTableItemProvider(CMSContext.get_CurrentUser());
				if (DataClassInfoProvider.GetDataClass(customTableName) == null)
				{
					this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProduct", "Custom table Null");
					flag = false;
				}
				else
				{
					string where = string.Concat("ItemID=", recordId);
					DataSet dataSet = customTableProvider.GetItems(customTableName, where, null, 1, "ItemID");
					if (DataHelper.DataSourceIsEmpty(dataSet))
					{
						this.logService.LogData(MessageType.Error, "GetAndUpdateCustomTableItem", "Item doesn't exsist");
						flag = false;
					}
					else
					{
						int itemID = ValidationHelper.GetInteger(dataSet.Tables[0].Rows[0][0], 0);
						CustomTableItem updateCustomTableItem = customTableProvider.GetItem(itemID, customTableName);
						if (updateCustomTableItem == null)
						{
							this.logService.LogData(MessageType.Error, "GetAndUpdateCustomTableItem", "Item doesn't exsist");
							flag = false;
						}
						else
						{
							updateCustomTableItem.SetValue("AttachFile", value);
							updateCustomTableItem.Update();
							flag = true;
						}
					}
				}
			}
			catch (Exception exception)
			{
				this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", exception.Message);
				flag = false;
			}
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

		private bool Import(string fileName, byte[] bytes, string folderName)
		{
			bool flag;
			try
			{
				SiteInfo siteInfo = HelperClass.GetSiteInfo();
				string filePath = HelperClass.GetFilePath(folderName, "CopyRightLicencingForm");
				MediaLibraryInfo libraryInfo = HelperClass.GetMediaLibraryInfo("CopyRightLicencingForm");
				fileName = this.ReplaceFileName(fileName);
				bool bRetValue = false;
				filePath = HttpContext.Current.Server.MapPath(string.Format("{0}/{1}", filePath, fileName));
				FileStream newFile = new FileStream(filePath, FileMode.Create);
				newFile.Write(bytes, 0, (int)bytes.Length);
				newFile.Close();
				if (File.Exists(filePath))
				{
					string path = MediaLibraryHelper.EnsurePath(filePath);
					MediaFileInfo fileInfo = new MediaFileInfo(path, libraryInfo.get_LibraryID(), folderName);
					fileInfo.set_FileSiteID(siteInfo.get_SiteID());
					MediaFileInfoProvider.ImportMediaFileInfo(fileInfo);
					bRetValue = true;
				}
				flag = bRetValue;
			}
			catch (Exception exception)
			{
				Exception ee = exception;
				this.logService.LogData(MessageType.Error, "Import File to Library", ee.Message);
				throw ee;
			}
			return flag;
		}

		private string ReplaceFileName(string fileName)
		{
			string str = fileName.Replace(" ", "-").Replace("&", "-").Replace("'", "-").Replace("+", "-").Replace("=", "-").Replace("[", "-").Replace("]", "-").Replace("#", "-").Replace("%", "-").Replace("\\", "-").Replace("/", "-").Replace(":", "-").Replace("*", "-").Replace("?", "-").Replace("\"", "-").Replace("<", "-").Replace(">", "-").Replace("|", "-");
			return str;
		}

		public int SaveContactDetails(CopyrightLicencingFormdata obj)
		{
			object id = null;
			int num;
			try
			{
				string customTableClassName = "customtable.CopyRightLicencing_ContactDetails";
				if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
				{
					this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", "Custom table Null");
					num = -1;
				}
				else
				{
					CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, this.customTableProvider);
					newCustomTableItem.SetValue("AddressLine2", obj.AddressLine2);
					newCustomTableItem.SetValue("AddressLine3", obj.AddressLine3);
					newCustomTableItem.SetValue("City", obj.City);
					newCustomTableItem.SetValue("Company", obj.Company);
					newCustomTableItem.SetValue("Country", obj.Country);
					newCustomTableItem.SetValue("CountyRegion", obj.CountyRegion);
					newCustomTableItem.SetValue("EmailAddress", obj.EmailAddress);
					newCustomTableItem.SetValue("Fax", obj.Fax);
					newCustomTableItem.SetValue("Name", obj.Name);
					newCustomTableItem.SetValue("AddressLine1", obj.AddressLine1);
					newCustomTableItem.SetValue("LastName", obj.LastName);
					newCustomTableItem.SetValue("Mobile", obj.Mobile);
					newCustomTableItem.SetValue("Phone", obj.Phone);
					newCustomTableItem.SetValue("PostCode", obj.PostCode);
					newCustomTableItem.SetValue("Title", obj.Title);
					newCustomTableItem.SetValue("Website", obj.Website);
					newCustomTableItem.SetValue("VatNumber", obj.VatNumber);
					newCustomTableItem.SetValue("UseContactDetailsInvoice", obj.UseContactDetails);
					newCustomTableItem.SetValue("InvoiceCompany", obj.InvoiceCompany);
					newCustomTableItem.SetValue("InvoiceAddressLine1", obj.InvoiceAddressLine1);
					newCustomTableItem.SetValue("InvoiceAddressLine2", obj.InvoiceAddressLine2);
					newCustomTableItem.SetValue("InvoiceAddressLine3", obj.InvoiceAddressLine3);
					newCustomTableItem.SetValue("InvoiceCity", obj.InvoiceCity);
					newCustomTableItem.SetValue("InvoiceCountyRegion", obj.Country);
					newCustomTableItem.SetValue("InvoicePostCode", obj.InvoicePostCode);
					newCustomTableItem.SetValue("InvoiceCountry", obj.InvoiceCountry);
					newCustomTableItem.Insert();
					if (!newCustomTableItem.TryGetValue("ItemID", ref id))
					{
						this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", "Insert fail");
						num = -1;
					}
					else
					{
						int newId = Convert.ToInt32(id);
						string folder = string.Concat("CRL_Form_", newId);
						this.CreateFolder(folder);
						num = Convert.ToInt32(newId);
					}
				}
			}
			catch (Exception exception)
			{
				Exception ee = exception;
				this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-ContactDetails", ee.Message);
				throw ee;
			}
			return num;
		}

		public bool SaveCopyRightLicencingProductInformation(int contactId, List<CopyRightLicencingProduct> CopyRightLicencingProductInformation)
		{
			object id = null;
			bool flag;
			try
			{
				string customTableClassName = "customtable.CopyRightLicencing_Product";
				if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
				{
					this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProduct", "Custom table Null");
					flag = false;
				}
				else
				{
					CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, this.customTableProvider);
					foreach (CopyRightLicencingProduct obj in CopyRightLicencingProductInformation)
					{
						newCustomTableItem.SetValue("CopyRightLicencingContactId", contactId);
						newCustomTableItem.SetValue("TitleOfProduct", obj.TitleOfProcuct);
						newCustomTableItem.SetValue("TypeOfProduct", obj.TypeOfProduct);
						newCustomTableItem.SetValue("PublishDate", obj.PublishDate);
						newCustomTableItem.SetValue("DateLicenceNeeds", obj.DateLicenceNeeds);
						newCustomTableItem.SetValue("TypeOfEdition", obj.TypeOfEdition);
						newCustomTableItem.SetValue("Publishlanguage", obj.Publishlanguage);
						newCustomTableItem.SetValue("FurtherInformation", obj.FurtherInformation);
						newCustomTableItem.SetValue("ProductDescription", obj.ProductDescription);
						newCustomTableItem.SetValue("ProductQuantity", obj.ProductQuantity);
						newCustomTableItem.SetValue("LaunchDate", obj.launctDate);
						newCustomTableItem.SetValue("ProductSellingPrice", obj.ProductSellingPrice);
						newCustomTableItem.SetValue("Usage_Rights_Required", obj.UsageRightsRequired);
						newCustomTableItem.SetValue("WhereItemDistributed", obj.WhereItemDistributed);
						newCustomTableItem.Insert();
						if (newCustomTableItem.TryGetValue("ItemID", ref id))
						{
							int productInformationId = Convert.ToInt32(id);
							string folderParent = string.Concat("CRL_Form_", Convert.ToInt32(contactId));
							string folderChild = string.Concat("CRL_Product_", productInformationId);
							string folder = string.Concat(folderParent, "/", folderChild);
							bool fol = this.CreateFolder(folder);
							if (obj.PostedFile.ContentLength != 0)
							{
								int fileLen = obj.PostedFile.ContentLength;
								byte[] Input = new byte[fileLen];
								Stream myStream = obj.PostedFile.InputStream;
								myStream.Read(Input, 0, fileLen);
								fol = this.CreateFolder(folder);
								this.Import(obj.PostedFile.FileName, Input, folder);
								string[] strArrays = new string[] { HelperClass.GetFilePath(folder, "CopyRightLicencingForm"), "/", this.ReplaceFileName(obj.PostedFile.FileName), "?ext", Path.GetExtension(obj.PostedFile.FileName) };
								string filePath = string.Concat(strArrays);
								this.GetAndUpdateFileAttachment(productInformationId, customTableClassName, filePath);
							}
							this.SaveCopyRightLicencingReproductionsInformation(contactId, productInformationId, obj.ProductReproductions);
						}
					}
					flag = true;
				}
			}
			catch (Exception exception)
			{
				Exception ee = exception;
				this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProduct", ee.Message);
				throw ee;
			}
			return flag;
		}

		private bool SaveCopyRightLicencingReproductionsInformation(int contactId, int productId, List<DacsOnline.Model.Business_Objects.CopyRightLicencingProductReproductions> CopyRightLicencingProductReproductions)
		{
			object id = null;
			bool flag;
			try
			{
				string customTableClassName = "customtable.CopyRightLicencing_Product_Reproductions";
				if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
				{
					this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProductReproductions", "Custom table Null");
					flag = false;
				}
				else
				{
					CustomTableItem newCustomTableItem = new CustomTableItem(customTableClassName, this.customTableProvider);
					foreach (DacsOnline.Model.Business_Objects.CopyRightLicencingProductReproductions obj in CopyRightLicencingProductReproductions)
					{
						newCustomTableItem.SetValue("CopyRightLicencing_Product_Id", productId);
						newCustomTableItem.SetValue("ArtistName", obj.ArtistName);
						newCustomTableItem.SetValue("TitleOfWork", obj.TitleOfWork);
						newCustomTableItem.SetValue("ContextOfUse", string.Join<string>(",", obj.ContextOfUse));
						newCustomTableItem.SetValue("DepictedWork", obj.DepictedWork);
						newCustomTableItem.SetValue("RefrenceId", contactId);
						newCustomTableItem.Insert();
						if (newCustomTableItem.TryGetValue("ItemID", ref id))
						{
							if (obj.PostedFile.ContentLength != 0)
							{
								int reproductInformationId = Convert.ToInt32(id);
								string folderParent = string.Concat("CRL_Form_", Convert.ToInt32(contactId));
								string folderChild = string.Concat("CRL_Product_", productId);
								string folderReproduction = string.Concat("CRL_Reproduction_", reproductInformationId);
								string[] strArrays = new string[] { folderParent, "/", folderChild, "/", folderReproduction };
								string folder = string.Concat(strArrays);
								this.CreateFolder(folder);
								int fileLen = obj.PostedFile.ContentLength;
								byte[] Input = new byte[fileLen];
								Stream myStream = obj.PostedFile.InputStream;
								myStream.Read(Input, 0, fileLen);
								this.Import(obj.PostedFile.FileName, Input, folder);
								strArrays = new string[] { HelperClass.GetFilePath(folder, "CopyRightLicencingForm"), "/", this.ReplaceFileName(obj.PostedFile.FileName), "?ext", Path.GetExtension(obj.PostedFile.FileName) };
								string filePath = string.Concat(strArrays);
								this.GetAndUpdateFileAttachment(reproductInformationId, customTableClassName, filePath);
							}
						}
					}
					flag = true;
				}
			}
			catch (Exception exception)
			{
				Exception ee = exception;
				this.logService.LogData(MessageType.Error, "CopyRightLicencingFormRepository-CopyRightLicencingProductReproductions", ee.Message);
				throw ee;
			}
			return flag;
		}

		public bool UpdateRefrence(int Id, string customTableClassName, int refrenceId)
		{
			bool flag;
			if (DataClassInfoProvider.GetDataClass(customTableClassName) != null)
			{
				string where = string.Concat("ItemID=", Id);
				DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, where, null);
				if (!DataHelper.DataSourceIsEmpty(customTableItems))
				{
					foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
					{
						CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
						modifyCustomTableItem.SetValue("RefrenceId", string.Concat("CL - ", refrenceId));
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