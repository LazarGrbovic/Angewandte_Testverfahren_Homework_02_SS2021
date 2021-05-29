using System;

namespace Warehouse
{
    public static class Validations
    {
        public static void ValidateProductName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new InvalidProductNameException();
        }

        public static void ValidateProductAmount(int amount)
        {
            if (amount < 1) throw new InvalidProductAmountException();
        }
    }
}