using FactorySupporter.Attributes;
using FactorySupporter.Delegates;
using FactorySupporter.Exceptions;
using FactorySupporter.Exceptions.ConcreteExceptions;
using FactorySupporter.Facades;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FactorySupporter
{
    public class ImplementationFactory : IImplementationFactory
    {
        public Assembly ExecutingAssembly { get; set; }
        private ITypeIdentifier _typeIdentifier = new TypeIdentifier();

        public ImplementationFactory()
        {
        }

        public ImplementationFactory(Assembly executingAssembly)
        {
            ExecutingAssembly = executingAssembly;
        }

        #region Interface methods
        public TResult Create<TResult, TAttribute>(Assembly executingAssembly, StrategyIdentifierFunc<TAttribute> strategySupportFunc)
            where TResult : class
            where TAttribute : StrategyIdentifier
        {
            TResult result = default(TResult);
            try
            {
                result = ExecuteCreating<TResult, TAttribute>(executingAssembly, strategySupportFunc);
            }
            catch (StrategySupportException e)
            {
                throw e;
            }

            if (result == null) throw new NotFoundImplementationException();

            return result;
        }

        public TResult Create<TResult, TAttribute>(StrategyIdentifierFunc<TAttribute> strategySupportFunc)
            where TResult : class
            where TAttribute : StrategyIdentifier
        {
            TResult result = default(TResult);
            try
            {
                result = ExecuteCreating<TResult, TAttribute>(ExecutingAssembly, strategySupportFunc);
            }
            catch (StrategySupportException e)
            {
                throw e;
            }
          
            if (result == null) throw new NotFoundImplementationException();

            return result;
        }
        #endregion

        private TResult ExecuteCreating<TResult, TAttribute>(Assembly executingAssembly, StrategyIdentifierFunc<TAttribute> strategySupportFunc)
            where TResult : class
            where TAttribute : StrategyIdentifier
        {
            if (executingAssembly == null) throw new MissingExecutingAssemblyException(new NullReferenceException());

            TResult result = default(TResult);

            try
            {
                Type type = _typeIdentifier.GetInstantiationType(strategySupportFunc, executingAssembly);
                result = (TResult)Activator.CreateInstance(type);
            }
            catch (Exception e) when (e is ArgumentException || e is ArgumentNullException
                || e is NotSupportedException || e is TargetInvocationException
                || e is MethodAccessException || e is MemberAccessException
                || e is InvalidComObjectException || e is COMException
                || e is MissingMethodException || e is TypeLoadException)
            {
                Console.WriteLine(e.ToString());
            }
            catch (StrategySupportException e)
            {
                throw e;
            }

            return result;
        }
    }
}
