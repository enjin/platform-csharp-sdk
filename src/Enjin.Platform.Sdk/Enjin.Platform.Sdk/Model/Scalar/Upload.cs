using System.IO;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Represents a file to be uploaded in an HTTP request.
/// </summary>
[JsonConverter(typeof(UploadJsonConverter))]
[PublicAPI]
public readonly struct Upload
{
    /// <summary>
    /// The file for this upload.
    /// </summary>
    public readonly FileStream File;

    /// <summary>
    /// Initializes a new instance of the <see cref="Upload"/> struct with the given file.
    /// </summary>
    /// <param name="file">The filestream for the file to upload.</param>
    public Upload(FileStream file)
    {
        File = file;
    }
}