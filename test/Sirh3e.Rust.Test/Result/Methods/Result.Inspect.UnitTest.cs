namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    [Theory]
    [InlineData(4)]
    [InlineData(42)]
    [InlineData(69)]
    [InlineData(100)]
    [InlineData(125639)]
    public void Result_Inspect_Ok(int number)
    {
        var buffer = new byte[4096];

        using var stream = new MemoryStream(buffer);
        using var writer = new StreamWriter(stream);

        void Print(int number)
        {
            writer.Write($"{number}");
            writer.Flush();
        }

        Result<int, string> result = Ok(number);

        result.IsErr.Should().BeFalse();
        result.IsOk.Should().BeTrue();

        result.Inspect(Print);

        Encoding.Default.GetBytes($"{number}").Should().BeEquivalentTo(buffer[..(int)writer.BaseStream.Position]);

        writer.Close();
        stream.Close();
    }

    [Theory]
    [InlineData("marvin")]
    [InlineData("michi")]
    public void Result_Inspect_Err(string name)
    {
        var buffer = new byte[4096];

        using var stream = new MemoryStream(buffer);
        using var writer = new StreamWriter(stream);

        void Print(int number)
        {
            writer.Write($"{number}");
            writer.Flush();
        }

        Result<int, string> result = Err(name);

        result.IsErr.Should().BeTrue();
        result.IsOk.Should().BeFalse();

        result.Inspect(Print);

        Encoding.Default.GetBytes(string.Empty).Should().BeEquivalentTo(buffer[..(int)writer.BaseStream.Position]);

        writer.Close();
        stream.Close();
    }
}