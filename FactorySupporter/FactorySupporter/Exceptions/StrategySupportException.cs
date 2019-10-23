using System;

namespace FactorySupporter.Exceptions
{
    public class StrategySupportException : Exception
    {
        public StrategySupportException(string message) : base(message)
        {
        }

        public StrategySupportException()
            : base(string.Format("The instantiation of the required implementation has failed.\n"))
        {
        }

        public StrategySupportException(string message, Exception innerException)
            : base(string.Format("The instantiation of the required implementation has failed.\n\n{0}", message), innerException)
        {
        }
    }
}
