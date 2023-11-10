<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultiTextBox.ascx.cs" Inherits="DacsOnlineWebParts.DacsOnlineControls.MultiTextBox" %>
<div id="dv1" runat="server">
</div>
 <div>
        <asp:Button ID="btAddTextBox" runat="server" Text="" OnClick="btAddTextBox_Click" />
    </div>
<asp:HiddenField ID="multiHiddenCount" runat="server" EnableViewState="true" Value="0"  />
<asp:Literal ID="ltlData" runat="server" Visible="false"></asp:Literal>
