using FactorySupporter.Attributes;
using FactorySupporter.Delegates;
using System;
using System.Reflection;

namespace FactorySupporter.Facades
{
    internal interface ITypeIdentifier
    {
        Type GetInstantiationType<TAttribute>(IdentifierFunc<TAttribute> strategySupportFunc, Assembly assembly)
            where TAttribute : IdentifierAttribute;
    }
}
