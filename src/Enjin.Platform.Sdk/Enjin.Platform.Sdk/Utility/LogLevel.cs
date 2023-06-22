using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Represent different levels of logging.
/// </summary>
[PublicAPI]
public enum LogLevel
{
    /// <summary>
    /// Indicates that logging at a trace level is to occur.
    /// </summary>
    /// <remarks>
    /// General contains detailed messages that may be considered sensitive and should not be enabled in production.
    /// </remarks>
    Trace,

    /// <summary>
    /// Indicates that logging at a debug level is to occur.
    /// </summary>
    /// <remarks>
    /// Generally used in debugging and development. May produce high volume of messages.
    /// </remarks>
    Debug,

    /// <summary>
    /// Indicates that logging at an informational level is to occur.
    /// </summary>
    Information,

    /// <summary>
    /// Indicates that logging at a warning level is to occur.
    /// </summary>
    Warning,

    /// <summary>
    /// Indicates that logging at an error level is to occur.
    /// </summary>
    Error,

    /// <summary>
    /// Indicates that logging at a critical level is to occur.
    /// </summary>
    Critical,

    /// <summary>
    /// Indicates that no logging is to occur.
    /// </summary>
    None,
}