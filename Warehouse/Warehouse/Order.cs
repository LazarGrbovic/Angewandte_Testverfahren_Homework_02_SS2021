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
            this.ValidateProductName(product);
            this.ValidateProductAmount(amount);
            this.ProductName = product;
            this.ProductAmount = amount;
            this.isFilled = false;                
        }

        public bool IsFilled()
        {
            return this.isFilled;
        }

        public bool CanFillOrder(IWarehouse warehouse)
        {
            throw new NotImplementedException();
        }

        public void Fill(IWarehouse warehouse)
        {
            throw new NotImplementedException();
        }        

        private void ValidateProductName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new InvalidProductNameException();
        }

        private void ValidateProductAmount(int amount)
        {
            if (amount < 1) throw new InvalidProductAmountException();
        }
    }

    

}