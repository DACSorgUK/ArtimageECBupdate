using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.FormControls;
using CMS.GlobalHelper;
using System.Web.UI.HtmlControls;

public partial class CMSFormControls_DDRelationShipToState : FormEngineUserControl
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
            ddRelationShip.SelectedValue = (string)value;
        }
    }


    /// <summary>

    /// Returns an array of values of any other fields returned by the control.

    /// </summary>

    /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>

    public override object[,] GetOtherValues()
    {
        object[,] array = new object[1, 2];
        array[0, 0] = "RelationShip";
        array[0, 1] = GetValue();
        return array;
    }


    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>

    public override bool IsValid()
    {
        if (ddRelationShip.SelectedValue=="-1")
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




    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <returns></returns>
    private string GetValue()
    {
        return ddRelationShip.SelectedValue;
    }
    #endregion


}