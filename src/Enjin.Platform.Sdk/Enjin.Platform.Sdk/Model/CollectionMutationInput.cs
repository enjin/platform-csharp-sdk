using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters that can be mutated for a collection.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<CollectionMutationInput>))]
[PublicAPI]
public class CollectionMutationInput : GraphQlParameter<CollectionMutationInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionMutationInput"/> class.
    /// </summary>
    public CollectionMutationInput()
    {
    }

    /// <summary>
    /// Sets the new owner account of the collection.
    /// </summary>
    /// <param name="owner">The owner account.</param>
    /// <returns>This parameter for chaining.</returns>
    public CollectionMutationInput SetOwner(string? owner)
    {
        return SetParameter("owner", owner);
    }

    /// <summary>
    /// Sets the new royalty for the collection.
    /// </summary>
    /// <param name="royalty">The new royalty.</param>
    /// <returns>This parameter for chaining.</returns>
    public CollectionMutationInput SetRoyalty(MutateRoyaltyInput? royalty)
    {
        return SetParameter("royalty", royalty);
    }

    /// <summary>
    /// Sets the explicit royalty currencies for the collection.
    /// </summary>
    /// <param name="explicitRoyaltyCurrencies">The explicit royalty currencies.</param>
    /// <returns>This parameter for chaining.</returns>
    public CollectionMutationInput SetExplicitRoyaltyCurrencies(params MultiTokenIdInput[]? explicitRoyaltyCurrencies)
    {
        return SetParameter("explicitRoyaltyCurrencies", explicitRoyaltyCurrencies);
    }
}