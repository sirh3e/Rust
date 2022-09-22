namespace Sirh3e.Rust.Attributes;

[AttributeUsage(Utilities.AttributeTargets)]
internal class Docs : Attribute
{
    public readonly string Url;

    public Docs(string url)
    {
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}