$(function () {
    $.ajax({
        url: "/Api/Makes/",
        dataType: "json",
        type: "GET",
        success: function (makes) {
            makes.forEach(function (element) {
                var markup = "<li><a href='/Make/Index/" + element.Id + "' class='k-link'>" + element.Name + "</a></li>";
                $("#makesMenu").append(markup);
            });
            $("#menu").kendoMenu();
        }
    });
    $("#menu").kendoMenu();
});