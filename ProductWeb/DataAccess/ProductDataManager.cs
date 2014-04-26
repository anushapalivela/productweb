using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProductWeb.Connection;
using ProductWeb.Entities;
namespace ProductWeb.DataAccess
{
    public class ProductDataManager
    {
        public int InsertProduct(string Name,string Desc,decimal Price,string Status,int CategoryId)
        {
            
            string query = "InsertProducts";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Desc;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;
            cmd.Parameters.Add("@CategoryId", SqlDbType.NVarChar).Value = CategoryId;
            SqlParameter outparam = new SqlParameter("@Identity", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outparam);
            //cmd.Parameters.Add("@StatementType",SqlDbType.NVarChar).Value="Insert";
            SQLHelper.executeInsertquery(query,cmd);
            return Convert.ToInt32(outparam.Value);           
        }
        public DataSet GetProducts(int PageIndex)
        {
            string query = "SelectProducts";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("PageIndex", SqlDbType.Int).Value = PageIndex;            
            //cmd.Parameters.Add("@StatementType", SqlDbType.NVarChar).Value = "Select";
            return SQLHelper.executeSelectquery(query, cmd);
        }
        public int UpdateProducts(int Id,string Name, string Desc, decimal Price, string Status,int CategoryId)
        {
            string query = "UpdateProducts";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Desc;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;
            cmd.Parameters.Add("@CategoryId", SqlDbType.NVarChar).Value = CategoryId;
            return SQLHelper.executeUpdatequery(query, cmd);

        }
        public int DeleteProducts(int Id)
        {
            string query = "DeleteProducts";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            return SQLHelper.executeDeletequery(query, cmd);
            
        }
        public int InsertCategory(string Name, string ImageName,int ParentId)
        {
            string query = "InsertCategory";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@ImageName", SqlDbType.NVarChar).Value = ImageName;
            cmd.Parameters.Add("@ParentId", SqlDbType.Int).Value = ParentId;         
            SqlParameter outparam = new SqlParameter("@CategoryId", SqlDbType.Int);
            outparam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outparam);
            SQLHelper.executeInsertquery(query, cmd);
            return Convert.ToInt32(outparam.Value);           
        }
        public DataSet GetCategories()
        {
            string query = "SelectCategories";
            SqlCommand cmd = new SqlCommand();
            return SQLHelper.executeSelectquery(query, cmd);
        }

    }
}