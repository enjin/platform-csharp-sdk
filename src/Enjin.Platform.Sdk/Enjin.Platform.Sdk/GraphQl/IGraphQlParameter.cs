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
/// <typeparam name="TParameter">The parameter type. Must implement this interface.</typeparam>
[PublicAPI]
public interface IGraphQlParameter<out TParameter> : IGraphQlParameter, IGraphQlParameterHolder<TParameter>
    where TParameter : IGraphQlParameter<TParameter>
{
}