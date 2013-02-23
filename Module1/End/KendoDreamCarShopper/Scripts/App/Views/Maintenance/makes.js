$(function () {
    $("#makes").kendoGrid({
        dataSource: {
            transport: {
                read: { url: "/Api/Makes", type: "GET" },
                update: {url: "/Api/Makes", type: "POST"},
                create: {url: "/Api/Makes", type: "POST"},
                destroy: {url: "/Api/Makes", type: "DELETE"}
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { editable: false, nullable: true },
                        Name: { editable: true, nullable: false, validation: { required: true } },
                        Location: { editable: true, nullable: false, validation: { required: true } },
                        ImageUrl: { editable: true, nullable: false, validation: { required: true } }
                    }
                }
            },
            sort: [{field: "Name", dir: "asc"}],
            pageSize: 5
        },
        columns: [
            { field: "Name", title: "Make", width: "120px" },
            { field: "Location", title: "Headquarters", width: "200px"},
            { field: "ImageUrl", title: "Image Location"},
            { command: ["edit", "destroy", { text: "Models", click: models }], title: "&nbsp;", width: "240px" }],
        editable: "popup",
        pageable: true,
        sortable: true,
        toolbar: ["create"]
    });
});

function models(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "/Maintenance/Models/" + dataItem.Id;
}