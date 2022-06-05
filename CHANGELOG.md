# 1.0.0-preview-0006
   
    Added support for net7.0

    Changes:
        Changed Sirh3e.Rust.Attributes from public -> internal

    Option:
        - [#12](https://github.com/sirh3e/Rust/issues/12) GetOrInsertDefault
        - [#13](https://github.com/sirh3e/Rust/issues/13) Inspect
        - [#14](https://github.com/sirh3e/Rust/issues/14) IsSomeAnd / IsSomeWith
        - [#15](https://github.com/sirh3e/Rust/issues/15) UnwrapUnchecked
        - [#16](https://github.com/sirh3e/Rust/issues/16) Unzip

    Result:
        - [#17](https://github.com/sirh3e/Rust/issues/17) Inspect
        - [#18](https://github.com/sirh3e/Rust/issues/18) InspectErr
        - [#19](https://github.com/sirh3e/Rust/issues/19) IntoOkOrErr
        - [#20](https://github.com/sirh3e/Rust/issues/20) IsErrAnd / IsErrWith
        - [#21](https://github.com/sirh3e/Rust/issues/21) IsOkAnd / IsOkWith
        - [#22](https://github.com/sirh3e/Rust/issues/22) UnwrapErrUnchecked
        - [#23](https://github.com/sirh3e/Rust/issues/23) UnwrapUnchecked

# 1.0.0-preview-0005
   
    Added support for Async on Option.Map* and Result.Map*

    Result:
        - MapAsync
        - MapOrAsync
        - MapOrElseAsync
        - MatchAsync
    Option:
        - MapAsync
        - MapErrAsync
        - MapOrAsync
        - MapOrElseAsync
        - MatchAsync

```csharp
//Example 01
    var doubleAsync = (int number) => Task.FromResult(number * 2);
    var ok = Result<int, string>.Ok(1);
    var result = await ok.MapAsync(doubleAsync);
```
# 1.0.0-preview-0004
   
    Added support for net6.0
    Added Ok and Err on Result see more on Example 01

```csharp
//Example 01
        Result<int, string> x = Ok(-3);
        Result<int, string> x = Err("Some error message");
```
# 1.0.0-preview-0003

    Added support for net45 netstandard1.1 netstandard1.3 netstandard1.6 netstandard2.0 netstandard2.1 net5.0
