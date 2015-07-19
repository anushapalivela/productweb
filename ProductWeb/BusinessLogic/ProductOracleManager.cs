using ProductWeb.Abstract;
using ProductWeb.Messages;
using ProductWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWeb.BusinessLogic
{
    public class ProductOracleManager : IProductManager
    {
        public int InsertProduct(Entities.Product product)
        {
            throw new NotImplementedException();
        }
        public ProductSearchResponse GetProducts(int PageIndex)
        {
            throw new NotImplementedException();
        }
        public ProductSearchResponse GetAllProducts()
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