using System;

namespace Warehouse
{
    public class Order
    {
        private bool isFilled;
        public string ProductName { get; private set; }

        public int ProductAmount { get; private set; }
        public Order(string product, int amount)
        {
            this.isFilled = false;                
        }

        public bool IsFilled()
        {
            throw new NotImplementedException();
        }

        public bool CanFillOrder(IWarehouse warehouse)
        {
            throw new NotImplementedException();
        }

        public void Fill(IWarehouse warehouse)
        {
            throw new NotImplementedException();
        }
        
    }

}