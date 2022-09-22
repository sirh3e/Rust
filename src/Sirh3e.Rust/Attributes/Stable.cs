namespace Sirh3e.Rust.Attributes;

[AttributeUsage(Utilities.AttributeTargets)]
internal class Stable : Attribute
{
    public readonly string Feature;
    public readonly string Since;

    public Stable(string feature, string since)
    {
        Feature = feature ?? throw new ArgumentNullException(nameof(feature));
        Since = since ?? throw new ArgumentNullException(nameof(since));
    }
}