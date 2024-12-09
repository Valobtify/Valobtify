using Resulver;

namespace Valobtify;


/// <summary>
/// Defines an interface for value objects that can be created from a single value.
/// </summary>
/// <typeparam name="TValueObject">The type of the value object that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of the value that the value object encapsulates. This type must be non-nullable.</typeparam>

public interface ICreatableValueObject<TValueObject, in TValue>
    where TValueObject : ICreatableValueObject<TValueObject, TValue>
    where TValue : notnull
{
    /// <summary>
    /// Creates a new instance of the value object from the specified value.
    /// </summary>
    /// <param name="value">The value to be encapsulated in the value object.</param>
    /// <returns>A result indicating the success or failure of creating the value object.</returns>
    public static abstract Result<TValueObject> Create(TValue value);
}