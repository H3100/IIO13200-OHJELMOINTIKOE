<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_T3a.aspx.cs" Inherits="H3100_T3a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>LadunSuhaajat</h1>
        <asp:Image ID="Image1" ImageUrl="./Images/hiihto.png" runat="server" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Salasana on sama, kuin käyttäjätunnus"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Käyttäjätunnus: "></asp:Label>
        <asp:TextBox ID="txtKT" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Salasana: "></asp:Label>
        <asp:TextBox ID="txtSalasana" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnKirjaudu" runat="server" Text="Kirjaudu" OnClick="btnKirjaudu_Click" />
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
