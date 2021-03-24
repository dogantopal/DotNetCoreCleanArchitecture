using System.Collections.Generic;

namespace WebUI.Models
{
    public class JqueryDatatableResultModel<T>
    {
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
