namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    [Fact]
    public async Task Option_MatchAsync_Action_From_TSome_Action_Some()
    {
        var state = 0;

        var increasse = (string name) => { state++; };
        var decreasse = () => { state--; };

        var some = Some("Marvin");

        state.Should().Be(0);
        await some.MatchAsync(increasse, decreasse);
        state.Should().Be(1);
    }

    [Fact]
    public async Task Option_MatchAsync_Action_From_TSome_Action_None()
    {
        var state = 0;

        var increasse = (string name) => { state++; };
        var decreasse = () => { state--; };

        var none = Option<string>.None;

        state.Should().Be(0);
        await none.MatchAsync(increasse, decreasse);
        state.Should().Be(-1);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_Action_Some()
    {
        var state = 0;

        var increasse = (string name) => { state++; return Task.CompletedTask; };
        var decreasse = () => { state--; };

        var some = Some("String");

        state.Should().Be(0);
        await some.MatchAsync(increasse, decreasse);
        state.Should().Be(1);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_Action_None()
    {
        var state = 0;

        var increasse = (string name) => { state++; return Task.CompletedTask; };
        var decreasse = () => { state--; };

        Option<string> some = None.Value;

        state.Should().Be(0);
        await some.MatchAsync(increasse, decreasse);
        state.Should().Be(-1);
    }

    [Fact]
    public async Task Option_MatchAsync_Action_From_TSome_Func_To_Task_Some()
    {
        var state = 0;

        var increasse = (string name) => { state++; };
        var decreasse = () => { state--; return Task.CompletedTask; };

        var some = Some("String");

        state.Should().Be(0);
        await some.MatchAsync(increasse, decreasse);
        state.Should().Be(1);
    }

    [Fact]
    public async Task Option_MatchAsync_Action_From_TSome_Func_To_Task_None()
    {
        var state = 0;

        var increasse = (string name) => { state++; };
        var decreasse = () => { state--; return Task.CompletedTask; };

        Option<string> some = None.Value;

        state.Should().Be(0);
        await some.MatchAsync(increasse, decreasse);
        state.Should().Be(-1);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_Func_To_Task_Some()
    {
        var increasse = (string name) => Task.FromResult(name.Length);
        var decreasse = () => 0;

        var some = Some("String");

        var length = await some.MatchAsync(increasse, decreasse);

        length.Should().Be(6);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_Func_To_Task_None()
    {
        var state = 0;

        var increasse = (string name) => { state++; return Task.CompletedTask; };
        var decreasse = () => { state--; return Task.CompletedTask; };

        var none = Option<string>.None;

        state.Should().Be(0);
        await none.MatchAsync(increasse, decreasse);
        state.Should().Be(-1);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_T_Func_To_T_Some()
    {
        var increasse = (string name) => Task.FromResult(name.Length);
        var decreasse = () => 0;

        var some = Some("String");

        var length = await some.MatchAsync(increasse, decreasse);

        length.Should().Be(6);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_T_Func_To_T_None()
    {
        var increasse = (string name) => Task.FromResult(name.Length);
        var decreasse = () => 0;

        Option<string> some = None.Value;

        var length = await some.MatchAsync(increasse, decreasse);

        length.Should().Be(0);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_T_Func_To_Task_T_Some()
    {
        var increasse = (string name) => name.Length;
        var decreasse = () => Task.FromResult(0);

        var some = Some("String");

        var length = await some.MatchAsync(increasse, decreasse);

        length.Should().Be(6);
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_T_Func_To_Task_T_None()
    {
        var increasse = (string name) => name.Length;
        var decreasse = () => Task.FromResult(0);

        Option<string> none = None.Value;

        var length = await none.MatchAsync(increasse, decreasse);

        length.Should().Be(6);
    }
   
    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_T_Func_To_Task_T_Some()
    {
        var increasse = (string name) => Task.FromResult(name.Length);
        var decreasse = () => Task.FromResult(0);

        var some = Some("String");

        var length = await some.MatchAsync(increasse, decreasse);

        length.Should().Be(6); 
    }

    [Fact]
    public async Task Option_MatchAsync_Func_From_TSome_To_Task_T_Func_To_Task_T_None()
    {
        var increasse = (string name) => Task.FromResult(name.Length);
        var decreasse = () => Task.FromResult(0);

        Option<string> none = None.Value;

        var length = await none.MatchAsync(increasse, decreasse);

        length.Should().Be(0);
    }
}