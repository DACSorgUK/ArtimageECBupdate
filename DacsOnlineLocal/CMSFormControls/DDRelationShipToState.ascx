<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDRelationShipToState.ascx.cs"
    Inherits="CMSFormControls_DDRelationShipToState" %>
<script type="text/javascript">
    $(document).ready(function () {
        $("#charity").hide();
        $("#onlybeneficiary").hide();

        $("#<%= ddRelationShip.ClientID %>").change(function () {
        var val = $("#<%= ddRelationShip.ClientID %> option:selected").val();
            if (val == 'I work for a charity which is the beneficiary') {
                $("#charity").show();
                $("#onlybeneficiary").show();
            }
            else if (val == 'I am a direct beneficiary') {
                $("#charity").hide();
                $("#onlybeneficiary").show();
            } else {
                $("#charity").hide();
                $("#onlybeneficiary").hide();
            }
        });
    });

</script>
<asp:DropDownList ID="ddRelationShip" class="text" runat="server">
    <asp:ListItem Value="-1">Please select</asp:ListItem>
    <asp:ListItem>I am a direct beneficiary</asp:ListItem>
    <asp:ListItem>I work for a charity which is the beneficiary</asp:ListItem>
    <asp:ListItem>I am a personal representative of the estate</asp:ListItem>
    <asp:ListItem>I am the executor of an artist&#39;s will</asp:ListItem>
</asp:DropDownList>
