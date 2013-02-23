$(function () {
    $("#models").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: function () {
                        var url = "/Api/Models";
                        var id = $.url().segment(-1);
                        if (!isNaN(id))
                            url = url + "/" + id;
                        return url;
                    } , type: "GET" },
                destroy: {url: "/Api/Models", type: "DELETE"}
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { editable: false},
                        Name: { editable: false},
                        Year: { editable: false},
                        BasePrice: { editable: false},
                        MakeId: { editable: false},
                        MakeName: { editable: false}
                    }
                }
            },
            sort: [{ field: "MakeName", dir: "asc" },{field: "Name", dir: "asc"}],
            pageSize: 5,
            group: { field: "MakeName" }
        },
        columns: [
            { field: "MakeName", title: "Make", groupHeaderTemplate: '#= value #' },
            { field: "Name", title: "Model"},
            { field: "Year", title: "Year", width: "85px", attributes: { style: "text-align:right;" }},
            { field: "BasePrice", title: "MSRP", format: "{0:c0}",  width: "100px", attributes: { style: "text-align:right;" } },
            { command: [{ text: "Detail", click: details }, { text: "Delete", click: deleteImage }], title: "&nbsp;", width: "170px"}],
        pageable: true,
        sortable: true,
        toolbar: kendo.template($("#toolbarTemplate").html())
    });
    $("#models").data("kendoGrid").hideColumn("MakeName");
    $("#addModel").click(addNewModel);
    
});

function details(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "/Maintenance/ModelDetails/" + dataItem.Id + "?showDetails=true&makeId=" + dataItem.MakeId;
}

function deleteImage(e) {
    if (confirm("Are you sure you want to delete this record?")) {
        var model = this.dataItem($(e.currentTarget).closest("tr"));
        var models = $(e.target).closest(".k-grid").data("kendoGrid").dataSource;
        models.remove(model);
        if (model.Id != 0) {
            $.ajax({
                url: "/Api/Models/",
                dataType: "json",
                type: "DELETE",
                data: JSON.stringify(model),
                contentType: "application/json;charset=utf-8"
            });
        }
    }
}

function addNewModel() {
    var url = "/Maintenance/ModelDetails/0";
    var makeId = $.url().segment(-1);
    url = url + "?makeId=" + makeId;
    window.location.href = url;
}