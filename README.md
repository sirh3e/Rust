# Sirh3e.Rust

![GitHub](https://img.shields.io/github/license/sirh3e/Rust)
![Nuget](https://img.shields.io/nuget/v/Sirh3e.Rust)
![Nuget](https://img.shields.io/nuget/dt/Sirh3e.Rust)

Sirh3e.Rust is a library that provide missing features in C# where are fundamental in the [Rust Programming Language](https://github.com/rust-lang/rust) like Option and Result.

See [features](#features) for all available methods.

## Status

| Type            | Service       | Status                                                                                                                                                       |
|-----------------|---------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| .NET Core Build | Github Action | ![.NET Core](https://github.com/sirh3e/Rust/workflows/.NET%20Core%20Build/badge.svg)                                                                         |
| .NET Core Test  | Github Action | ![.NET Core](https://github.com/sirh3e/Rust/workflows/.NET%20Core%20Test/badge.svg)                                                                          |
| .NET Format     | Github Action | ![.NET Format](https://github.com/sirh3e/Rust/workflows/.NET%20Format/badge.svg)                                                                             |
| Maintainability | CODE CLIMATE  | [![Maintainability](https://api.codeclimate.com/v1/badges/7eb0b456887eeedaad92/maintainability)](https://codeclimate.com/github/sirh3e/Rust/maintainability) |
| Test Coverage   | CODE CLIMATE  | [![Test Coverage](https://api.codeclimate.com/v1/badges/7eb0b456887eeedaad92/test_coverage)](https://codeclimate.com/github/sirh3e/Rust/test_coverage)       |
| Code Quality    | CodeFactor    | [![CodeFactor](https://www.codefactor.io/repository/github/sirh3e/rust/badge)](https://www.codefactor.io/repository/github/sirh3e/rust)                      |

## License

[BSD-3-Clause](https://github.com/sirh3e/Rust/blob/features/LICENSE.txt)

## Nuget

```cmd
dotnet add package Sirh3e.Rust --version 1.0.0-preview-0004
```

## Features

Legend:

- ✅ Implemented no bugs/🐛 known.
- ❌ Not implemented and will not be to implement do to C# language boundaries.
- 😐 Rust concept that is not required in C#.
- 🚧 Currently under construction will raise NotImplementedException.

1. Option
    - Methods:
    - ✅ And
    - ✅ AndThen
    - 😐 AsDeref
    - 😐 AsDerefMut
    - 😐 AsPinMut
    - 😐 AsPinRef
    - 😐 AsRef
    - ✅ Cloned
    - ✅ Contains
    - 😐 Copied
    - ✅ Expect
    - ✅ ExpectFailed
    - ✅ ExpectNone
    - ✅ ExpectNoneFailed
    - ✅ Filter
    - ✅ Flatten
    - 🚧 GetOrInsert
    - 🚧 GetOrInsertWith
    - 🚧 Insert
    - ✅ IsNone
    - ✅ IsSome
    - ✅ Iter
    - ❌ IterMut
    - ✅ Map
    - ✅ MapOr
    - ✅ MapOrElse
    - ✅ OkOr
    - ✅ OkOrElse
    - ✅ Or
    - ✅ OrElse
    - ✅ Replace
    - 🚧 Take
    - ✅ Transpose
    - ✅ Unwrap
    - ✅ UnwrapNone
    - ✅ UnwrapOr
    - ✅ UnwrapOrDefault
    - ✅ UnwrapOrElse
    - ✅ Xor
    - ✅ Zip
    - ✅ ZipWith
2. Result
    - Methods:
    - ✅ And
    - ✅ AndThen
    - 😐 AsDeref
    - 😐 AsDerefMut
    - 😐 AsMut
    - 😐 AsRef
    - ✅ Cloned
    - ✅ Contains
    - ✅ ContainsErr
    - 😐 Copied
    - ✅ Err
    - ✅ Expect
    - ✅ ExpectErr
    - ✅ Flatten
    - ✅ IntoOk
    - ✅ IsErr
    - ✅ IsOk
    - ✅ Iter
    - ❌ IterMut
    - ✅ Map
    - ✅ MapErr
    - ✅ MapOr
    - ✅ MapOrElse
    - ✅ Ok
    - ✅ Or
    - ✅ OrElse
    - ✅ Transpose
    - ✅ Unwrap
    - ✅ UnwrapErr
    - ✅ UnwrapOr
    - ✅ UnwrapOrDefault
    - ✅ UnwrapOrElse

## Becoming Active in Sirh3e.Rust development

New contributors are always welcome and I am happy to provide guidance if necessary.

## Semantic Versioning

Sirh3e.Rust project strictly adhere to a [semantic](https://semver.org/) versioning scheme.
