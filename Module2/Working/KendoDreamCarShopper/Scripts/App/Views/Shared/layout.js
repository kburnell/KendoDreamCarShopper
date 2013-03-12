$(function () {
    $("#menu").kendoMenu();
    $.ajax({
        url: "/Api/Makes/",
        dataType: "json",
        type: "GET",
        success: function (makes) {
            makes.forEach(function (make) {
                var markup = "<li><a href='/Makes/Index/" + make.Id + "'>" + make.Name + "</a></li>";
                $("#makesMenu").append(markup);
            });
            $("#menu").kendoMenu();
        }
    });
});