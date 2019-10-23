using System;

namespace FactorySupporter.Exceptions.ConcreteExceptions
{
    class MissingStrategyIdentifierFuncException : StrategySupportException
    {
        public MissingStrategyIdentifierFuncException(Exception innerException)
                : base(string.Format("The passed StrategyIdentifierFunc is null.\n\n", innerException.Message), innerException)
        {
        }
    }
}
