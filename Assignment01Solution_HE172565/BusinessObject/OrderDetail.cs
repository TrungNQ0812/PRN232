﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice {  get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        //Navigation
        [JsonIgnore]
        public Order Order { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }

}
