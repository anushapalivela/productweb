<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ProductWeb.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <%-- <script type="text/javascript" src="Scripts/product.js"></script>--%>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="Scripts/product.js">
    <%--$(document).ready(function() {
        alert("Page is loaded");
    });--%>

    </script>
    <link href="Styles/Button.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br/>
        <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label>
        &nbsp;<asp:TextBox ID="txtDesc" runat="server"></asp:TextBox><br/>
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br/>
        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Value="0">--Select--</asp:ListItem>
            <asp:ListItem>In Stock</asp:ListItem>
            <asp:ListItem>Out of Stock</asp:ListItem>
            <asp:ListItem>Back Order</asp:ListItem>
        </asp:DropDownList><br/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
             <%--OnClientClick="return validate();"--%> 
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
