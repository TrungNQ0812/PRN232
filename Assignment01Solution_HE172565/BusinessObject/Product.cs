﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }

        //Navigation 
        [JsonIgnore]
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }

}
