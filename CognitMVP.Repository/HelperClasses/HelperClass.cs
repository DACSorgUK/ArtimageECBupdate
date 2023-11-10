using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.SiteProvider;
using CMS.MediaLibrary;
using CMS.CMSHelper;

namespace DacsOnline.Repository.DataContext
{
    public static class HelperClass
    {
        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        public static string GetFilePath(string folder,string libraryName)
        {
            SiteInfo siteInfo = GetSiteInfo();
            MediaLibraryInfo libraryInfo = GetMediaLibraryInfo(libraryName);

            string filePath = string.Format("~/{0}/media/{1}/{2}", siteInfo.SiteName, libraryInfo.LibraryFolder, folder);

            return filePath;
        }

        /// <summary>
        /// Gets the media library info.
        /// </summary>
        /// <returns></returns>
        public static MediaLibraryInfo GetMediaLibraryInfo(string libraryName)
        {
            return MediaLibraryInfoProvider.GetMediaLibraryInfo(libraryName, CMSContext.CurrentSiteName); ;
        }

        /// <summary>
        /// Gets the site info.
        /// </summary>
        /// <returns></returns>
        public static SiteInfo GetSiteInfo()
        {
            return SiteInfoProvider.GetCurrentSite();
        }
    }
}
