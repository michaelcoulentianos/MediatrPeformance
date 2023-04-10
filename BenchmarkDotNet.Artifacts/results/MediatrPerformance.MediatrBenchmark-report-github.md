``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1413/22H2/2022Update/SunValley2)
Unknown processor
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|  Method |      Mean |    Error |    StdDev |   Gen0 | Allocated |
|-------- |----------:|---------:|----------:|-------:|----------:|
| Mediatr | 217.72 ns | 9.671 ns | 27.902 ns | 0.0648 |     408 B |
|  Direct |  29.92 ns | 0.601 ns |  0.590 ns | 0.0344 |     216 B |
