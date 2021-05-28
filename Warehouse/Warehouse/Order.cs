using System;

namespace Warehouse
{
    public class Order
    {
        public Order(string product, int amount)
        {

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