using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDataAccess;
using CMS.SiteProvider;
using CMS.CMSHelper;

namespace DacsOnline.Repository.Repositories
{
    public  abstract class BaseKenticoDao
    {
        public CustomTableItemProvider customTableProvider;
        
        protected BaseKenticoDao()
        {
          customTableProvider = new CustomTableItemProvider(CMSContext.CurrentUser);
        }
    }
}
