using System;

namespace FactorySupporter.Exceptions.ConcreteExceptions
{
    public class MissingExecutingAssemblyException : StrategySupportException
    {
        public MissingExecutingAssemblyException(Exception innerException)
        : base(string.Format("The implementation's contaning Assembly reference was null. " +
              "At first please assing an Assembly reference for the ExecutingAssembly property.\n\n", innerException.Message), innerException)
        {
        }
    }
}
