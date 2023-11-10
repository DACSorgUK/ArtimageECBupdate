using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.FormControls;
using CMS.GlobalHelper;
using System.Web.UI.HtmlControls;

public partial class CMSFormControls_UKSortCode : FormEngineUserControl
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
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                SetValue(value.ToString());
            }
        }
    }


    /// <summary>

    /// Returns an array of values of any other fields returned by the control.

    /// </summary>

    /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>

    public override object[,] GetOtherValues()
    {
        object[,] array = new object[1, 2];
        array[0, 0] = "SortCode";
        array[0, 1] = GetValue();
        return array;
    }


    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>

    public override bool IsValid()
    {
        if (!string.IsNullOrEmpty(((string)Value).Trim().Replace("-","")))
        {
            if (Value.ToString() == "N/A-N/A-N/A")
                return true;
            else if (txtFirst.Text.Trim() != "" && txtSecond.Text.Trim() != "" && txtThird.Text.Trim() != "")
            {
                string val = ((string)Value).Replace("-", "");
                double Num;
                bool isNum = double.TryParse(val, out Num);
                if (isNum)
                {
                    return true;
                }
                else
                {
                    this.ValidationError = "This field is mandatory, please enter.";
                    return false;
                }
            }
            else
            {
                this.ValidationError = "This field is mandatory please enter";
                return false;
            }
            

        }
        else
        {
            // Set form control validation error message.
            //this.ValidationError = "Please Enter Value.";
            //return false;
            return false; //It's mandatory
        }
    }




    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <returns></returns>
    private string GetValue()
    {
        string data = string.Empty;

        data = txtFirst.Text.Trim() + "-" + txtSecond.Text.Trim() + "-" + txtThird.Text.Trim();

        return data;
    }

    /// <summary>
    /// Sets the value.
    /// </summary>
    /// <param name="SortCode">The sort code.</param>
    /// <returns></returns>
    private void SetValue(string SortCode)
    {
        string[] arrValues = SortCode.Split('-');
        if (arrValues.Length > 2)
        {
        txtFirst.Text = arrValues[0];
        txtSecond.Text = arrValues[1];
        txtThird.Text = arrValues[2];
        }
    }
    #endregion


  
}