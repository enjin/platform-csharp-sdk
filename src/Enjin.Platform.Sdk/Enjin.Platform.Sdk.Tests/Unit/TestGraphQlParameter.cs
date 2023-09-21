namespace Enjin.Platform.Sdk.Tests;

public sealed class TestGraphQlParameter : GraphQlParameter<TestGraphQlParameter>
{
    public TestGraphQlParameter Set<T>(string name, T? amount)
    {
        return SetParameter(name, amount);
    }
}