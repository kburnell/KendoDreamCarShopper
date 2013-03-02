$(function () {

    $("#makes").kendoGrid({
        dataSource: {
            transport: {
                read: { url: "/Api/Makes", type: "GET" },
                update: { url: "/Api/Makes", type: "POST" },
                create: { url: "/Api/Makes", type: "POST" },
                destroy: { url: "/Api/Makes", type: "DELETE" }
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Name: { validation: { required: true, validationMessage: "Please enter Name." } },
                        Location: { validation: { required: true, validationMessage: "Please enter Headquarters." } },
                        ImageUrl: { validation: { required: true, validationMessage: "Please enter Image Url." } }
                    }
                }
            },
            pageSize: 5
        },
        columns: [
            { field: "Name", title: "Make", width: "120px" },
            { field: "Location", title: "Headquarters", width: "200px" },
            { field: "ImageUrl", title: "Image Location" },
            { command: ["edit", "destroy", { text: "Models", click: models }], title: "&nbsp;", width: "240px" }],
        sortable: true,
        pageable: true,
        editable: "popup",
        toolbar: ["create"]
        
    });
    
    function models(e) {
        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        window.location.href = "/Maintenance/Models/" + dataItem.Id;
    }

});