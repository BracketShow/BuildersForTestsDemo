using System;

namespace Banking
{
    public class InsufficientFundException : Exception
    {
        public InsufficientFundException() : base()
        {
        }

        public override string Message
        {
            get
            {
                return Resource.InsufficientFundException;
            }
        }
    } 
}
