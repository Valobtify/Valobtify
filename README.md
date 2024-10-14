[![NuGet Package](https://img.shields.io/nuget/v/Valobtify)](https://www.nuget.org/packages/Valobtify/)

### Table of content
- [Installation](#installation)
- [Usage](#usage)
- [Single-Value Objects](#single-value-objects)
  - [Using Data Annotation](#using-data-annotation)
- [Integrate with EF Core](https://github.com/Valobtify/Valobtify.EntityFrameworkCore) 
- [Integrate with ASP.NET Core web api](https://github.com/Valobtify/Valobtify.AspNetCore.WebApi)

### Installation
```shell
dotnet add package Valobtify
```

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

You can validate value before creating single-value object
```csharp
public sealed class Age : SingleValueObject<Age, int>, ICreatableValueObject<Age, int>
{
    private Age(int value) : base(value) { }

    public static Result<Age> Create(int value)
    {
        if (value < 0) return new ResultError("Age is not valid");

        return new Age(value);
    }
}
```

