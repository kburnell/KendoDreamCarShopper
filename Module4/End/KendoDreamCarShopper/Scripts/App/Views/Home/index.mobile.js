$(function () {
   var app = new kendo.mobile.Application(document.body);
});

var models;
var itemId;

function loadModels() {
    models = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/Api/Models/",
                dataType: "json"
            }
        },
        group: "MakeLogoUrl",
    });
    $("#modelsList").kendoMobileListView({
        dataSource: models,
        template: $("#modelsListItemTemplate").html(),
        headerTemplate: $("#modelsListHeaderTemplate").html(),
        fixedHeaders: true
    })
    .kendoTouch({
        filter: ">li .details",
        tap: navigate
    });
}

function detailShow(e) {
    var model = models.getByUid(itemId);
    $("#modelName").text(model["MakeName"] + ': ' + model["Year"] + " " + model["Name"]);
    $("#modelPrice").text(kendo.toString(model["BasePrice"],"c0"));
    $("#modelEngine").text(model["EngineType"]);
    $("#modelDescription").text(model["Description"]);
    $("#modelHorsepower").text(model["BreakHorsepower"]);
    $("#modelZeroToSixty").text(model["ZeroToSixty"] + " secs");
    $("#modelTopSpeed").text(model["TopSpeed"] + " mph");
}

function imagesInit(e) {
    var model = models.getByUid(itemId);
    $.ajax({
        url: "/Api/ModelImages/" + model["Id"],
        type: "GET",
        dataType: "json",
        success: function (images) {
            var template = kendo.template($("#modelImageTemplate").html());
            var content = kendo.render(template, images);
            $("#modelImagesDisplay").kendoMobileScrollView().data("kendoMobileScrollView").content("<!--" + content + "-->");
        }
    });

}

function imagesShow(e) {
    var model = models.getByUid(itemId);
    $("#modelImages_modelName").text(model["MakeName"] + ': ' + model["Year"] + " " + model["Name"]);
}

function navigate(e) {
    itemId = $(e.touch.currentTarget).parent().data("uid");
    kendo.mobile.application.navigate("#modelDetail?uid=" + itemId);
}

function modelDetail_tabStrip_click(item) {
    kendo.mobile.application.navigate(item.item[0].hash + "?uid=" + itemId);
}