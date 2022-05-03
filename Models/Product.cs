﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Contents { get; set; }
        public string Recipe { get; set; }
        public double TotalPrice { get; set; }
        public double TotalCalorie { get; set; }
        public double SellerPrice { get; set; }
    }
}
