$(document).ready(function () {
    $("#employeeLink").click(function (e) {
        e.preventDefault();
        $('html, body').animate({
            scrollTop: $("#employeesTitle").offset().top
        }, 1000);
    });
});