using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A fragment for requesting properties of a <see cref="FuelTank"/> returned by the platform.
/// </summary>
[PublicAPI]
public class FuelTankFragment : GraphQlFragment<FuelTankFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FuelTankFragment"/> class.
    /// </summary>
    public FuelTankFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.Name"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithName(bool isIncluded = true)
    {
        return WithField("name", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.TankId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithTankId(bool isIncluded = true)
    {
        return WithField("tankId", isIncluded);
    }
}