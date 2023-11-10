using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.DACSArtistSearchWebService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DACS_TestArtistSearchCMR : System.Web.UI.Page
{
    string key = ConfigurationManager.AppSettings["CRMWebServiceAccessKey"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //System.Net.ServicePointManager.
        //    ServerCertificateValidationCallback =
        //       ((sender1, certificate, chain, sslPolicyErrors) => true);

        //DACSAccessSoapClient _service = new DACSAccessSoapClient();
        
        //string firstName = txtFirstName.Text.Trim();
        //string lastName = txtLastName.Text.Trim();
        //int pageSize = Convert.ToInt32(txtPageSize.Text);

        //DACSAtristList _items = _service.SearchARRArtist(key,firstName, lastName, pageSize, 1);
        //lblMessage.Text = "<br/>====== "+DateTime.Now.ToLongDateString()+" "+ DateTime.Now.ToLongTimeString() + @" =====<br/>
        //   TOTAL Record :"+ _items .TotalArtist+ " <br/><br/>";
        ////foreach (PayBack.DACSArtist temp in _items.ArtistList)
        ////{
        ////    lblMessage.Text += temp.FirstName + " " + temp.LastName + "- year of Birth(" + temp.YearOfBirth + ")<br/>";
        ////}
        //GridView1.RowStyle.VerticalAlign = VerticalAlign.Middle;
        //GridView1.DataSource = _items.ArtistList;
        //GridView1.DataBind();
    }
}