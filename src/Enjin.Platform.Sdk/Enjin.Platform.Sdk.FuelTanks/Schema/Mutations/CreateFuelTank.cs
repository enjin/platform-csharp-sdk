using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for creating a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class CreateFuelTank : GraphQlRequest<CreateFuelTank, TransactionFragment>,
                              IHasIdempotencyKey<CreateFuelTank>,
                              IHasSkipValidation<CreateFuelTank>,
                              IHasSigningAccount<CreateFuelTank>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateFuelTank"/> class.
    /// </summary>
    public CreateFuelTank() : base("CreateFuelTank", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the fuel tank name.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>This request for chaining.</returns>
    public CreateFuelTank SetName(string? name)
    {
        return SetVariable("name", CoreTypes.String, name);
    }

    /// <summary>
    /// Sets the flag for existential deposit.
    /// </summary>
    /// <param name="reservesExistentialDeposit">The flag.</param>
    /// <returns>This request for chaining.</returns>
    public CreateFuelTank SetReservesExistentialDeposit(bool? reservesExistentialDeposit)
    {
        return SetVariable("reservesExistentialDeposit", CoreTypes.Boolean, reservesExistentialDeposit);
    }

    /// <summary>
    /// Sets the flag for account creation deposit.
    /// </summary>
    /// <param name="reservesAccountCreationDeposit">The flag.</param>
    /// <returns>This request for chaining.</returns>
    public CreateFuelTank SetReservesAccountCreationDeposit(bool? reservesAccountCreationDeposit)
    {
        return SetVariable("reservesAccountCreationDeposit", CoreTypes.Boolean, reservesAccountCreationDeposit);
    }

    /// <summary>
    /// Sets the flag for deposit.
    /// </summary>
    /// <param name="providesDeposit">The flag.</param>
    /// <returns>This request for chaining.</returns>
    public CreateFuelTank SetProvidesDeposit(bool? providesDeposit)
    {
        return SetVariable("providesDeposit", CoreTypes.Boolean, providesDeposit);
    }

    /// <summary>
    /// Sets the fuel tank account rules.
    /// </summary>
    /// <param name="accountRules">The account rules.</param>
    /// <returns>This request for chaining.</returns>
    public CreateFuelTank SetAccountRules(AccountRuleInputType? accountRules)
    {
        return SetVariable("accountRules", FuelTanksTypes.AccountRuleInputType, accountRules);
    }

    /// <summary>
    /// Sets the fuel tank dispatch rules.
    /// </summary>
    /// <param name="dispatchRules">The dispatch rules.</param>
    /// <returns>This request for chaining.</returns>
    public CreateFuelTank SetDispatchRules(params DispatchRuleInputType[]? dispatchRules)
    {
        return SetVariable("dispatchRules", FuelTanksTypes.DispatchRuleInputTypeArray, dispatchRules);
    }
}