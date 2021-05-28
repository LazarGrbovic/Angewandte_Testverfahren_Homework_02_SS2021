using System;
using System.Collections.Generic;

namespace Warehouse
{
    public class WarehouseImplementation : IWarehouse
    {
        private List<ProductInfo> products;

        public WarehouseImplementation ()
        {
            this.products = new List<ProductInfo>();
        }
        public void AddStock(string product, int amount)
        {
            this.ValidateProductName(product);
            this.ValidateProductAmount(amount);
        }

        public int CurrentStock(string product)
        {
            this.ValidateProductName(product);
            throw new NotImplementedException();
        }

        public bool HasProduct(string product)
        {
            this.ValidateProductName(product);
            throw new NotImplementedException();
        }

        public void TakeStock(string product, int amount)
        {
            this.ValidateProductName(product); 
            this.ValidateProductAmount(amount);           
        }

        private void ValidateProductName(string name) { if (string.IsNullOrEmpty(name)) throw new InvalidProductNameException(); }        

        private void ValidateProductAmount(int amount) { if (amount < 1) throw new InvalidProductAmountException(); }

        private class ProductInfo
        {
            public int Amount { get; set; }
            public string ProductName { get; set; }

            public ProductInfo (string productName, int amount)
            {
                this.ProductName = productName;
                this.Amount = amount;
            }
        }
    }
}