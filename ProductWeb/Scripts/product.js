$(document).ready(function () {
    categoryManager.loadSubCategories('ddlSubCategory'); 
    //$("#ddlSubCategory").change(function () {
    //    var CategoryId = $(this).children(":selected").attr("id");    
    //});  
        $("#ddlSubCategory").focus(); //Focus on the first item in the form
        $("#btnSubmit").click(function () {
            var product = new Product();
            product.Name = $("#txtName").val();
            product.Description = $("#txtDesc").val();
            product.Price = $("#txtPrice").val();
            product.Status = $("#ddlStatus").val();
            var CategoryId = $("#ddlSubCategory").children(":selected").attr("id");
            alert(CategoryId);
            var message = "";
            //var status = $("lblMsg");
            $("#txtName").removeClass('red');
            $("#txtPrice").removeClass('red');
            $("#ddlStatus").removeClass('red');
            //if ($("ddlSubCategory").val() == undefined) {

            //    message += "Please select a category";
            //    $("ddlSubCategory").addClass('red');

            //}
            if (CategoryId == undefined)
            {
                message += "Please Select a category\n";
                $("#ddlSubCategory").addClass('red');
            }
            if (product.Name == "")
            {
                message += "Please Enter Name\n";
                $("#txtName").addClass('red');
            }
            //if ($("#txtName").val() == "") {
            //    message += "Please Enter Name\n";
            //    $("#txtName").addClass('red');
            //}
            if (product.Price == "")
            {
                message += "Please Enter Price\n";
                $("#txtPrice").addClass('red');

            }
            //if ($("#txtPrice").val() == "") {
            //    message += "Please Enter Price\n";
            //    $("#txtPrice").addClass('red');
            //}
            if (product.Status == undefined)
            {
                message += "Please Enter Status";
                $("#ddlStatus").addClass('red');

            }
            //if ($("#ddlStatus").val() == undefined) {
            //    message += "Please Enter Status\n";
            //    $("#ddlStatus").addClass('red');
            //}
            
            if (message == "") {
                
                //var prodname = $("#txtName").val();
                //var description = $("#txtDesc").val();
                //var price = $("#txtPrice").val();
                //var status = $("#ddlStatus").val();
                $.ajax({
                    type: "POST",
                    url: "AddProduct.aspx?action=save",
                    //name: prodname, description: description, price: price, status: status,
                    data: { product: JSON.stringify(product),CategoryId:CategoryId },
                    contentType: "application/x-www-form-urlencoded; charset=utf-8",
                    success: function (msg) {
                       
                        alert(msg);
                        $("#form1").each(function () {
                            this.reset(); // reset form on success

                        });
                    },
                    error: function (msg) {
                        alert(msg);
                    }

                }); //Sends data to Server
                return false;

            }
            else {
                alert(message);//Displays all Errors            
                return false;//Restricted           
            }
        //});
    });
});

categoryManager = {};
categoryManager.loadSubCategories = function (ddlCategoryId, categoryHolder) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "AddProduct.aspx/BindSubCategoryDataToDropDown",
        data: "{}",
        dataType: "Json",
        success: function (data) {
            categoryManager.displaySubCategories(data.d.CategoryList, ddlCategoryId, categoryHolder);
        },
        error: function (data) {
            if (data.length < 0) {
                alert("in error");
            }
        }
    });
    categoryManager.displaySubCategories = function (data, ddlCategoryId, categoryHolder) {
        var dropdown = $("#" + ddlCategoryId);
        if (dropdown.length == 0) {
            dropdown = $("<select id='ddlEditCategory'><option value='' disabled='disabled' selected='selected'>--Select--</option></select>")
        }
        for (var i = 0; i < data.length; i++) {                      
            dropdown.append("<option value='" + data[i].CategoryName + "' id='" + data[i].CategoryId + "'>" + data[i].CategoryName + "</option>");           
        }
        if (categoryHolder != undefined) {
            categoryHolder.html("");
            categoryHolder.append(dropdown);
        }
        //return dropdown;
    }
 
}
function Product(Name, Description, Price, Status) {
    this.Name = Name;
    this.Description = Description;
    this.Price = Price;
    this.Status = Status;
}