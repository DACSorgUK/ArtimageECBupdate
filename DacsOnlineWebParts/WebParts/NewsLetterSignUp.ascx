<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsLetterSignUp.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.NewsLetterSignUp" %>
<div id="signup" runat="server" visible="True">
    <h2>
        Sign Up for Our Newsletter</h2>
    <p>
        Get DACS news, press releases and upcoming events direct to your inbox. <a href="/about-us/privacy-policy">
            Privacy Policy</a></p>
    <div class="colgroup">
        <div class="column half">
            <asp:TextBox ID="TxtFirstName" class="text" runat="server" ValidationGroup="ValGroupNewsLetterSignUp"></asp:TextBox>
            <ajaxtoolkit:textboxwatermarkextender id="wmTxtFirstName" runat="server" targetcontrolid="TxtFirstName"
                watermarktext="First name(s)" />
        </div>
        <div class="column half">
            <asp:TextBox ID="TxtSecondName" class="text" runat="server" ValidationGroup="ValGroupNewsLetterSignUp"></asp:TextBox>
            <ajaxtoolkit:textboxwatermarkextender id="wtTxtSecondName" runat="server" targetcontrolid="TxtSecondName"
                watermarktext="Last Name" />
        </div>
    </div>
    <span class="combined">
        <asp:TextBox ID="Txtemail" class="text" runat="server" ValidationGroup="ValGroupNewsLetterSignUp"></asp:TextBox>
        <ajaxtoolkit:textboxwatermarkextender id="wtTxtemail" runat="server" targetcontrolid="Txtemail"
            watermarktext="Email" />
        <asp:Button ID="BtnSignup" class="button" runat="server" Text="Sign Up" OnClick="BtnSignup_Click" />
    </span>
</div>
<em class="red">
        <asp:RequiredFieldValidator ID="ReqValFirstName" runat="server" ErrorMessage="First Name is mandatory, please enter."
            ControlToValidate="TxtFirstName" ValidationGroup="ValGroupNewsLetterSignUp"></asp:RequiredFieldValidator>
    </em></br><em class="red">
        <asp:RequiredFieldValidator ID="ReqValLastName" runat="server" ErrorMessage="Last Name is mandatory, please enter."
            ControlToValidate="TxtSecondName" ValidationGroup="ValGroupNewsLetterSignUp"></asp:RequiredFieldValidator>
    </em></br><em class="red">
        <asp:RegularExpressionValidator ID="RegExpEmail" ControlToValidate="Txtemail" Text="*Invalid email"
            ValidationExpression="^[a-z0-9_\+-]+(\.[a-z0-9_\+-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,4})$"
            runat="server" ValidationGroup="ValGroupNewsLetterSignUp" />
    </em>
<div id="confirmation" runat="server" visible="False">
    <h2 class="notification success last-child">
        <li class="icon-tick first-child">Sign up has been successful</li>
    </h2>
</div>
