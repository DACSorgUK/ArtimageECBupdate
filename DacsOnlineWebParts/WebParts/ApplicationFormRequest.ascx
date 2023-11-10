<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicationFormRequest.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.ApplicationFormRequest" %>
<fielset>
<h2>
    Need help?</h2>
<ul>
    <li><strong>Email:</strong> <a href='mailto:<%# AdministratorEmail %>?subject=DACS'>
        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></a></li>
    <li><strong>Telephone:</strong> <a>
        <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label></a></li>
</ul>
    <legend><strong>Prefer pen and paper?</strong></legend>
     <div id="postme" runat="server" visible="True">
        <div>
            <asp:TextBox ID="txtPost" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox>
            <ajaxtoolkit:textboxwatermarkextender id="txtWPostal" runat="server" targetcontrolid="txtPost"
                watermarktext="Enter your name and postal address and we'll send you a paper application form." />
        </div>
       
        <div class="buttongroup">
            <asp:Button ID="btnPostForm" class="button" runat="server" Text="Post me this form"
                OnClick="Button1_Click" />
            <%--  <a href="#">Download PDF</a>--%>
        </div>
    </div>
<div id="confirmation" runat="server" visible="False">
    <p class="first-child">
        <strong> <li class="icon-tick first-child">Thank you for your interest</li>
        We will post you a paper copy of this form as soon as we can.</strong></p>
</div>
</fielset>
