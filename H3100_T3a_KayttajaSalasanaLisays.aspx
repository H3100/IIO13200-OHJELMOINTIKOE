<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_T3a_KayttajaSalasanaLisays.aspx.cs" Inherits="H3100_T3a_KayttajaSalasanaLisays" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Käyttäjätunnus: "></asp:Label>
        <asp:TextBox ID="txtKT" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Salasana: "></asp:Label>
        <asp:TextBox ID="txtSalasana" TextMode="Password" runat="server"></asp:TextBox>

        <br />
        <asp:Button ID="Button1" runat="server" Text="Tallenna" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="lblTesti" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
