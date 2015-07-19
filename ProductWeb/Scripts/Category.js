$(document).ready(function () {

        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "AddProduct.aspx/BindCategoryDataToDropDown",
        data: "{}",
        dataType: "Json",
        success: function (data) {
            displayCategories(data.d.CategoryList);
        },
        error:function(data)
        {
            if (data.length < 0) {
                alert("in error");
            }
        }
 
        });
        $("#btnCategory").click(function () {
            var msg;
            var Category = $("#ddlCategories").children(":selected").attr("id");
            if (Category == undefined)
            {
                 msg = "Please select Category\n";
            }
            //alert(Category);
            var Subcategory = $("#txtCategoryName").val();
            if (Subcategory == "")
            {

                msg += "Please enter subcategory\n";
            }

            //alert(Subcategory);
            var fileupload = $("#imgid").val();
            //alert(fileupload);
            if (fileupload == "")
            {
                msg += "please select a file to upload";
            }
            if (msg)                
                alert(msg);
            return true;


        });
    function displayCategories(data)
    {
        for (var i = 0; i < data.length; i++) {
            $("#ddlCategories").append("<option value='" + data[i].CategoryName + "' id='"+data[i].CategoryId+"'>" + data[i].CategoryName + "</option>");
            
        }
       
    }
    $("#ddlCategories").change(function () {
        var id = $(this).children(":selected").attr("id");
        $("#ValueHiddenField").val(id);
    });

    $("input:file").change(
        function (e) {
            var file = this.files;
            for (var i = 0, len = file.length; i < len; i++) {
                var type = file[i].type;
                var size = file[i].size;
                alert("File type is" + type);

                if (type != "image/gif" && type != "image/jpeg" && type != "image/png") {
                    alert("Upload only images");
                    $('#imgid').val('');
                }
                else {

                    alert("File Size" + size);
                    if (size > 2097152) {
                        alert("Upload a file that is less than 2mb");

                    }

                }
            }

        }
     )
});

        

  

    
        