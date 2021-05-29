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
            Validations.ValidateProductName(product);
            Validations.ValidateProductAmount(amount);
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
            if (warehouse == null) throw new NullReferenceException(nameof(warehouse));

            try
            {
                if (warehouse.HasProduct(this.ProductName))
                {
                    if(warehouse.CurrentStock(this.ProductName) - this.ProductAmount < 0) return false;
                    return true;
                }

                return false;
            }
            catch (System.Exception e)
            {                
                throw e;
            }
        }

        public void Fill(IWarehouse warehouse)
        {
            if (warehouse == null) throw new NullReferenceException(nameof(warehouse));
            if (this.IsFilled()) throw new OrderAlreadyFilledException();

            try
            {
                warehouse.TakeStock(this.ProductName, this.ProductAmount);
                this.isFilled = true;
            }
            catch (System.Exception e)
            {                
                throw e;
            }
        }                
    }
}