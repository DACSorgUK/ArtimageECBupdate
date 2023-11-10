<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDExclusiveRightsToLicenece.ascx.cs"
    Inherits="CMSFormControls_DDExclusiveRightsToLicenece" %>

<script type="text/javascript">
    $(document).ready(function () {

        setParagraphText();

        $("#<%= ddExclusiveRightsToLicenece.ClientID %>").change(function () {

            setParagraphText();
        });

    });

    function setParagraphText() {
        var selectedText = $("[id*='ddExclusiveRightsToLicenece'] :selected").text();

        if (selectedText == 'Yes, for ALL my works' || selectedText == 'Yes, for some of my works') {
            $("#<%= ExclusiveRightsToLiceneceText.ClientID %>").css("display", "block");
        }
        else {
            $("#<%= ExclusiveRightsToLiceneceText.ClientID %>").css("display", "none");
        }        
    }

</script>
   

<asp:DropDownList ID="ddExclusiveRightsToLicenece" class="text first" runat="server" ClientIDMode="Static">
    <asp:ListItem Value="-1">Please select</asp:ListItem>
    <asp:ListItem>Yes, for ALL my works</asp:ListItem>
    <asp:ListItem>Yes, for some of my works</asp:ListItem>
    <asp:ListItem>No</asp:ListItem>
</asp:DropDownList>

<p class="caption" runat="server" id="ExclusiveRightsToLiceneceText">
<strong>Important:</strong>  You may not be able to benefit from the DACS copyright licensing service. Please<a href="/about-us/contact-us"> contact us</a>  if you need further explanation or help on this matter.</p>
