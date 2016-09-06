using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebApi452.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
    }
}