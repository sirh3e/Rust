namespace Sirh3e.Rust.Attributes;

[AttributeUsage(Utilities.AttributeTargets)]
internal class Source : Attribute
{
    public readonly string Url;

    public Source(string url)
    {
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}