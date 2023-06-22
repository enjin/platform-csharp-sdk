using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request for querying a fuel tank.
/// </summary>
/// <seealso cref="FuelTank"/>
[PublicAPI]
public class GetFuelTank : GraphQlRequest<GetFuelTank, FuelTankFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetFuelTank"/> class.
    /// </summary>
    public GetFuelTank() : base("GetFuelTank", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the fuel tank name.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>This request for chaining.</returns>
    public GetFuelTank SetName(string? name)
    {
        return SetVariable("name", CoreTypes.String, name);
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public GetFuelTank SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }
}