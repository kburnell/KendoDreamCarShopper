$(function () {
    $.ajax({
        url: "/Api/Makes/",
        dataType: "json",
        type: "GET",
        success: function (makes) {
            makes.forEach(function (make) {
                var markup = "<li><a href='/Home/Make/" + make.Id + "' class='k-link'>" + make.Name + "</a></li>";
                $("#makesMenu").append(markup);
            });
            $("#menu").kendoMenu();
        }
    });
    $("#menu").kendoMenu();
});