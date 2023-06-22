using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface used to add an extension method for setting <c>idempotencyKey</c> parameter.
/// </summary>
/// <typeparam name="THolder">The type of the parameter setter. Must implement this interface.</typeparam>
/// <seealso cref="HasIdempotencyKeyExtension"/>
[PublicAPI]
public interface IHasIdempotencyKey<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasIdempotencyKey<THolder>
{
}

/// <summary>
/// Contains extension method for setting <c>idempotencyKey</c> parameter on classes implementing
/// <see cref="IHasIdempotencyKey{T}"/>.
/// </summary>
/// <seealso cref="IHasIdempotencyKey{T}"/>
[PublicAPI]
public static class HasIdempotencyKeyExtension
{
    /// <summary>
    /// Sets the idempotency key to set. It is recommended to use a UUID for this.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="idempotencyKey">The idempotency key.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    /// <remarks>
    /// The platform may default the key if not set.
    /// </remarks>
    public static THolder SetIdempotencyKey<THolder>(this THolder caller, string? idempotencyKey)
        where THolder : IHasIdempotencyKey<THolder>
    {
        return caller.SetParameter("idempotencyKey", idempotencyKey);
    }
}