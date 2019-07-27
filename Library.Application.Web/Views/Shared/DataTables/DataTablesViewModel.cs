using System.Collections.Generic;
using System.Linq;

// ReSharper disable InconsistentNaming
namespace FeedbackApp.Web.Views.Shared.DataTables
{
    public sealed class DataTablesViewModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public List<Order> order { get; set; }
        public Search search { get; set; }

        public Order SingleOrder => order.SingleOrDefault();
        public int SingleOrderColumn => SingleOrder?.column ?? -1;
        public string SingleOrderDirection => SingleOrder?.dir ?? "asc";
    }

    public sealed class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public sealed class Order
    {
        public int column { get; set; }
        public string dir { get; set; }

        public bool IsAscending => dir == "asc";
    }

    public sealed class Search
    {
        public string value { get; set; }
        public bool regex { get; set; }
    }
}
