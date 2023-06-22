using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface used to add an extension method for setting encodable <c>tokenId</c> parameter.
/// </summary>
/// <typeparam name="THolder">The type of the parameter setter. Must implement this interface.</typeparam>
/// <seealso cref="HasEncodableTokenIdExtension"/>
[PublicAPI]
public interface IHasEncodableTokenId<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasEncodableTokenId<THolder>
{
}

/// <summary>
/// Contains extension method for setting encodable <c>tokenId</c> parameter on classes implementing
/// <see cref="IHasEncodableTokenId{T}"/>.
/// </summary>
/// <seealso cref="IHasEncodableTokenId{T}"/>
[PublicAPI]
public static class HasEncodableTokenIdExtension
{
    /// <summary>
    /// Sets the token ID.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="tokenId">The token ID.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetTokenId<THolder>(this THolder caller, EncodableTokenIdInput? tokenId)
        where THolder : IHasEncodableTokenId<THolder>
    {
        return caller.SetParameter("tokenId", tokenId);
    }
}