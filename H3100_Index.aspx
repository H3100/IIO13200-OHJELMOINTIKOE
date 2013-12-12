<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_Index.aspx.cs" Inherits="H3100_Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/H3100_T2.aspx" runat="server">Toinen</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" NavigateUrl="~/H3100_T3a.aspx" runat="server">Kolmas</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/H3100_T4.aspx" runat="server">Neljäs</asp:HyperLink>
        <asp:HyperLink ID="HyperLink4" NavigateUrl="~/H3100_Pisteet.aspx" runat="server">Pistearvio</asp:HyperLink>
    </div>
    </form>
</body>
</html>
