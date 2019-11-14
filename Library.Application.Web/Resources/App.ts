//NPM packages
import "bootstrap";
import "expose-loader?$!jquery";
import "jquery-ajax-unobtrusive";
import "jquery-validation";
import "jquery-validation-unobtrusive";
import "bootstrap-select";
import "bootstrap-select/dist/js/i18n/defaults-nl_NL.js";
import "bootstrap-datepicker";
import "bootstrap-datepicker/dist/locales/bootstrap-datepicker.nl.min.js";
import "datatables.net";
import "datatables.net-bs4";
import "datatables.net-select";
import "datatables.net-select-bs4";
import "datatables.net-buttons";
import "datatables.net-buttons-bs4";
import "datatables.net-responsive-bs4";
import "moment";

//NPM packages style
import "bootstrap-datepicker/dist/css/bootstrap-datepicker3.css";
import "datatables.net-bs4/css/dataTables.bootstrap4.css";
import "datatables.net-buttons-bs4/css/buttons.bootstrap4.css";
import "datatables.net-select-bs4/css/select.bootstrap4.css";
import "datatables.net-responsive-bs4/css/responsive.bootstrap4.css";


//Application scripts
import "expose-loader?Layout!./../Views/Shared/Layout/_Layout.ts";
import "expose-loader?Users!./../Views/Users/Users.ts";
import "expose-loader?Books!./../Views/Books/Books.ts";
import "expose-loader?MyBooks!./../Views/MyBooks/MyBooks.ts";

//Application style
require("./Css/style.scss");