export const defaultPageSize: number = 25;

export module Layout {
    export function init(): void {
        initDatatableSettings();
    }

    function initDatatableSettings(): void {
        $.extend($.fn.dataTable.defaults, {
            serverSide: true,
            ordering: true,
            processing: true,
            searching: true,
            responsive: {
                details: {
                    type: 'column'
                }
            },
            autoWidth: false,
            pageLength: defaultPageSize,
            lengthMenu: [25, 50, 100, 200],
            pagingType: "full_numbers",
            dom: "<lp<t>lp>",
            language: {
                "sProcessing": "Bezig...",
                "sLengthMenu": "_MENU_ resultaten weergeven",
                "sZeroRecords": "Geen resultaten gevonden",
                "sInfo": "_START_ tot _END_ van _TOTAL_ resultaten",
                "sInfoEmpty": "Geen resultaten gevonden",
                "sInfoFiltered": " (gefilterd uit _MAX_ resultaten)",
                "sInfoPostFix": "",
                "sSearch": "Zoeken:",
                "sEmptyTable": "Geen resultaten gevonden",
                "sInfoThousands": ".",
                "sLoadingRecords": "Een moment geduld aub - bezig met laden...",
                "oPaginate": {
                    "sFirst": "<i class='fas fa-angle-double-left' aria-hidden='true'></i>",
                    "sLast": "<i class='fas fa-angle-double-right' aria-hidden='true'></i>",
                    "sPrevious": "<i class='fas fa-angle-left' aria-hidden='true'></i>",
                    "sNext": "<i class='fas fa-angle-right' aria-hidden='true'></i>"
                },
                "oAria": {
                    "sSortAscending": ": activeer om kolom oplopend te sorteren",
                    "sSortDescending": ": activeer om kolom aflopend te sorteren",
                    "oPaginate": {
                        "sFirst": "Eerste",
                        "sLast": "Laatste",
                        "sNext": "Volgende",
                        "sPrevious": "Vorige"
                    }
                }
            }
        });

        $.extend($.fn.dataTable.ext.classes, {
            sLengthSelect: "form-control form-control-sm",
        });
    }
}
