using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of an <see cref="Attribute"/> returned by the platform.
/// </summary>
[PublicAPI]
public class AttributeFragment : GraphQlFragment<AttributeFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AttributeFragment"/> class.
    /// </summary>
    public AttributeFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Attribute"/> is to be returned with its <see cref="Attribute.Key"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AttributeFragment WithKey(bool isIncluded = true)
    {
        return WithField("key", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Attribute"/> is to be returned with its <see cref="Attribute.Value"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public AttributeFragment WithValue(bool isIncluded = true)
    {
        return WithField("value", isIncluded);
    }
}