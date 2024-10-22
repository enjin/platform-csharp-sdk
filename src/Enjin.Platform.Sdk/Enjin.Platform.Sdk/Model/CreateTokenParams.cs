using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for the parameters to create a token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<CreateTokenParams>))]
[PublicAPI]
public class CreateTokenParams : GraphQlParameter<CreateTokenParams>,
                                 IHasEncodableTokenId<CreateTokenParams>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTokenParams"/> class.
    /// </summary>
    public CreateTokenParams()
    {
    }

    /// <summary>
    /// Sets the initial supply of tokens to mint to the specified recipient. Must not exceed the token cap if set.
    /// </summary>
    /// <param name="initialSupply">The initial supply.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetInitialSupply(BigInteger? initialSupply)
    {
        return SetParameter("initialSupply", initialSupply);
    }
    
    /// <summary>
    /// Sets the number of tokens accounts that can be created before a deposit is required.
    /// </summary>
    /// <param name="accountDepositCount">The account count.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetAccountDepositCount(int? accountDepositCount)
    {
        return SetParameter("accountDepositCount", accountDepositCount);
    }

    /// <summary>
    /// Sets the token cap (if required). A cap of 1 will create this token as a single mint type to produce an NFT.
    /// </summary>
    /// <param name="cap">The token cap setting.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetCap(TokenMintCap? cap)
    {
        return SetParameter("cap", cap);
    }

    /// <summary>
    /// Sets the market behavior for the token.
    /// </summary>
    /// <param name="behavior">The market behavior.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetBehavior(TokenMarketBehaviorInput? behavior)
    {
        return SetParameter("behavior", behavior);
    }

    /// <summary>
    /// Sets whether the token can be listed in the marketplace.
    /// </summary>
    /// <param name="listingForbidden">Whether the token can be listed in the marketplace.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetListingForbidden(bool? listingForbidden)
    {
        return SetParameter("listingForbidden", listingForbidden);
    }
    
    /// <summary>
    /// Sets the freeze state of the token.
    /// </summary>
    /// <param name="freezeState">Whether the token is frozen on create.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetFreezeState(FreezeState? freezeState)
    {
        return SetParameter("freezeState", freezeState);
    }

    /// <summary>
    /// Sets the initial attributes for the token.
    /// </summary>
    /// <param name="attributes">The attributes.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetAttributes(params AttributeInput[] attributes)
    {
        return SetParameter("attributes", attributes);
    }
    
    /// <summary>
    /// Sets the amount of ENJ infused into each token.
    /// </summary>
    /// <param name="infusion">The infusion amount.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetInfusion(BigInteger? infusion)
    {
        return SetParameter("infusion", infusion);
    }
    
    /// <summary>
    /// Sets if anyone can infuse ENJ into this token.
    /// </summary>
    /// <param name="anyoneCanInfuse">The flag value.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetAnyoneCanInfuse(bool? anyoneCanInfuse)
    {
        return SetParameter("anyoneCanInfuse", anyoneCanInfuse);
    }
    
    /// <summary>
    /// Sets the metadata for the token.
    /// </summary>
    /// <param name="metadata">The metadata.</param>
    /// <returns>This parameter for chaining.</returns>
    public CreateTokenParams SetMetadata(TokenMetadataInput? metadata)
    {
        return SetParameter("metadata", metadata);
    }
}