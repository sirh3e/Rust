using System;

namespace Sirh3e.Rust.Generator.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ResultAttribute<TOk, TErr> : Attribute
{
}