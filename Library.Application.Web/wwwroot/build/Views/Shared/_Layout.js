"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var moment = require("moment");
var common_utils_1 = require("@versteey/common-utils");
var Layout;
(function (Layout) {
    /* Custom validators, declare once and add before the onload. Only then jquery validation can use these methods. */
    //Add custom validator for atleastone validation for list of checkboxes.
    jQuery.validator.addMethod("atleastone", function (value, element) {
        var questionWithAnswers = $(element).parents(".question");
        return $(questionWithAnswers).find("[data-val-atleastone]:checked").length > 0;
    });
    jQuery.validator.unobtrusive.adapters.addBool("atleastone");
    // Add custom validator for BSN 11-proof.
    jQuery.validator.addMethod("bsn", function (value, element) {
        var bsnInput = $(element).val();
        var bsn = bsnInput.toString();
        if (common_utils_1.Utils.isUndefinedOrNull(bsn) || bsn === "")
            return true;
        if (bsn.length < 8 || bsn.length > 9) {
            return false;
        }
        var pos = 0;
        var result = 0;
        for (var i = bsn.length; i > 0; i--) {
            result += (i !== 1) ? (Number(bsn.charAt(pos)) * i) : (Number(bsn.charAt(pos)) * i * -1);
            pos++;
        }
        return (result % 11 === 0);
    }, jQuery.validator.messages.bsn);
    jQuery.validator.unobtrusive.adapters.addBool("bsn");
    /* Functions */
    function init(document, baseUrl) {
        var settings = new common_utils_1.UtilSettings(baseUrl, errorDialogSettings);
        settings.initForms = initForms;
        settings.handleUnauthorizedAjaxRequests = handleUnauthorizedAjaxRequests;
        common_utils_1.Utils.initialize(settings);
        initForms();
        initLoading(document);
    }
    Layout.init = init;
    function toggleSidebar(event) {
        $("#sidebar").toggleClass("sidebar--show");
        var clickListener = function (event) {
            if (!$(event.target).closest("#sidebar").length) {
                $("#sidebar").removeClass("sidebar--show");
                // ReSharper disable once VariableUsedInInnerScopeBeforeDeclared
                removeClickListener();
            }
        };
        var removeClickListener = function () {
            document.removeEventListener("click", clickListener);
            // ReSharper disable once Html.EventNotResolved
            document.removeEventListener("touchstart", clickListener);
        };
        document.addEventListener("click", clickListener);
        // ReSharper disable once Html.EventNotResolved
        document.addEventListener("touchstart", clickListener);
        event.stopPropagation();
    }
    Layout.toggleSidebar = toggleSidebar;
    // Error Dialog
    var errorDialogId = "error";
    var loadingId = "loading-request";
    var loadingTimeoutIds = [];
    var errorDialogSettings = {
        hideErrorDialog: function () {
            $("#" + errorDialogId).hide();
        },
        showErrorDialog: function (textMessage) {
            var errorDialog = $("#" + errorDialogId);
            errorDialog.find("#error-text").html(textMessage.replace(/(?:\r\n|\r|\n)/g, "<br>"));
            errorDialog.show();
        }
    };
    function handleUnauthorizedAjaxRequests() {
        errorDialogSettings.showErrorDialog("Your session has expired! Please login again...");
    }
    // Forms init
    function initForms() {
        initDropdown();
        initValidation();
        initDatePicker();
        initPhoneNumberMask();
        initPopover();
        initTooltips();
    }
    Layout.initForms = initForms;
    function initDropdown() {
        $().ready(function () {
            $(".selectpicker").selectpicker();
            $(".selectpicker").on("changed.bs.select", function () {
                $(this).blur();
            });
        });
    }
    function initDatePicker() {
        $().ready(function () {
            $("[data-provide='datepicker']").on("keyup", function () {
                var currentVal = $(this).val().toString();
                if (currentVal.length === 8 && currentVal.split("-").length === 1) {
                    var day = currentVal.substr(0, 2);
                    var month = currentVal.substr(2, 2);
                    var year = currentVal.substr(4, 4);
                    var dutchDate = day + "-" + month + "-" + year;
                    $(this).val(dutchDate);
                }
            });
            //Make sure to validate after selecting in a datepicker
            $("[data-provide='datepicker']").on("change.dp", function () {
                $(this).blur();
            });
        });
    }
    function initPhoneNumberMask() {
        $().ready(function () {
            $("input[type=tel]").on("keydown", function (event) {
                var keyCode = event.keyCode;
                // Allow: backspace, delete, tab, escape, and enter
                var isBackspaceOrDeleteOrTabOrEscapeOrEnter = keyCode === 46 || //Backspace
                    keyCode === 8 || //Delete
                    keyCode === 9 || //Tab
                    keyCode === 27 || //Escape
                    keyCode === 13; //Enter
                // Allow: Ctrl+A, Ctrl+C, Ctrl+V, Ctrl+X
                var isCtrlPlusAorCorVorX = event.ctrlKey === true &&
                    (keyCode === 65 || //A
                        keyCode === 67 || //C
                        keyCode === 86 || //V
                        keyCode === 88); //X
                // Allow: home, end, left, right
                var isHomeOrEndOrLeftOrRight = (keyCode >= 35 && keyCode <= 39);
                if (isBackspaceOrDeleteOrTabOrEscapeOrEnter || isCtrlPlusAorCorVorX || isHomeOrEndOrLeftOrRight) {
                    return; // let it happen, don't do anything
                }
                else {
                    // Ensure that it is a number and stop the keypress
                    if ((event.shiftKey || keyCode < 48 || keyCode > 57) &&
                        (keyCode < 96 || keyCode > 105)) {
                        event.preventDefault();
                    }
                }
            });
        });
    }
    function initPopover() {
        $('[data-toggle="popover"]').popover({
            trigger: "hover focus",
            html: true
        });
    }
    function initValidation() {
        $.validator.methods.number = function (value, element) {
            return this.optional(element) ||
                /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)?(?:,\d+)?$|^-?(?:\d+|\d{1,3}(?:\,\d{3})+)?(?:.\d+)?$/.test(value);
        };
        $.validator.methods.date = function (value, element) {
            var language = $(element).attr("data-date-language");
            if (language === "nl") {
                return this.optional(element) ||
                    value === "" ||
                    value === null ||
                    value === undefined ||
                    moment(value, "DD-MM-YYYY", true).isValid();
            }
            else if (language === "es") {
                return this.optional(element) ||
                    value === "" ||
                    value === null ||
                    value === undefined ||
                    moment(value, "DD/MM/YYYY", true).isValid();
            }
            else {
                return this.optional(element) ||
                    value === "" ||
                    value === null ||
                    value === undefined ||
                    moment(value, "l", true).isValid();
            }
        };
    }
    function initTooltips() {
        $().ready(function () {
            $("[data-toggle='tooltip']").tooltip();
        });
    }
    // Global init
    function initLoading(document) {
        $(document).ajaxSend(function () {
            var id = setTimeout(function () {
                $("#" + loadingId).fadeIn(250);
            }, 250);
            loadingTimeoutIds.push(id);
        });
        $(document).ajaxStop(function () {
            loadingTimeoutIds.forEach(function (id) {
                clearTimeout(id);
            });
            loadingTimeoutIds = [];
            $("#" + loadingId).fadeOut(250);
        });
    }
})(Layout = exports.Layout || (exports.Layout = {}));
