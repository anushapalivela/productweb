using ProductWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWeb.Messages
{
    public class ProductSearchResponse
    {
        public List<Product> ProductList { get; set; }
        public int Count { get; set; }

        public ProductSearchResponse()
        {
            ProductList = new List<Product>();
        }
    }
}