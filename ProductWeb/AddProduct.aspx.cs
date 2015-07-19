using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ProductWeb.BusinessLogic;
using ProductWeb.Entities;
using ProductWeb.Abstract;
using System.Web.Script.Serialization;
using System.Web.Services;
using ProductWeb.Messages;
using System.IO;
namespace ProductWeb
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["product"] != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Product product = serializer.Deserialize<Product>(Request.Params["product"]);//convert json string into .net objects
                if (Request.Params["CategoryId"] != null)
                {
                    product.Category.CategoryId = Convert.ToInt32(Request.Params["CategoryId"]);
                }
                
                if (Request.Params["action"] != null && Request.Params["action"] == "save")
                {
                                    
                    SaveProduct(product);
                }

            }
            //Not using Web Method
            //if (Request.Params["action"] != null && Request.Params["action"] == "get")
            //{
            //    //GetProducts();
            //    BindDataTable(PageIndex);

            //}
            if (Request.Params["product"] != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Product product = serializer.Deserialize<Product>(Request.Params["product"]);
                try
                {
                    if (Request.Params["CategoryId"] != null)
                    {
                        product.Category.CategoryId = Convert.ToInt32(Request.Params["CategoryId"]);
                    }
                }
                catch (InvalidCastException ex)
                {

                    throw new InvalidCastException("Category cannot be null", ex);
                
                }
                if (Request.Params["action"] != null && Request.Params["action"] == "update")
                {

                    UpdateProducts(product);
                }
            }
            if (Request.Params["Id"] != null)
            {

                if (Request.Params["action"] != null && Request.Params["action"] == "delete")
                {
                    
                    int Id = Convert.ToInt32(Request.Params["Id"]);
                    DeleteProducts(Id);

                }
            }
            
            foreach(string file in Request.Files)
            {
                Category category = new Category();
                
                    if (Request.Form["txtCategoryName"] != "")
                    {
                        category.CategoryName = Convert.ToString(Request.Form["txtCategoryName"]);
                    }
                
                
                if (Request.Form["ValueHiddenField"] != null)
                {
                    string Category = Request.Form["ValueHiddenField"];
                    category.ParentId = Convert.ToInt32(Category);
                }
               
                if (Request.Files[file] != null)
                {
                    HttpPostedFile postedfile = Request.Files[file];
                    string fileName = Path.GetFileName(postedfile.FileName);
                    string path = Path.Combine(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["filepath"].ToString()), fileName);
                    //string filetype = postedfile.ContentType;
                    //int fileSize = postedfile.ContentLength;
                    //if (filetype != "image/gif" && filetype != "image/jpeg" && filetype != "image/png")
                    //{
                    //    System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Can upload only images')</SCRIPT>");

                    //}              
                    //else
                    //{
                    //    if (fileSize > 2097152)
                    //    {
                    //        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Upload file less than 2mb')</SCRIPT>");

                    //    }
                    //    else
                    //    {
                    postedfile.SaveAs(path);
                    category.ImageName = fileName;
                }
                        IProductManager productManager = ProductFactory.GetProductManager();
                        
                        
                        int result = productManager.InsertCategory(category);
                       // Response.Clear();
                       
                        if (result > 0)
                        {
                            //Response.Write("Successfully Inserted");
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);

                        }
                        else
                        {
                            Response.Write("Error while inserting data");
                        }
                        //Response.End();
                        
                   // }
               // }
            }
        }
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    Product product = new Product();            
        //    IProductManager productManager = ProductFactory.GetProductManager();
        //    product.Name = Convert.ToString(txtName.Text);
        //    product.Description = Convert.ToString(txtDesc.Text);
        //    product.Price = Convert.ToDecimal(txtPrice.Text);
        //    product.Status = Convert.ToString(ddlStatus.SelectedValue);

        //    int result = productManager.InsertProduct(product);
        //    if (result > 0)
        //    {
        //        lblMsg.Text = "Success";

        //    }
        //    else
        //    {
        //        lblMsg.Text = "No success";
        //    }
        //}

        //private void SaveProduct(string Name, string Description, string Price, string Status)
        private void SaveProduct(Product product)
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            //Product product = new Product();
            //product.Name = Convert.ToString(Name);
            //product.Description = Convert.ToString(Description);
            //product.Price = Convert.ToDecimal(Price);
            //product.Status = Convert.ToString(Status);
            //int result = productManager.InsertProduct(product);
            int result = productManager.InsertProduct(product);
            Response.Clear();
            //Response.ContentType = "application/json";
            if (result > 0)
            {
                Response.Write("Successfully Inserted");

            }
            else
            {
                Response.Write("Error while inserting data");
            }
            Response.End();
        }

        //private List<Product> GetProducts()
        //{
        //    IProductManager productManager = ProductFactory.GetProductManager();
        //    Product product = new Product();
        //    List<Product> products = productManager.GetProducts();

        //    return products;

        //}

        [WebMethod]
        public static ProductSearchResponse BindDataTable(int PageIndex)
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            //HttpContext context = HttpContext.Current;use this in web method for Response.Write
            return productManager.GetProducts(PageIndex);
        }

        [WebMethod]
        public static CategorySearchResponse BindCategoryDataToDropDown()
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            return productManager.GetCategories();
        }
        [WebMethod]
        public static CategorySearchResponse BindSubCategoryDataToDropDown()
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            return productManager.GetSubCategories();
        }
        private void UpdateProducts(Product product)
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            int result = productManager.UpdateProducts(product);
            Response.Clear();
            if (result > 0)
            {
                Response.Write("Successfully Updated");

            }
            else
            {
                Response.Write("Error while updating");
            }
            Response.End();

        }
        //[WebMethod]
        //public static void DeleteProducts(int Id)
        //{
        //    IProductManager productManager = ProductFactory.GetProductManager();
        //    productManager.DeleteProducts(Id);

        //}

        private void DeleteProducts(int Id)
        {
            IProductManager productManager = ProductFactory.GetProductManager();
            int result = productManager.DeleteProducts(Id);
            Response.Clear();
            if (result > 0)
            {
                Response.Write("Successfully Deleted");

            }
            else
            {
                Response.Write("Error while deleting");
            }
            Response.End();
        }


        //Not using Web Method
        //private ProductSearchResponse BindDataTable(int PageIndex)
        //{
        //     IProductManager productManager = ProductFactory.GetProductManager();
        //     Product product = new Product();
        //     return productManager.GetProducts(PageIndex);

        //}
        //private void SaveSubCategory(Category category)
        //{
        //    IProductManager productManager = ProductFactory.GetProductManager();           
        //    int result = productManager.InsertProduct(category);
        //    Response.Clear();
            
        //    if (result > 0)
        //    {
        //        Response.Write("Successfully Inserted");

        //    }
        //    else
        //    {
        //        Response.Write("Error while inserting data");
        //    }
        //    Response.End();
        //}
        public int PageIndex { get; set; }


        public int Id { get; set; }

        
       
    }

}