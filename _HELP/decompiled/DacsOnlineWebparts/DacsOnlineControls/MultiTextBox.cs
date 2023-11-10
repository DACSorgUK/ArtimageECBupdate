using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DacsOnlineWebParts.DacsOnlineControls
{
	public class MultiTextBox : UserControl
	{
		protected HtmlGenericControl dv1;

		protected Button btAddTextBox;

		protected HiddenField multiHiddenCount;

		protected Literal ltlData;

		public string HeaderText
		{
			set
			{
				this.btAddTextBox.Text = value.ToString();
			}
		}

		private int TableRowCount
		{
			get
			{
				int num;
				num = (this.ViewState[this.ClientID] != null ? Convert.ToInt32(this.ViewState[this.ClientID].ToString()) : 0);
				return num;
			}
			set
			{
				this.ViewState[this.ClientID] = value;
			}
		}

		public string Text
		{
			get
			{
				return this.GetValue();
			}
			set
			{
				if ((value == null ? false : !string.IsNullOrEmpty(value.ToString())))
				{
					this.AddRows(1, 1, true);
					this.SetValue(value.ToString());
				}
			}
		}

		public MultiTextBox()
		{
		}

		public void AddRows(int NumberOfRowsToAdd, int NumberOfCellsToAdd, bool increment)
		{
			if (NumberOfRowsToAdd == 0)
			{
				NumberOfRowsToAdd = 1;
			}
			for (int i = 0; i < NumberOfRowsToAdd; i++)
			{
				HtmlGenericControl dynDiv = new HtmlGenericControl("div");
				TextBox textbox = new TextBox();
				textbox.Attributes.Add("runat", "server");
				textbox.Attributes.Add("class", "text");
				this.dv1.Controls.Add(dynDiv);
				dynDiv.Controls.Add(textbox);
			}
			if (increment)
			{
				this.TableRowCount = this.TableRowCount + 1;
			}
		}

		protected void btAddTextBox_Click(object sender, EventArgs e)
		{
			string val = this.GetValue();
			if (val != "")
			{
				string[] values = val.Split(new char[] { ',' });
				if (this.TableRowCount <= (int)values.Length)
				{
					this.AddRows(1, 1, true);
				}
			}
		}

		private string GetValue()
		{
			string data = string.Empty;
			foreach (Control ctrl in this.dv1.Controls)
			{
				HtmlGenericControl dynDiv = ctrl as HtmlGenericControl;
				if (dynDiv != null)
				{
					foreach (Control ctrl2 in dynDiv.Controls)
					{
						TextBox textbox = ctrl2 as TextBox;
						if ((textbox == null ? false : !string.IsNullOrEmpty(textbox.Text)))
						{
							data = string.Concat(textbox.Text, ",", data);
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

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.Page.RegisterRequiresControlState(this);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.AddRows(1, 1, true);
			}
			else
			{
				this.AddRows(this.TableRowCount, 1, false);
			}
		}

		private void SetValue(string value)
		{
			foreach (Control ctrl in this.dv1.Controls)
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
	}
}