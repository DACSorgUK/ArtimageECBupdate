using CMS.GlobalHelper;
using CMS.SettingsProvider;
using CMS.SiteProvider;
using DacsOnline.Model.RepostioriesInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DacsOnline.Repository.Repositories
{
	public class DocumentListRepository : BaseKenticoDao, IDocumentRepository
	{
		public DocumentListRepository()
		{
		}

		public List<string> GetDocumentsInformation()
		{
			List<string> strs;
			List<string> list = new List<string>();
			string customTableClassName = "customtable.NewsCategories";
			if (DataClassInfoProvider.GetDataClass(customTableClassName) == null)
			{
				strs = list;
			}
			else
			{
				DataSet customTableItems = this.customTableProvider.GetItems(customTableClassName, " Status=1", "itemOrder ASC");
				if (DataHelper.DataSourceIsEmpty(customTableItems))
				{
					strs = list;
				}
				else
				{
					foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
					{
						CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
						list.Add(ValidationHelper.GetString(modifyCustomTableItem.GetValue("NewsCategory"), ""));
					}
					strs = list;
				}
			}
			return strs;
		}
	}
}