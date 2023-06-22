using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Static class which contains members representing the name of each Substrate based event on the platform.
/// </summary>
[PublicAPI]
public static class SubstrateEvents
{
    /// <summary>
    /// The name of the event for when an account is created for a <c>Collection</c>.
    /// </summary>
    public const string CollectionAccountCreated = "platform:collection-account-created";

    /// <summary>
    /// The name of the event for when an account is destroyed for a <c>Collection</c>.
    /// </summary>
    public const string CollectionAccountDestroyed = "platform:collection-account-destroyed";

    /// <summary>
    /// The name of the event for when an account is frozen for a <c>Collection</c>.
    /// </summary>
    public const string CollectionAccountFrozen = "platform:collection-account-frozen";

    /// <summary>
    /// The name of the event for when an account is thawed for a <c>Collection</c>.
    /// </summary>
    public const string CollectionAccountThawed = "platform:collection-account-thawed";

    /// <summary>
    /// The name of the event for when a <c>Collection</c> is approved.
    /// </summary>
    public const string CollectionApproved = "platform:collection-approved";

    /// <summary>
    /// The name of the event for when an <c>Attribute</c> is removed from a <c>Collection</c>.
    /// </summary>
    public const string CollectionAttributeRemoved = "platform:collection-attribute-removed";

    /// <summary>
    /// The name of the event for when an <c>Attribute</c> is set for a <c>Collection</c>.
    /// </summary>
    public const string CollectionAttributeSet = "platform:collection-attribute-set";

    /// <summary>
    /// The name of the event for when a <c>Collection</c> is created.
    /// </summary>
    public const string CollectionCreated = "platform:collection-created";

    /// <summary>
    /// The name of the event for when a <c>Collection</c> is destroyed.
    /// </summary>
    public const string CollectionDestroyed = "platform:collection-destroyed";

    /// <summary>
    /// The name of the event for when a <c>Collection</c> is frozen.
    /// </summary>
    public const string CollectionFrozen = "platform:collection-frozen";

    /// <summary>
    /// The name of the event for when a <c>Collection</c> is mutated.
    /// </summary>
    public const string CollectionMutated = "platform:collection-mutated";

    /// <summary>
    /// The name of the event for when a <c>Collection</c> is thawed.
    /// </summary>
    public const string CollectionThawed = "platform:collection-thawed";

    /// <summary>
    /// The name of the event for when a <c>Collection</c> is unapproved.
    /// </summary>
    public const string CollectionUnapproved = "platform:collection-unapproved";

    /// <summary>
    /// The name of the event for when an account is created for a <c>Token</c>.
    /// </summary>
    public const string TokenAccountCreated = "platform:token-account-created";

    /// <summary>
    /// The name of the event for when an account is destroyed for a <c>Token</c>.
    /// </summary>
    public const string TokenAccountDestroyed = "platform:token-account-destroyed";

    /// <summary>
    /// The name of the event for when an account is frozen for a <c>Token</c>.
    /// </summary>
    public const string TokenAccountFrozen = "platform:token-account-frozen";

    /// <summary>
    /// The name of the event for when an account is thawed for a <c>Token</c>.
    /// </summary>
    public const string TokenAccountThawed = "platform:token-account-thawed";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is approved.
    /// </summary>
    public const string TokenApproved = "platform:token-approved";

    /// <summary>
    /// The name of the event for when an <c>Attribute</c> is removed from a <c>Token</c>.
    /// </summary>
    public const string TokenAttributeRemoved = "platform:token-attribute-removed";

    /// <summary>
    /// The name of the event for when an <c>Attribute</c> is set for a <c>Token</c>.
    /// </summary>
    public const string TokenAttributeSet = "platform:token-attribute-set";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is burned.
    /// </summary>
    public const string TokenBurned = "platform:token-burned";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is created.
    /// </summary>
    public const string TokenCreated = "platform:token-created";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is destroyed.
    /// </summary>
    public const string TokenDestroyed = "platform:token-destroyed";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is frozen.
    /// </summary>
    public const string TokenFrozen = "platform:token-frozen";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is minted.
    /// </summary>
    public const string TokenMinted = "platform:token-minted";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is mutated.
    /// </summary>
    public const string TokenMutated = "platform:token-mutated";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is thawed.
    /// </summary>
    public const string TokenThawed = "platform:token-thawed";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is transferred.
    /// </summary>
    public const string TokenTransferred = "platform:token-transferred";

    /// <summary>
    /// The name of the event for when a <c>Token</c> is unapproved.
    /// </summary>
    public const string TokenUnapproved = "platform:token-unapproved";
}