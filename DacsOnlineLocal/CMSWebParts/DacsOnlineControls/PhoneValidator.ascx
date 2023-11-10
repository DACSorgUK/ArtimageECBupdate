<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhoneValidator.ascx.cs" Inherits="DacsOnlineWebParts.WebParts.DacsOnlineControls.PhoneValidator" %>
<asp:TextBox ID="txtWebsite" MaxLength="100" runat="server" class="text"/>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtWebsite"
Text="*Invalid phone number" ValidationExpression="(^(\+?\-? *[0-9]+)([,0-9 ]*)([0-9 ])*$)|(^ *$)|([0-9a-zA-Z\\s]{1,6})" runat="server" />
