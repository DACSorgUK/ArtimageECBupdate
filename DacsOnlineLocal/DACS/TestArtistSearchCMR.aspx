<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestArtistSearchCMR.aspx.cs" Inherits="DACS_TestArtistSearchCMR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>PayBack WebService Test</h1>
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
         <br />
        <br />
        <asp:Label ID="lblPageSize" runat="server" Text="Page Size"></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="txtPageSize" runat="server" Text="3"></asp:TextBox>
        <br /> 
        <br />
        
        --------- <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        Search Result :<br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br />
        --------------
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
