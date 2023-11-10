<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeCLArtistSearch.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.HomeCLArtistSearch" %>
<asp:Panel ID="panelArrSearch" runat="server" DefaultButton="btSubmitSearch">

   <fieldset class="first-child last-child">
        <p class="first-child">
            Search here to find out if the artist whose works you wish to reproduce is represented by DACS:</p>
        <div class="colgroup">
                       <div class="column half">
                <label for="name" class="first-child">
                    First name</label>
                <asp:TextBox ID="txtArtistFirstName" runat="server" class="text last-child"></asp:TextBox>
            </div>
            <div class="column half">
                <label for="name" class="first-child">
                    Last name</label>
                                 <asp:TextBox ID="txtArtistLastName" CssClass="text first-child" runat="server"></asp:TextBox>
                      </div>
        </div>
		<div class="right">
		   <asp:Button ID="btSubmitSearch" runat="server" Text="Search" ClientIDMode="Static"
                                OnClick="BtnSearch_Click" class="button" />
								</div>
        <p class="caption last-child">
            <a href='<%# AZUrl%>' class="first-child last-child">Browse A-Z</a></p>
    </fieldset>
</asp:Panel>
