using CMS.CMSHelper;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using System;

namespace DacsOnline.Repository.DataContext
{
	public static class HelperClass
	{
		public static string GetFilePath(string folder, string libraryName)
		{
			SiteInfo siteInfo = HelperClass.GetSiteInfo();
			MediaLibraryInfo libraryInfo = HelperClass.GetMediaLibraryInfo(libraryName);
			string filePath = string.Format("~/{0}/media/{1}/{2}", siteInfo.get_SiteName(), libraryInfo.get_LibraryFolder(), folder);
			return filePath;
		}

		public static MediaLibraryInfo GetMediaLibraryInfo(string libraryName)
		{
			return MediaLibraryInfoProvider.GetMediaLibraryInfo(libraryName, CMSContext.get_CurrentSiteName());
		}

		public static SiteInfo GetSiteInfo()
		{
			return SiteInfoProvider.GetCurrentSite();
		}
	}
}