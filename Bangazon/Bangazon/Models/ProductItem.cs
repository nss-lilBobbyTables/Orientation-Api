using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Bangazon.Models
{
    public class ProductItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int InStock { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

    }
}