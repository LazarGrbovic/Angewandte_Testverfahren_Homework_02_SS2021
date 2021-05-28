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
}
