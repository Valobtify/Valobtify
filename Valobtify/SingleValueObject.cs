namespace Valobtify;

public abstract class SingleValueObject<TValue, TValuleObject> : ValueObject
    where TValuleObject : SingleValueObject<TValue, TValuleObject>, new()
{
    public virtual TValue? Value { get; init; }

    public static TValuleObject Create(TValue value)
    {
        return new TValuleObject { Value = value };
    }

    public override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
    public override string? ToString()
    {
        if (Value is not null)
        {
            return Value.ToString();
        }
        return null;
    }

    public static explicit operator string(SingleValueObject<TValue, TValuleObject> value)
    {
        return value.ToString() ?? "";
    }
}
