<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesInformation.ascx.cs"
    Inherits="DacsOnlineWebParts.DacsOnlineControls.SalesInformation" %>
<%@ Register Src="Calendar.ascx" TagName="Calendar" TagPrefix="uc2" %>
<%@ Register Src="MultiTextBox.ascx" TagName="MultiTextBox" TagPrefix="uc1" %>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
<script src="~/App_Themes/DACS/_js/jquerycalendar/js/jquery-ui-1.8.20.custom.min.js"
    type="text/javascript"></script>
<script src="~/App_Themes/DACS/_js/watermarks.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%= nypEdit.ClientID %>").click(function () {

            var displayBig = $("#<%= idProduct.ClientID %>").css("display");

            if (displayBig == 'none') {
                $("#<%= idProduct.ClientID %>").css("display", "block");
            }
            if (displayBig == 'block') {
                $("#<%= idProduct.ClientID %>").css("display", "none");
                return false;
            }
        });



    });
    $(function () {
        $("#<%= txtDateOfBirth.ClientID %>").Watermark("yyyy");
        $("#<%= txtDateDeath.ClientID %>").Watermark("yyyy");
        
    });
</script>
<asp:HyperLink ID="nypEdit" runat="server"></asp:HyperLink>
<div id="idProduct" runat="server">
    <legend>Your Sales Information </legend>
    <br />
    <div class="third">
        <label class="first-child" for="text25">
            Sale date:<abbr title="Required">*</abbr>
        </label>
        <uc2:Calendar ID="calSaleDate" runat="server" />
      <%--  <asp:TextBox ID="txtSaleDate" class="text date" runat="server"></asp:TextBox>--%>
        <em class="red">
            <asp:CustomValidator ID="CusSaleDateValidator" runat="server" ErrorMessage="This field is mandatory, please enter."
                ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales"
                OnServerValidate="CusSaleDateValidator_ServerValidate"></asp:CustomValidator>
        </em>
    </div>
    <div class="threequarters">
        <label class="first-child" for="text50">
            Your reference(e.g. stock number or lot number):
        </label>
        <asp:TextBox ID="txtRefrence" runat="server" ValidationGroup="ValGroupArtMarketsales" class="text"></asp:TextBox>
    </div>
    <div class="threequarters">
        <label class="first-child" for="text33">
            Artist Name:<abbr title="Required">*</abbr>
        </label>
        <asp:TextBox ID="txtArtistName" runat="server" MaxLength="1000" class="text"></asp:TextBox>
        <em class="red">
            <asp:CustomValidator ID="cusValArtistName" runat="server" ErrorMessage="This field is mandatory, please enter."
                ValidateEmptyText="true" ValidationGroup="ValGroupArtMarketsales" ControlToValidate="txtArtistName"
                OnServerValidate="cusValArtistName_ServerValidate"></asp:CustomValidator>
        </em>
    </div>


    <label class="first-child" for="text25">
          Year of Birth (if known):
        </label>
    <div class="third">
        <asp:TextBox ID="txtDateOfBirth" runat="server" class="text" MaxLength="4"></asp:TextBox>
              <%--   <uc2:Calendar ID="calDateOfBirth" runat="server" />--%>
     <%--   <asp:TextBox ID="txtDateOfBirth" class="text date" runat="server"></asp:TextBox>--%>
        <em class="red">
             <%-- <asp:CustomValidator ID="cusValDateOfBirth" runat="server" ValidateEmptyText="true" 
                ErrorMessage="This field is not in the correct format, please change." ValidationGroup="ValGroupArtMarketsales"
                   OnServerValidate="cusValDateOfBirth_ServerValidate"></asp:CustomValidator>--%>
        </em>
        <%-- <uc2:Calendar ID="calDateOfBirth" runat="server" />--%>
    </div>
    <div class="third">
        <label class="first-child" for="text25">
           Year of Death (if known):
        </label>
      <%--  <asp:TextBox ID="txtDateDeath" class="text date" runat="server"></asp:TextBox>--%>
       <%--  <uc2:Calendar ID="calDateDeath" runat="server" />--%>
        <asp:TextBox ID="txtDateDeath" runat="server" class="text" MaxLength="4"></asp:TextBox>
        <em class="red">
        
<%--     <asp:CustomValidator ID="cusValDateOFDeath" runat="server" ValidateEmptyText="true"
                ErrorMessage="This field is not in the correct format, please change." ValidationGroup="ValGroupArtMarketsales"
          OnServerValidate="cusValDateOFDeath_ServerValidate"></asp:CustomValidator>--%>
        </em>
    </div>

   <div class="threequarters">
        <label class="first-child" for="text50">
            Nationality:<abbr title="Required">*</abbr>
        </label>
        <div class="MultitextBox">
            <uc1:MultiTextBox ID="txtNationality" runat="server" HeaderText="+ Add another Nationality" />
            <em>If the artist held multiple passports, add futher nationalities below</em> <em
                class="red">
                <asp:CustomValidator ID="cusValNationality" runat="server" ErrorMessage="This field is mandatory, please enter."
                    OnServerValidate="cusValNationality_ServerValidate" ValidationGroup="ValGroupArtMarketsales"></asp:CustomValidator>
            </em>
        </div>
    </div>
    <div class=" threequarters">
        <label class="first-child" for="text50">
            Title of work and year:<abbr title="Required">*</abbr>
        </label>
        <asp:TextBox ID="txtTitleOfWork" runat="server" class="text"></asp:TextBox>
        <em class="red">
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldTitleOfWork" runat="server" ErrorMessage="This field is mandatory please enter" ValidationGroup="ValGroupArtMarketsales"
                ControlToValidate="txtTitleOfWork">
            </asp:RequiredFieldValidator>--%>
             <asp:CustomValidator ID="cusValTitleOfWork" runat="server" ErrorMessage="This field is mandatory, please enter."
                    OnServerValidate="cusValTitleOfWork_ServerValidate" ValidationGroup="ValGroupArtMarketsales"></asp:CustomValidator>
        </em>
    </div>

    <div class=" threequarters">
        <label class="first-child" for="text50">
            Medium:
        </label>
        <asp:TextBox ID="txtMedium" runat="server" class="text"></asp:TextBox>
    </div>
    <div class="threequarters">
        <label class="first-child" for="text50">
            Edition number (if applicable):
        </label>
        <asp:TextBox ID="txtEditionNumber" runat="server" class="text"></asp:TextBox>
    </div>
    <div class="threequarters">
        <label class="first-child" for="text50">
            Dimensions:
        </label>
        <asp:TextBox ID="txtDimensions" runat="server" class="text"></asp:TextBox>
    </div>
    <div class=" threequarters">
        <label class="first-child" for="text50">
            Sale price (in Pounds,excluding VAT):<abbr title="Required">*</abbr>
        </label>
        <asp:TextBox ID="txtSalePrice" runat="server" class="text"></asp:TextBox>
        <em class="red">
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldSalePrice" runat="server" ErrorMessage="This field is mandatory please enter" ValidationGroup="ValGroupArtMarketsales"
                ControlToValidate="txtSalePrice">
            </asp:RequiredFieldValidator>--%>
            <asp:CustomValidator ID="cusValSalesPrice" runat="server" ErrorMessage="This field is mandatory, please enter."
                    OnServerValidate="cusValSalesPrice_ServerValidate" ValidationGroup="ValGroupArtMarketsales"></asp:CustomValidator>
        </em>
    </div>
   <%-- <fieldset class="options">
        <legend class="first-child">Are you claiming "Bought as stock" exception?": <a href='~/for-art-market-professionals/frequently-asked-questions#FAQ91' target="_blank">
            What's this?</a>
            <ul class="compact">
                <asp:RadioButtonList ID="rbClaiming" runat="server">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="true">No</asp:ListItem>
                </asp:RadioButtonList>
            </ul>
        </legend>
    </fieldset>--%>
</div>
