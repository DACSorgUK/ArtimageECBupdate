using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DacsOnlineWebParts.DacsOnlineControls
{
    public partial class MultiTextBox : System.Web.UI.UserControl
    {
        #region //Private properties
        /// <summary>
        /// Gets or sets the table row count.
        /// </summary>
        /// <value>
        /// The table row count.
        /// </value>
        private int TableRowCount
        {
            set
            {
                ViewState[this.ClientID] = value;
            }
            get
            {
                if (ViewState[this.ClientID] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(ViewState[this.ClientID].ToString());
                }
            }
        }
        #endregion

        #region //Page Methods
        /// <summary>
        /// Handles the Click event of the btAddTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btAddTextBox_Click(object sender, EventArgs e)
        {
            string val = GetValue();
            if (val != "")
            {
                string[] values = val.Split(',');
                if (TableRowCount <= values.Length)
                {
                    AddRows(1, 1, true);
                }
            }
        }

        /// <summary>
        /// Init event handler.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        ///// <summary>
        ///// Saves any server control state changes that have occurred since the time the page was posted back to the server.
        ///// </summary>
        ///// <returns>
        ///// Returns the server control's current state. If there is no state associated with the control, this method returns null.
        ///// </returns>
        //protected override object SaveControlState()
        //{
        //    object[] objR = {
        //                      base.SaveControlState(),
        //                      TableRowCount
                  
        //                    };
        //    return objR;
        //}

        ///// <summary>
        ///// Restores control-state information from a previous page request that was saved by the <see cref="M:System.Web.UI.Control.SaveControlState"/> method.
        ///// </summary>
        ///// <param name="savedState">An <see cref="T:System.Object"/> that represents the control state to be restored.</param>
        //protected override void LoadControlState(object savedState)
        //{
        //    object[] objState = (object[])savedState;
        //    base.LoadControlState(objState[0]);
        //    TableRowCount = (int)objState[1];

        //}
        #endregion

        #region //Public Methods
        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="NumberOfRowsToAdd">The number of rows to add.</param>
        /// <param name="NumberOfCellsToAdd">The number of cells to add.</param>
        public void AddRows(int NumberOfRowsToAdd, int NumberOfCellsToAdd,bool increment)
        {
            if (NumberOfRowsToAdd == 0)
                NumberOfRowsToAdd = 1;
            /******TABLE CODE******
            for (int i = 1; i <= NumberOfRowsToAdd; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                for (int j = 1; j <= NumberOfCellsToAdd; j++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    cell.Controls.Add(new TextBox() { Width = Unit.Pixel(80) });
                    row.Cells.Add(cell);
                }
                table1.Rows.Add(row);
            }

           // ViewState["TableRowCount"] = table1.Rows.Count;  
            TableRowCount = table1.Rows.Count;

             */
            /******dIV CODE*******/
            for (int i = 0; i < NumberOfRowsToAdd; i++)
            {
                HtmlGenericControl dynDiv =
                new HtmlGenericControl("div");
                TextBox textbox = new TextBox();
                textbox.Attributes.Add("runat", "server");
                textbox.Attributes.Add("class", "text");
                dv1.Controls.Add(dynDiv);
                dynDiv.Controls.Add(textbox);
            }

         
           // multiHiddenCount.Value = (Convert.ToInt32(multiHiddenCount.Value.ToString()) + 1).ToString();
            

            //for (int i = 1; i <= NumberOfRowsToAdd; i++)
            //{
            //    HtmlTableRow row = new HtmlTableRow();
            //    table1.Rows.Add(row);
            //}
            if(increment)
               TableRowCount = TableRowCount + 1;
        }
        #endregion

        #region //Public Properties
        /// <summary>
        /// Sets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        public string HeaderText
        {
            set
            {
                btAddTextBox.Text = value.ToString();
            }
        }
        /// <summary>
        /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
        /// </summary>

        public string Text
        {
            get
            {
                return GetValue();
            }
            set
            {
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    AddRows(1, 1,true);
                    SetValue(value.ToString());
                }
            }

        }



        /// <summary>
        /// Handler for the Load event of the control.
        /// </summary>

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //if (ViewState["TableRowCount"] != null)
                //    AddRows(Convert.ToInt32(ViewState["TableRowCount"]), 1);
                AddRows(TableRowCount, 1,false);
            }
            else
            {
                AddRows(1, 1,true);
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        private string GetValue()
        {
            string data = string.Empty;

            foreach (Control ctrl in dv1.Controls)
            {
                HtmlGenericControl dynDiv = ctrl as HtmlGenericControl;
                if (dynDiv != null)
                {
                    foreach (Control ctrl2 in dynDiv.Controls)
                    {
                        TextBox textbox = ctrl2 as TextBox;
                        if (textbox != null && !string.IsNullOrEmpty(textbox.Text))
                        {
                            data = textbox.Text +"," + data;
                        }
                    }
                }

            }

            if (data.Length > 0)
            {
                data = data.Substring(0, data.Length - 1);
            }

            return data;
        }
        private void SetValue(string value)
        {
            foreach (Control ctrl in dv1.Controls)
            {
                HtmlGenericControl dynDiv = ctrl as HtmlGenericControl;
                if (dynDiv != null)
                {
                    foreach (Control ctrl2 in dynDiv.Controls)
                    {
                        TextBox textbox = ctrl2 as TextBox;
                        if (textbox != null)
                        {
                            textbox.Text = value;
                            break;
                        }
                    }
                }

            }
        }
        #endregion
    }
}