<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArtistDetails.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.ArtistDetails" %>
<div class="container">
    <div class="document" role="document">
        <h1 class="pagetitle">
            <asp:Label ID="lbLastName" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbFirstName" runat="server" Text=""></asp:Label>
        </h1>
        <div class="colgroup">
            <dl class="compact">
                <dt>Name:</dt>
                <dd>
                    <asp:Label ID="lbLastName2" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbFirstName2" runat="server" Text=""></asp:Label>
                </dd>
                <dt>Pseudonyms:</dt>
                <dd>
                    <asp:Label ID="lbPseudonyms" runat="server" Text=""></asp:Label>
                </dd>
                <asp:PlaceHolder ID="PhNationality" runat="server">
                    <dt>Nationality:</dt>
                    <dd>
                        <asp:Label ID="lbNationality" runat="server" Text=""></asp:Label>
                    </dd>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phLived" runat="server">
                    <dt>Lived:</dt>
                    <dd>
                        <asp:Label ID="lblDateOfBirth" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblDateofDeath" runat="server" Text=""></asp:Label>
                    </dd>
                </asp:PlaceHolder>

                <%--<dt>Website:</dt>
                        <dd>
                            <asp:HyperLink ID="lnkWebsite" runat="server"></asp:HyperLink></dd>--%>
            </dl>
            <br />
            <br />
            <br />
        </div>
        <!--/.compact-->
        <h2>
            <asp:Literal ID="ltlCLRepresentationMessage" runat="server"></asp:Literal>
        </h2>
        <ul>
            <li runat="server" id="liCLOnlyMessage">
                <asp:Literal ID="ltlCLOnlyMessage" runat="server"></asp:Literal></li>
            <li runat="server" id="liServiceDurationMessage">
                <asp:Literal ID="ltlCLServiceDurationMessage" runat="server"></asp:Literal></li>
            <li runat="server" id="liCLConsultMessage">
                <asp:Literal ID="ltlCLConsultMessage" runat="server"></asp:Literal></li>
            <li runat="server" id="liCLContextMessage">
                <asp:Literal ID="ltlCLContextMessage" runat="server"></asp:Literal></li>
            <%--<li runat="server" id="liCLImageMessage">
                <asp:Literal ID="ltlCLImageMessage" runat="server"></asp:Literal></li>--%>
        </ul>
        <div class="buttongroup" runat="server" id="divhrefCLApply">
            <a class="button" runat="server" id="hrefCLApply" href="<%# ApplyCL_URL %>">Apply for
                copyright licence</a>
        </div>
        <asp:PlaceHolder ID="phImageHireMessage" runat="server" Visible='<%# (ImageHireMessage != "") %>'>
            <h2>
                <asp:Literal ID="Literal1" Text="<%$Resources:DACSOnlineResources, ImageHireHeaderDetailPage%>" runat="server"></asp:Literal></h2>
            <ul>
                <li runat="server" id="li1">
                    <asp:Literal ID="Literal2" Text="<%$Resources:DACSOnlineResources, ImageHireDetail1DetailPage%>" runat="server"></asp:Literal></li>

            </ul>
            <div class="buttongroup" runat="server">
                <a class="button" id="lnkVisitArtimage" target="_blank" href="http://www.artimage.org.uk">Visit Artimage</a>
            </div>
        </asp:PlaceHolder>
        <!--/.buttongroup-->
        <h2>
            <asp:Literal ID="ltlEligibilityMessage" runat="server"></asp:Literal></h2>
        <ul>
            <li runat="server" id="liMandateMessage">
                <asp:Literal ID="ltlMandateMessage" runat="server"></asp:Literal></li>
            <li runat="server" id="liPaymentMessage">
                <asp:Literal ID="ltlPaymentMessage" runat="server"></asp:Literal></li>
        </ul>
        <div class="buttongroup" runat="server" id="divhrefARRApply">
            <a class="button" runat="server" id="hrefARRApply" href="<%# ApplyARR_URL %>">Submit
                ARR sales info</a>
        </div>
        <!--/.buttongroup-->
    </div>
    <!--/.column-->
</div>
