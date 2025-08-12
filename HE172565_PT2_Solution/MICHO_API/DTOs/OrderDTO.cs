using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MICHO_data.DTOs
{
    public  class OrderDTO
    {
        public int CustomerID { get; set; }
        public int EmpID { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
