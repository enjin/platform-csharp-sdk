using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Contains HTTP data for sending a request to the platform.
/// </summary>
[PublicAPI]
public sealed class PlatformRequest : IPlatformRequest
{
    private IDictionary<string, FileStream>? _fileVariables;

    private const string MapContentName = @"""map""";
    private const string OperationsContentName = @"""operations""";

    private static readonly Encoding ENCODING = Encoding.UTF8;
    private static readonly string MEDIA_TYPE = "application/json";
    private static readonly JsonSerializerOptions SERIALIZER_OPTIONS;

    /// <summary>
    /// Determines whether this request has file variables.
    /// </summary>
    private bool HasFileVariables => _fileVariables is { Count: > 0 };

    /// <summary>
    /// Initializes a new instance of the <see cref="PlatformRequest"/> class.
    /// </summary>
    /// <param name="path">The relative path of the URI.</param>
    /// <param name="operations">The operations for the request content.</param>
    private PlatformRequest(string path, List<Operation> operations)
    {
        Path = path;
        Content = CreateContent(operations);
    }

    static PlatformRequest()
    {
        SERIALIZER_OPTIONS = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters =
            {
                // BigInt
                new BigIntegerJsonConverter(),
                new NullableBigIntegerJsonConverter(),

                // DateTime
                new DateTimeJsonConverter(),
                new NullableDateTimeJsonConverter(),
            },
        };
    }

    /// <summary>
    /// Creates the HTTP content for this request.
    /// </summary>
    /// <param name="operations">The operations for the content.</param>
    /// <returns>The HTTP content.</returns>
    private HttpContent CreateContent(List<Operation> operations)
    {
        // Create operations content
        HttpContent operationsContent = CreateOperationsContent(operations);

        if (!HasFileVariables)
        {
            return operationsContent;
        }

        // Create multipart form content and add operation content
        MultipartFormDataContent formContent = new();
        formContent.Add(operationsContent, OperationsContentName);

        // Define the values for the file contents and create the JSON object for the map content
        int i = 0;
        List<Tuple<StreamContent, string, string>> fileContents = new();
        using MemoryStream mapWriterStream = new MemoryStream();
        using Utf8JsonWriter mapWriter = new Utf8JsonWriter(mapWriterStream);

        mapWriter.WriteStartObject();

        foreach (KeyValuePair<string, FileStream> kvPair in _fileVariables!)
        {
            string variableId = i++.ToString();
            string variableName = kvPair.Key;
            FileStream fs = kvPair.Value;
            StreamContent content = new StreamContent(fs);

            fileContents.Add(new Tuple<StreamContent, string, string>(content, variableId, fs.Name));

            mapWriter.WriteStartArray(variableId);
            mapWriter.WriteStringValue(variableName);
            mapWriter.WriteEndArray();
        }

        mapWriter.WriteEndObject();
        mapWriter.Flush();

        // Create and add the map content for the files
        formContent.Add(new StringContent(ENCODING.GetString(mapWriterStream.ToArray()),
                                          ENCODING,
                                          MEDIA_TYPE),
                        MapContentName);

        // Create and add the file contents
        foreach (Tuple<StreamContent, string, string> fileContent in fileContents)
        {
            formContent.Add(fileContent.Item1,
                            "\"" + fileContent.Item2 + "\"",
                            "\"" + fileContent.Item3 + "\"");
        }

        return formContent;
    }

    /// <summary>
    /// Creates HTTP content for the operations data of this request.
    /// </summary>
    /// <param name="operations">The operations.</param>
    /// <returns>The HTTP content for the operations data.</returns>
    private HttpContent CreateOperationsContent(List<Operation> operations)
    {
        int count = operations.Count;
        if (count > 1)
        {
            _fileVariables = new Dictionary<string, FileStream>();

            for (int i = 0; i < count; i++)
            {
                IReadOnlyDictionary<string, object?>? variables = operations[i].Variables;

                if (variables is not { Count: > 0 })
                {
                    continue;
                }

                IDictionary<string, FileStream> uploads = GetUploads(i + ".variables", variables);
                foreach (KeyValuePair<string, FileStream> upload in uploads)
                {
                    _fileVariables.Add(upload);
                }
            }

            return new StringContent(JsonSerializer.Serialize(operations, SERIALIZER_OPTIONS), ENCODING, MEDIA_TYPE);
        }

        Operation operation = operations[0];

        if (operation.Variables is { Count: > 0 })
        {
            _fileVariables = GetUploads("variables", operation.Variables);
        }

        return new StringContent(JsonSerializer.Serialize(operation, SERIALIZER_OPTIONS), ENCODING, MEDIA_TYPE);
    }

    /// <summary>
    /// Creates a builder instance to be used for creating an instance of <see cref="PlatformRequest"/>.
    /// </summary>
    /// <returns>The builder instance.</returns>
    public static PlatformRequestBuilder Builder() => new();

    /// <summary>
    /// Gets a mapping of uploads and the keys for their variables.
    /// </summary>
    /// <param name="root">The root key of the variables.</param>
    /// <param name="variables">The variables to check.</param>
    /// <returns>A dictionary containing the files and their variable keys.</returns>
    private static IDictionary<string, FileStream> GetUploads(string root,
                                                              IReadOnlyDictionary<string, object?> variables)
    {
        Dictionary<string, FileStream> files = new();

        foreach (KeyValuePair<string, object?> kvPair in variables)
        {
            GetUploads(root + "." + kvPair.Key, kvPair.Value, files);
        }

        return files;
    }

    /// <summary>
    /// Helper method for recursively getting the mapping of uploads and the keys for their variables.
    /// </summary>
    /// <param name="key">The current key.</param>
    /// <param name="variable">The current variable.</param>
    /// <param name="files">The dictionary to place the files and their variable keys in.</param>
    private static void GetUploads(string key, object? variable, IDictionary<string, FileStream> files)
    {
        int i = 0; // Counter to be used when variable is a list

        switch (variable)
        {
            // Ignore if the variable is null
            case null:
                break;

            // Add file if the variable is a non-nullable Upload
            case Upload upload:
                files[key] = upload.File;
                break;

            // Add multiple files if variable is a list of Uploads
            case IEnumerable<Upload> list:
                foreach (Upload upload in list)
                {
                    string newKey = key + "." + i++;
                    files[newKey] = upload.File;
                }

                break;

            // Add multiple files if variable is a list of Uploads
            case IEnumerable<Upload?> list:
                foreach (Upload? upload in list)
                {
                    if (!upload.HasValue)
                    {
                        continue;
                    }

                    string newKey = key + "." + i++;
                    files[newKey] = upload.Value.File;
                }

                break;

            // Make recursive call if variable is a GraphQL variable
            case IGraphQlParameter v:
                foreach (KeyValuePair<string, object?> innerVariable in v.Parameters)
                {
                    GetUploads(key + "." + innerVariable.Key, innerVariable.Value, files);
                }

                break;

            // Make recursive call if variable is a list of GraphQL variables
            case IEnumerable<IGraphQlParameter> vList:
                foreach (IGraphQlParameter v in vList)
                {
                    foreach (KeyValuePair<string, object?> innerVariable in v.Parameters)
                    {
                        GetUploads(key + "." + i++ + "." + innerVariable.Key, innerVariable.Value, files);
                    }
                }

                break;

            // Ignore by default
        }
    }

    #region IPlatformRequest

    /// <inheritdoc/>
    public HttpContent Content { get; }

    /// <inheritdoc/>
    public string Path { get; }

    #endregion IPlatformRequest

    /// <summary>
    /// The builder class for defining and creating a new instance of the <see cref="PlatformRequest"/> class.
    /// </summary>
    [PublicAPI]
    public sealed class PlatformRequestBuilder
    {
        private string? _path;
        private List<Operation> _operations = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformRequestBuilder"/> class.
        /// </summary>
        internal PlatformRequestBuilder()
        {
        }

        /// <summary>
        /// Adds an operation for the request.
        /// </summary>
        /// <param name="query">The query of the operation.</param>
        /// <param name="variables">The variables of the operation.</param>
        /// <returns>This builder for chaining.</returns>
        public PlatformRequestBuilder AddOperation(string query, IReadOnlyDictionary<string, object?>? variables)
        {
            _operations.Add(new Operation(query, variables));
            return this;
        }

        /// <summary>
        /// Builds an instance of <see cref="PlatformRequest"/> using the set values.
        /// </summary>
        /// <returns>The request instance.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if no operations have been added at the time of the call.
        /// </exception>
        public PlatformRequest Build()
        {
            if (_operations.Count == 0)
            {
                throw new InvalidOperationException($"Cannot build {nameof(PlatformRequest)} with no operations");
            }

            return new PlatformRequest(_path ?? string.Empty, _operations);
        }

        /// <summary>
        /// Sets the relative path of the URI to be used for the request.
        /// </summary>
        /// <param name="path">The relative path.</param>
        /// <returns>This builder for chaining.</returns>
        /// <remarks>
        /// Defaults to an empty string if not set.
        /// </remarks>
        public PlatformRequestBuilder SetPath(string path)
        {
            _path = path;
            return this;
        }
    }

    /// <summary>
    /// Represents a request operation.
    /// </summary>
    private class Operation
    {
        /// <summary>
        /// The query of this operation.
        /// </summary>
        [JsonPropertyName("query")]
        [UsedImplicitly]
        public string Query { get; }

        /// <summary>
        /// The variables of this operation.
        /// </summary>
        [JsonPropertyName("variables")]
        [UsedImplicitly]
        public IReadOnlyDictionary<string, object?>? Variables { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        /// <param name="query">The query for the operation.</param>
        /// <param name="variables">The variables for the operation.</param>
        public Operation(string query, IReadOnlyDictionary<string, object?>? variables)
        {
            Query = query;
            Variables = variables;
        }
    }
}