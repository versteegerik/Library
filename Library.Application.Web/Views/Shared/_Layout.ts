//import * as moment from "moment";

//export function initForms(): void {

//    initDropdown();
//    initValidation();
//    initDatePicker();
//    initPopover();
//}

//function initDropdown(): void {
//    $().ready(() => {
//        $(".selectpicker").selectpicker();

//        $('.selectpicker').on('changed.bs.select', function () {
//            $(this).blur();
//        });
//    });
//}

//function initValidation(): void {
//    $.validator.methods.number = function (value: any, element: any) {
//        return this.optional(element) ||
//            /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)?(?:,\d+)?$|^-?(?:\d+|\d{1,3}(?:\,\d{3})+)?(?:.\d+)?$/.test(value);
//    }
//    $.validator.methods.date = function (value: any, element: any) {
//        const language = $(element).attr("data-date-language");
//        var format = "L";
//        if (language === "nl-NL") {
//            format = "DD-MM-YYYY";
//        } else if (language === "es") {
//            format = "DD/MM/YYYY";
//        }

//        return this.optional(element) ||
//            value === "" ||
//            value === null ||
//            value === undefined ||
//            moment(value, format, true).isValid();
//    }
//}

//function initDatePicker(): void {
//    $().ready(() => {
//        $("[data-provide='datepicker']").on("keyup",
//            function () {
//                var currentVal = $(this).val().toString();
//                if (currentVal.length === 8 && currentVal.split("-").length === 1) {
//                    var day = currentVal.substr(0, 2);
//                    var month = currentVal.substr(2, 2);
//                    var year = currentVal.substr(4, 4);
//                    var dutchDate = day + "-" + month + "-" + year;
//                    $(this).val(dutchDate);
//                }
//            });
//        //Make sure to validate after selecting in a datepicker
//        $("[data-provide='datepicker']").on("change.dp",
//            function () {
//                $(this).blur();
//            });
//    });
//}

//function initPopover(): void {
//    $('[data-toggle="popover"]').popover({
//        trigger: "hover focus",
//        html: true
//    });
//}