using System.IO;
using System.Text;

namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    [Theory]
    [InlineData(4)]
    [InlineData(42)]
    [InlineData(69)]
    [InlineData(100)]
    [InlineData(125639)]
    public void Option_Inspect_Some(int number)
    {
        var buffer = new byte[4096];

        using var stream = new MemoryStream(buffer);
        using var writer = new StreamWriter(stream);

        void Print(int number)
        {
            writer.Write($"{number}");
            writer.Flush();
        }

        var option = Some(number);

        option.IsNone.Should().BeFalse();
        option.IsSome.Should().BeTrue();

        option.Inspect(Print);

        Encoding.Default.GetBytes($"{number}").Should().BeEquivalentTo(buffer[..(int)writer.BaseStream.Position]);

        writer.Close();
        stream.Close();
    }

    [Fact]
    public void Option_Inspect_None()
    {
        var buffer = new byte[4096];

        using var stream = new MemoryStream(buffer);
        using var writer = new StreamWriter(stream);

        void Print(int number)
        {
            writer.Write($"{number}");
            writer.Flush();
        }

        var option = Option<int>.None;

        option.IsNone.Should().BeTrue();
        option.IsSome.Should().BeFalse();

        option.Inspect(Print);

        Encoding.Default.GetBytes(string.Empty).Should().BeEquivalentTo(buffer[..(int)writer.BaseStream.Position]);

        writer.Close();
        stream.Close();
    }
}