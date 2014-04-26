using ProductWeb.Entities;
using ProductWeb.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWeb.Abstract
{
    public interface IProductManager
    {
       int InsertProduct(Product product);
       ProductSearchResponse GetProducts(int PageIndex);
       int UpdateProducts(Product product);
       int DeleteProducts(int Id);
       int InsertCategory(Category category);
       CategorySearchResponse GetCategories();
       CategorySearchResponse GetSubCategories();
        
    }
    
}
