using System;

using CMS.UIControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class CMSPages_PortalTemplate : PortalPage
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        // Init the header tags
        tags.Text = HeaderTags;

        //HtmlMeta meta = new HtmlMeta();
        //meta.Name = "normanrain";
        //meta.Content = "Some words listed here";
        //this.Header.Controls.Add(meta);

        //Control DownloadFirstName = Page.FindControl("MainImage");
        
    }
}
