<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ARRArtistSearch.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.ARRArtistSearch" %>
<%@ Register Src="../DacsOnlineControls/PagingControl.ascx" TagName="PagingControl"
    TagPrefix="ucPaging" %>
<%@ Register Src="../DacsOnlineControls/ConformationLightbox.ascx" TagName="ConformationLightbox"
    TagPrefix="LightBox" %>
<script type="text/javascript">
    $(document).ready(function () {
      //  $('#AjaxRunTimeArtistSearch').hide
        $("#Proceed").click(function () {
            document.getElementById('<%=btSubmitSearch.ClientID %>').click();
        });
        $("#accept").click(function () {

            if ($("#accept").attr('checked')) {
                $("#Proceed").removeAttr("disabled");
            }
            else {
                $("#Proceed").attr("disabled", "disabled");
            }
        });

        $('.btnPaging').click(
       function () {
           $('#AjaxRunTimeArtistSearch').show();
       });
    });

    function ShowAjaxRunTime()
    {
        this.disabled = true;
        this.value = 'Searching...';
        $(document).ready(function () {
            $('#AjaxRunTimeArtistSearch').show();
        });
    }
</script>
<asp:Panel ID="panelArrSearch" runat="server" DefaultButton="btnSubmit">
    <h1  class="pagetitle">
        Artist Search</h1>
    <fieldset class="first-child last-child">
        <p class="first-child">
            If you are making a sale, search below to find out if DACS represents the artist and whether an ARR royalty is due. Any artist not found in the search may still be entitled to a royalty.
        </p>
        <div class="colgroup">
            <!--<div class="column quarter first-child">
                <label for="year" class="first-child">
                    Year of sale</label>
                <asp:DropDownList ID="ddYear" runat="server" CssClass="fill last-child">
                </asp:DropDownList>
            </div>-->
            <div class="column half">
                <label for="name" class="first-child">
                    First name</label>
                <asp:TextBox ID="txtArtistFirstName" runat="server" CssClass="text last-child" ></asp:TextBox>
            </div>
            <div class="column half last-child">
                <label for="name" class="first-child">
                    Last name</label>
                <span class="combined last-child">
                    <asp:TextBox ID="txtArtistLastName" CssClass="text first-child" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSubmit" runat="server" Text="Search" OnClientClick="ShowAjaxRunTime();"  OnClick="btnSubmit_Click" />
                </span>
            </div>
        </div>
        <p class="caption last-child">
            <a href='<%# AZUrl %>' class="first-child last-child">Browse A-Z</a></p>
    </fieldset>
     <div id="AjaxRunTimeArtistSearch" style="width: 400px; vertical-align: central; min-height: 35px;display:none;">
        <img style="float: left;" src="~/App_Themes/DACS/_assets/hourglass.gif" />
        <div style="padding-top: 8px">Loading, please wait .. .. ..</div>
    </div>

    <h2 runat="server" id="confirmHead" visible="false">
        <asp:Literal ID="ltlConfirm" runat="server"></asp:Literal></h2>
    <ol class="results">
        <asp:Repeater ID="RepeterArtist" runat="server" OnItemDataBound="RepeterArtist_ItemDataBound">
            <ItemTemplate>
                <li class="colgroup">
                    <div class="column third">
                        <h3>
                            <a href='<%# String.Format("{0}?ArtistId={1}&YearSale={2}",ArtistDetailsUrl,Eval("ArtistId"),DateTime.Now.Year.ToString()) %>'>
                                <%# Eval("LastName")%><%# Eval("FirstName").ToString().Trim() == "" || Eval("LastName").ToString().Trim() == "" ? "" : ","%>
                                <%# Eval("FirstName")%>
                            </a>
                        </h3>
                        <p class="caption">
                            <em>
                                <%# Eval("Nationality")%>
                                <%# Eval("Confirmed")%>
                                <%# Eval("YearOfBirth")%>
                                <%# Eval("YearOfDeath")%></em></p>
                    </div>
                    <div class="column twothirds">
                        <dl class="summary">
                            <%--<dt class="icon-tick">--%>
                            <%# Eval("EligibilityMessage")%><%--</dt>--%>
                            <dd>
                                <a class="more" href='<%# ARRRoyaltyCalculator %>' runat="server" visible='<%# Eval("DisplayArr") %>'>
                                    calculate royalty</a> <a runat="server" visible='<%#  SetMoreInfoMessage(Eval("MandateMessage").ToString(),Eval("PaymentMessage").ToString()) %>'
                                        class="toggle more" href='#'>More info</a></dd>
                        </dl>
                        <div class="details boxout is-hidden" runat="server">
                            <ul>
                                <li runat="server" visible='<%# Eval("MandateMessage") !=null && Eval("MandateMessage").ToString() !=""?true:false %>'>
                                    <%# Eval("MandateMessage")%>
                                </li>
                                <li runat="server" visible='<%# Eval("PaymentMessage") !=null && Eval("PaymentMessage").ToString() !=""?true:false %>'>
                                    <%# Eval("PaymentMessage")%></li>
                            </ul>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ol>
    <asp:Panel ID="panlNoresult" runat="server" Visible="false">
    <div class="notification failure">
            <h2 class="first-child">
                No matches found for &#8216;<asp:Literal ID="ltlArtistName" runat="server"></asp:Literal>&#8217;</h2>
            <h3>
                Warning: these search results are not exhaustive</h3>
            <p>
                You still need to pay ARR if the artist has a passport in the European Economic
                Area and, if deceased, they have a date of death within 70 years of the sale date.</p>
            <p>
                <a class="more" href='<%# NationalityUrl%>'>View list of eligible countries</a></p>
        </div>
    </asp:Panel>
    <div class="colgroup last-child">
        <ucPaging:PagingControl ID="PagingControlBottom" runat="server" />
        <ul class="right navigation pagination">
            <li class="label first-child">Items per page</li>
            <li>
                <%-- <asp:Button ID="btTeanRecords" runat="server" Text="10" CssClass="selected" OnClick="btTenRecords_Click" />--%>
                <asp:HyperLink ID="btTeanRecords" runat="server">10</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="btFiftyRecords" runat="server">50</asp:HyperLink>
                <%--<asp:Button ID="btFiftyRecords" runat="server" Text="50" OnClick="btFiftyRecords_Click" />--%></li>
        </ul>
    </div>
    <LightBox:ConformationLightbox ID="ConformationLightbox" runat="server" />
    <asp:Button ID="btSubmitSearch" runat="server" Text="Search" ClientIDMode="Static"
        OnClick="btnSubmit_Click_Modal" Style="display: none;" />
</asp:Panel>
