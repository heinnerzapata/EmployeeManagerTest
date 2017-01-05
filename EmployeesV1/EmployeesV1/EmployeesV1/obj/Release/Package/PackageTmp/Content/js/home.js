$(window).ready(function () {
        
    function resetValidation() {

        $(".form-control-feedback").addClass("hidden");
        $(".form-group").removeClass("has-success");
        $(".form-group").removeClass("has-danger");


    }

    function init() {

        resetValidation();

        $("#hdnUserPosition").val($("#selOrsition").find("option:selected").val());
        $("#hdnUserProject").val($("#selProject").find("option:selected").val());
               
        
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


    $("#imgUserCreate").click(function () {
                
        $("#file").click();
                 

    });

    $('#file').change(function () {
        $("#lblPath").html($("#file").val());
    });

   

    $("#btn-modal").click(function () {

        resetValidation();

    });

    $(".form-validate").blur(function () {

        var validErr = validateFormError();

    });

    $("#btnSave").click(function () {

        if (!validateFormError())
            $("#btnSaveSubmit").click();

    });
    
    
    
    $("#selProject").change(function () {

        var $valor = $(this).find("option:selected").val()

        //alert($valor);
        $("#hdnUserProject").val($valor);

    });


    $("#selOrsition").change(function(){
    
        var $valor = $(this).find("option:selected").val()

        //alert($valor);
        $("#hdnUserPosition").val($valor);
        
    });
    

    // Delete 

    $(".btnDelete").click(function () {

        var Id = $(this).parent().find(".hdnId").html();

        $.ajax({
            url: "../Home/Delete",
            type: "GET",
            data: { Id: Id },
            success: function (response) {
                
                location.reload();
                
            },
            error: function (response) {
                alert(response.Message);
            }
        });

    });
    
    // Search Employees
    $("#btnSearch").click(function () {
             
        var filter = $("#txtSearch").val();
        var filterProject = $("#selProjectFilter option:selected").val();
        var filterPosition = $("#selPositionFilter option:selected").val();
        
        $.ajax({
            url: "../Home/SearchEmployee",
            type: "GET",
            data: { filter: filter, filterProject: filterProject, filterPosition: filterPosition },
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