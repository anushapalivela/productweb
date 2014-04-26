using ProductWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWeb.Messages
{
    public class CategorySearchResponse
    {
        public List<Category> CategoryList { get; set; }
        public CategorySearchResponse()
        {
            CategoryList = new List<Category>();
        }
    }
}