namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    [Theory]
    [InlineData(4)]
    [InlineData(42)]
    [InlineData(69)]
    [InlineData(100)]
    [InlineData(125639)]
    public void Result_InspectErr_Ok(int number)
    {
        var buffer = new byte[4096];

        using var stream = new MemoryStream(buffer);
        using var writer = new StreamWriter(stream);

        void PrintErr(int number)
        {
            writer.Write($"{number}");
            writer.Flush();
        }

        Result<int, int> result = Ok(number);

        result.IsErr.Should().BeFalse();
        result.IsOk.Should().BeTrue();

        result.InspectErr(PrintErr);

        Encoding.Default.GetBytes(string.Empty).Should().BeEquivalentTo(buffer[..(int)writer.BaseStream.Position]);

        writer.Close();
        stream.Close();
    }

    [Theory]
    [InlineData("marvin")]
    [InlineData("michi")]
    public void Result_InspectErr_Err(string name)
    {
        var buffer = new byte[4096];

        using var stream = new MemoryStream(buffer);
        using var writer = new StreamWriter(stream);

        void PrintErr(string name)
        {
            writer.Write(name);
            writer.Flush();
        }

        Result<int, string> result = Err(name);

        result.IsErr.Should().BeTrue();
        result.IsOk.Should().BeFalse();

        result.InspectErr(PrintErr);

        Encoding.Default.GetBytes(name).Should().BeEquivalentTo(buffer[..(int)writer.BaseStream.Position]);

        writer.Close();
        stream.Close();
    }
}