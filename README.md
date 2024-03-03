# Pipas

Pipas is a implementation of Pipe Operators (`|>`) from Functional Programming into a C# Extension. 

```cs
var add = (int a, int b) => a + b;
var square = (int a) => a * a;

var result = 5
  .Pipa(add, 5)
  .Pipa(square)
  ;

result.Should().Be(100);
```

## Install

```sh
dotnet add package {package}
```
