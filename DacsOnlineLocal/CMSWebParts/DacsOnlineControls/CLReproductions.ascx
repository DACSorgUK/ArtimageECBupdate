<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CLReproductions.ascx.cs"
    Inherits="DacsOnlineWebParts.DacsOnlineControls.CLReproductions" %>
<style>
    .help-block {
        display: block;
        margin-top: 5px;
        margin-bottom: 10px;
        color: #737373;
    }

    .addedArtworkDisplay {
        background-color: white;
        border: 1px solid #666;
    }

    .tblAddedReproduction {
        background: #fff;
        border: 1px solid #ddd;
        width: 100%;
        max-width: 100%;
        margin-bottom: 20px;
        border-spacing: 0;
        border-collapse: collapse;
    }
</style>


<div id="divReproducctionListContainer" runat="server">
    <div runat="server" id="divHeader" visible="false">Artwork added to your enquiry</div>
    <asp:ListView ID="lvReproducctionList" OnItemCommand="lvReproducctionList_ItemCommand" runat="server" DataKeyNames="Id">

        <LayoutTemplate>
            <table class="tblAddedReproduction">
                <tr>
                    <th style="width: 45%; padding-left: 5px">Artist</th>
                    <th style="width: 45%">Artwork</th>
                    <th style="width: 10%">Option</th>
                </tr>
                <tr runat="server" id="itemPlaceholder" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td style="width: 45%; padding-left: 5px">
                    <asp:Label ID="lblAtistname" runat="server" Text='<%#Eval("ArtistName") %>' />
                </td>
                <td>
                    <asp:Label ID="lblTitleOfWork" runat="server" Text='<%#Eval("TitleOfWork") %>' />
                </td>
                <td>
                    <asp:Button ID="btndel" runat="server" Text="Remove" ToolTip="Delete a record"
                        OnClientClick="javascript:return confirm('Are you sure you want to remove this artwork ?')"
                        CommandName="DeleteArtwork" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>



<div id="reproductionBig" runat="server">
     <div class="colgroup full">
         <div class="column half">

             <label for="address-country">
                Artist 
            <abbr title="Required">*</abbr>
            </label>
              <div class="help-block">Please start typing artist's surname and then select from the drop down list. Then type the artwork title and click ‘add artwork’ to save your selection’</div>
            
         </div>
        <div class="column half">

             <label for="address-country">
                Artwork 
            <abbr title="Required">*</abbr>
            </label>
             <div class="help-block">(Title, date, max 100 characters)<br />&nbsp;<br /></div>
           
         </div>
         </div>

    <div class="colgroup full">
         
        <div class="column half">
           <%-- <label for="address-country">
                Artist 
            <abbr title="Required">*</abbr>
            </label>--%>
           <%--<asp:TextBox ID="txtAtistname" runat="server" class="text txtAtistnameSearch" ValidationGroup="ValGroupCLForm" MaxLength="100"></asp:TextBox>--%>
            <asp:DropDownList ID="ddlAtistname" Style="width: 100%" CssClass="text ddlAtistnameSearch" ValidationGroup="ValGroupCLForm" MaxLength="100" runat="server"></asp:DropDownList>
            <asp:HiddenField ID="hdnddlAtistname" ClientIDMode="Static" runat="server" />
             <asp:HiddenField ID="hdnddlAtistId" ClientIDMode="Static" runat="server" />
           <%-- <em class="red">
                <asp:CustomValidator ID="cusValtxtAtistname" runat="server" ErrorMessage="This field is mandatory, please enter." ValidateEmptyText="true"
                    ValidationGroup="zxc" ControlToValidate="ddlAtistname" OnServerValidate="cusValtxtAtistname_ServerValidate"></asp:CustomValidator>
            </em>--%>
        </div>
        <div class="column half">
           <%-- <label for="address-postcode">
                Artwork:
            <abbr title="Required">
                *</abbr>
            </label>--%>
            <asp:TextBox ID="txtTitleOfWork" runat="server" class="text" ValidationGroup="ValGroupCLForm"
                MaxLength="100"></asp:TextBox>
            <em class="red">
                <asp:CustomValidator
                    Display = "Dynamic"
                    ID="cusValtxtTitleOfWork" runat="server"
                    ErrorMessage="This field is mandatory please enter" ValidateEmptyText="true"
                    ValidationGroup="zxc" ControlToValidate="txtTitleOfWork"
                    OnServerValidate="cusValtxtTitleOfWork_ServerValidate"></asp:CustomValidator>
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3"
                    Display = "Dynamic"
                    ValidationExpression = "^[\s\S]{2,100}$"
                     ValidationGroup="zxc" ControlToValidate="txtTitleOfWork"
                    ErrorMessage="Minimum 2 and Maximum 100 characters allowed.">
                    </asp:RegularExpressionValidator>
            </em>
        </div>
    </div>
    <div class="colgroup full">
        <asp:Label ID="lblReproductionErrorMessage" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
    </div>
</div>
