<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebSiteValidator.ascx.cs" Inherits="DacsOnlineWebParts.WebParts.DacsOnlineControls.WebSiteValidator" %>
<asp:TextBox ID="txtWebsite" MaxLength="100" runat="server" />
      <%--  <asp:RequiredFieldValidator ID="txtWebsiteValidator" ControlToValidate="txtWebsite"
            Text="*" ErrorMessage="Website is Missing" runat="server" />--%>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtWebsite"
            Text="This field is mandatory, please enter." ValidationExpression="(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$" runat="server" />


