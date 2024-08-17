namespace Valobtify;

public abstract class SingleValueObject<TValue> : ValueObject
{
    public virtual required TValue Value { get; init; }

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

    public static explicit operator string(SingleValueObject<TValue> value)
    {
        return value.ToString() ?? "";
    }
}
