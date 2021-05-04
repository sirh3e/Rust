#if !NET2_0_OR_GREATER
namespace System
{
    public interface ICloneable
    {
        object Clone();
    }
} 
#endif