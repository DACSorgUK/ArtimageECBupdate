<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeARRArtistSearch.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.HomeARRArtistSearch" %>
<%@ Register Src="../DacsOnlineControls/ConformationLightbox.ascx" TagName="ConformationLightbox"
    TagPrefix="LightBox" %>

<asp:Panel ID="panelArrSearch" runat="server" DefaultButton="btnSubmit">
    <fieldset class="first-child last-child">
        <p class="first-child">
           <%# HeaderText%>
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
                <asp:TextBox ID="txtArtistFirstName" runat="server" CssClass="text last-child"></asp:TextBox>
            </div>
            <div class="column half last-child">
                <label for="name" class="first-child">
                    Last name</label>
                <span class="combined last-child">
                    <asp:TextBox ID="txtArtistLastName" CssClass="text first-child" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSubmit" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                </span>
            </div>
        </div>
        <p class="caption last-child">
            <a href='<%# AZUrl%>' class="first-child last-child">Browse A-Z</a></p>
    </fieldset>
    <LightBox:ConformationLightbox ID="ConformationLightbox" runat="server" />
    <asp:Button ID="btSubmitSearch" runat="server" Text="Search" ClientIDMode="Static"
        OnClick="btnSubmit_Click_Modal" Style="display: none;" />
    <div id="Div1" runat="server">
        <script language="javascript" type="text/javascript">
            $(document).ready(function () {
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
            });
        </script>
    </div>
</asp:Panel>
