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
using System.Collections.Generic;

namespace DacsOnline.Repository.Repositories
{
    public class DocumentListRepository : BaseKenticoDao, IDocumentRepository
    {
 
        #region contructor
        public DocumentListRepository()
        {
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the documents that we want show in the form
        /// </summary>
        /// <param name="Form">The form.</param>
        /// <returns></returns>
        public List<string> GetDocumentsInformation()
        {
            List<string> list = new List<string>();
            string customTableClassName = DocumentList.DocumentListTable;
            DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);


            if (customTable != null)
            {

                string where = " Status=1";
                DataSet customTableItems = customTableProvider.GetItems(customTableClassName, where, "itemOrder ASC");

                if (!DataHelper.DataSourceIsEmpty(customTableItems))
                {
                    int i = 0;
                    foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                    {
                        CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
                        list.Add(ValidationHelper.GetString(modifyCustomTableItem.GetValue("NewsCategory"), ""));
                    }
                    return list;

                }
                else
                {
                    return list;
                }

            }
            else
            {
                return list;
            }   
        }

        #endregion


    }
}
