$(function () {
    var viewModel = new kendo.Observable({
        modelImages: []
    });
    var mainImages = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/Api/MainImages/",
                dataType: "json"
            }
        }
    });
    mainImages.fetch(function() {
        viewModel.mainImages = mainImages.data();
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