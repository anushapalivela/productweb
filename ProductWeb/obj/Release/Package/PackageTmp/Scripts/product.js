//function validate()
//{
//    alert("I am in");
//    var Name=document.getElementById("txtName").value;
//    var Price=document.getElementById("txtPrice").value;
//    var Status = document.getElementById("ddlStatus").value;
//    var isvalid = true;
//    if (Name == "") {
//        isvalid = false;
//        alert("Enter Name");        
//    }
//    if (Price == "") {
//        isvalid = false;
//        alert("Enter Price");        
//    }
//    if (Status == "0 ") {
//        isvalid = false;
//        alert("Enter Status ");        
//    }
//     return isvalid;
//}

$(document).ready(function () {  
    $("#btnSubmit").click(function () {
        var message = "";
        $("#txtName").removeClass('red');
        $("#txtPrice").removeClass('red');
        $("#ddlStatus").removeClass('red');
        if ($("#txtName").val() == "") {
            message += "Please,Enter Name\n";
            $("#txtName").addClass('red');
        }
        //else { }
        if ($("#txtPrice").val() == "") {
            message += "Please,Enter Price\n";
            $("#txtPrice").addClass('red');
        }
        if ($("#ddlStatus").val() == "0") {
            message += "Please,Enter Status\n";
            $("#ddlStatus").addClass('red');
        }
        if (message == "") {
            return true; //Sends data to Server
        }
        else {
           
            alert(message);//Dispalys all Errors            
            //$("#btnSubmit").addClass('red');
            return false;//Restricted           
        }

     });
   });
   