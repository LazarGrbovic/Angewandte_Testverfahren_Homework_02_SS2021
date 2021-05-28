using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warehouse.Test
{
    [TestClass]
    public class Warehouse_Exceptions_Tests
    {
        #region InvalidProductNameException        
        [DataTestMethod]
        [DataRow("", 1)]
        [DataRow(null, 1)]
        [ExpectedException(typeof(InvalidProductNameException))]
        public void Warehouse_Add_Method_Throws_Exception_On_Invalid_Name(string name, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock(name, amount);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(InvalidProductNameException))]
        public void Warehouse_CurrentStock_Method_Throws_Exception_On_Invalid_Name(string name)
        {
            var w = new WarehouseImplementation();
            w.CurrentStock(name);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(InvalidProductNameException))]
        public void Warehouse_HasProduct_Method_Throws_Exception_On_Invalid_Name(string name)
        {
            var w = new WarehouseImplementation();
            w.HasProduct(name);
        }

        [DataTestMethod]
        [DataRow("", 1)]
        [DataRow(null, 1)]
        [ExpectedException(typeof(InvalidProductNameException))]
        public void Warehouse_TakeStock_Method_Throws_Exception_On_Invalid_Name(string name, int amount)
        {
            var w = new WarehouseImplementation();
            w.TakeStock(name, amount);
        }
        #endregion
        
        #region InvalidProductAmountException
        [DataTestMethod]
        [DataRow("Product", 0)]
        [DataRow("Product", -1)]
        [DataRow("Product", -10)]
        [DataRow("Product", -100)]
        [DataRow("Product", -1000)]
        [ExpectedException(typeof(InvalidProductAmountException))]
        public void Warehouse_Add_Method_Throws_Exception_On_Invalid_Amount(string name, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock(name, amount);
        }
            
        [DataTestMethod]
        [DataRow("Product", 0)]
        [DataRow("Product", -1)]
        [DataRow("Product", -10)]
        [DataRow("Product", -100)]
        [DataRow("Product", -1000)]
        [ExpectedException(typeof(InvalidProductAmountException))]
        public void Warehouse_TakeStock_Method_Throws_Exception_On_Invalid_Amount(string name, int amount)
        {
            var w = new WarehouseImplementation();
            w.TakeStock(name, amount);
        }
        #endregion
    }

    [TestClass]
    public class Warehouse_Functionality_Tests
    {
        #region AddStock_Method
        public void Warehouse_AddStock_Method_Test(string productName, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock("SomeProduct1", 1);
            w.AddStock("SomeProduct2", 2);
            w.AddStock("SomeProduct3", 3);            
            w.AddStock(productName, amount);
            Assert.AreEqual(true, w.HasProduct(productName)); 
        }        
        #endregion

        #region CurrentStock_Method
        [DataTestMethod]
        [DataRow("TestProduct1", 1)]
        [DataRow("TestProduct2", 2)]
        [DataRow("TestProduct3", 3)]
        public void Warehouse_CurrentStock_Method_Test(string productName, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock("SomeProduct1", 1);
            w.AddStock("SomeProduct2", 2);
            w.AddStock("SomeProduct3", 3);
            w.AddStock(productName, amount);
            Assert.AreEqual(amount, w.CurrentStock(productName));
        }
        #endregion CurrentStock_Method

        #region HasStock_Method
        [DataTestMethod]
        [DataRow("TestProduct1", 1)]
        [DataRow("TestProduct2", 2)]
        [DataRow("TestProduct3", 3)]
        public void Warehouse_HasStock_Method_Test(string productName, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock("SomeProduct1", 1);
            w.AddStock("SomeProduct2", 2);
            w.AddStock("SomeProduct3", 3);
            w.AddStock(productName, amount);
            Assert.AreEqual(true, w.HasProduct(productName));
        }
        #endregion HasStock_Method

        #region TakeStock_Method
        [DataTestMethod]
        [DataRow("TestProduct1", 10, 1)]
        [DataRow("TestProduct2", 20, 10)]
        [DataRow("TestProduct3", 30, 20)]
        public void Warehouse_TakeStock_Method_Takes_Successfully_Given_Amount_Test(string productName, int amount, int amountToTake)
        {
            var w = new WarehouseImplementation();
            w.AddStock("SomeProduct1", 1);
            w.AddStock("SomeProduct2", 2);
            w.AddStock("SomeProduct3", 3);
            w.AddStock(productName, amount);
            w.TakeStock(productName, amountToTake);
            Assert.AreEqual(amount - amountToTake, w.CurrentStock(productName));
        }

        [DataTestMethod]
        [DataRow("TestProduct1", 10)]
        [DataRow("TestProduct2", 20)]
        [DataRow("TestProduct3", 30)]
        public void Warehouse_TakeStock_Method_Removes_Product_When_It_Is_Sold_Out_Test(string productName, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock("SomeProduct1", 1);
            w.AddStock("SomeProduct2", 2);
            w.AddStock("SomeProduct3", 3);
            w.AddStock(productName, amount);
            w.TakeStock(productName, amount);
            Assert.AreEqual(false, w.HasProduct(productName));            
        }
        #endregion TakeStock_Method
    }
}
