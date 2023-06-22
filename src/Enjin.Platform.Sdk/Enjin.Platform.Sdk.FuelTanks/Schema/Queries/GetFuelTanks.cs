using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request for querying a fuel tanks.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="FuelTank"/>
[PublicAPI]
public class GetFuelTanks : GraphQlRequest<GetFuelTanks, FuelTankConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetFuelTanks"/> class.
    /// </summary>
    public GetFuelTanks() : base("GetFuelTanks", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the fuel tank names.
    /// </summary>
    /// <param name="names">The names.</param>
    /// <returns>This request for chaining.</returns>
    public GetFuelTanks SetNames(params string[]? names)
    {
        return SetVariable("names", CoreTypes.StringArray, names);
    }

    /// <summary>
    /// Sets the wallet addresses of the fuel tanks.
    /// </summary>
    /// <param name="tankIds">The addresses.</param>
    /// <returns>This request for chaining.</returns>
    public GetFuelTanks SetTankIds(params string[]? tankIds)
    {
        return SetVariable("tankIds", CoreTypes.StringArray, tankIds);
    }
}