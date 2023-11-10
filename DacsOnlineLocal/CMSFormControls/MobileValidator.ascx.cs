using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.FormControls;

public partial class CMSFormControls_MobileValidator : FormEngineUserControl
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
                this.txtMobile.Text = value.ToString();
        }
    }


    /// <summary>

    /// Returns an array of values of any other fields returned by the control.

    /// </summary>

    /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>

    public override object[,] GetOtherValues()
    {
        object[,] array = new object[1, 2];
        array[0, 0] = "Mobile";
        array[0, 1] = GetValue();
        return array;
    }


    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>

    public override bool IsValid()
    {
        if (!string.IsNullOrEmpty(GetValue()))
        {
            string expression = @"(^(\+?\-? *[0-9]+)([,0-9 ]*)([0-9 ])*$)|(^ *$)";
            Regex r = new Regex(expression, RegexOptions.IgnoreCase);
            Match m = r.Match(txtMobile.Text);
            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        else //It's not required
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

        data = txtMobile.Text.Trim();

        return data;
    }
    #endregion

}