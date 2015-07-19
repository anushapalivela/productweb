<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProductWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"> </script>
    <script src="Scripts/login.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" method="post">
    <div>
    <table>
                
                <tr>
                    <td>Name</td>
                    <td>
                        <input id="txtName" name="Name" type="text" /></td>
                </tr>
                <tr>
                    <td>Email Address</td>
                    <td>
                        <input id="txtEmail" name="Email" type="text" /></td>
                </tr>
                <tr>
                      <td>Password</td>
                        <td><input id="txtPassword" name="Password" type="password"/></td>
                </tr>
                <tr>
                    <td>
                        <input id="btnLogin" type="submit" value="Register" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
