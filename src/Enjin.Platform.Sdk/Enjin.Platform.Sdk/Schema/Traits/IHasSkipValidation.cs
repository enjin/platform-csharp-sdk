using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface used to add an extension method for setting <c>skipValidation</c> parameter.
/// </summary>
/// <typeparam name="THolder">The type of the parameter setter. Must implement this interface.</typeparam>
/// <seealso cref="HasSkipValidationExtension"/>
[PublicAPI]
public interface IHasSkipValidation<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasSkipValidation<THolder>
{
}

/// <summary>
/// Contains extension method for setting <c>skipValidation</c> parameter on classes implementing
/// <see cref="IHasSkipValidation{T}"/>.
/// </summary>
/// <seealso cref="IHasSkipValidation{T}"/>
[PublicAPI]
public static class HasSkipValidationExtension
{
    /// <summary>
    /// Sets whether to skip all validation rules, use with caution.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="skipValidation">Whether to skip all validation rules.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetSkipValidation<THolder>(this THolder caller, bool? skipValidation)
        where THolder : IHasSkipValidation<THolder>
    {
        return caller.SetParameter("skipValidation", skipValidation);
    }
}