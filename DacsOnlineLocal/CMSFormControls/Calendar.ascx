<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendar.ascx.cs" Inherits="CMSFormControls_Calendar" %>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
<script src="~/App_Themes/DACS/_js/jquerycalendar/js/jquery-ui-1.8.20.custom.min.js"
    type="text/javascript"></script>
     <script src="~/App_Themes/DACS/_js/watermarks.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#<%= Txtdate.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
        $("#<%= Txtdate.ClientID %>").Watermark("dd/mm/yyyy");
    });
</script>
<asp:TextBox ID="Txtdate" class="date_dd_mm_yyyy text" runat="server"></asp:TextBox>

