using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductWeb.Entities;
using ProductWeb.Abstract;
using ProductWeb.Connection;
using ProductWeb.BusinessLogic;
using ProductWeb.DataAccess;
using ProductWeb.Messages;
namespace ProductMVC.Controllers
{
    public class ProductController : ApiController
    {

        public void PostProduct(Product product)
        {
            //Add Products to database
            
            IProductManager productManager = ProductFactory.GetProductManager();

            product.Id = productManager.InsertProduct(product);

        }

        [HttpGet]
        [ActionName("GetAllProducts")]
        public ProductSearchResponse GetAllProducts()
        {
            //Added attribute level routing 
            IProductManager productManager = ProductFactory.GetProductManager();
            return productManager.GetAllProducts();
        }

        [ActionName("SubCategories")]
        [HttpGet]
        public CategorySearchResponse SubCategories()
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            return productManager.GetSubCategories();

        }
        public void PutProduct(Product product)
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            productManager.UpdateProducts(product);

        }
        public void DeleteProduct(int productId)
        {
            //404 error still working
            IProductManager productManager = ProductFactory.GetProductManager();
            productManager.DeleteProducts(productId);

        }

    }
}