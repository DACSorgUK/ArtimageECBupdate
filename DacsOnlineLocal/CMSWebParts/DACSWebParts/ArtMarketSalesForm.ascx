<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArtMarketSalesForm.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.ArtMarketSalesForm" %>
<%@ Register Src="../DacsOnlineControls/CountrySelector.ascx" TagName="CountrySelector"
    TagPrefix="uc1" %>

       <style>
   .validation_summary_as_bulletlist
    {
         color: #990000;
         margin-top:10px;
         font: 400 0.875em/1.3334 sans-serif;
         font-size:large;

         
         
    }
      .validation_summary_as_bulletlist ul
    {
        display:none;
         
    }
   </style>


<h1 class="pagetitle">
    Submit your sales details</h1>
<div class="colgroup">
    <div class="column" role="main">
     <asp:ValidationSummary ID="valSummaryCL" runat="server" HeaderText="Please scroll through the form to complete all highlighted mandatory fields." ValidationGroup="ValGroupArtMarketsales" ShowSummary="true" CssClass="validation_summary_as_bulletlist" DisplayMode="BulletList"  />
        <fieldset>
            <legend>Your Contact Details</legend>
            <div class="colgroup">
                <label for="name-title">
                    Name:
                    <abbr title="Required">
                        *</abbr></label>
                <div class="colgroup">
                    <asp:DropDownList ID="ddTitle" runat="server" class="left" ValidationGroup="ValGroupArtMarketsales">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtName" runat="server" class="text third left" ValidationGroup="ValGroupArtMarketsales"
                        MaxLength="1000"></asp:TextBox>
                    <ajaxtoolkit:textboxwatermarkextender id="txtWFirstName" runat="server" targetcontrolid="txtName"
                        watermarktext="First name(s)" />
                    <asp:TextBox ID="txtLastName" runat="server" class="text third left" ValidationGroup="ValGroupArtMarketsales"
                        MaxLength="1000"></asp:TextBox>
                    <ajaxtoolkit:textboxwatermarkextender id="txtWLastName" runat="server" targetcontrolid="txtLastName"
                        watermarktext="Last Name" />
                    <%--   <em class="red">
                    <asp:CustomValidator ID="cusValTitle" runat="server" ErrorMessage="Title is mandatory please enter"
                        ControlToValidate="ddTitle" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValTitle_ServerValidate"></asp:CustomValidator>
                </em>--%>
                </div>
                <em class="red">
                    <asp:CustomValidator ID="cusValName" runat="server" ErrorMessage="First Name is mandatory, please enter."
                        ControlToValidate="txtName" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValName_ServerValidate"></asp:CustomValidator>
                </em><em class="red">
                    <asp:CustomValidator ID="cusValLastName" runat="server" ErrorMessage="Last Name is mandatory, please enter."
                        ControlToValidate="txtLastName" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValLastName_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div>
                <label for="company">
                    Company: <abbr title="Required">*</abbr>
                </label>
                <asp:TextBox ID="txtCompany" runat="server" class="text threequarters" ValidationGroup="ValGroupArtMarketsales"
                    MaxLength="1000"></asp:TextBox>
                <em class="red">
                    <asp:CustomValidator ID="cusValCompany" runat="server" ErrorMessage="This field is mandatory, please enter."
                        ControlToValidate="txtCompany" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValCompany_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div>
                <label for="address-street">
                    Postal address:<abbr title="Required">*</abbr>
                </label>
                <asp:TextBox ID="txtAddressLine1" runat="server" class="text threequarters" ValidationGroup="ValGroupArtMarketsales"
                    MaxLength="1000"></asp:TextBox>
                <ajaxtoolkit:textboxwatermarkextender id="txtWAddressLine1" runat="server" targetcontrolid="txtAddressLine1"
                    watermarktext="House Number / Street" />
                <asp:TextBox ID="txtAddressLine2" runat="server" class="text threequarters" ValidationGroup="ValGroupArtMarketsales"
                    MaxLength="1000"></asp:TextBox>
                <ajaxtoolkit:textboxwatermarkextender id="txtWAddressLine2" runat="server" targetcontrolid="txtAddressLine2"
                    watermarktext="Address Line 2" />
                <asp:TextBox ID="txtAddressLine3" runat="server" class="text threequarters" ValidationGroup="ValGroupArtMarketsales"
                    MaxLength="1000"></asp:TextBox>
                <ajaxtoolkit:textboxwatermarkextender id="txtWAddressLine3" runat="server" targetcontrolid="txtAddressLine3"
                    watermarktext="Address Line 3" />
                <em class="red">
                    <asp:CustomValidator ID="cusValAddressLine1" runat="server" ErrorMessage="This field is mandatory, please enter."
                        ControlToValidate="txtAddressLine1" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValAddressLine1_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div>
                <label for="address-city">
                    City/Town:<abbr title="Required">*</abbr>
                    <em class="red">
                        <asp:CustomValidator ID="cusValCity" runat="server" ErrorMessage="This field is mandatory, please enter."
                            ControlToValidate="txtCity" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                            OnServerValidate="cusValCity_ServerValidate"></asp:CustomValidator>
                    </em>
                </label>
                <asp:TextBox ID="txtCity" runat="server" class="text threequarters" ValidationGroup="ValGroupArtMarketsales"
                    MaxLength="1000"></asp:TextBox>
            </div>
            <div class="colgroup threequarters">
                <div class="column half">
                    <label for="address-country">
                        County/Region:
                        <%-- <abbr title="Required"> not mandatory
                            <asp:CustomValidator ID="cusValRegion" runat="server" ErrorMessage="This field is mandatory please enter" ControlToValidate="txtRegion"
                                ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales" OnServerValidate="cusValRegion_ServerValidate"></asp:CustomValidator>
                        </abbr>--%>
                    </label>
                    <asp:TextBox ID="txtRegion" runat="server" class="text fill" ValidationGroup="ValGroupArtMarketsales"
                        MaxLength="1000"></asp:TextBox>
                </div>
                <div class="column half">
                    <label for="address-postcode">
                        Postcode/Zipcode:<abbr title="Required">*</abbr>
                    </label>
                    <asp:TextBox ID="txtPostCode" runat="server" class="text" ValidationGroup="ValGroupArtMarketsales"
                        MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValPostCode" runat="server" ErrorMessage="This field is mandatory, please enter."
                            ControlToValidate="txtPostCode" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                            OnServerValidate="cusValPostCode_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
            </div>
            <div>
                <label for="address-country">
                    Country:<abbr title="Required">*</abbr>
                </label>
                <div class="text threequarters">
                    <uc1:CountrySelector ID="ArtCountrySelector" runat="server" />
                </div>
                <em class="red">
                    <asp:CustomValidator ID="cusValCountry" runat="server" ErrorMessage="This field is mandatory, please enter."
                        ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales" OnServerValidate="cusValCountry_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div>
                <label for="tel">
                    Phone:<abbr title="Required">*</abbr>
                </label>
                <asp:TextBox ID="txtPhone" runat="server" class="text third" MaxLength="1000"></asp:TextBox>
                <em class="red">
                    <asp:CustomValidator ID="cusValPhone" runat="server" ErrorMessage="This field is mandatory, please enter."
                        ControlToValidate="txtPhone" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValPhone_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div class="colgroup threequarters">
                <div class="column half">
                    <label for="tel-mobile">
                        Mobile(Optional):
                    </label>
                    <asp:TextBox ID="txtBoxMobile" runat="server" class="text fill" ValidationGroup="ValGroupArtMarketsales"
                        MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValMobile" runat="server" ErrorMessage="This field is mandatory, please enter."
                            ControlToValidate="txtBoxMobile" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                            OnServerValidate="cusValMobile_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
                <div class="column half">
                    <label for="fax">
                        Fax(Optional):
                    </label>
                    <asp:TextBox ID="txtFax" runat="server" class="text fill" ValidationGroup="ValGroupArtMarketsales"
                        MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValfax" runat="server" ErrorMessage="This field is mandatory, please enter."
                            ControlToValidate="txtFax" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                            OnServerValidate="cusValfax_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
            </div>
            <div>
                <label for="email">
                    Email address:<abbr title="Required">*</abbr>
                </label>
                <asp:TextBox ID="txtEmail" runat="server" class="text threequarters" ValidationGroup="ValGroupArtMarketsales"
                    MaxLength="1000"></asp:TextBox>
                <em class="red">
                    <asp:CustomValidator ID="cusValEmail" runat="server" ErrorMessage="This field is mandatory, please enter."
                        ControlToValidate="txtEmail" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValEmail_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div>
                <label for="url">
                    Website (if you have one):
                </label>
                <asp:TextBox ID="txtWebSite" runat="server" class="text threequarters" ValidationGroup="ValGroupArtMarketsales"
                    MaxLength="1000"></asp:TextBox>
                <em class="red">
                    <asp:CustomValidator ID="cusValWebSite" runat="server" ErrorMessage="This field is mandatory, please enter."
                        ControlToValidate="txtFax" ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                        OnServerValidate="cusValWebSite_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div>
                <label for="checkbox" class="check">
                    <asp:CheckBox ID="chkCookie" runat="server" />
                    Remember contact details for next time (see <a href='<%# CookieUrl %>' target="_blank">cookie policy</a>)</label>
            </div>
        </fieldset>
    </div>
    <!--/.column-->
</div>
<fieldset>
    <br />
    <asp:PlaceHolder ID="plcSales" runat="server"></asp:PlaceHolder>
    <br />
</fieldset>
<fieldset>
  <p class="icon-plus first-child last-child">
                    <asp:Button ID="btAddAnother" class="link linkAddItem" runat="server" Text="Add another item to your sales information" ValidationGroup="ValGroupArtMarketsales" CausesValidation="true"
                OnClick="btAddAnother_Click" />
    </p>
    <br />
    <asp:Button ID="btSubmit" class="button" runat="server" Text="Submit sales details " CausesValidation="true"
        ValidationGroup="ValGroupArtMarketsales" OnClick="btSubmitData_Click" />
</fieldset>
