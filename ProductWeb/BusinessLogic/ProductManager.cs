using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductWeb.DataAccess;
using ProductWeb.Entities;
using ProductWeb.Abstract;
using System.Data;
using ProductWeb.Messages;

namespace ProductWeb.BusinessLogic
{
    public class ProductManager : IProductManager
    {
        ProductDataManager productDataManager;
        public int InsertProduct(Product product)
        {
           productDataManager = new ProductDataManager();
           return productDataManager.InsertProduct(product.Name, product.Description, product.Price, product.Status, product.Category.CategoryId);
             
        }
        public ProductSearchResponse GetProducts(int PageIndex)
        {
            List<Product> products = new List<Product>();
            productDataManager = new ProductDataManager();
            DataSet ds = productDataManager.GetProducts(PageIndex);
            ProductSearchResponse response = new ProductSearchResponse();
            DataTable dt=new DataTable();
            dt = ds.Tables[0];
            
                if(dt.Rows.Count>0)
                {
                     foreach (DataRow dr in dt.Rows)
                        {
                         Product product = new Product();
                         product.Id = Convert.ToInt32(dr["ProductId"]);
                         product.Name = dr["Name"].ToString();
                         product.Description = dr["Description"].ToString();
                         product.Price = Convert.ToDecimal(dr["Price"]);
                         product.Status = dr["Status"].ToString();
                         product.Category = new Category();
                         product.Category.CategoryName =Convert.ToString(dr["CategoryName"]);
                         if (dr["CategoryId"] != System.DBNull.Value)
                         {
                             product.Category.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                         }
                         products.Add(product);
                        }
                }
               // NoOfRows = dt.Rows.Count;
                response.ProductList = products;
                response.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                return response; 
                
            }
        public ProductSearchResponse GetAllProducts()
        {
            List<Product> products = new List<Product>();
            productDataManager = new ProductDataManager();
            DataSet ds = productDataManager.GetAllProducts();
            ProductSearchResponse response = new ProductSearchResponse();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(dr["Id"]);
                    product.Name = dr["Name"].ToString();
                    product.Description = dr["Description"].ToString();
                    product.Price = Convert.ToDecimal(dr["Price"]);
                    product.Status = dr["Status"].ToString();
                    product.Category = new Category();
                    product.Category.CategoryName = Convert.ToString(dr["CategoryName"]);
                    if (dr["CategoryId"] != System.DBNull.Value)
                    {
                        product.Category.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    }
                    products.Add(product);
                }
            }
            // NoOfRows = dt.Rows.Count;
            response.ProductList = products;
            response.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return response; 
                

           
        
        }
        public int UpdateProducts(Product product)
        {
            productDataManager = new ProductDataManager();
            return productDataManager.UpdateProducts(product.Id,product.Name, product.Description, product.Price, product.Status,product.Category.CategoryId);         
        
        }
        public int DeleteProducts(int Id)
        {
           productDataManager = new ProductDataManager();
           return productDataManager.DeleteProducts(Id);
        
        }
        public int InsertCategory(Category category)
        {
            productDataManager = new ProductDataManager();
            return productDataManager.InsertCategory(category.CategoryName,category.ImageName,category.ParentId);
        
        }
        public CategorySearchResponse GetCategories()
        {
            List<Category> categories = new List<Category>();
            productDataManager = new ProductDataManager();
            DataSet ds = productDataManager.GetCategories();
            CategorySearchResponse response = new CategorySearchResponse();
            DataTable dtCategory=new DataTable();
            dtCategory = ds.Tables[0];
            if (dtCategory.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCategory.Rows)
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    category.CategoryName = dr["CategoryName"].ToString();
                    categories.Add(category);
                }
            }

            response.CategoryList = categories;
            
            return response; 
        
        }
        public CategorySearchResponse GetSubCategories()
        {
            List<Category> categories = new List<Category>();
            productDataManager = new ProductDataManager();
            DataSet ds = productDataManager.GetCategories();
            CategorySearchResponse response = new CategorySearchResponse();
            DataTable dtSubCategory = new DataTable();
            dtSubCategory = ds.Tables[1];
            if (dtSubCategory.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubCategory.Rows)
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    category.CategoryName = dr["CategoryName"].ToString();
                    categories.Add(category);
                }
            }

            response.CategoryList = categories;

            return response;

        }
       
    }

    
}