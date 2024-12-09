using System.Reflection;

namespace Valobtify;

/// <summary>
/// Provides extension methods for working with types that inherit from `SingleValueObject` 
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Retrieves the types that inherit from `SingleValueObject` from an assembly.
    /// </summary>
    /// <param name="assembly">The assembly in which types are being checked.</param>
    /// <returns>A collection of types that inherit from `SingleValueObject`.</returns>
    public static IEnumerable<Type> GetSingleValueObjectTypes(this Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(type => type.IsSingleValueObject());
    }
    
    /// <summary>
    /// Checks if a given type inherits from `SingleValueObject` or not.
    /// </summary>
    /// <param name="type">The type to be checked.</param>
    /// <returns>Returns `true` if the type inherits from `SingleValueObject`, otherwise `false`.</returns>
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