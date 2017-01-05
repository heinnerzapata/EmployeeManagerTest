$(window).ready(function () {



    function resetValidation() {

        $(".form-control-feedback").addClass("hidden");
        $(".form-group").removeClass("has-success");
        $(".form-group").removeClass("has-danger");


    }

    function init() {

        resetValidation();

    }
    

    function validateFormError() {

        var $txtName = $("#txtName");

        var $isFormDataError = false;


        // txtName
        if ($txtName.val() == "") {

            $txtName.parent().removeClass("has-success");
            $txtName.parent().addClass("has-danger");
            $txtName.parent().find(".form-control-feedback").removeClass("hidden");

            $isFormDataError = true;
        }
        else {
            $txtName.parent().removeClass("has-danger");
            $txtName.parent().addClass("has-success");
            $txtName.parent().find(".form-control-feedback").addClass("hidden");

        }



        return $isFormDataError;

    }

    $("#btn-modal").click(function () {

        resetValidation();

    });

    $(".form-validate").blur(function () {

        var validErr = validateFormError();

    });

    $("#btnSave").click(function () {

        if (!validateFormError())
            alert("ok");

    });
      


    // Search Employees
    $("#btnSearch").click(function () {
             
        var filter = $("#txtSearch").val();
        $.ajax({
            url: "../Home/SearchEmployee",
            type: "GET",
            data: { filter: filter },
            success: function (response) {
                
                $("#cardsContainer").empty();
                $("#cardsContainer").append(response.Content);

            },
            error: function (response) {
                alert(response.Message);
            }
        });
        

    });


    init();
    
});