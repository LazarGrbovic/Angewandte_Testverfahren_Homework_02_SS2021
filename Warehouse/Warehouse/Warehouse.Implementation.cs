using System;

namespace Warehouse
{
    public class WarehouseImplementation : IWarehouse
    {
        public void AddStock(string product, int amount)
        {
            this.ValidateProductName(product);
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
        }

        private void ValidateProductName(string name) { if (string.IsNullOrEmpty(name)) throw new InvalidProductNameException(); }        
    }
}