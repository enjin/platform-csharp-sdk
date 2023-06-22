using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for setting single use beam codes to expire.
/// </summary>
[PublicAPI]
public class ExpireSingleUseCodes : GraphQlRequest<ExpireSingleUseCodes>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpireSingleUseCodes"/> class.
    /// </summary>
    public ExpireSingleUseCodes() : base("ExpireSingleUseCodes", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the array of single use codes.
    /// </summary>
    /// <param name="codes">The single use codes.</param>
    /// <returns>This request for chaining.</returns>
    public ExpireSingleUseCodes SetCodes(params string[]? codes)
    {
        return SetVariable("codes", CoreTypes.StringArray, codes);
    }
}