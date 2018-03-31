using System;

namespace MainDSA.Quizes
{
    public class InfinityException : Exception
    {
        public InfinityException() :
            base("Max value is infinity!")
        {
        }
    }
}
