<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllArtistSearch.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.AllArtistSearch" %>
<%@ Register Src="../DacsOnlineControls/PagingControl.ascx" TagName="PagingControl"
    TagPrefix="ucPaging" %>
<div class="colgroup">
<div class="column first-child last-child">
    <h1 class="pagetitle">
        Browse Artists</h1>
</div>
    <asp:Repeater ID="RepeaterSubscriptions" runat="server">
        <HeaderTemplate>
            <ul class="navigation alphanumeric" role="navigation">
                       </HeaderTemplate>
        <ItemTemplate>
            <li class='<%# Container.DataItem !=null && Container.DataItem.ToString() == WordSelected ? "selected":"" %>'>
                <a href='<%# String.Format("{0}?Letter={1}","",Container.DataItem) %>'>
                    <%# Container.DataItem %></a></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <h2 runat="server" id="confirmHead" visible="true"><asp:Literal ID="ltlConfirm" runat="server"></asp:Literal></h2>
    <ol class="results">
        <asp:Repeater ID="RepeterArtist" runat="server" OnItemDataBound="RepeterArtist_ItemDataBound" >
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
                           <%-- <em>
                                <%# Eval("Nationality")%>
                                <%# Eval("YearOfBirth")%></em>--%>
                             <em>
                                        <%# Eval("Nationality")%>
                                        <%# Eval("YearOfBirth")%>
                                        <%# Eval("YearOfDeath")%></em>

                        </p>
                    </div>
                    <div class="column twothirds">
                        <dl class="summary">
                            <dt>
                                <%# Eval("CLRepresentationMessage")%></dt>
                            <dt class="icon-blank">
                                <%# Eval("CLServiceDurationMessage")%></dt>
                            <dt class="icon-blank">
                                <%# Eval("CLImageHireMessage")%>
                            </dt>
                            <dd>
                               <%-- <a class="more" href='<%# CLCalculatorUrl %>' runat="server">Calculate royalty</a>--%>
                               <a id="A1" class="more" href='<%# CLApplyURL %>' runat="server" visible='<%# Eval("CLShowApplyFor") %>'>Apply for licence</a>
                                <a class="toggle more" runat="server" visible='<%#  SetMoreInfoMessage(Eval("CLMoreInfoMessage_1").ToString(),Eval("CLMoreInfoMessage_2").ToString()) %>' href="#">More info</a> 
                                
                            </dd>
                        </dl>
                        <div class="details boxout is-hidden">
                            <ul>
                                <li runat="server" visible='<%# Eval("CLMoreInfoMessage_1") !=null && Eval("CLMoreInfoMessage_1").ToString() !=""?true:false %>'>
                                    <%# Eval("CLMoreInfoMessage_1")%></li>
                                <li runat="server" visible='<%# Eval("CLMoreInfoMessage_2") !=null && Eval("CLMoreInfoMessage_2").ToString() !=""?true:false %>'>
                                    <%# Eval("CLMoreInfoMessage_2")%></li>
                            </ul>
                        </div>
                        <dl class="summary">
                           <%-- <dt class="icon-tick">--%>
                                <%# Eval("ARREligibilityMessage")%><%--</dt>--%>
                            <dd>
                                <a class="more" href='<%# ARRSubmitUrl %>' runat="server"  visible='<%# Eval("DisplayArr") %>'>Calculate royalty</a>
                                <a class="toggle more" href='#' visible='<%#  SetMoreInfoMessage(Eval("ARRMandateMessage").ToString(),Eval("ARRPaymentMessage").ToString()) %>' runat="server">More info</a>
                             </dd>
                        </dl>
                        <div class="details boxout is-hidden">
                            <ul>
                                <li runat="server" visible='<%# Eval("ARRMandateMessage") !=null && Eval("ARRMandateMessage").ToString() !=""?true:false %>'>
                                    <%# Eval("ARRMandateMessage")%></li>
                                <li runat="server" visible='<%# Eval("ARRPaymentMessage") !=null && Eval("ARRPaymentMessage").ToString() !=""?true:false %>'>
                                    <%# Eval("ARRPaymentMessage")%></li>
                            </ul>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ol>
</div>
<div class="colgroup last-child">
    <ucPaging:PagingControl ID="PagingControlBottom" runat="server" />
    <ul class="right navigation pagination">
        <li class="label first-child">Items per page</li>
        <li>
            <asp:HyperLink ID="btTeanRecords" runat="server">10</asp:HyperLink>
           </li>
        <li>
            <asp:HyperLink ID="btFiftyRecords" runat="server">50</asp:HyperLink>
        </li>
    </ul>
</div>
