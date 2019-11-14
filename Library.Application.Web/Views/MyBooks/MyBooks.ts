var table: DataTables.Api;
var filters: any;

export function initList() {
    //initFilters();
    table = $("#book-table").DataTable({
        order: [[1, "asc"]],
        ajax: {
            url: "https://localhost:5001/MyBooks/BuildList", //Utils.getBaseUrl() + "MyBooks/BuildList",
            type: "POST",
            data(data: any) {
                data.__RequestVerificationToken = $("input[name=__RequestVerificationToken]").val();
                //data.filters = filters;
            }
        },
        rowId: "id",
        columns: [
            {
                className: "control",
                render(): any { return null; }
            },
            { "data": "title" },
            { "data": "author" }
        ],
        columnDefs: [
            {
                targets: 0,
                orderable: false
            },
            {
                targets: 1,
                render(data: any, type: any, row: any) {
                    if (data) {
                        //TODO
                        //const url = Utils.getBaseUrl() + "MyBook/Update?id=" + row["id"];
                        const url = "https://localhost:5001/MyBooks/Update?id=" + row["id"];
                        return `<a href=\"${url}\"})"><div style="width:70%;"><strong">${row["title"]}</strong></div></a>`;
                    }
                    return null;
                }
            },
            {
                targets: 2,
            }
        ]
    });

    $("#SearchTerm").keypress((event: JQuery.Event) => {
        var keycode = (event.keyCode ? event.keyCode : event.which).toString();
        if (keycode === "13") {
            search();
        }
    });
}

export function search() {
    var searchTerm = $("#SearchTerm").val().toString();
    table.search(searchTerm).draw();
}

//export function initFilters() {
//    filters = {
//        filterHasAgreedToUseDataForResearch: null,
//        filterLastMeasureMoment: null
//    };
//    $("#filterHasAgreedToUseDataForResearch").change(() => {
//        filters.filterHasAgreedToUseDataForResearch = $("#filterHasAgreedToUseDataForResearch").val();
//        table.draw();
//    });
//    $("#filterLastMeasureMoment").on("change", () => {
//        filters.filterLastMeasureMoment = $("#filterLastMeasureMoment").val();
//        table.draw();
//    });
//}
