using System;

namespace FactorySupporter.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IdentifierAttribute : Attribute
    {
    }
}
