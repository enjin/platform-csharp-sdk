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
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.TankId"/> property.
    /// </summary>
    /// <param name="fragment">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithTankId(AccountFragment? fragment)
    {
        return WithField("tankId", fragment);
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
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.ReservesExistentialDeposit"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithReservesExistentialDeposit(bool isIncluded = true)
    {
        return WithField("reservesExistentialDeposit", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.ReservesAccountCreationDeposit"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithReservesAccountCreationDeposit(bool isIncluded = true)
    {
        return WithField("reservesAccountCreationDeposit", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.ProvidesDeposit"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithProvidesDeposit(bool isIncluded = true)
    {
        return WithField("providesDeposit", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.IsFrozen"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithIsFrozen(bool isIncluded = true)
    {
        return WithField("isFrozen", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.AccountCount"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithAccountCount(bool isIncluded = true)
    {
        return WithField("accountCount", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.Owner"/> property.
    /// </summary>
    /// <param name="fragment">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithOwner(WalletFragment? fragment)
    {
        return WithField("owner", fragment);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.Accounts"/> property.
    /// </summary>
    /// <param name="fragment">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithWallets(WalletFragment? fragment)
    {
        return WithField("accounts", fragment);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.AccountRules"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithAccountRules(bool isIncluded = true)
    {
        return WithField("accountRules", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="FuelTank"/> is to be returned with its <see cref="FuelTank.DispatchRules"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public FuelTankFragment WithDispatchRules(bool isIncluded = true)
    {
        return WithField("dispatchRules", isIncluded);
    }
}