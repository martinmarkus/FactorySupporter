using FactorySupporter.Attributes;
using FactorySupporter.Delegates;
using System.Reflection;

namespace FactorySupporter
{
    public interface IImplementationFactory
    {
        Assembly ExecutingAssembly { get; set; }

        /// <summary>
        /// Instantiates an implementation determined by the StrategySupportFunc delegate.
        /// </summary>
        /// <typeparam name="TResult">Type of the required implementation's return type.</typeparam>
        /// <typeparam name="TAttribute">Type of the Attribute, which defines the required metadata to determine the returned implementation.</typeparam>
        /// <param name="executingAssembly">Assembly, which contains the implemented Strategy Pattern.</param>
        /// <param name="strategySupportFunc">Delegate, which will be invoked on determining the required implementation.</param>
        /// <exception cref="Exceptions.StrategySupportException"></exception>
        /// <exception cref="Exceptions.ConcreteExceptions.MissingExecutingAssemblyException"></exception>
        /// <exception cref="Exceptions.ConcreteExceptions.MissingStrategyIdentifierFuncException"></exception>
        /// <exception cref="Exceptions.ConcreteExceptions.NotFoundImplementationException"></exception>
        /// <returns></returns>
        TResult Create<TResult, TAttribute>(IdentifierFunc<TAttribute> strategySupportFunc) 
            where TResult : class 
            where TAttribute : IdentifierAttribute;

        /// <summary>
        /// Instantiates an implementation determined by the StrategySupportFunc delegate.
        /// </summary>
        /// <typeparam name="TResult">Type of the required implementation's return type.</typeparam>
        /// <typeparam name="TAttribute">Type of the Attribute, which defines the required metadata to determine the returned implementation.</typeparam>
        /// <param name="executingAssembly">Assembly, which contains the implemented Strategy Pattern.</param>
        /// <param name="strategySupportFunc">Delegate, which will be invoked on determining the required implementation.</param>
        /// <exception cref="Exceptions.StrategySupportException"></exception>
        /// <exception cref="Exceptions.ConcreteExceptions.MissingExecutingAssemblyException"></exception>
        /// <exception cref="Exceptions.ConcreteExceptions.MissingStrategyIdentifierFuncException"></exception>
        /// <exception cref="Exceptions.ConcreteExceptions.NotFoundImplementationException"></exception>
        /// <returns></returns>
        TResult Create<TResult, TAttribute>(Assembly executingAssembly, IdentifierFunc<TAttribute> strategySupportFunc)
            where TResult : class
            where TAttribute : IdentifierAttribute;
    }
}
