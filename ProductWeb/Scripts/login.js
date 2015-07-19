$(document).ready(function () {
    $("#btnLogin").click(function () {
        
        var valid = true;
        message = "";
        $("#form1 input").each(function () {
            
            var $this = $(this);
            if (!$this.val()) {
                var inputname = $this.attr('name');
                alert(inputname);
                valid = false;
                message += 'please enter your' + inputname + '\n';
            }
           
        });
        
        if (!valid)
        {
            alert(message);
        }
    });
    var name = $("#txtName");
    var email = $("#txtEmail");
    var password = $("#txtPassword");
    $("#form1").submit(function () {

        if (ValidateName() & ValidateEmail() & ValidatePassword()) {
            return true;
        }
        else {

            return false;
        }
    });
        //$("#txtName").keyup(function () {

        //    if (ValidateName())
        //    { return true; }
        //    else { return false; }
        //})
        //$("#txtEmail").keyup(function () {
        //    if (ValidateEmail()) { return true; }
        //    else { return false; }

        //});
        //$("#txtPassword").keyup(function () {
        //    if (ValidateEmail()) { return true; }
        //    else { return false; }
        //});
        
   
    function ValidateName()
    {
        var filter=/^[a-zA-Z]*$/;
        if (filter.test(name.val())) {

            return true;
        }
        else {
            alert("Name cannot be numbers");
            return false;
        }

    }
    function ValidateEmail() {
        //var filter = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        //var filter=new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
        var filter = /^[a-zA-Z0-9]+[a-zA-Z0-9_.-]+[a-zA-Z0-9_-]+@[a-zA-Z0-9]+[a-zA-Z0-9.-]+[a-zA-Z0-9]+.[a-z]{2,4}$/;
        if (filter.test(email.val()))
        {
            
            return true;
        }
        else {
            alert("Valid Email Please");
            return false;
        }

    }
    function ValidatePassword() {
        if (password.val().length< 8)
            alert("more than 8");
        var filter = /^[A-Za-z0-9\d=!\-@._*]*$/;
            //&& /[a-z]/ && /\d/;
        if (filter.test(password.val())) {
            
            return true;
        }
        else {
            alert("Password is no good");
            return false;

        }
    }
});
