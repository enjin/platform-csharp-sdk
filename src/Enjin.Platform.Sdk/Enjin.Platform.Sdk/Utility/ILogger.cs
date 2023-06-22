using System;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for logging.
/// </summary>
[PublicAPI]
public interface ILogger
{
    /// <summary>
    /// Logs a message at the given <see cref="LogLevel"/>.
    /// </summary>
    /// <param name="logLevel">The <see cref="LogLevel"/>.</param>
    /// <param name="message">The message.</param>
    public void Log(LogLevel logLevel, string? message);

    /// <summary>
    /// Logs an exception and message at the given <see cref="LogLevel"/>.
    /// </summary>
    /// <param name="logLevel">The <see cref="LogLevel"/>.</param>
    /// <param name="e">The exception.</param>
    /// <param name="message">The message.</param>
    public void Log(LogLevel logLevel, Exception? e, string? message);
}