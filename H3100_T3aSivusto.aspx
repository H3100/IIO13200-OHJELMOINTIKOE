<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_T3aSivusto.aspx.cs" Inherits="H3100_T3aSivusto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Tervetuloa!</h1>
        <!--
            <hiihtaja>Teppo</hiihtaja>
    <PVM>12.12.2012</PVM>
    <tunnit>1</tunnit>
    <minuutit>12</minuutit>
    <kilometrit>15</kilometrit>
            -->

        <asp:Label ID="Label1" runat="server" Text="Nimi: "></asp:Label>
        <asp:TextBox ID="txtNimi" runat="server"></asp:TextBox> 

        <br />

        <asp:Label ID="Label2" runat="server" Text="Pvm: "></asp:Label>
        <asp:TextBox ID="txtPvm" runat="server"></asp:TextBox> 
      <!--  <asp:RegularExpressionValidator id="validatorRegexpNimi" runat="SERVER" ControlToValidate="txtPvm" 
       ValidationExpression="^[0-9]{1,2}\\.[0-9]{1,2}\\.[0-9]{4}$" /> -->
        <br />

        <asp:Label ID="Label3" runat="server" Text="Tunnit: "></asp:Label>
        <asp:TextBox ID="txtTunnit" runat="server"></asp:TextBox> 
       <!-- <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="SERVER" ControlToValidate="txtTunnit" 
       ValidationExpression="^[0-9]*$" /> -->
        <br />

        <asp:Label ID="Label4" runat="server" Text="Minuutit: "></asp:Label>
        <asp:TextBox ID="txtMinuutit" runat="server"></asp:TextBox> 
     <!--   <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="SERVER" ControlToValidate="txtMinuutit" 
       ValidationExpression="^[0-9]*$" /> -->
        <br />

        <asp:Label ID="Label5" runat="server" Text="Kilometrit"></asp:Label>
        <asp:TextBox ID="txtKilometrit" runat="server"></asp:TextBox> 
      <!--  <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="SERVER" ControlToValidate="txtKilometrit" 
       ValidationExpression="^[0-9]*$" /> -->
        <br />

        <asp:Button ID="btnTallenna" runat="server" Text="Tallenna" OnClick="btnTallenna_Click" /> 
        <asp:Button ID="btnListaa" runat="server" Text="Listaa suoritukset" OnClick="btnListaa_Click" />
        <br />

        <asp:Table ID="tblHiihdot" runat="server"></asp:Table>

        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
