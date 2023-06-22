using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enums representing the level of detail to log HTTP traffic at.
/// </summary>
[PublicAPI]
public enum HttpLogLevel
{
    /// <summary>
    /// Value for no logging to occur.
    /// </summary>
    None,

    /// <summary>
    /// Value signifying to log basic HTTP data, such as the method, URI, and content-length.
    /// </summary>
    Basic,

    /// <summary>
    /// Same as <see cref="Basic"/>, but also includes HTTP headers.
    /// </summary>
    Headers,

    /// <summary>
    /// Same as <see cref="Headers"/>, but also includes the message body.
    /// </summary>
    Body,
}