using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using DacsOnline.Presentation.Presenters;
using WebFormsMvp.Web;
using DacsOnline.Presentation.Views;

namespace DacsOnlineWebParts.DacsOnlineControls
{
    [PresenterBinding(typeof(CountrySelectorPresenter))]
    public partial class CountrySelector : MvpUserControl, ICountrySelectorView
    {
        
        #region //Public Properties
        /// <summary>
        /// Gets the country.
        /// </summary>
        public string Country
        {
            get
            {
                return countryselectorDacs.Value;
            }
            set
            {
              ListItem item=  countryselectorDacs.Items.FindByValue(value);
              int index=countryselectorDacs.Items.IndexOf(item);
              countryselectorDacs.SelectedIndex = index;
            }
        }
        #endregion

        #region //Event Handlers
        /// <summary>
        /// Occurs when [load form].
        /// </summary>
        public event EventHandler LoadForm;
        #endregion

        #region //Public Methods



        /// <summary>
        /// Loads the form.
        /// </summary>
        /// <param name="CountryList"></param>
        public void BindCountry(List<string> CountryList)
        {
           
            //countryselectorDacs.DataSource = CountryList;
            //countryselectorDacs.DataBind();
            countryselectorDacs.Items.Insert(0, new ListItem("Type to select Country", "Type to select Country"));
            int location=1;
            foreach (string item in CountryList)
            {
                countryselectorDacs.Items.Insert(location, new ListItem(item, item));
                location++;
            }
        }

       

        #endregion

        #region //Page Methods
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (LoadForm != null)
                {
                    LoadForm(sender, e);
                }
            }
        }
        #endregion

        //protected void CustomCountryValidator_ServerValidate(object source, ServerValidateEventArgs args)
        //{

        //    if (Country == "Type to select Country")
        //    {
        //        args.IsValid = false;
        //    }
        //}
    }
}