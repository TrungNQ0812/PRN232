﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //Navigation
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }

    }
}
