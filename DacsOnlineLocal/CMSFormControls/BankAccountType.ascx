<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BankAccountType.ascx.cs"
    Inherits="CMSFormControls_BankAccountType" %>
<script type="text/javascript">
    $(document).ready(function () {
      
        fnddBankDetails();
        $("#<%= ddBankDetails.ClientID %>").change(function () {
            fnddBankDetails();
                      
        });


    });

    function fnddBankDetails() {
            var val = $("#<%= ddBankDetails.ClientID %> option:selected").val();

        if (val == 'IBA') {
            $(".RollNumber").hide();
            $(".valBankAddress").show();
            $(".AdditionalInfo").show();
            $(".bankIN").show();
            $(".bankUk").hide();

            //uk account mandatory
            if ($(".uk1").val() == "") {
                $(".uk1").attr("value", "N/A");
            }
            if ($(".uk2").val() == "") {
                $(".uk2").attr("value", "N/A");
            }
            if ($(".uk3").val() == "") {
                $(".uk3").attr("value", "N/A");
            }
            //international bank
            if ($(".IBAN").val() == "N/A") {
                $(".IBAN").attr("value", "");
            }
            if ($(".SWIFT").val() == "N/A") {
                $(".SWIFT").attr("value", "");
            }

        }
        else if (val == 'UBA') {
            $(".valBankAddres").hide();
            $(".valBankAddress").hide();
            $(".RollNumber").hide();
            $(".AdditionalInfo").hide();
            $(".Hidden").hide();
            $(".bankIN").hide();
            $(".bankUk").show();
            //check if has N/A
            if ($(".uk1").val() == "N/A") {
                $(".uk1").attr("value", "");
            }
            if ($(".uk2").val() == "N/A") {
                $(".uk2").attr("value", "");
            }
            if ($(".uk3").val() == "N/A") {
                $(".uk3").attr("value", "");
            }
            //International Bank
            if ($(".IBAN").val() == "") {
                $(".IBAN").attr("value", "N/A");
            }
            if ($(".SWIFT").val() == "") {
                $(".SWIFT").attr("value", "N/A");
            }


        }
        else if (val == 'UBS') {
            $(".valBankAddres").hide();
            $(".RollNumber").show();
            $(".AdditionalInfo").hide();
            $(".valBankAddress").hide();


            $(".Hidden").hide();
            $(".bankIN").hide();
            $(".bankUk").show();
            //check if has N/A
            if ($(".uk1").val() == "N/A") {
                $(".uk1").attr("value", "");
            }
            if ($(".uk2").val() == "N/A") {
                $(".uk2").attr("value", "");
            }
            if ($(".uk3").val() == "N/A") {
                $(".uk3").attr("value", "");
            }
            //International Bank
            if ($(".IBAN").val() == "") {
                $(".IBAN").attr("value", "N/A");
            }
            if ($(".SWIFT").val() == "") {
                $(".SWIFT").attr("value", "N/A");
            }

        }
        else {
            $(".bankUk").show();
            $(".bankIN").show();

        }
    }

</script>
<asp:DropDownList ID="ddBankDetails" class="text" runat="server">
    <%--    <asp:ListItem Value="-1">Please Select</asp:ListItem>--%>
    <asp:ListItem Value="UBA" Selected="true">UK Bank Account</asp:ListItem>
    <asp:ListItem Value="UBS">UK Building Society</asp:ListItem>
    <asp:ListItem Value="IBA">International Bank Account</asp:ListItem>
</asp:DropDownList>
