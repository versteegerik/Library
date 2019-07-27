"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//NPM packages
require("bootstrap");
require("expose-loader?$!jquery");
require("jquery-ajax-unobtrusive");
require("jquery-validation");
require("jquery-validation-unobtrusive");
require("bootstrap-select");
require("bootstrap-select/dist/js/i18n/defaults-nl_NL.js");
require("bootstrap-datepicker");
require("bootstrap-datepicker/dist/locales/bootstrap-datepicker.nl.min.js");
//import "datatables.net";
//import "datatables.net-bs4";
//import "datatables.net-select";
//import "datatables.net-select-bs4";
//import "datatables.net-buttons";
//import "datatables.net-buttons-bs4";
//import "datatables.net-responsive-bs4";
require("moment");
//NPM packages style
require("bootstrap-datepicker/dist/css/bootstrap-datepicker3.css");
//Application scripts
require("expose-loader?Layout!./../Views/Shared/_Layout.ts");
require("expose-loader?Users!./../Views/Users/Users.ts");
//Application style
require("./Css/style.scss");
