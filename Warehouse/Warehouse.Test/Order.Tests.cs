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

    [TestClass]
    public class Order_Exceptions_Tests
    {
        #region Constructor_Exceptions
        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(InvalidProductNameException))]
        public void Order_Constructor_Throws_Exception_On_Invalid_Name(string name)
        {                    
            var r = new Random();
            var o = new Order(name, r.Next(1, int.MaxValue));
        }

        [DataTestMethod]
        [DataRow("MyProduct", 0)]
        [DataRow("MyProduct", -1)]
        [DataRow("MyProduct", -10)]
        [DataRow("MyProduct", -100)]
        [DataRow("MyProduct", -1000)]
        [ExpectedException(typeof(InvalidProductAmountException))]
        public void Order_Constructor_Throws_Exception_On_Invalid_Amount(string name, int amount)
        {                  
            var o = new Order(name, amount);
        }
        #endregion

        #region Order_Already_Filled_Exception
        [DataTestMethod]
        [DataRow("MyProduct", 1, 1)]
        [DataRow("MyProduct", 10, 9)]
        [DataRow("MyProduct", 100, 10)]
        [DataRow("MyProduct", 1000, 100)]
        [ExpectedException(typeof(OrderAlreadyFilledException))]
        public void Order_Throws_Exception_On_Already_Filled_Order(string name, int number, int amountToTake)
        {

            var o = new Order(name, number);
            var w = new WarehouseImplementation();
            w.AddStock(name, number);
            o.Fill(w);
            o.Fill(w);
        }
        #endregion
        
        #region Order_Rethrows_Exceptions_Of_TakeStock
        [DataTestMethod]
        [DataRow("NonExistingProduct1", 1)]
        [DataRow("NonExistingProduct2", 2)]
        [DataRow("NonExistingProduct3", 3)]
        [ExpectedException(typeof(NoSuchProductException))]
        public void Order_Rethrows_Exception_Of_TakeStock_On_NonexistingProduct(string name, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock("Product1", 1);
            w.AddStock("Product2", 2);
            w.AddStock("Product3", 3);
            var o = new Order(name, amount);
            o.Fill(w);
        }

        [DataTestMethod]
        [DataRow("Product1", 1)]
        [DataRow("Product2", 2)]
        [DataRow("Product3", 3)]
        [ExpectedException(typeof(InsufficientStockException))]
        public void Order_Rethrows_Exceptions_Of_TakeStock_On_InsufficientStockException(string name, int amount)
        {
            var w = new WarehouseImplementation();
            w.AddStock(name, amount);
            var o = new Order(name, amount + 1);
            o.Fill(w);
        }
        #endregion        
        
        #region Null_Reference_Exception
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Order_CanFillOrder_Method_Throws_NullReferenceException_On_Null_IWarehouse()
        {
            var o = new Order("Product", 1);
            o.CanFillOrder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Order_Fill_Method_Throws_NullReferenceException_On_Null_IWarehouse()
        {
            var o = new Order("Product", 1);
            o.Fill(null);
        }
        #endregion
    }

    [TestClass]
    public class Order_Mock_Tests
    {
        [DataTestMethod]
        [DataRow("Product1", 1)]
        [DataRow("Product2", 2)]
        [DataRow("Product3", 3)]
        
        
        public void Order_Correctly_Calls_IWarehouse_When_Inside_CanFillOrder_Method_For_An_Order_That_Can_Be_Filled(string name, int amount)
        {
            var mock = new Mock<IWarehouse>();            
            mock.Setup(IWarehouse => IWarehouse.HasProduct(name)).Returns(true);
            mock.Setup(IWarehouse => IWarehouse.CurrentStock(name)).Returns(10);

            IWarehouse mockhause = mock.Object;                        
            var order = new Order(name, amount);

            Assert.AreEqual(true, order.CanFillOrder(mockhause));
            mock.Verify(cal => cal.HasProduct(name), Times.Once);
            mock.Verify(cal => cal.CurrentStock(name), Times.Once);
        }

        [DataTestMethod]
        [DataRow("Product1", 1, 10)]
        [DataRow("Product2", 2, 20)]
        [DataRow("Product3", 3, 30)]
        
        
        public void Order_Correctly_Calls_IWarehouse_When_Inside_CanFillOrder_Method_For_An_Order_That_Can_Not_Be_Filled(string name, int amount, int amountToTake)
        {
            var mock = new Mock<IWarehouse>();            
            mock.Setup(IWarehouse => IWarehouse.HasProduct(name)).Returns(true);
            mock.Setup(IWarehouse => IWarehouse.CurrentStock(name)).Returns(amount);

            IWarehouse mockhause = mock.Object;                        
            var order = new Order(name, amountToTake);

            Assert.AreEqual(false, order.CanFillOrder(mockhause));
            mock.Verify(cal => cal.HasProduct(name), Times.Once);
            mock.Verify(cal => cal.CurrentStock(name), Times.Once);
        }

        [DataTestMethod]
        [DataRow("Product1", 1)]
        [DataRow("Product1", 2)]
        [DataRow("Product1", 3)]
        public void Order_Correctly_Calls_IWarehouse_When_Inside_Fill_Method(string name, int amount)
        {
            var mock = new Mock<IWarehouse>();
            var order = new Order(name, amount);
            IWarehouse mockhause = mock.Object;            

            order.Fill(mockhause);
            Assert.AreEqual(true, order.IsFilled());
            mock.Verify(cal => cal.TakeStock(name, amount), Times.Once);
        }
    }
}