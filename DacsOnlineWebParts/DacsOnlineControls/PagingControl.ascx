<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagingControl.ascx.cs"
    Inherits="DacsOnlineWebParts.DacsOnlineControls.PagingControl" %>

<ul class="navigation pagination" role="navigation">
    <asp:Literal ID="ltlCurrentValue" runat="server" Visible="false"></asp:Literal><asp:Literal
        ID="ltlTotalItems" runat="server" Visible="false"></asp:Literal>
           <li class="prev">
            <asp:HyperLink ID="lnkPrevious" runat="server" Visible="false">Previous</asp:HyperLink>
        </li>
   
    <asp:Repeater runat="server" ID="rptPaging" OnItemDataBound="rptPaging_OnItemDataBound">
        <ItemTemplate>
            <li>
                <%--  <asp:Button runat="server" ID="btnPaging" EnableViewState="true" />--%>
                <asp:HyperLink ID="btnPaging" runat="server"></asp:HyperLink>
            </li>
        </ItemTemplate>
        <SeparatorTemplate>
        </SeparatorTemplate>
    </asp:Repeater>
    <li class="next">
        <%--<asp:Button ID="lnkNext" runat="server" OnClick="lnkNext_Click" Text="Next" />--%>
        <asp:HyperLink ID="lnkNext" runat="server" Visible="false">Next</asp:HyperLink>
    </li>
</ul>
