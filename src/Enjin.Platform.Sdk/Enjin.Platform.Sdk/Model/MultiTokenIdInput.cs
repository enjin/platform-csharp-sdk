using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for setting the unique identifier for a token. Composed using a collection ID and a token ID.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<MultiTokenIdInput>))]
[PublicAPI]
public class MultiTokenIdInput : GraphQlParameter<MultiTokenIdInput>,
                                 IHasEncodableTokenId<MultiTokenIdInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MultiTokenIdInput"/> class.
    /// </summary>
    public MultiTokenIdInput()
    {
    }

    /// <summary>
    /// Sets the collection ID of a multi-token.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This parameter for chaining.</returns>
    public MultiTokenIdInput SetCollectionId(BigInteger? collectionId)
    {
        return SetParameter("collectionId", collectionId);
    }
}