using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface used to add an extension method for setting <c>signingAccount</c> parameter.
/// </summary>
/// <typeparam name="THolder">The type of the parameter setter. Must implement this interface.</typeparam>
/// <seealso cref="HasSigningAccountExtension"/>
[PublicAPI]
public interface IHasSigningAccount<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasSigningAccount<THolder>
{
}

/// <summary>
/// Contains extension method for setting <c>signingAccount</c> parameter on classes implementing
/// <see cref="IHasSigningAccount{T}"/>.
/// </summary>
/// <seealso cref="IHasSigningAccount{T}"/>
[PublicAPI]
public static class HasSigningAccountExtension
{
    /// <summary>
    /// ...
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="account">The signing account address or public key.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    /// <remarks>
    /// The platform will use the daemon account if not set.
    /// </remarks>
    public static THolder SetSigningAccount<THolder>(this THolder caller, string? account)
        where THolder : IHasSigningAccount<THolder>
    {
        return caller.SetParameter("signingAccount", account);
    }
}