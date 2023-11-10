using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DacsOnlineWebParts.WebParts.DacsOnlineControls
{
    public partial class Calendar : System.Web.UI.UserControl
    {
        public string Date
        {
            get
            {
                if (String.IsNullOrEmpty(Txtdate.Text))
                    return null;
                else
                    return Txtdate.Text.Trim();
            }
            set
            {
                Txtdate.Text = value.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
 
        }


    }
}