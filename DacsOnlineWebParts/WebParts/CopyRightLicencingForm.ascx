<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CopyRightLicencingForm.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.CopyRightLicencingForm" %>
<%@ Register Src="../DacsOnlineControls/CountrySelector.ascx" TagName="CountrySelector"
    TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<style>
    .validation_summary_as_bulletlist {
        color: #990000;
        margin-top: 10px;
        font: 400 0.875em/1.3334 sans-serif;
        font-size: large;
    }

        .validation_summary_as_bulletlist ul {
            display: none;
        }

    .colgroup .threequarters {
        margin-bottom: 5px;
        margin-top: 5px;
    }

    table, th, td {
        padding: 5px;
    }

    #imgLoader {
        display: none;
    }

    .ui-icon-info {
    background-position: -16px -144px;
}
    .ui-icon, .ui-widget-content .ui-icon {
    background-image: url("../../App_Themes/DACS/_assets/ui-icons_222222_256x240.png");
}

    .ui-icon {
    width: 16px;
    height: 16px;
}
    .ui-icon {
    display: block;
    text-indent: -99999px;
    overflow: hidden;
    background-repeat: no-repeat;
}
    .ui-icon {
    display: inline-block !important;
    position: relative;
    top: 3px;
}

</style>



<script>

    function fillCell(row, cellNumber, text) {
        var cell = row.insertCell(cellNumber);
        cell.innerHTML = text;
        // cell.style.borderBottom = cell.style.borderRight = "solid 1px #aaaaff";
    }
    function addToClientTable(name, text) {
        var table = document.getElementById("<%= clientSide.ClientID %>");
        var row = table.insertRow(0);
        fillCell(row, 0, name);
        fillCell(row, 1, text);
        $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully.";
    }

    function uploadError(sender, args) {
        addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
        $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";

    }

    //function uploadComplete(sender, args) {
    //    //  var contentType = args.get_contentType();


    //    let _contentLength = (args.get_length() / (1024)).toFixed(2);
    //    var text = _contentLength + " KB";

    //    if (_contentLength > (1024)) {
    //        text = (_contentLength / 1024).toFixed(2) + " MB";
    //    }

    //    //if (contentType.length > 0) {
    //    //    text += ", '" + contentType + "'";
    //    //}
    //    addToClientTable(args.get_fileName(), text);
    //}

</script>

<h1 class="pagetitle">Request Licence</h1>
<div class="colgroup">
    <div class="column">
        <asp:ValidationSummary ID="valSummaryCL" runat="server" HeaderText="Please fill the required fields" ValidationGroup="ValGroupCLForm" ShowSummary="true" CssClass="validation_summary_as_bulletlist" DisplayMode="BulletList" />
        <!--/.breadcrumb-->
        <%--<div class="boxout">
                    <p class="caption"><img class="left" src="/_assets/icon-padlock.png" alt="icon-padlock" width="28" height="32" />SSL security is used to protect the information you send us via this form. This means that your details will be private and encrypted during transmission.</p>
                </div>--%>
        <%-- <fieldset>--%>
        <%--<legend>1. Artwork details</legend>--%>
        <p>
            Artwork can bring a project to life. If you are interested in licensing the use of an artwork in your project, please complete this short form telling us more about your project and one of our team will get back to you. 
        </p>
        <asp:PlaceHolder ID="plcProduct" runat="server"></asp:PlaceHolder>
        <%-- </fieldset>--%>


        <fieldset>
            <legend>3. Your contact details</legend>
            <div class="colgroup">
                <label for="name-title">
                    Name:
                    <abbr title="Required">
                        *</abbr>
                </label>
                <div class="colgroup">
                   <%-- <div class="left">
                        <asp:DropDownList ID="ddTitle" runat="server" ValidationGroup="ValGroupCLForm">
                        </asp:DropDownList>
                    </div>--%>
                    <asp:TextBox ID="txtFirstName" class="text third left" runat="server" ValidationGroup="ValGroupCLForm"
                        MaxLength="1000"></asp:TextBox>
                    <ajaxtoolkit:textboxwatermarkextender id="txtWName" runat="server" targetcontrolid="txtFirstName"
                        watermarktext="First name(s)" />
                    <asp:TextBox ID="txtLastName" runat="server" class="text third left" ValidationGroup="ValGroupCLForm"
                        MaxLength="1000"></asp:TextBox>
                    <ajaxtoolkit:textboxwatermarkextender id="wtxtLName" runat="server" targetcontrolid="txtLastName"
                        watermarktext="Last name" />
                </div>
                <%--   <em class="red">
                        <asp:CustomValidator ID="cusValTitle" runat="server" ErrorMessage="Title is mandatory please enter"
                            ControlToValidate="ddTitle" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                            OnServerValidate="cusValTitle_ServerValidate"></asp:CustomValidator>
                    </em>--%>
                <em class="red">
                    <asp:CustomValidator ID="CusValFirstName" runat="server" ErrorMessage="First Name is mandatory please enter"
                        ControlToValidate="txtFirstName" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                        OnServerValidate="CusValFirstName_ServerValidate"></asp:CustomValidator>
                </em>
                <em class="red">
                    <asp:CustomValidator ID="cusValLastName" runat="server" ErrorMessage="Last Name is mandatory please enter"
                        ControlToValidate="txtLastName" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                        OnServerValidate="cusValLastName_ServerValidate"></asp:CustomValidator>
                </em>
            </div>

            <div class="colgroup threequarters">
                <div class="column half">
                    <label for="email">
                        Email address:
                         <abbr title="Required">
                             *</abbr>
                    </label>
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="ValGroupCLForm" class="text" MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValEmail" runat="server" ErrorMessage="This field is mandatory please enter"
                            ControlToValidate="txtEmail" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                            OnServerValidate="cusValEmail_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
                <div class="column half">
                    <label for="tel">
                        Phone:
                        <abbr title="Required">
                        </abbr>
                    </label>
                    <asp:TextBox ID="txtPhone" class="fill text" runat="server" MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <%-- <asp:CustomValidator ID="cusValPhone" runat="server" ErrorMessage="Invalid input!"
                            ControlToValidate="txtPhone" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                            OnServerValidate="cusValPhone_ServerValidate"></asp:CustomValidator>--%>
                    </em>
                </div>
            </div>


            <%--  <div class="colgroup threequarters">
                <div class="column half">
                    <label for="tel-mobile">
                        Mobile:
                    </label>
                    <asp:TextBox ID="txtBoxMobile" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValMobile" runat="server" ErrorMessage="Invalid input!"
                            ControlToValidate="txtBoxMobile" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                            OnServerValidate="cusValMobile_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
                <div class="column half">
                    <label for="fax">
                        Fax:
                    </label>
                    <asp:TextBox ID="txtFax" runat="server" class="text fill" ValidationGroup="ValGroupCLForm"
                        MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValfax" runat="server" ErrorMessage="Invalid input!"
                            ControlToValidate="txtFax" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                            OnServerValidate="cusValfax_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
            </div>--%>

            <div class="threequarters">
                <label for="company">
                    Company name (if different):
                     <%--<span class="ui-icon ui-icon-info addtooltip" title="if not a company please add your own name."></span>
                    <span class="info-container" title="if not a company please add your own name.">?<abbr title="Required">
                    </abbr>
                    </span>--%>
                </label>
                <asp:TextBox ID="txtCompany" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                <em class="red">
                    <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Company is mandatory please enter"
                        ControlToValidate="txtCompany" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                        OnServerValidate="CusValCompany_ServerValidate"></asp:CustomValidator>--%>
                </em>
            </div>
            <div class="threequarters">
                <label for="address-street">
                    Postal address:
                    <abbr title="Required">
                        *</abbr>
                </label>
                <asp:TextBox ID="txtAddressLine1" runat="server" class="text" ValidationGroup="ValGroupCLForm"
                    MaxLength="1000"></asp:TextBox>
                <ajaxtoolkit:textboxwatermarkextender id="wtxtAddressLine1" runat="server" targetcontrolid="txtAddressLine1"
                    watermarktext="House Number / Street" />
                <asp:TextBox ID="txtAddressLine2" runat="server" class="text" ValidationGroup="ValGroupCLForm"
                    MaxLength="1000"></asp:TextBox>
                <ajaxtoolkit:textboxwatermarkextender id="wtxtAddressLine2" runat="server" targetcontrolid="txtAddressLine2"
                    watermarktext="Address Line 2" />
                <asp:TextBox ID="txtAddressLine3" runat="server" class="text" ValidationGroup="ValGroupCLForm"
                    MaxLength="1000"></asp:TextBox>
                <ajaxtoolkit:textboxwatermarkextender id="wtxtAddressLine3" runat="server" targetcontrolid="txtAddressLine3"
                    watermarktext="Address Line 3" />
                <em class="red">
                    <asp:CustomValidator ID="cusValAddressLine1" runat="server" ErrorMessage="This field is mandatory please enter"
                        ControlToValidate="txtAddressLine1" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                        OnServerValidate="cusValAddressLine1_ServerValidateT"></asp:CustomValidator>
                </em>
            </div>
            <div class="threequarters">
                <label for="address-city">
                    City/Town:
                    <abbr title="Required">
                        *</abbr>
                </label>
                <asp:TextBox ID="txtCity" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                <em class="red">
                    <asp:CustomValidator ID="cusValCity" runat="server" ErrorMessage="This field is mandatory please enter"
                        ControlToValidate="txtCity" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                        OnServerValidate="cusValCity_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div class="colgroup threequarters">
                <div class="column half">
                    <label for="address-country">
                        County/Region:
                        <%--  <abbr title="Required">
                            *</abbr>--%>
                        <%--   <abbr title="Required">
                            <asp:CustomValidator ID="cusValRegion" runat="server" ErrorMessage="*" ControlToValidate="txtRegion"
                                ValidateEmptyText="true" ValidationGroup="ValGroupCLForm" OnServerValidate="cusValRegion_ServerValidate"></asp:CustomValidator>
                        </abbr>--%>
                    </label>
                    <asp:TextBox ID="txtRegion" runat="server" class="fill text" ValidationGroup="ValGroupCLForm"
                        MaxLength="1000"></asp:TextBox>
                </div>
                <div class="column half">
                    <label for="address-postcode">
                        Postcode/Zipcode:
                        <abbr title="Required">
                            *</abbr>
                    </label>
                    <asp:TextBox ID="txtPostCode" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValPostCode" runat="server" ErrorMessage="This field is mandatory please enter"
                            ControlToValidate="txtPostCode" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                            OnServerValidate="cusValPostCode_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
            </div>
            <div class="text threequarters">
                <label for="address-country">
                    Country:
                    <abbr title="Required">
                        *</abbr></label>
               <%-- <uc1:CountrySelector ID="ArtCountrySelector" runat="server" />--%>
                 <asp:DropDownList ID="ArtCountrySelector" runat="server" CssClass="full" ValidationGroup="ValGroupCLForm">
                            </asp:DropDownList>
                <em class="red">
                    <asp:CustomValidator ID="cusValCountrySelector" runat="server" ErrorMessage="This field is mandatory please enter"
                        ValidationGroup="ValGroupCLForm"
                        OnServerValidate="cusValCountry_ServerValidate"></asp:CustomValidator>
                </em>
            </div>

            <div class="threequarters">
                <label for="url">
                    Website (if you have one):
                </label>
                <asp:TextBox ID="txtWebSite" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                <em class="red">
                    <asp:CustomValidator ID="cusValWebSite" runat="server" ErrorMessage="Invalid input!"
                        ControlToValidate="txtWebSite" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                        OnServerValidate="cusValWebSite_ServerValidate"></asp:CustomValidator>
                </em>
            </div>
            <div class="threequarters">
                <label for="vat">
                    VAT number (if applicable):</label>
                <asp:TextBox ID="txtVatNumber" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
            </div>


            <div>
                <asp:CheckBox ID="chkCookie" class="check" runat="server" />
                Remember contact details for next time (see <a href='<%# CookieUrl %>'>cookie policy</a>)
            </div>

            <asp:UpdatePanel ID="upInvoiceSection" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div>
                        <fieldset class="options">
                            <legend>Use these contact details for the invoice?:
                    <abbr title="Required">
                        *</abbr>
                            </legend>
                            <ul class="compact">
                                <asp:RadioButtonList ID="rbListinvoice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbListinvoice_SelectedIndexChanged">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ul>
                            <em class="red">
                                <asp:CustomValidator ID="cusValContactDetails" runat="server" ErrorMessage="This field is mandatory please enter"
                                    ControlToValidate="rbListinvoice" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusContactDetails_ServerValidate"></asp:CustomValidator>
                            </em>
                        </fieldset>
                    </div>

                    <asp:Panel ID="pnlInvoice" runat="server" Visible="false">
                        <div>
                            Please complete your billing address to be used for billing purposes:
                        </div>
                        <div class="threequarters">
                            <label for="address-BillingContactName">
                                Billing contact name (if different):
                            </label>
                            <asp:TextBox ID="txtBillingContactName" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>

                        </div>
                        <div class="threequarters">
                            <label for="address-BillingEmailAddress">
                                Billing email address (if different):
                            </label>
                            <asp:TextBox ID="txtBillingEmailAddress" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                            <em class="red">
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="please enter enter a valid email"
                                    ControlToValidate="txtBillingEmailAddress" ValidateEmptyText="false" ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusValBillingEmailAddress_ServerValidate"></asp:CustomValidator>
                            </em>
                        </div>
                        <div class="threequarters">
                            <label for="company">
                                Company:
                                <abbr title="Required">*</abbr>
                                <span class="ui-icon ui-icon-info addtooltip" title="if not a company please add your own name."></span>
                            <asp:TextBox ID="txtInvoiceCompany" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                            <em class="red">
                                <asp:CustomValidator ID="cusValInvoiceCompany" runat="server" ErrorMessage="Company is mandatory please enter"
                                    ControlToValidate="txtInvoiceCompany" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="CusValCompany_ServerValidate"></asp:CustomValidator>
                            </em>
                        </div>
                        <div class="threequarters">
                            <label for="address-street">
                                Postal address:
        <abbr title="Required">
            *</abbr>
                            </label>
                            <asp:TextBox ID="txtInvoiceAddressLine1" runat="server" class="text" ValidationGroup="ValGroupCLForm"
                                MaxLength="1000"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="Textboxwatermarkextender1" runat="server" targetcontrolid="txtInvoiceAddressLine1"
                                watermarktext="House Number / Street" />
                            <asp:TextBox ID="txtInvoiceAddressLine2" runat="server" class="text" ValidationGroup="ValGroupCLForm"
                                MaxLength="1000"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="Textboxwatermarkextender2" runat="server" targetcontrolid="txtInvoiceAddressLine2"
                                watermarktext="Address Line 2" />
                            <asp:TextBox ID="txtInvoiceAddressLine3" runat="server" class="text" ValidationGroup="ValGroupCLForm"
                                MaxLength="1000"></asp:TextBox>
                            <ajaxtoolkit:textboxwatermarkextender id="Textboxwatermarkextender3" runat="server" targetcontrolid="txtInvoiceAddressLine3"
                                watermarktext="Address Line 3" />
                            <em class="red">
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="This field is mandatory please enter"
                                    ControlToValidate="txtInvoiceAddressLine1" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusValInvoiceAddressLine1_ServerValidateT"></asp:CustomValidator>
                            </em>
                        </div>
                        <div class="threequarters">
                            <label for="address-city">
                                City/Town:
        <abbr title="Required">
            *</abbr>
                            </label>
                            <asp:TextBox ID="txtInvoiceCity" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                            <em class="red">
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="This field is mandatory please enter"
                                    ControlToValidate="txtInvoiceCity" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusValInvoiceCity_ServerValidate"></asp:CustomValidator>
                            </em>
                        </div>
                        <div class="colgroup threequarters">
                            <div class="column half">
                                <label for="address-country">
                                    County/Region:
                                </label>
                                <asp:TextBox ID="txtInvoiceRegion" runat="server" class="fill text" ValidationGroup="ValGroupCLForm"
                                    MaxLength="1000"></asp:TextBox>
                            </div>
                            <div class="column half">
                                <label for="address-postcode">
                                    Postcode/Zipcode:
            <abbr title="Required">
                *</abbr>
                                </label>
                                <asp:TextBox ID="txtInvoicePostCode" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                                <em class="red">
                                    <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="This field is mandatory please enter"
                                        ControlToValidate="txtInvoicePostCode" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                                        OnServerValidate="cusValInvoicePostCode_ServerValidate"></asp:CustomValidator>
                                </em>
                            </div>
                        </div>
                        <div class="text threequarters">
                            <label for="address-country">
                                Country:
        <abbr title="Required">
            *</abbr></label>
                           <%-- <uc1:CountrySelector ID="ArtInvoiceCountrySelector" runat="server" />--%>
                             <asp:DropDownList ID="ArtInvoiceCountrySelector" runat="server" CssClass="full" ValidationGroup="ValGroupCLForm"></asp:DropDownList>
                            <em class="red">
                                <asp:CustomValidator ID="cusValInvoiceCountrySelector" runat="server" ErrorMessage="This field is mandatory please enter"
                                    ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusValInvoiceCountry_ServerValidate"></asp:CustomValidator>
                            </em>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>

                    <asp:AsyncPostBackTrigger ControlID="rbListinvoice" EventName="SelectedIndexChanged" />

                </Triggers>
            </asp:UpdatePanel>

            <%--<br />


            <br />--%>
            <div style="display: none;">
                <%--<fieldset>--%>
                <p class="icon-plus">
                    <asp:Button ID="btAddAnother" class="MultitextBox" runat="server" Text="Add another product to this application"
                        OnClick="btAddAnother_Click" />
                    <br />
                    i.e. a separate product containing its own reproductions
                </p>
            </div>
            <br />
            <br />
        </fieldset>
        <fieldset>
            <legend>4. Upload a layout and submit your enquiry</legend>
            <div>
                <label class="first-child" for="text50">
                    Attach an additional document (optional):
                </label>
                <em>Please upload a layout (a depiction of the work as it will appear in your product) if the artworks will be used in any of the following ways:
                   <ul>
                       <li>on the cover</li>
                       <li>over-printed</li>
                       <li>cropped or manipulated</li>
                   </ul>

                    The file type must be PDF, DOC or JPG. You can upload a maximum of 10 files with a combined size of 25MB.
                </em>
                <%--<asp:FileUpload ID="FileUploadProduct" runat="server" AllowMultiple="false" onchange="callme(this)" />--%>

                <div class="colgroup threequarters">
                    <div class="column half">
                        &nbsp;&nbsp;&nbsp;&nbsp;<input type="file" id="files" multiple />

                    </div>
                    <div class="column quarter" style="padding-left: 20px; padding-top: 20px;">
                        <asp:Image ID="imgLoader" ClientIDMode="Static" runat="server" ImageUrl="~\App_Themes\Default\Images\RTL\Design\Controls\Tree\loading.gif" />
                    </div>

                </div>
                <button type="button" id="btnUpload" class="button">Upload</button>


                <br />
                <asp:Label ID="lblUploadedList" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblMesg" runat="server" Text=""></asp:Label>
                <br />
                <table class="tblAddedReproduction" runat="server" id="clientSide" />
                <%-- <asp:CustomValidator ID="cusValFileValidator" runat="server" ErrorMessage="This field is mandatory, please enter."
                    ValidationGroup="ValGroupCLForm" OnServerValidate="cusValFileValidator_ServerValidate"></asp:CustomValidator>--%>
                <label>
               If you experience any issues with submitting your enquiry please contact the team at licensing@dacs.org.uk or speak to us on 02077807550.</label>
            </div>
        </fieldset>
        <fieldset>
            <div class="buttongroup">
                <asp:Button ID="btSubmit" runat="server" class="button" Text="Submit licence request"
                    ValidationGroup="zxc,ValGroupCLForm" OnClick="btSubmitData_Click" />
            </div>
        </fieldset>
        <!--/.buttongroup-->

    </div>
</div>
