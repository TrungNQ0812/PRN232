using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MICHO_data.DTOs
{
    public class InvoiceDTO
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal Total { get; set; }
    }
}
