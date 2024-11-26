using Resulver;

namespace Valobtify;

public interface ICreatableValueObject<TValueObject, TValue>
    where TValueObject : ICreatableValueObject<TValueObject, TValue>
{
    public static abstract Result<TValueObject> Create(TValue value);
}