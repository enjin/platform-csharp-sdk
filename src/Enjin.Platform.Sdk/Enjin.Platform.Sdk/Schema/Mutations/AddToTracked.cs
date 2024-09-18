using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Add on-chain data to track. Use this to limit which collections and tokens are synced
/// and tracked on the platform. If existing data exists on chain it will be imported.
/// </summary>
[PublicAPI]
public class AddToTracked : GraphQlRequest<AddToTracked>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddToTracked"/> class.
    /// </summary>
    public AddToTracked() : base("AddToTracked", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the type of models to track.
    /// </summary>
    /// <param name="modelType">The model type to track.</param>
    /// <returns>This request for chaining.</returns>
    public AddToTracked SetType(ModelType? modelType)
    {
        return SetVariable("type", CoreTypes.ModelType, modelType);
    }
    
    /// <summary>
    /// Adds models to track.
    /// </summary>
    /// <param name="chainIds">The model chain ids to track.</param>
    /// <returns>This request for chaining.</returns>
    public AddToTracked SetChainIds(params BigInteger[]? chainIds)
    {
        return SetVariable("chainIds", CoreTypes.BigIntArray, chainIds);
    }
    
    /// <summary>
    /// Sets whether to sync the newly added models right away.
    /// </summary>
    /// <param name="hotSync">The hoySync flag.</param>
    /// <returns>This request for chaining.</returns>
    public AddToTracked SetChainIds(bool? hotSync)
    {
        return SetVariable("hotSync", CoreTypes.Boolean, hotSync);
    }
}