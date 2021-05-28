using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace Warehouse.Test
{
    [TestClass]
    public class Order_Functionality_Tests
    {
        [DataTestMethod]
        [DataRow("Product", 1)]
        [DataRow("Product", 2)]
        [DataRow("Product", 3)]
        public void Order_IsFilled_Method_Returns_False_After_Creation(string name, int amount)
        {
            var o = new Order(name, amount);
            Assert.AreEqual(false, o.IsFilled());
        }

        [DataTestMethod]
        [DataRow("MyProduct", 1, 1)]
        [DataRow("MyProduct", 10, 9)]
        [DataRow("MyProduct", 100, 10)]
        [DataRow("MyProduct", 1000, 100)]
        public void Order_IsFilled_Method_Returns_True_After_A_Successful_Order(string name, int amount, int amountToTake)
        {
            var w = new WarehouseImplementation();
            var o = new Order(name, amount);
            w.AddStock(name, amount);
            o.Fill(w);
            Assert.AreEqual(true, o.IsFilled());
        }
    }
}