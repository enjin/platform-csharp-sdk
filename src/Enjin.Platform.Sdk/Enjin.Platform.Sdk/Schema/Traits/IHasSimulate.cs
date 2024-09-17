using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface used to add an extension method for setting <c>simulate</c> parameter.
/// </summary>
/// <typeparam name="THolder">The type of the parameter setter. Must implement this interface.</typeparam>
/// <seealso cref="HasSimulateExtension"/>
[PublicAPI]
public interface IHasSimulate<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasSimulate<THolder>
{
}

/// <summary>
/// Contains extension method for setting <c>simulate</c> parameter on classes implementing
/// <see cref="IHasSimulate{T}"/>.
/// </summary>
/// <seealso cref="IHasSimulate{T}"/>
[PublicAPI]
public static class HasSimulateExtension
{
    /// <summary>
    /// Sets whether to simulate the call.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="simulate">Whether to simulate.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetSimulate<THolder>(this THolder caller, bool? simulate)
        where THolder : IHasSimulate<THolder>
    {
        return caller.SetParameter("simulate", simulate);
    }
}