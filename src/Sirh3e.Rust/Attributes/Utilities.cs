namespace Sirh3e.Rust.Attributes;

internal static class Utilities
{
    internal const AttributeTargets AttributeTargets = System.AttributeTargets.Class
                                                       | System.AttributeTargets.Struct
                                                       | System.AttributeTargets.Interface
                                                       | System.AttributeTargets.Method
                                                       | System.AttributeTargets.Property;
}