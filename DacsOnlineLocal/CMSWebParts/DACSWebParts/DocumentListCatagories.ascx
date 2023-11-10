<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentListCatagories.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.DocumentListCatagories" %>
<ul ID="section-navigation" role="navigation">
    <%--<li class="highlighted"><a href="#" >Latest News</a></li>--%>
    <asp:Repeater ID="RepeterDocument" runat="server" OnItemDataBound="RepeterDocument_ItemDataBound">
        <ItemTemplate>
            <li runat="server" id="hrefId"><a href='<%# String.Format("{0}?category={1}&title=Y",DocumentCatogeryUrl,Container.DataItem  ) %>'>
                <%# Container.DataItem %></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<%--<li runat="server" id="hrefId" ></li>--%>