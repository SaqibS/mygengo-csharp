namespace MyGengo
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class MyGengoException : Exception
    {
        public MyGengoException()
            : base()
        {
        }

        public MyGengoException(string message)
            : base(message)
        {
        }

        public MyGengoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected MyGengoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
