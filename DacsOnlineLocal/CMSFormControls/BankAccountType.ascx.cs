using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.FormControls;
using CMS.GlobalHelper;
using System.Web.UI.HtmlControls;
using CMS.PortalControls;

public partial class CMSFormControls_BankAccountType : FormEngineUserControl
{
    public EventHandler ChangeDropDown;
  
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
           // ddBankDetails.SelectedValue = ((string)value).Trim();
        }
    }


    /// <summary>

    /// Returns an array of values of any other fields returned by the control.

    /// </summary>

    /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>

    public override object[,] GetOtherValues()
    {
        object[,] array = new object[1, 2];
        array[0, 0] = "BankAccout";
        array[0, 1] = GetValue();
        return array;
    }


    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>

    public override bool IsValid()
    {
        if (ddBankDetails.SelectedValue == "-1")
        {
            this.ValidationError = "This field is mandatory, please enter.";
            return false;

        }
        else
        {
            return true;
        }
    }




    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <returns></returns>
    private string GetValue()
    {

        return ddBankDetails.SelectedValue;
       
    }

    private void SetValue(string data)
    {
        //string data = string.Empty;
        ddBankDetails.SelectedValue = data;
    }


    #endregion


  

    protected void Page_Load(object sender, EventArgs e)
    {
       	   if (IsPostBack)
	   {
	        Page.ClientScript.RegisterHiddenField("hdnPostBack", "1");
	   }
    }

   

}