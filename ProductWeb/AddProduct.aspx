<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ProductWeb.AddProduct" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.10.2.min.js"></script>--%>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/product.js"> </script>
    <script type="text/javascript" src="Scripts/displayproducts.js"></script>
    <script src="Scripts/Category.js"></script>
    <link href="Styles/Button.css" rel="stylesheet" />
    <link href="Styles/Home.css" rel="stylesheet" />
    <link href="Styles/VerticalMenu.css" rel="stylesheet" />
</head>
<body>
   <%-- <div class="top">        
        <ul>
            <li>
                <span>
                    Welcome Guest
                    <a>Sign In</a>
                    <span><a>Create Account</a></span>                   
                </span>
            </li>
        </ul>
    </div>
    <div id="Image">
        <section>
            <img src="Images/Shopping-deals-header1.jpg" />
        </section>
    </div>
    <div id="Menu">
        <ul>
            <li><a href="#home">Home</a></li>
            <li><a href="#add">Add</a>
                <ul id="#vertical menu">
                    <li><a href="#addproduct">Product</a></li>
                    <li><a href="#addcategory">Category</a></li>
                </ul>
           </li>
            <li><a href="#update">Update</a></li>
            <li><a href="#view">View</a></li>
            <li><a href="#manage">Change Password</a></li>
            <li><a href="#logout">Logout</a></li>
        </ul>
    </div>--%>
    <form id="form1">
        <div style="align-content:center "width: 268px">
            <table style="align-items:center">
                <tr>
                    <td>Category</td>
                    <td><select id="ddlSubCategory"><option value="" disabled="disabled" selected="selected">--Select--</option></select></td>

                </tr>
                <tr>
                    <td>Name</td>
                    <td>
                        <input id="txtName" type="text" /></td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <textarea id="txtDesc"></textarea>
                        <%--<input id="txtDesc" type="text" />--%></td>
                </tr>
                <tr>
                    <td>Price</td>
                    <td>
                        <input id="txtPrice" type="text" /></td>
                </tr>
                <tr>
                    <td>Status</td>
                    <td>
                        <select id="ddlStatus">
                            <option value="" disabled="disabled" selected="selected">--Select--</option>
                            <option value="In Stock">In Stock</option>
                            <option value="Out of Stock">Out of Stock</option>
                            <option value="Back Order">Back Order</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="btnSubmit" type="submit" value="Submit" /></td>
                </tr>
            </table>
        </div>
    </form>
    <form id="uploadform" method="post" enctype="multipart/form-data" target="uploading" action="AddProduct.aspx">
    <div> 
        <table>
                <tr><td>Categories</td>
                <td><select id="ddlCategories"><option value="" disabled="disabled" selected="selected">--Select--</option></select></td>
                <tr><td>SubCategory Name</td>
                <td><input id="txtCategoryName" type="text" runat="server" /></td></tr>
                <tr><td>Select a file:</td><td><input type="file"  id="imgid" name="imgText"/></td></tr>
                <tr><td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button type="submit" id="btnCategory"/>Submit</td></tr> 
           
        </table>             
        <input type="hidden" id="ValueHiddenField" runat="server"/>  
         </div> 
       
    </form>
    
            
    <div id="paging">
        <button type="button" id="btnGetData">Get Data</button>
        <table id="tbGetData">
            <thead style="background-color: #DC5807; color: White; font-weight: bold">
                <tr style="border: solid 1px #000000">
                    <td>Category Name</td>
                    <td>Product</td>
                    <td>Description</td>
                    <td>Price</td>
                    <td>Status</td>
                    <td>Action</td>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
        <%--<button type="button" id="btnExport">Export to Excel</button>--%>
    </div>
     <iframe  id="uploading" style="width:0px;height:0px;"></iframe>
</body>
</html>
