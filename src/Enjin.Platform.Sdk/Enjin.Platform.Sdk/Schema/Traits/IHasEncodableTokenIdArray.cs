using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface used to add an extension method for setting encodable <c>tokenIds</c> parameter.
/// </summary>
/// <typeparam name="THolder">The type of the parameter setter. Must implement this interface.</typeparam>
/// <seealso cref="HasEncodableTokenIdArrayExtension"/>
[PublicAPI]
public interface IHasEncodableTokenIdArray<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasEncodableTokenIdArray<THolder>
{
}

/// <summary>
/// Contains extension method for setting encodable <c>tokenIds</c> parameter on classes implementing
/// <see cref="IHasEncodableTokenIdArray{T}"/>.
/// </summary>
/// <seealso cref="IHasEncodableTokenIdArray{T}"/>
[PublicAPI]
public static class HasEncodableTokenIdArrayExtension
{
    /// <summary>
    /// Sets the token IDs.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="tokenIds">The token IDs.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetTokenIds<THolder>(this THolder caller, params EncodableTokenIdInput[]? tokenIds)
        where THolder : IHasEncodableTokenIdArray<THolder>
    {
        return caller.SetParameter("tokenIds", tokenIds);
    }
}