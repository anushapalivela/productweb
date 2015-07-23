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

        //private static List<Product> _products;

        //[HttpPost]
        public void PostProduct(Product product)
        {
            // Product product = new Product();
            //if (_products == null)
            //{
            //    _products = new List<Product>();
            //}
            IProductManager productManager = ProductFactory.GetProductManager();

            product.Id = productManager.InsertProduct(product);

        }

        [HttpGet]
        [ActionName("GetAllProducts")]
        public ProductSearchResponse GetAllProducts()
        {

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
            IProductManager productManager = ProductFactory.GetProductManager();
            productManager.DeleteProducts(productId);

        }

    }
}