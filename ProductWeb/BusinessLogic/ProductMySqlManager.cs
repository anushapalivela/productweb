using ProductWeb.Abstract;
using ProductWeb.Entities;
using ProductWeb.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWeb.BusinessLogic
{
    public class ProductMySqlManager : IProductManager
    {
        public int InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public ProductSearchResponse GetProducts(int PageIndex)
        {
            throw new NotImplementedException();
        }
        public int UpdateProducts(Entities.Product product)
        {
            throw new NotImplementedException();
        }
        public int DeleteProducts(int Id)
        {
            throw new NotImplementedException();
        }
        public int InsertCategory(Category category)
        {
            throw new NotImplementedException();
        }
        public CategorySearchResponse GetCategories()
        {
            throw new NotImplementedException();
        }
        public CategorySearchResponse GetSubCategories()
        {
            throw new NotImplementedException();
        }
    }
}