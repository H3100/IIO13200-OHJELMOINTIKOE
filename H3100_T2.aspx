<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_T2.aspx.cs" Inherits="H3100_T2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="TableMyTable" runat="server"></asp:Table>
        <asp:Label ID="lblTyontekijat" runat="server" Text="Tyontekijät yhteensä: "></asp:Label>
        <br />
        <asp:Label ID="lblPalkat" runat="server" Text="Palkat yhteensä: "></asp:Label>
        <br />
        <asp:Button ID="btnHae" runat="server" Text="Hae arvot" OnClick="btnHae_Click" />
    </div>
    </form>
</body>
</html>
