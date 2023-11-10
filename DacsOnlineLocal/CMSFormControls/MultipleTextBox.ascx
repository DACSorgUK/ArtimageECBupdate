<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultipleTextBox.ascx.cs"
    Inherits="CMSFormControls_MultipleTextBox" %>
<%--<table>
    <tr>
        <td>
            <table id="table1" runat="server">
            </table>
        </td>
        <td>
            <asp:Button ID="btAddTextBox" runat="server" Text="Button" OnClick="btAddTextBox_Click" />
        </td>
    </tr>
</table>--%>

<div id="dv1" runat="server">
</div>
   <div>
        <asp:Button ID="Button1" runat="server" Text="" OnClick="btAddTextBox_Click" />
    <em><asp:Label ID="LbNote" runat="server" Text=""></asp:Label></em>
    </div>
    
<asp:HiddenField ID="multiHiddenCount" runat="server" Value="0" />
<asp:Literal ID="ltlData" runat="server" Visible="false"></asp:Literal>