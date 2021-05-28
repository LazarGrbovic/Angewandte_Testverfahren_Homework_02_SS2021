using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warehouse.Test
{
    [TestClass]
    public class Warehouse_Exceptions_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidProductNameException))]
        public void Warehouse_Add_Method_Throws_Exception_On_Invalid_Name()
        {
            var w = new WarehouseImplementation();
            w.AddStock("", 1);
        }
    }
}
