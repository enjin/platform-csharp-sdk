using System.Net.Http;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for platform requests to implement.
/// </summary>
[PublicAPI]
public interface IPlatformRequest
{
    /// <summary>
    /// The HTTP content of the request.
    /// </summary>
    public HttpContent Content { get; }

    /// <summary>
    /// The relative path for the URI of the request.
    /// </summary>
    public string Path { get; }
}