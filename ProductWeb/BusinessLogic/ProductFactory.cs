using ProductWeb.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWeb.BusinessLogic
{
    public class ProductFactory
    {
        public static IProductManager GetProductManager()
        {
            string managerType = System.Configuration.ConfigurationManager.AppSettings["datamanager"];
            IProductManager productManager = null;
            switch (managerType)
            {
                case "sql":
                    productManager = new ProductSqlManager();
                    break;
                case "oracle":
                    productManager = new ProductOracleManager();
                    break;

            }
            return productManager;
        }
    }
}