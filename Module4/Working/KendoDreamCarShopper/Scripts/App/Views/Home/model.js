$(function () {
    var modelId = $.url().segment(-1);
    $.ajax({
        url: "/Api/ModelDetail/" + modelId,
        dataType: "json",
        type: "GET",
        success: function (model) {
            var selectedModelImage = $(".selectedModelImage");
            selectedModelImage.attr("src", model.Images[0].LowResolutionUrl);
            selectedModelImage.attr("title", model.Images[0].ShortDescription);
            selectedModelImage.attr("alt", model.Images[0].ShortDescription);
            $("#modelThumbnails").kendoListView({
                dataSource: model.Images,
                template: kendo.template($("#modelThumbnailTemplate").html())
            });
            $(".thumbnail").each(function (index, element) {
                if (index === 0) {
                    $(element).addClass("selectedThumbnail");
                }
                $(element).click(function (e) {
                    $(".thumbnail").removeClass("selectedThumbnail");
                    var thumbnail = $(e.target);
                    thumbnail.addClass("selectedThumbnail");
                    selectedModelImage.attr("src", thumbnail.attr("src"));
                    selectedModelImage.attr("title", thumbnail.attr("title"));
                    selectedModelImage.attr("alt", thumbnail.attr("alt"));
                });
            });
            var makeImage = $("#makeImage");
            makeImage.attr("src", model.MakeImageUrl);
            makeImage.attr("title", model.MakeName);
            makeImage.attr("alt", model.MakeName);
            $("#yearAndName").text(model.Year + " " + model.Name);
            $("#basePrice").text(kendo.toString(model.BasePrice, "c"));
            $("#description").text(model.Description);
            $("#engineType").text(model.EngineType);
            $("#power").text(model.BreakHorsepower + " bhp");
            $("#zeroToSixty").text(model.ZeroToSixty + " secs");
            $("#topSpeed").text(model.TopSpeed + " mph");
        }
    });
});