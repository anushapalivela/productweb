$(document).ready(function () {
    $("#tbGetData").hide();
    $("#btnGetData").click(function () {
        var Index = 1;//Default first Page
        $("#tbGetData tbody").empty();
        $("#paging a").remove();
        $.ajax({
            type: "POST",
            url: "AddProduct.aspx/BindDataTable",
            data: "{PageIndex:" + Index + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //List implementation
                //$.each(msg.d, function (index, obj) {
                //    row += "<tr><td>" + obj.Name + "</td><td>" + obj.Description + "</td><td>" + obj.Price + "</td></tr>" + "<tr><td>" + obj.Status + "</td><td>";
                //});
                //$("#tbGetData tbody").append(row);
                //    }
                //}
                displayproducts(data.d.ProductList);
                var pageTotal = Math.ceil((data.d.Count) / 10);
                for (var i = 0; i < pageTotal; i++) {
                    $("#paging").append("<a href=\"#\" style=\"padding:3px\" onClick=\"pageData(" + (i + 1) + ")\">" + (i + 1) + "</a>")

                }

            },
            error: function (data) {
                if (data.d.Count < 0) {
                    alert("Error while trying to get data");

                }
            }

        });

    });
});
function pageData(e) {
    $("#tbGetData tbody").empty();
    $(this).css("background", "red");
    $.ajax({
        type: "POST",
        url: "AddProduct.aspx/BindDataTable",
        data: "{PageIndex:" + e + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            displayproducts(data.d.ProductList);
        },
        error: function (data) {
            if (data.d.Count < 0) {
                alert("Error while trying to get data");

            }
        }
    });
    return false;
}
function displayproducts(data) {
    $("#tbGetData").show();
    for (var i = 0; i < data.length; i++) {
        $("#tbGetData").append("<tr rowindex=" + data[i].Id + "><td>"+data[i].Category.CategoryName+"</td><td>" + data[i].Name + "</td><td>" + data[i].Description + "</td><td>" + data[i].Price + "</td><td>" + data[i].Status + "</td><td><button type='button' id='btnEdit'>Edit</button><button type='button' id='btnDelete'>Delete</button><button type='button' id='btnUpdate'>Save</button><button type='button' id='btnCancel'>Cancel</button></td></tr>");
        //$('[id=btnUpdate]').hide();
        //$('[id=btnCancel]').hide();
       
    }
    $("[id=btnEdit]").on('click', (function () {
        var currentrow = $(this).closest('tr').find('td:eq(5)');
        //currentrow.find('#btnEdit').hide();
        //currentrow.find('#btnDelete').hide();
        //currentrow.find('#btnUpdate').show();
        //currentrow.find('#btnCancel').show();
        //currentrow.find('td:eq(5)').append("<button type='button' id='btnUpdate'>Save</button>")
        //currentrow.find('td:eq(5)').append("<button type='button' id='btnCancel'>Cancel</button>")
        var ExistingCategory=$(this).closest('tr').find('td:eq(0)').text();

        categoryManager.loadSubCategories(undefined, $(this).parent().closest('tr').find('td:eq(0)'));
        //$(this).parent().closest('tr').find('td:eq(0)').append(dropdown);// html('<select id="ddlSubCategory"><option value="" disabled="disabled" selected="selected">--Select--</option></select>');
        $(this).parent().closest('tr').find('td:gt(0):lt(4)').each(function () {
            //$(this).parent
            // $(this).closest('tr').find('td:lt(4)').each(function () {
            var existingVal = $(this).text();
            $(this).html('<input type="text" value="' + existingVal + '" >');
        });
        $("[id=btnCancel]").on('click', (function () {
            $(this).closest('tr').find('td:eq(0)').html(ExistingCategory);
             $(this).closest('tr').find('td:gt(0):lt(4)').each(function () {
                var existingVal = $(this).find('input').val();
                $(this).html("<label>").text(existingVal);
             });

             var currentrow = $(this).closest('tr').find('td:eq(5)');
                //currentrow.find('#btnEdit').show();
                //currentrow.find('#btnDelete').show();
                //currentrow.find('#btnUpdate').hide();           
                //$(this).hide();
                return false;
        }));
        $("[id=btnUpdate]").on('click', (function () {
            var product = new Product();
            var currentRow = $(this).closest('tr');
            var SelectedCategoryName= currentRow.find('td:eq(0)').find('select').children(":selected").attr("value");
            var SelectedCategoryId = currentRow.find('td:eq(0)').find('select').children(":selected").attr("id");
            product.Id = currentRow.attr("rowindex");
            product.Name = currentRow.find('td:eq(1)').find('input').val();
            product.Description = currentRow.find('td:eq(2)').find('input').val();
            product.Price = currentRow.find('td:eq(3)').find('input').val();
            product.Status = currentRow.find('td:eq(4)').find('input').val();
            //product.Status = currentRow.find('td:eq(3)').find('input').val().toLowerCase();
            //alert(status);
            var message = "";
            if (SelectedCategoryName == "")
            {
                message+="Please a select Category for the product\n";
            
            }
            if (product.Name == "") {
                message += "Please Enter Name\n";
            }
            if (product.Price == "") {
                message += "Please Enter Price\n";
            }
            if (product.Status == "") //&& (product.Status != "in stock" && product.Status != "out of stock" && product.Status != "back order"))
            {
                message += "Please Enter Status as In Stock/Out of Stock/Back Order";
            }
            //if (product.Status != "in stock" && product.Status != "out of stock" && product.Status != "back order")
            //{
            //    message += "Please Enter Status as In Stock/Out of Stock/Back Order";

            //}

            if (message == "") {
                $.ajax({
                    type: "POST",
                    url: "AddProduct.aspx?action=update",
                    data: { product: JSON.stringify(product),CategoryId:SelectedCategoryId },
                    contentType: "application/x-www-form-urlencoded; charset=utf-8",
                    success: function (msg) {
                        alert(msg);

                    },
                    error: function (msg) {
                        alert(msg);
                    }
                }); //Sends data to Server
                $(this).parent().closest('tr').find('td:eq(0)').find('select').children(":selected").attr("value").html("<label>").text(SelectedCategoryName)
                $(this).parent().closest('tr').find('td:gt(0):lt(4)').each(function () {
                    var updatedVal = $(this).find('input').val();
                    $(this).html("<label>").text(updatedVal);
                });
                var currentrow = $(this).closest('tr').find('td:eq(5)');
                //currentrow.find('#btnUpdate').hide();
                //currentrow.find('#btnCancel').hide();
                //currentrow.find('#btnEdit').show();
                //currentrow.find('#btnDelete').show();
                //$(this).hide();
            }
            else {
                alert(message);
            }
        }));

    }));
    $("[id=btnDelete]").on('click', function () {
        var currentRow = $(this).closest('tr');
        //var product = new Product();
        //product.Id = currentRow.attr("rowindex");
        $(this).closest('tr').fadeOut("slow", function () {
            this.remove();
        });
        var RowId = currentRow.attr("rowindex");
        $.ajax({
            //If using Web Method
            //data:"{Id:" + RowId + "}",
            //url: "AddProduct.aspx/DeleteProducts",
            //contentType: "application/json; charset=utf-8",
            //dataType: "json",
            type: "POST",
            url: "AddProduct.aspx?action=delete",
            //data: { Id: JSON.stringify(RowId) },As we are passing only one parameter 
            data: { Id: RowId },
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            success: function (msg) {
                alert(msg);
                $("#btnGetData").click();
            },
            error: function (msg) {
                alert(msg);
            }
        }); //Sends data to Server
    });
}
function Product(Id, Name, Description, Price, Status) {
    this.Id = Id;
    this.Name = Name;
    this.Description = Description;
    this.Price = Price;
    this.Status = Status;
}


//function sleep(ms) {
//    var start = new Date().getTime(), expire = start + ms;
//    while (new Date().getTime() < expire) { }
//    return;
//}