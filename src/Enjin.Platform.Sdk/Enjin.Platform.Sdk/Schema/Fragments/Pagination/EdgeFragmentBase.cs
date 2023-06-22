using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Abstract base class for GraphQL fragments of the platform's <c>Edge</c> type to extend from.
/// </summary>
/// <typeparam name="TEdge">The inheriting edge class. Must extend this class.</typeparam>
[PublicAPI]
public abstract class EdgeFragmentBase<TEdge> : GraphQlFragment<TEdge>
    where TEdge : EdgeFragmentBase<TEdge>
{
    /// <summary>
    /// Sets whether the <see cref="Edge{T}"/> is to be returned with its <see cref="Edge{T}.Cursor"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TEdge WithCursor(bool isIncluded = true)
    {
        return WithField("cursor", isIncluded);
    }
}