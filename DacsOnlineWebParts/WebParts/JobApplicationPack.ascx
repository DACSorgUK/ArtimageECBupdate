<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobApplicationPack.ascx.cs" Inherits="DacsOnlineWebParts.WebParts.JobApplicationPack" %>
<fieldset>

<div id="sendemail" runat="server">
    <h2>
        How to apply
    </h2>
    <p>
        First, download the
        <asp:LinkButton ID="lnkApplication" runat="server" 
            onclick="lnkApplication_Click"> application pack, </asp:LinkButton>
        then email the completed forms to
        <asp:Label ID="lbemail" runat="server" Text=""></asp:Label></p>
    <div id="enterEmail" runat="server" visible="false">
       <label class="first-child">
         Please, enter your email</label>
           <div class="text first">
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        </div>
             <asp:Button ID="btnSubmit" runat="server" class="button" Text="Submit" 
            onclick="btnSubmit_Click" />
    </div>
</div>
<div id="confirmation" runat="server" visible="false">
    <asp:HyperLink ID="linkdownload" runat="server">Click here to download</asp:HyperLink>
</div>
</fieldset>
