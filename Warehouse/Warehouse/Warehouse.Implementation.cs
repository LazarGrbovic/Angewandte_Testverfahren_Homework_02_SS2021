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
            Validations.ValidateProductName(product);
            Validations.ValidateProductAmount(amount);         
            foreach (var p in this.products) if (p.ProductName == product) { p.IncreaseAmount(amount); return; }
            this.products.Add(new ProductInfo(product, amount));
        }

        public int CurrentStock(string product)
        {
            Validations.ValidateProductName(product);
            if (!this.HasProduct(product)) throw new NoSuchProductException();
            foreach (var p in this.products) { if (p.ProductName == product) return p.Amount; }
            throw new NoSuchProductException(); // Had to be thrown, as otherwise the Compiler complains (since this method must return an Integer)
        }

        public bool HasProduct(string product)
        {
            Validations.ValidateProductName(product);
            foreach(var p in this.products) { if (p.ProductName == product) return true; }
            return false;
        }

        public void TakeStock(string product, int amount)
        {
            Validations.ValidateProductName(product); 
            Validations.ValidateProductAmount(amount);
            if (!this.HasProduct(product)) throw new NoSuchProductException();           
            foreach (var p in products) if (p.ProductName == product) { PerformTakeStockOperation(p, amount); break;}
        }

        private void PerformTakeStockOperation(ProductInfo product, int amountToTake)
        {
            if (product == null) throw new NoSuchProductException();
            if (product.Amount - amountToTake < 0) throw new InsufficientStockException();

            if (product.Amount - amountToTake == 0) this.HandleAllProductsSold(product);
            else product.DecreaseAmount(amountToTake);            
        }

        private void HandleAllProductsSold(ProductInfo product) => this.products.Remove(product);              
        
        private class ProductInfo
        {
            public int Amount { get; private set; }
            public string ProductName { get; private set; }

            public ProductInfo (string productName, int amount)
            {
                this.ProductName = productName;
                this.Amount = amount;
            }

            public void IncreaseAmount(int amount) { this.Amount += amount; }
            public void DecreaseAmount(int amount) { this.Amount -= amount; } 
        }
    }
}