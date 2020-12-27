using System;

namespace Sirh3e.Rust.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class Unstable : Attribute
    {
        public readonly string Feature;
        public readonly ulong Issue;

        public Unstable(string feature, ulong issue)
        {
            Feature = feature ?? throw new ArgumentNullException(nameof(feature));
            Issue = issue;
        }
    }
}