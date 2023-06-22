using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for complex GraphQL parameters.
/// </summary>
[PublicAPI]
public interface IGraphQlParameter : IGraphQlCompilable, IGraphQlParameterHolder
{
}

/// <summary>
/// Interface for setting inner parameters for complex GraphQL parameters.
/// </summary>
/// <typeparam name="T">The parameter type. Must implement this interface.</typeparam>
[PublicAPI]
public interface IGraphQlParameter<out T> : IGraphQlParameter, IGraphQlParameterHolder<T>
    where T : IGraphQlParameter<T>
{
}