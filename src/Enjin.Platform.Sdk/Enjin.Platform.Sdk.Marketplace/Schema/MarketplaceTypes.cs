﻿using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Contains fields describing variable types used in the platform's Marketplace API.
/// </summary>
[PublicAPI]
public static class MarketplaceTypes
{
    // AssetInputType

    /// <summary>
    /// String for <c>AssetInputType</c> type.
    /// </summary>
    public const string AssetInputType = "AssetInputType!";

    /// <summary>
    /// String for an array of <c>AssetInputType</c> type.
    /// </summary>
    public const string AssetInputTypeArray = "[AssetInputType!]!";

    // AuctionDataInputType

    /// <summary>
    /// String for <c>AuctionDataInputType</c> type.
    /// </summary>
    public const string AuctionDataInputType = "AuctionDataInputType!";

    /// <summary>
    /// String for an array of <c>AuctionDataInputType</c> type.
    /// </summary>
    public const string AuctionDataInputTypeArray = "[AuctionDataInputType!]!";

    // ListingStateEnum
    
    /// <summary>
    /// String for <c>ListingStateEnum</c> type.
    /// </summary>
    public const string ListingStateEnum = "ListingStateEnum!";
    
    /// <summary>
    /// String for an array of <c>ListingStateEnum</c> type.
    /// </summary>
    public const string ListingStateEnumArray = "[ListingStateEnum!]!";
    
    // ListingDataInput
    
    /// <summary>
    /// String for <c>ListingDataInput</c> type.
    /// </summary>
    public const string ListingDataInput = "ListingDataInput!";
    
    /// <summary>
    /// String for an array of <c>ListingDataInput</c> type.
    /// </summary>
    public const string ListingDataInputArray = "[ListingDataInput!]!";
}