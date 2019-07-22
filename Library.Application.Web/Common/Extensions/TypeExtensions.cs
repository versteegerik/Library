using System;
using System.Linq;
using System.Reflection;

namespace Library.Application.Web.Common.Extensions
{
    public static class TypeExtensions
    {
        internal static Type[] GetTypesInNamespace(this Assembly assembly, string nameSpace) => assembly.GetTypes()
                  .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                  .ToArray();
    }
}
