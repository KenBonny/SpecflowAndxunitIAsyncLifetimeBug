using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace SpecflowAndXunit.IAsyncLifetimeBugReproduction;

public class RegularCalculatorTests : Setup
{
    public RegularCalculatorTests(ITestOutputHelper output) : base(output)
     {
     }

    [Fact]
    public void TestAddingTwoNumbers()
    {
        var result = new Calculator().Add(5, 6);
        Assert.Equal(11, result);
        Output.WriteLine($"Result = {result}");
    }
}

public abstract class Setup : IAsyncLifetime
{
    protected readonly ITestOutputHelper Output;

    protected Setup(ITestOutputHelper output) => Output = output;

    // [BeforeScenario]
    public Task InitializeAsync()
    {
        Output.WriteLine("Write before each test");
        return Task.CompletedTask;
    }

    // [AfterScenario]
    public Task DisposeAsync()
    {
        Output.WriteLine("Write after each test");
        return Task.CompletedTask;
    }
}
