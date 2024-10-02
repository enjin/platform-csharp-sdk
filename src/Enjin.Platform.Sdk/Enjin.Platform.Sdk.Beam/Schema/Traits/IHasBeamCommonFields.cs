using System;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Interface used to add extension methods for setting common beam parameters.
/// </summary>
/// <typeparam name="THolder">The type of the parameter holder. Must implement this interface.</typeparam>
/// <seealso cref="HasBeamCommonFieldsExtension"/>
[PublicAPI]
public interface IHasBeamCommonFields<out THolder> : IGraphQlParameterHolder<THolder>
    where THolder : IHasBeamCommonFields<THolder>
{
}

/// <summary>
/// Contains extension methods for setting common beam parameters on classes implementing
/// <see cref="IHasBeamCommonFields{T}"/>.
/// </summary>
/// <seealso cref="IHasBeamCommonFields{T}"/>
[PublicAPI]
public static class HasBeamCommonFieldsExtension
{
    /// <summary>
    /// Sets the name of the beam.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="name">The name.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetName<THolder>(this THolder caller, string? name)
        where THolder : IHasBeamCommonFields<THolder>
    {
        return caller.SetParameter("name", name);
    }

    /// <summary>
    /// Sets the description of the beam.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="description">The description.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetDescription<THolder>(this THolder caller, string? description)
        where THolder : IHasBeamCommonFields<THolder>
    {
        return caller.SetParameter("description", description);
    }

    /// <summary>
    /// Sets the image URL of the beam.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="image">The image URL.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetImage<THolder>(this THolder caller, string? image)
        where THolder : IHasBeamCommonFields<THolder>
    {
        return caller.SetParameter("image", image);
    }

    /// <summary>
    /// Sets the start date of the claim period.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="start">The start date.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetStart<THolder>(this THolder caller, DateTime? start)
        where THolder : IHasBeamCommonFields<THolder>
    {
        return caller.SetParameter("start", start);
    }

    /// <summary>
    /// Sets the end date of the claim period.
    /// </summary>
    /// <param name="caller">The caller to set the parameter on.</param>
    /// <param name="end">The end date.</param>
    /// <typeparam name="THolder">The caller type.</typeparam>
    /// <returns>The caller for chaining.</returns>
    public static THolder SetEnd<THolder>(this THolder caller, DateTime? end)
        where THolder : IHasBeamCommonFields<THolder>
    {
        return caller.SetParameter("end", end);
    }
}