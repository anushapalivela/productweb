using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Caching;

namespace ProductWeb.Connection
{
    public class SQLHelper
    {
        static string constr = ConfigurationManager.ConnectionStrings["dbConnectionString"].ToString();
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\USERS\GEETHAJI\DOCUMENTS\VISUAL STUDIO 2012\PROJECTS\PRODUCTWEB\PRODUCTWEB\APP_DATA\CATALOG.MDF;Integrated Security=True");      
        public static void executeInsertquery(String query, SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(constr);
            try
            {
                cmd.Connection = conn;              
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                //int NoOfRowsInserted=cmd.ExecuteNonQuery();Using Output Parameter Identity

            }

            catch (SqlException e)
            {
               Console.Write("Error-Connection.executeInsertQuery-Query:" + query + "\n Exeception: \n" + e.StackTrace.ToString());
                

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        public static int executeUpdatequery(String query, SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(constr);
            int NoOfRowsUpdated = 0;
            try
            {
                cmd.Connection = conn;              
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                NoOfRowsUpdated= cmd.ExecuteNonQuery();

            }

            catch (SqlException e)
            {
                Console.Write("Error-Connection.executeUpdateQuery-Query:" + query + "\n Exeception: \n" + e.StackTrace.ToString());

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return NoOfRowsUpdated;
        }
        public static DataSet executeSelectquery(String query, SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                //if (HttpContext.Current.Cache["data"] == null)
                //{
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;                  
                    adapter.Fill(ds);
                    //HttpContext.Current.Cache["data"] = ds;
                //}
                //else
                //{
                //    ds = (DataSet)HttpContext.Current.Cache["data"];
                //}
            }           
            catch (SqlException e)
            {
                Console.Write("Error-Connection.executeSelectQuery-Query:" + query + "\n Exeception: \n" + e.StackTrace.ToString());

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ds; 
        }
        public static int executeDeletequery(String query, SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(constr);
            int NoOfRowsDeleted=0;
            try
            {
                cmd.Connection = conn;
                cmd.Connection.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                NoOfRowsDeleted = cmd.ExecuteNonQuery();
               
            }
            catch (SqlException e)
            {
                Console.Write("Error-Connection.executeDeleteQuery-Query:" + query + "\n Exeception: \n" + e.StackTrace.ToString());

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
             return NoOfRowsDeleted;         
        }
    }
}