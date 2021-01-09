# Sirh3e.Rust

![GitHub](https://img.shields.io/github/license/sirh3e/Rust)![Nuget](https://img.shields.io/nuget/v/Sirh3e.Rust)![Nuget](https://img.shields.io/nuget/dt/Sirh3e.Rust)

Sirh3e.Rust is a library that provide missing features in C# where are fundamental in the [Rust Programming Language](https://github.com/rust-lang/rust).

See [features](#features) for all available methods.

## Status

| Type            | Service       | Status                                                                                                                                                       |
|-----------------|---------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| .NET Core       | Github Action | ![.NET Core](https://github.com/sirh3e/Rust/workflows/.NET%20Core/badge.svg)                                                                                 |
| .NET Format     | Github Action | ![.NET Format](https://github.com/sirh3e/Rust/workflows/.NET%20Format/badge.svg)                                                                             |
| Maintainability | CODE CLIMATE  | [![Maintainability](https://api.codeclimate.com/v1/badges/7eb0b456887eeedaad92/maintainability)](https://codeclimate.com/github/sirh3e/Rust/maintainability) |
| Test Coverage   | CODE CLIMATE  | [![Test Coverage](https://api.codeclimate.com/v1/badges/7eb0b456887eeedaad92/test_coverage)](https://codeclimate.com/github/sirh3e/Rust/test_coverage)       |
| Code Quality    | CodeFactor    | [![CodeFactor](https://www.codefactor.io/repository/github/sirh3e/rust/badge)](https://www.codefactor.io/repository/github/sirh3e/rust)                      |

## License

[BSD-3-Clause](https://github.com/sirh3e/Rust/LICENSE.txt)

## Nuget

```cmd
dotnet add package Sirh3e.Rust --version 1.0.0-preview-0002
```

## Features

1. Option
    - Methods:
    - ✅ And
    - ✅ AndThen
    - ✅ Cloned
    - ✅ Contains
    - ✅ Expect
    - ✅ ExpectFailed
    - ✅ ExpectNone
    - ✅ ExpectNoneFailed
    - ✅ Filter
    - ✅ Flatten
    - ❌ GetOrInsert
    - ❌ GetOrInsertWith
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
    - ✅ Take
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
    - ✅ Cloned
    - ✅ Contains
    - ✅ ContainsErr
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
