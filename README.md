[![NuGet Package](https://img.shields.io/nuget/v/Valobtify)](https://www.nuget.org/packages/Valobtify/)

### Table of content
- [Table of content](#table-of-content)
- [Usage](#usage)
- [Single-Value Objects](#single-value-objects)
  - [Using Data Annotation](#using-data-annotation)

### Usage 
```csharp

public class Price : ValueObject
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public override IEnumerable<object?> GetAtomicValues()
    {
        return [Amount, Currency];
    }
}

```


### Single-Value Objects
```csharp
public class UserName : SingleValueObject<string>
{
    public UserName(string value)
    {
        if (value.Length > 20)
            throw new Exception("Name is not valid!");

        Value = value;
    }
}
```

#### Using Data Annotation
```csharp
public class UserName : SingleValueObject<string>
{
    [MaxLength(20)]
    public override required string Value { get; init; }
}
```


