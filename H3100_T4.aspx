<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_T4.aspx.cs" Inherits="H3100_T4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:SqlDataSource ID="SqlDataSource" 
        ConnectionString="<%$ ConnectionStrings:Ilmot %>"
        SelectCommand="SELECT count(id) FROM lasnaolot"
        runat="server">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource1" 
        ConnectionString="<%$ ConnectionStrings:Ilmot %>"
        SelectCommand="SELECT count(id) FROM lasnaolot"
        runat="server">
    </asp:SqlDataSource>

    <asp:DetailsView ID="DetailsView1" DataSourceID="SqlDataSource" runat="server" AllowPaging="true" />
</asp:Content>

