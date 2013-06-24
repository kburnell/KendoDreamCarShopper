$(function () {
    var viewModel = new kendo.Observable({
        modelImages: []
    });
    var modelImages = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/Api/MainImages/",
                dataType: "json"
            }
        }
    });
    modelImages.fetch(function() {
        viewModel.modelImages = modelImages.data();
        kendo.bind("#body", viewModel);
    });
    var makeImages = new kendo.data.DataSource({
         transport: {
            read: {
                url: "/Api/Makes/",
                dataType: "json"
            }
        }
    });
    $("#makeImages").kendoListView({
        dataSource: makeImages,
        template: kendo.template($("#makesTemplate").html())
    });
});