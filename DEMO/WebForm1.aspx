﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DEMO.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    <asp:textbox runat="server" ID="textbox1"></asp:textbox>
         <asp:textbox runat="server" ID="txtSession"></asp:textbox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
