import * as moment from "moment";
import { Utils } from "@versteey/common-utils";
import { UtilSettings, IErrorDialog } from "@versteey/common-utils/dist/UtilSettings";

export module Layout {
    /* Custom validators, declare once and add before the onload. Only then jquery validation can use these methods. */

    //Add custom validator for atleastone validation for list of checkboxes.
    jQuery.validator.addMethod("atleastone", (value, element) => {
        var questionWithAnswers = $(element).parents(".question");
        return $(questionWithAnswers).find("[data-val-atleastone]:checked").length > 0;
    });
    jQuery.validator.unobtrusive.adapters.addBool("atleastone");
    // Add custom validator for BSN 11-proof.
    jQuery.validator.addMethod("bsn", (value, element) => {
        var bsnInput = $(element).val();
        var bsn = bsnInput.toString();

        if (Utils.isUndefinedOrNull(bsn) || bsn === "")
            return true;

        if (bsn.length < 8 || bsn.length > 9) {
            return false;
        }

        let pos = 0;
        let result = 0;
        for (let i = bsn.length; i > 0; i--) {
            result += (i !== 1) ? (Number(bsn.charAt(pos)) * i) : (Number(bsn.charAt(pos)) * i * -1);
            pos++;
        }
        return (result % 11 === 0);

    }, jQuery.validator.messages.bsn);
    jQuery.validator.unobtrusive.adapters.addBool("bsn");

    /* Functions */

    export function init(document: any, baseUrl: string): void {

        const settings = new UtilSettings(baseUrl, errorDialogSettings);
        settings.initForms = initForms;
        settings.handleUnauthorizedAjaxRequests = handleUnauthorizedAjaxRequests;
        Utils.initialize(settings);

        initForms();
        initLoading(document);
    }

    export function toggleSidebar(event: Event) {
        $("#sidebar").toggleClass("sidebar--show");

        const clickListener = (event: Event) => {
            if (!$(event.target as HTMLElement).closest("#sidebar").length) {
                $("#sidebar").removeClass("sidebar--show");
                // ReSharper disable once VariableUsedInInnerScopeBeforeDeclared
                removeClickListener();
            }
        }

        const removeClickListener = () => {
            document.removeEventListener("click", clickListener);
            // ReSharper disable once Html.EventNotResolved
            document.removeEventListener("touchstart", clickListener);
        }
        document.addEventListener("click", clickListener);
        // ReSharper disable once Html.EventNotResolved
        document.addEventListener("touchstart", clickListener);

        event.stopPropagation();
    }

    // Error Dialog
    var errorDialogId = "error";
    var loadingId = "loading-request";
    var loadingTimeoutIds: any[] = [];

    var errorDialogSettings: IErrorDialog = {
        hideErrorDialog() {
            $(`#${errorDialogId}`).hide();
        },

        showErrorDialog(textMessage: string) {

            const errorDialog = $(`#${errorDialogId}`);

            errorDialog.find("#error-text").html(textMessage.replace(/(?:\r\n|\r|\n)/g, "<br>"));
            errorDialog.show();
        }
    };

    function handleUnauthorizedAjaxRequests(): void {

        errorDialogSettings.showErrorDialog("Your session has expired! Please login again...");
    }

    // Forms init
    export function initForms(): void {

        initDropdown();
        initValidation();
        initDatePicker();
        initPhoneNumberMask();
        initPopover();
        initTooltips();
    }

    function initDropdown(): void {
        $().ready(() => {
            $(".selectpicker").selectpicker();

            $(".selectpicker").on("changed.bs.select", function () {
                $(this).blur();
            });
        });
    }

    function initDatePicker(): void {
        $().ready(() => {
            $("[data-provide='datepicker']").on("keyup",
                function () {
                    const currentVal = $(this).val().toString();
                    if (currentVal.length === 8 && currentVal.split("-").length === 1) {
                        const day = currentVal.substr(0, 2);
                        const month = currentVal.substr(2, 2);
                        const year = currentVal.substr(4, 4);
                        const dutchDate = day + "-" + month + "-" + year;
                        $(this).val(dutchDate);
                    }
                });
            //Make sure to validate after selecting in a datepicker
            $("[data-provide='datepicker']").on("change.dp",
                function () {
                    $(this).blur();
                });
        });
    }

    function initPhoneNumberMask(): void {
        $().ready(() => {
            $("input[type=tel]").on("keydown", (event: any): void => {
                const keyCode = event.keyCode;

                // Allow: backspace, delete, tab, escape, and enter
                const isBackspaceOrDeleteOrTabOrEscapeOrEnter =
                    keyCode === 46 || //Backspace
                    keyCode === 8 || //Delete
                    keyCode === 9 || //Tab
                    keyCode === 27 || //Escape
                    keyCode === 13;   //Enter

                // Allow: Ctrl+A, Ctrl+C, Ctrl+V, Ctrl+X
                const isCtrlPlusAorCorVorX =
                    event.ctrlKey === true &&
                    (keyCode === 65 || //A
                        keyCode === 67 || //C
                        keyCode === 86 || //V
                        keyCode === 88);  //X

                // Allow: home, end, left, right
                const isHomeOrEndOrLeftOrRight = (keyCode >= 35 && keyCode <= 39);

                if (isBackspaceOrDeleteOrTabOrEscapeOrEnter || isCtrlPlusAorCorVorX || isHomeOrEndOrLeftOrRight) {
                    return; // let it happen, don't do anything
                } else {
                    // Ensure that it is a number and stop the keypress
                    if ((event.shiftKey || keyCode < 48 || keyCode > 57) &&
                        (keyCode < 96 || keyCode > 105)) {
                        event.preventDefault();
                    }
                }
            });
        });
    }

    function initPopover(): void {
        $('[data-toggle="popover"]').popover({
            trigger: "hover focus",
            html: true
        });
    }

    function initValidation(): void {
        $.validator.methods.number = function (value: any, element: any) {
            return this.optional(element) ||
                /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)?(?:,\d+)?$|^-?(?:\d+|\d{1,3}(?:\,\d{3})+)?(?:.\d+)?$/.test(value);
        }
        $.validator.methods.date = function (value: any, element: any) {
            const language = $(element).attr("data-date-language");
            if (language === "nl") {
                return this.optional(element) ||
                    value === "" ||
                    value === null ||
                    value === undefined ||
                    moment(value, "DD-MM-YYYY", true).isValid();
            } else if (language === "es") {
                return this.optional(element) ||
                    value === "" ||
                    value === null ||
                    value === undefined ||
                    moment(value, "DD/MM/YYYY", true).isValid();
            } else {
                return this.optional(element) ||
                    value === "" ||
                    value === null ||
                    value === undefined ||
                    moment(value, "l", true).isValid();
            }
        }
    }

    function initTooltips(): void {
        $().ready(() => {
            $("[data-toggle='tooltip']").tooltip();
        });
    }

    // Global init
    function initLoading(document: any): void {
        $(document).ajaxSend(() => {
            var id = setTimeout(() => {
                $(`#${loadingId}`).fadeIn(250);
            }, 250);
            loadingTimeoutIds.push(id);
        });
        $(document).ajaxStop(() => {
            loadingTimeoutIds.forEach(id => {
                clearTimeout(id);
            });
            loadingTimeoutIds = [];
            $(`#${loadingId}`).fadeOut(250);
        });
    }
}
