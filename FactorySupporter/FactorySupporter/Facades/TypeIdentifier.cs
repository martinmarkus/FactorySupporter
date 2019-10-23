using FactorySupporter.Attributes;
using FactorySupporter.Delegates;
using FactorySupporter.Exceptions.ConcreteExceptions;
using System;
using System.Reflection;

namespace FactorySupporter.Facades
{
    internal class TypeIdentifier : ITypeIdentifier
    {
        public Type GetInstantiationType<TAttribute>(StrategyIdentifierFunc<TAttribute> strategySupportFunc, Assembly assembly)
            where TAttribute : StrategyIdentifier
        {
            if (strategySupportFunc == null) throw new MissingStrategyIdentifierFuncException(new NullReferenceException());

            Type initializerType = null;
            Type[] assemblyTypes = GetAssemblyTypes(assembly);

            foreach (Type type in assemblyTypes)
            {
                TAttribute[] attributes = GetAttributes<TAttribute>(type);
                if (attributes == null || attributes.Length <= 0) continue;

                bool isMeetingContidion = IsMeetingConditions(type, strategySupportFunc, attributes);

                if (isMeetingContidion)
                {
                    initializerType = type;
                    break;
                }
            }

            return initializerType;
        }

        private Type[] GetAssemblyTypes(Assembly assembly)
        {
            Type[] types = null;

            try
            {
                types = assembly?.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                Console.WriteLine(e.ToString());
            }

            return types;
        }

        private TAttribute[] GetAttributes<TAttribute>(Type type)
            where TAttribute : Attribute
        {
            TAttribute[] attributes = null;

            try
            {
                attributes = (TAttribute[])type?.GetCustomAttributes(typeof(TAttribute));
            }
            catch (Exception e) when (e is ArgumentNullException || e is ArgumentException
                || e is NotSupportedException || e is TypeLoadException)
            {
                Console.WriteLine(e.ToString());
            }

            return attributes;
        }

        private bool IsMeetingConditions<TAttribute>(Type type, StrategyIdentifierFunc<TAttribute> strategySupportFunc, TAttribute[] attributes)
            where TAttribute : StrategyIdentifier
        {
            bool condition = false;

            foreach (TAttribute attribute in attributes)
            {
                condition = strategySupportFunc.Invoke(attribute);

                if (condition)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
