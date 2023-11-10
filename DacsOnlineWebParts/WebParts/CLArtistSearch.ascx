<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CLArtistSearch.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.CLArtistSearch" %>
<%@ Register Src="../DacsOnlineControls/PagingControl.ascx" TagName="PagingControl"
    TagPrefix="ucPaging" %>
<%@ Register Src="../DacsOnlineControls/ConformationLightbox.ascx" TagName="ConformationLightbox"
    TagPrefix="uc1" %>
<script type="text/javascript">
    $(document).ready(function () {
      
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
<asp:Panel ID="panelArrSearch" runat="server" DefaultButton="btSubmitSearch">
    <h1 class="pagetitle">
        Artist Search</h1>
    <div class="colgroup">
        <div class="column">
            <fieldset class="first-child last-child">
                <div class="colgroup">
                    <div class="column quarter">
                        <label for="name" class="first-child">
                            First name</label>
                        <asp:TextBox ID="txtArtistFirstName" runat="server" CssClass="text last-child"></asp:TextBox>
                    </div>
                    <div class="column half last-child">
                        <label for="name" class="first-child">
                            Last name</label>
                        <span class="combined last-child">
                            <asp:TextBox ID="txtArtistLastName" CssClass="text first-child" runat="server"></asp:TextBox>
                            <asp:Button ID="btSubmitSearch" runat="server" Text="Search" ClientIDMode="Static"
                                OnClick="BtnSearch_Click" OnClientClick="ShowAjaxRunTime();" CssClass="button last-child" />
                        </span>
                    </div>
                </div>
                <p class="caption last-child">
                    <a href='<%# AZUrl%>' class="first-child last-child">Browse A-Z</a></p>
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
                                    <a href='<%# String.Format("{0}?ArtistId={1}",ArtistDetailsUrl,Eval("ArtistId") ) %>'>
                                        <%# Eval("LastName")%><%# Eval("FirstName").ToString().Trim() == "" || Eval("LastName").ToString().Trim() == "" ? "" : ","%>
                                        <%# Eval("FirstName")%>
                                    </a>
                                </h3>
                                <p class="caption">
                                    <em>
                                        <%# Eval("Nationality")%>
                                        <%# Eval("YearOfBirth")%>
                                        <%# Eval("YearOfDeath")%>
                                    </em>
                                </p>
                            </div>
                            <div class="column twothirds">
                                <dl class="summary">                                    
                                        <%# Eval("RepresentationMessage")%>
                                    <%--<dt class="icon-blank">
                                        <%# Eval("ServiceDurationMessage")%>
                                    </dt>--%>
                                     <dd>
                                        <a class="more" href='<%# CLApplyUrl %>' runat="server" visible='<%# Eval("ShowApplyFor") %>'> Request a licence</a>
                                    </dd>
                                    <dt class="icon-blank">
                                        <%# Eval("ImageHireMessage")%>
                                    </dt>
                                    <asp:PlaceHolder ID="phImageHireMessage" runat="server" Visible='<%# (Eval("ImageHireMessage").ToString() != "") %>'>
                                    <dd>
                                        <a class="more" target="_blank" href='http://www.artimage.org.uk' runat="server" > Browse and request images</a>
                                    </dd>
                                    </asp:PlaceHolder>
                                    
                                  <%--  <dd>
                                        <a class="toggle more" target="_blank" runat="server" href="#" visible='<%#  SetMoreInfoMessage(Eval("MoreInfoMessage_1").ToString(),Eval("MoreInfoMessage_2").ToString()) %>'>
                                                More info</a>
                                    </dd>--%>
                                </dl>
                                <div class="details boxout is-hidden">
                                    <ul>
                                        <li runat="server" visible='<%# Eval("MoreInfoMessage_1") !=null && Eval("MoreInfoMessage_1").ToString() !=""?true:false %>'>
                                            <%# Eval("MoreInfoMessage_1")%></li>
                                        <li runat="server" visible='<%# Eval("MoreInfoMessage_2") !=null && Eval("MoreInfoMessage_2").ToString() !=""?true:false %>'>
                                            <%# Eval("MoreInfoMessage_2")%></li>
                                    </ul>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ol>
        </div>
    </div>
    <asp:Panel ID="panlNoresult" runat="server" Visible="false">
    <h2 id="H2" runat="server">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </h2>
           <div class="notification failure">
                    <h2 id="H1" runat="server">No matches found for &#8216;<asp:Literal ID="ltlArtistName2" runat="server"></asp:Literal>&#8217;</h2>
                    <p>If the artist's name has been anglicised, you may want to try some alternative spellings
                of &#8216;<asp:Literal ID="ltlArtistName" runat="server"></asp:Literal>
                &#8217; name</p> 
                   <p> If the artist is known by any other names (pseudonyms), you may want to try those
                variants.</p>
                <p> If you need help, or thinks may be an error, please contact <a>licensing@dacs.org.uk</a></p>
                 </div>
        <%--<h2 id="H1" runat="server">
            <asp:Literal ID="ltlRecordCount" runat="server"></asp:Literal>
        </h2>
        <div class="notification failure">
            <h3>
                If the artist's name is anglised, you may want to try some alternative spellings
                of &#8216;<asp:Literal ID="ltlArtistName" runat="server"></asp:Literal>
                &#8217; name</h3>
            <h4>
                If the artist is known by any other names (pseudonyms), you may want to try those
                variants.
            </h4>
            <h5>
                If you need help, email licensing@dacs.org.uk if you would like further assistance.
            </h5>
        </div>--%>
    </asp:Panel>
    <div class="colgroup last-child">
        <ucPaging:PagingControl ID="PagingControlBottom" runat="server" />
        <ul class="right navigation pagination">
            <li class="label first-child">Items per page</li>
            <li>
                <asp:HyperLink ID="btTeanRecords" runat="server">10</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="btFiftyRecords" runat="server">50</asp:HyperLink></li>
        </ul>
    </div>
</asp:Panel>

