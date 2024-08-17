### Table of content
- [Getting started](#getting-started)
    - [Installing](#1-Installing-package)
    - [Usage](#2-Usage)
- [Single-Value objects](#Single-Value-objects)


## Getting started
### 1. Installing package
  ```bash
  dotnet add package Valobtify
  ```

  ### 2. Usage
   ```csharp
   public class MyValueObject : ValueObject
   {
      
   }
   ```

### Single-Value objects 
single avlue object is used when your object has only one property

```csharp
public class MyValueObject : SingleValueObject<string>
{
          
}
       
```
