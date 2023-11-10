using CMS.CMSHelper;
using CMS.SiteProvider;
using System;

namespace DacsOnline.Repository.Repositories
{
	public abstract class BaseKenticoDao
	{
		public CustomTableItemProvider customTableProvider;

		protected BaseKenticoDao()
		{
			this.customTableProvider = new CustomTableItemProvider(CMSContext.get_CurrentUser());
		}
	}
}