using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warehouse.Test
{
    [TestClass]
    public class Warehouse_Exceptions_Tests
    {
        [DataTestMethod]
        [DataRow("", 1)]
        [DataRow(null, 1)]
        [ExpectedException(typeof(InvalidProductNameException))]
        public void Warehouse_Add_Method_Throws_Exception_On_Invalid_Name(string name, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock(name, amount);
        }
    }
}
