using System;
using System.Collections.Generic;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Static class with LINQ styled methods.
/// </summary>
internal static class LinqExtension
{
    /// <summary>
    /// Performs an action on each element of the given source.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="action">The action.</param>
    /// <typeparam name="TSource">The type of the elements in the source.</typeparam>
    public static void Do<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        foreach (TSource el in source)
        {
            action(el);
        }
    }
}