using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWeb.Entities
{
    public class Product
    {
        public Product()
        { 
             this.Category = new Category();
        }
      
        public string Name { get; set; }
        public string Description { get; set; }   
        public decimal Price { get; set; }    
        public string Status { get; set; }   
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}