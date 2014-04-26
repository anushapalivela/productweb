using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductWeb.BusinessLogic;
using ProductWeb.Abstract;
using ProductWeb.Entities;
using System.Collections.Generic;
using ProductWeb.Messages;

namespace ProductWebTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IProductManager manager =  ProductFactory.GetProductManager();
            int PageIndex = 1;
            ProductSearchResponse products =  manager.GetProducts(PageIndex);
            Assert.IsTrue(products.Count > 0);
        }
    }
}
