using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace SpecflowAndXunit.IAsyncLifetimeBugReproduction;

[Binding]
public class Example : Setup
{
    private int _first;
    private int _second;
    private int _result;

    public Example(ITestOutputHelper output) : base(output)
    {
    }

    [Given(@"the first number is (.*)")]
    public void GivenTheFirstNumberIs(int first) => _first = first;

    [Given(@"the second number is (.*)")]
    public void GivenTheSecondNumberIs(int p0) => _second = p0;

    [When(@"the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _result = new Calculator().Add(_first, _second);
        Output.WriteLine($"Result = {_result}");
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int expected) => Assert.Equal(expected, _result);
}