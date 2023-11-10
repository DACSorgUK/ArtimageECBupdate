using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.FormControls;

public partial class CMSFormControls_CalendarNoMandatory : FormEngineUserControl
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
                Txtdate.Text = value.ToString();
        }
    }


    /// <summary>

    /// Returns an array of values of any other fields returned by the control.

    /// </summary>

    /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>

    public override object[,] GetOtherValues()
    {
        object[,] array = new object[1, 2];
        array[0, 0] = "Calendar";
        array[0, 1] = GetValue();
        return array;
    }


    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>

    public override bool IsValid()
    {
        string val = GetValue().Replace("dd/mm/yyyy", "");
        if (!string.IsNullOrEmpty(val))
        {
            try
            {
                DateTime time = DateTime.Parse(val);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        else //Not Required
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
        string data = string.Empty;

        data = Txtdate.Text;

        return data;
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
       //if (!IsPostBack)
       //   Txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
    }

}