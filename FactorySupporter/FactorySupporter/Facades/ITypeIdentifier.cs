using FactorySupporter.Attributes;
using FactorySupporter.Delegates;
using System;
using System.Reflection;

namespace FactorySupporter.Facades
{
    internal interface ITypeIdentifier
    {
        Type GetInstantiationType<TAttribute>(StrategyIdentifierFunc<TAttribute> strategySupportFunc, Assembly assembly)
            where TAttribute : StrategyIdentifier;
    }
}
