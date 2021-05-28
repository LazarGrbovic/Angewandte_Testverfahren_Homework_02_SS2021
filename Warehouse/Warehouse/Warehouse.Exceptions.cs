using System;

namespace Warehouse
{
    public class InvalidProductNameException : Exception 
    {
        public override string Message { get { return "Invalid Product Name"; }}        
    }    
}