<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CLProduct.ascx.cs" Inherits="DacsOnlineWebParts.DacsOnlineControls.CLProduct" %>
<%@ Register Src="CLReproductions.ascx" TagName="CLReproductions" TagPrefix="CLPro" %>

<script src="~/App_Themes/DACS/_js/jquerycalendar/js/jquery-ui-1.8.20.custom.min.js"
    type="text/javascript"></script>
<script src="~/App_Themes/DACS/_js/watermarks.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $(function () {

            $("#<%= txtDateLicence.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtDateLicence.ClientID %>").Watermark("dd/mm/yyyy");

            $("#<%= txtPlannedDateOfIssue.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtPlannedDateOfIssue.ClientID %>").Watermark("dd/mm/yyyy");
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $("#<%= txtDateLicence.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtDateLicence.ClientID %>").Watermark("dd/mm/yyyy");

            $("#<%= txtPlannedDateOfIssue.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtPlannedDateOfIssue.ClientID %>").Watermark("dd/mm/yyyy");
        });

    });
</script>
<asp:HyperLink ID="nypEdit" runat="server" Visible="false"></asp:HyperLink>
<div id="idProduct" runat="server">
    <fieldset>
        <legend>1. Artwork details</legend>
        <div>
            <%--Add artists and artworks<span class="info-container" title="Please select an artist and add an artwork to your enquiry by typing
in the details and pressing the add button.">?<abbr title="Required">
    &nbsp;</abbr></span>--%>
            Please provide details of the artist and artwork that you would like to license and click <b> ‘Add artwork’</b>.
            <label>It can take a moment to return the artist results.</label>
        </div>
        <asp:UpdatePanel ID="upnReproduction" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="plcProductReproductions" runat="server">
                    <CLPro:CLReproductions ID="CLReproductionsFirst" runat="server" />
                </asp:PlaceHolder>
                <p>
                    <asp:Button ID="btAddReproduction" class="MultitextBox" runat="server" Text="Add Artwork" ValidationGroup="zxc"
                        OnClick="btAddReproduction_Click" /><br />
                    <asp:Label ID="lbProduct2" runat="server" Text=""></asp:Label>
                </p>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btAddReproduction" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="full">
            <label>
                Will any of the artworks be cropped, overprinted or manipulated?<abbr title="Required">*</abbr></label>
            <asp:DropDownList ID="ddContextOfUseCropped" runat="server" class="text" ValidationGroup="ValGroupCLForm">
                <asp:ListItem Value="-1" Selected="True">Please Select</asp:ListItem>
                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                <asp:ListItem Value="No">No</asp:ListItem>

            </asp:DropDownList>
            <em class="red">
                <asp:CustomValidator ID="cusValddContextOfUseCropped" runat="server" ErrorMessage="This field is mandatory, please enter."
                    ValidateEmptyText="true" ValidationGroup="ValGroupCLForm" ControlToValidate="ddContextOfUseCropped"
                    OnServerValidate="cusValddContextOfUseCropped_ServerValidate"></asp:CustomValidator>
            </em>
        </div>
        <div class="full">
            <label>
                Will any of the artworks be used on the cover of the product?<abbr title="Required">*</abbr></label>
            <asp:DropDownList ID="ddContextOfUseCover" runat="server" class="text" ValidationGroup="ValGroupCLForm">
                <asp:ListItem Value="-1" Selected="True">Please Select</asp:ListItem>
                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                <asp:ListItem Value="No">No</asp:ListItem>

            </asp:DropDownList>
            <em class="red">
                <asp:CustomValidator ID="cusValddContextOfUseCover" runat="server" ErrorMessage="This field is mandatory, please enter."
                    ValidateEmptyText="true" ValidationGroup="ValGroupCLForm" ControlToValidate="ddContextOfUseCover"
                    OnServerValidate="cusValddContextOfUseCover_ServerValidate"></asp:CustomValidator>
            </em>
        </div>
    </fieldset>
    <fieldset>
        <legend>2. Product details</legend>

        <div class="full">
            <label id="item1-type">
                Product type:<abbr title="Required">*</abbr></label>
            <asp:DropDownList ID="ddTypeOfproduct" runat="server" AutoPostBack="true" class="text" ValidationGroup="ValGroupCLForm" OnSelectedIndexChanged="ddTypeOfproduct_SelectedIndexChanged">
                <asp:ListItem Value="-1" Selected="True">Please Select</asp:ListItem>
                <asp:ListItem>Advertisement</asp:ListItem>
                <asp:ListItem Value="Book">Book / eBook</asp:ListItem>
                <asp:ListItem>Catalogue</asp:ListItem>
                <asp:ListItem Value="DigitalProducts">Digital Products</asp:ListItem>
                <asp:ListItem>Magazine</asp:ListItem>
                <asp:ListItem Value="MLP">Marketing Literature / Promotional Material</asp:ListItem>
                <asp:ListItem>Merchandise</asp:ListItem>
                <asp:ListItem>Newspaper</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
                <asp:ListItem Value="TFV">TV, Film or Video</asp:ListItem>
                <asp:ListItem>Website</asp:ListItem>
            </asp:DropDownList>
            <em class="red">
                <asp:CustomValidator ID="cusValddTypeOfproduct" runat="server" ErrorMessage="This field is mandatory, please enter."
                    ValidateEmptyText="true" ValidationGroup="ValGroupCLForm" ControlToValidate="ddTypeOfproduct"
                    OnServerValidate="cusValddTypeOfproduct_ServerValidate"></asp:CustomValidator>
            </em>
        </div>
        <asp:UpdatePanel ID="upProductSection" runat="server">
            <ContentTemplate>
                <div class="threequarters">
                    <label for="item1-title">
                        Product title:<abbr title="Required">*</abbr></label>
                    <asp:TextBox ID="txtTitleOFProduct" MaxLength="100" runat="server" class="text" ValidationGroup="ValGroupCLForm"></asp:TextBox>
                    <em class="red">
                        <asp:CustomValidator ID="cusValtxtTitleOFProduct" runat="server" ErrorMessage="This field is mandatory, please enter."
                            ValidateEmptyText="true" ValidationGroup="ValGroupCLForm" ControlToValidate="txtTitleOFProduct"
                            OnServerValidate="cusValtxtTitleOFProduct_ServerValidate"></asp:CustomValidator>
                    </em>
                </div>
                <asp:Panel ID="panelItems" runat="server">
                    <div class="colgroup threequarters">
                        <div id="divISBN" runat="server" class="half column" visible="false">
                            <label for="item1-isbn">
                                ISBN:<abbr title="Required"></abbr>
                                 <span class="ui-icon ui-icon-info addtooltip" title="An ISBN is 13 digits."></span>
                                <%--<span class="info-container" title="An ISBN is 13 digits.">?<abbr title="Required">
                                    &nbsp;</abbr></span>--%>

                            </label>
                            <asp:TextBox ID="txtISBN" runat="server" class="text" ValidationGroup="ValGroupCLForm"></asp:TextBox>
                            <em class="red">
                                <asp:CustomValidator ID="cusValtxtISBN" runat="server" ErrorMessage="An ISBN is 13 digits."
                                    ValidateEmptyText="false" ValidationGroup="ValGroupCLForm" ControlToValidate="txtISBN"
                                    OnServerValidate="cusValtxtISBN_ServerValidate"></asp:CustomValidator>
                            </em>
                        </div>
                        <div class="half column">&nbsp</div>
                    </div>
                    <div class="colgroup threequarters">
                        <div id="divPlannedDateOfIssue" runat="server" class="half column">
                            <label class="first-child" for="text25">
                                Your deadline:
                            </label>

                            <asp:TextBox ID="txtPlannedDateOfIssue" class="date_dd_mm_yyyy text" runat="server"></asp:TextBox>
                            <em class="red">
                                <asp:CustomValidator ID="cusValPlanneddate" runat="server" ErrorMessage="This field is mandatory, please enter."
                                    ValidationGroup="ValGroupCLForm" OnServerValidate="cusValPlanneddate_ServerValidate" ControlToValidate="txtPlannedDateOfIssue"></asp:CustomValidator>
                            </em>

                        </div>
                        <div id="divcalDateLicence" runat="server" class="half column">
                            <label class="first-child" for="text25">
                                Licence start date:<abbr title="Required">*</abbr>
                                <span class="ui-icon ui-icon-info addtooltip" title="e.g. this would usually be the launch/publication date of your product"></span>
                                <%--<span class="info-container" title="e.g. this would usually be the launch/publication date of your product">?
                                    *</abbr></span>--%>
                            </label>

                            <asp:TextBox ID="txtDateLicence" class="date_dd_mm_yyyy text" runat="server"></asp:TextBox>
                            <em class="red">
                                <asp:CustomValidator ID="cusvalDateLicence" runat="server" ValidateEmptyText="true"
                                    ErrorMessage="This field is mandatory please enter" ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusvalDateLicence_ServerValidate" ControlToValidate="txtDateLicence"></asp:CustomValidator>
                            </em>
                        </div>
                    </div>
                    <div class="colgroup threequarters">
                        <div class="half column" id="divPrintRun" runat="server" visible="false">
                            <label class="first-child" for="text50">
                                Print Run
                            </label>
                            <asp:TextBox ID="txtPrintRun" runat="server" class="text"></asp:TextBox>

                            <em class="red">
                                <asp:CustomValidator ID="cusvalPrintRun" runat="server" ValidateEmptyText="false"
                                    ErrorMessage="Allow only numeric character entry (e.g.12345).." ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusvalPrintRun_ServerValidate"
                                    ControlToValidate="txtPrintRun"></asp:CustomValidator>

                            </em>

                        </div>
                        <div class="half column" id="divPrintRunDigital" runat="server" visible="false">
                            <label class="first-child" for="text50">
                                Print Run (Digital)
                            </label>
                            <asp:TextBox ID="txtPrintRunDigital" runat="server" class="text"></asp:TextBox>

                            <em class="red">
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ValidateEmptyText="false"
                                    ErrorMessage="Allow only numeric character entry (e.g.12345)." ValidationGroup="ValGroupCLForm"
                                    OnServerValidate="cusvalPrintRunDigital_ServerValidate"
                                    ControlToValidate="txtPrintRunDigital"></asp:CustomValidator>
                            </em>
                        </div>
                    </div>
                    <div class="colgroup threequarters">
                        <div id="divDistributed" runat="server" class="half column">
                            <fieldset class="options">
                                <legend class="first-child">Product distribution:
                        <ul class="compact">
                            <asp:DropDownList ID="ddlDistributed" runat="server" CssClass="full" ValidationGroup="ValGroupCLForm">
                                <asp:ListItem Value="">Please Select</asp:ListItem>
                                <asp:ListItem Value="Worldwide">Worldwide</asp:ListItem>
                                <asp:ListItem Value="UK">UK only</asp:ListItem>
                            </asp:DropDownList>
                        </ul>
                                </legend>
                            </fieldset>
                        </div>
                    </div>
                    <div class="colgroup threequarters">
                        <div id="divLanguage" runat="server" visible="false">
                            <fieldset class="options">
                                <legend class="first-child">Language:
                        <ul class="compact">
                            <asp:DropDownList ID="ddlLanguage" runat="server">
                                <asp:ListItem Value="All Languages">All Languages</asp:ListItem>
                                <asp:ListItem Value="English">English</asp:ListItem>
                            </asp:DropDownList>
                        </ul>
                                </legend>
                            </fieldset>
                        </div>
                    </div>
                    <div class="threequarters" id="divWebSite" runat="server" visible="false">
                        <label for="url">
                            Website (if website use):
                        </label>
                        <asp:TextBox ID="txtWebSite" runat="server" class="text" ValidationGroup="ValGroupCLForm" MaxLength="1000"></asp:TextBox>
                        <em class="red">
                            <asp:CustomValidator ID="cusValWebSite" runat="server" ErrorMessage="Invalid input!"
                                ControlToValidate="txtWebSite" ValidateEmptyText="true" ValidationGroup="ValGroupCLForm"
                                OnServerValidate="cusValWebSite_ServerValidate"></asp:CustomValidator>
                        </em>
                    </div>
                    <div class="full" id="divLicenceDuration" runat="server" visible="false">
                        <label id="item1-LicenceDuration">
                            Licence Duration:<abbr title="Required">*</abbr></label>
                        <asp:DropDownList ID="ddlLicenceDuration" runat="server" class="text" ValidationGroup="ValGroupCLForm">
                            <asp:ListItem Value="-1" Selected="True">Please Select</asp:ListItem>
                            <asp:ListItem>5 years</asp:ListItem>
                            <asp:ListItem>In perpetuity</asp:ListItem>
                        </asp:DropDownList>
                        <em class="red">
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="This field is mandatory, please enter."
                                ValidateEmptyText="true" ValidationGroup="ValGroupCLForm" ControlToValidate="ddlLicenceDuration"
                                OnServerValidate="cusValLicenceDuration_ServerValidate"></asp:CustomValidator>
                        </em>
                    </div>
                    <div id="divUsage" runat="server" visible="false">
                        <fieldset class="options">
                            <legend class="first-child">For Television requests, please select the relevant rights
                        <ul class="compact">
                            <asp:CheckBox ID="ckbAllTVrights" CssClass="TVRelevantRights" Text="All TV rights" runat="server" />
                            <br />
                            Or<br />
                            <asp:CheckBox ID="ckbStandardTV" CssClass="TVRelevantRights" Text="Standard TV" runat="server" /><abbr title="Required"></abbr>
                             <span class="ui-icon ui-icon-info addtooltip" title="'Free to air' service broadcast available with a UK television licence only e.g. BBC"></span>
                            <%--<span class="info-container" title="'Free to air' service broadcast available with a UK television licence only e.g. BBC">?<abbr title="Required">
                                &nbsp;</abbr></span>--%>
                            <br />
                            <asp:CheckBox ID="ckbNonStandardTV" CssClass="TVRelevantRights" Text="Non standard TV" runat="server" />
                             <span class="ui-icon ui-icon-info addtooltip" title="Subscription based service broadcast by satellite or cable e.g. Sky"></span>
                            <%--<span class="info-container" title="Subscription based service broadcast by satellite or cable e.g. Sky">?<abbr title="Required">
                                &nbsp;</abbr></span>--%>
                            <br />
                            <asp:CheckBox ID="ckbVideoOnDemand" CssClass="TVRelevantRights" Text="Video on demand" runat="server" />
                             <span class="ui-icon ui-icon-info addtooltip" title="Streaming or broadcaster’s own catch up services e.g. iPlayer"></span>
                            <%--<span class="info-container" title="Streaming or broadcaster’s own catch up services e.g. iPlayer">?<abbr title="Required">
                                &nbsp;</abbr></span>--%>
                            <br />
                            <asp:CheckBox ID="ckbVideogramAndDTO" CssClass="TVRelevantRights" Text="Videogram and DTO" runat="server" />
                             <span class="ui-icon ui-icon-info addtooltip" title="Includes DVDs, Blu-ray and download to own"></span>
                           <%-- <span class="info-container" title="Includes DVDs, Blu-ray and download to own">?<abbr title="Required">
                                &nbsp;</abbr></span>--%>
                            <br />
                            <asp:CheckBox ID="ckbNonTheatric" CssClass="TVRelevantRights" Text="Non-theatric" runat="server" />
                             <span class="ui-icon ui-icon-info addtooltip" title="You need a ‘non-theatric’ film licence to show films and TV programmes in public (but not in a cinema) regardless of whether the event is fee paying. This includes at one-off events and in common areas for guests, residents and passengers."></span>
                            <%--<span class="info-container" title="You need a ‘non-theatric’ film licence to show films and TV programmes in public (but not in a cinema) regardless of whether the event is fee paying. This includes at one-off events and in common areas for guests, residents and passengers.">?<abbr title="Required">
                                &nbsp;</abbr></span>--%>
                        </ul>
                            </legend>
                        </fieldset>
                    </div>
                    <div class="threequarters">
                        <label class="first-child" for="text50">
                            Additional information:
                             <span class="ui-icon ui-icon-info addtooltip" title=" If there is anything else you would like to tell us about your project, please provide details here."></span>
                            <%--<span class="info-container" title="> If there is anything else you would like to tell us about your project, please provide details here.">?<abbr title="Required">
                                </abbr></span>--%>
                        </label>
                        <asp:TextBox ID="txtFutherInformation" runat="server" class="text" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddTypeOfproduct" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </fieldset>
</div>
<br />

<asp:HiddenField ID="hidReproductId" runat="server" />
