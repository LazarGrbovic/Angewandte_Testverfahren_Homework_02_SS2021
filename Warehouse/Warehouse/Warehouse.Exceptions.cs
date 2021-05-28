using System;

namespace Warehouse
{
    public class InvalidProductNameException : Exception 
    {
        public override string Message { get { return "Invalid Product Name"; }}        
    }    

    public class InvalidProductAmountException : Exception
    {
        public override string Message { get { return "Invalid Product Amount"; }}
    }

    public class NoSuchProductException : Exception
    {
        public override string Message { get { return "No Such Product Exists"; }}
    }

    public class InsufficientStockException : Exception
    {
        public override string Message { get {return "Insufficient Stock for the Product"; }}
    }
}