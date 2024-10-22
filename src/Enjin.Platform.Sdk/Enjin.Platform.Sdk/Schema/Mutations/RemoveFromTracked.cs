using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Stop on-chain data from being tracked. Models that were previously tracked
/// will no longer be updated but will remain in the platform's database.
/// </summary>
[PublicAPI]
public class RemoveFromTracked : GraphQlRequest<RemoveFromTracked>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveFromTracked"/> class.
    /// </summary>
    public RemoveFromTracked() : base("RemoveFromTracked", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the type of models to stop tracking.
    /// </summary>
    /// <param name="modelType">The model type to stop tracking.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveFromTracked SetType(ModelType? modelType)
    {
        return SetVariable("type", CoreTypes.ModelType, modelType);
    }
    
    /// <summary>
    /// Removed models from being tracked.
    /// </summary>
    /// <param name="chainIds">The model chain ids to stop tracking.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveFromTracked SetChainIds(params BigInteger[]? chainIds)
    {
        return SetVariable("chainIds", CoreTypes.BigIntArray, chainIds);
    }
}