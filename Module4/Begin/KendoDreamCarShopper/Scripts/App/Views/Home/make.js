$(function () {
    var makeId = $.url().segment(-1);
    $.ajax({
        url: "/Api/Makes/" + makeId,
        dataType: "json",
        type: "GET",
        success: function (make) {
            $("#makeImage").attr("src", make.ImageUrl);
            $("#makeImage").attr("title", make.Name);
            $("#makeLocation").text(make.Location);
        }
    });
    var models = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/Api/Models/" + makeId,
                dataType: "json"
            }
        }
    });
    $("#models").kendoListView({
        dataSource: models,
        template: kendo.template($("#modelsTemplate").html())
    });
});