namespace FactorySupporter.Exceptions.ConcreteExceptions
{
    public class NotFoundImplementationException : StrategySupportException
    {
        public NotFoundImplementationException()
        : base("The implementation was not found in the passed Assembly. (Maybe the ExecutingAssembly property is not correct?)")
        {
        }
    }
}
