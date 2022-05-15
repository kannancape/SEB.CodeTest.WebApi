using System;
using System.Reflection;
using System.Composition;
using SimpleInjector.Advanced;
using System.Linq;

namespace CodeTest.Infrastructure.Bootstrap
{
    internal class ImportPropertySelectionBehavior : IPropertySelectionBehavior

    {
        public bool SelectProperty(Type type, PropertyInfo prop)
        {
            return prop.GetCustomAttributes(typeof(ImportAttribute)).Any();
        }
    }
}

