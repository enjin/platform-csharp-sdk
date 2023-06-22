using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface used to add an extension method for setting <c>continueOnFailure</c> parameter. Intended for
/// implementation by batch requests.
/// </summary>
/// <typeparam name="THolder">The type of the parameter setter. Must implement this interface.</typeparam>
/// <seealso cref="HasContinueOnFailureExtension"/>
[PublicAPI]
public interface IHasContinueOnFailure<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasContinueOnFailure<THolder>
{
}

/// <summary>
/// Contains extension method for setting <c>continueOnFailure</c> parameter on classes implementing
/// <see cref="IHasContinueOnFailure{T}"/>.
/// </summary>
/// <seealso cref="IHasContinueOnFailure{T}"/>
[PublicAPI]
public static class HasContinueOnFailureExtension
{
    /// <summary>
    /// Sets whether data that would cause the whole batch to fail ought to be skipped.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="continueOnFailure">Whether to skip data that would cause the batch to fail.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetContinueOnFailure<THolder>(this THolder caller, bool? continueOnFailure)
        where THolder : IHasContinueOnFailure<THolder>
    {
        return caller.SetParameter("continueOnFailure", continueOnFailure);
    }
}