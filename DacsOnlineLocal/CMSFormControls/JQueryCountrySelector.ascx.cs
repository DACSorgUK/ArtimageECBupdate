using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.FormControls;
using CMS.GlobalHelper;
using System.Web.UI.HtmlControls;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;
using CMS.SettingsProvider;
using System.Data;
using CMS.SiteProvider;
using CMS.CMSHelper;

public partial class CMSFormControls_JQueryCountrySelector : FormEngineUserControl
{

    #region //Public Properties
    /// <summary>
    /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
    /// </summary>

    public override Object Value
    {
        get
        {
            return GetValue();
        }
        set
        {
            if (value != null)
                SetValue(value.ToString());
        }
    }

    #endregion

    #region //Public methods

    /// <summary>

    /// Returns an array of values of any other fields returned by the control.

    /// </summary>

    /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>

    public override object[,] GetOtherValues()
    {
        object[,] array = new object[1, 2];
        array[0, 0] = "Country";
        array[0, 1] = GetValue();
        return array;
    }


    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>

    public override bool IsValid()
    {
        if ((string)Value == ("Type to select Country"))
        {

            this.ValidationError = "This field is mandatory, please enter.";
            return false;

        }
        else
        {
            // Set form control validation error message.
            //this.ValidationError = "Please Enter Value.";
            //return false;
            return true;
        }
    }

#endregion

    #region //Private Methods

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <returns></returns>
    private string GetValue()
    {
        string data = string.Empty;

        data = countryselectorDacs.Value;

        return data;
    }



    /// <summary>
    /// Sets the value.
    /// </summary>
    /// <param name="data">The data.</param>
    private void SetValue(string data)
    {
        if (!(countryselectorDacs.Items.Count > 0))
        {
            GetNationalities();
        }
        ListItem item = countryselectorDacs.Items.FindByValue(data);
        int index = countryselectorDacs.Items.IndexOf(item);
        countryselectorDacs.SelectedIndex = index;
    }

    //This something i didn't want to do i have tried use unity injection and MVP both didn't work with Form Controls 
    //i have email to Kentico regarding this but didn't get a good response. i will do more research about this untill i
    //figure this thing out properly i need to keep the code like this
    /// <summary>
    /// Gets the nationalities.
    /// </summary>
    /// <returns></returns>
    private void GetNationalities()
    {
        countryselectorDacs.Items.Insert(0, new ListItem("Type to select Country", "Type to select Country"));
        int location = 1;
        CustomTableItemProvider customTableProvider = new CustomTableItemProvider(CMSContext.CurrentUser);
        string customTableClassName = ConstantDataArtistSearch.NationalityTable;
        DataClassInfo customTable = DataClassInfoProvider.GetDataClass(customTableClassName);
        if (customTable != null)
        {
            DataSet customTableItems = customTableProvider.GetItems(customTableClassName, null, "Country");
            if (!DataHelper.DataSourceIsEmpty(customTableItems))
            {
                foreach (DataRow customTableItemDr in customTableItems.Tables[0].Rows)
                {
                  
                    CustomTableItem modifyCustomTableItem = new CustomTableItem(customTableItemDr, customTableClassName);
                    string country = ValidationHelper.GetString(modifyCustomTableItem.GetValue("Country"), "");
                    countryselectorDacs.Items.Insert(location, new ListItem(country, country));
                    location++;
                }

            }
        }
    }
    #endregion

    #region //Page Methods
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!(countryselectorDacs.Items.Count > 0))
            {
                GetNationalities();
            }
            
        }
    }
    #endregion


}