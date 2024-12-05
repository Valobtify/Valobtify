using System.Reflection;

namespace Valobtify;

public static class Extensions
{
    public static IEnumerable<Type> GetSingleValueObjectTypes(this Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(type => type.IsSingleValueObject());
    }

    public static bool IsSingleValueObject(this Type type)
    {
        var baseType = typeof(SingleValueObject<,>);

        return type is
               {
                   IsClass: true,
                   IsAbstract: false,
                   BaseType.IsGenericType: true
               } &&
               type.BaseType.GetGenericTypeDefinition() == baseType;
    }
}