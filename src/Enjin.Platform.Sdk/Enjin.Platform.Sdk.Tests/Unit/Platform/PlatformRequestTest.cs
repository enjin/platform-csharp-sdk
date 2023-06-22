using NUnit.Framework;
using RequestBuilder = Enjin.Platform.Sdk.PlatformRequest.PlatformRequestBuilder;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class PlatformRequestTest
{
    [Test]
    public void BuildRequestWithoutAddingAnOperationThrowsInvalidOperationException()
    {
        // Arrange
        RequestBuilder builder = PlatformRequest.Builder();

        // Assert
        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Test]
    public void BuildRequestWithNullVariablesReturnsContentWithNoVariablesField()
    {
        // Arrange
        const string expected = @"{""query"":""""}";
        Dictionary<string, object?>? variables = null;
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.That(actual.Content.ReadAsStringAsync().Result, Is.EqualTo(expected));
    }

    [Test]
    public void BuildRequestWithEmptyVariablesReturnsContentWithEmptyVariablesField()
    {
        // Arrange
        const string expected = @"{""query"":"""",""variables"":{}}";
        Dictionary<string, object?> variables = new();
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.That(actual.Content.ReadAsStringAsync().Result, Is.EqualTo(expected));
    }

    [Test]
    public void BuildRequestWithNonEmptyVariablesReturnsContentWithExpectedVariablesField()
    {
        // Arrange
        const string expected = @"{""query"":"""",""variables"":{""key"":""value""}}";
        Dictionary<string, object?> variables = new()
        {
            { "key", "value" },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.That(actual.Content.ReadAsStringAsync().Result, Is.EqualTo(expected));
    }

    [Test]
    public void BuildBatchRequestWithNullVariablesReturnsContentWithNoVariablesField()
    {
        // Arrange
        const string expected = @"[{""query"":""""},{""query"":""""}]";
        Dictionary<string, object?>? variables1 = null;
        Dictionary<string, object?>? variables2 = null;
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables1)
                                                .AddOperation(string.Empty, variables2);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.That(actual.Content.ReadAsStringAsync().Result, Is.EqualTo(expected));
    }

    [Test]
    public void BuildBatchRequestWithEmptyVariablesReturnsContentWithEmptyVariablesField()
    {
        // Arrange
        const string expected = @"[{""query"":"""",""variables"":{}},{""query"":"""",""variables"":{}}]";
        Dictionary<string, object?> variables1 = new();
        Dictionary<string, object?> variables2 = new();
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables1)
                                                .AddOperation(string.Empty, variables2);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.That(actual.Content.ReadAsStringAsync().Result, Is.EqualTo(expected));
    }

    [Test]
    public void BuildBatchRequestWithNonEmptyVariablesReturnsContentWithExpectedVariablesField()
    {
        // Arrange
        const string expected =
            @"[{""query"":"""",""variables"":{""key1"":""value1""}},{""query"":"""",""variables"":{""key2"":""value2""}}]";
        Dictionary<string, object?> variables1 = new()
        {
            { "key1", "value1" },
        };
        Dictionary<string, object?> variables2 = new()
        {
            { "key2", "value2" },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables1)
                                                .AddOperation(string.Empty, variables2);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.That(actual.Content.ReadAsStringAsync().Result, Is.EqualTo(expected));
    }

    [Test]
    public void BuildRequestWithSingleFileVariableReturnsContentWithExpectedForms()
    {
        // Arrange
        const string expectedOperationsFormName = @"name=""operations""";
        const string expectedMapFormName = @"name=""map""";
        const string expectedFileFormName = @"name=""0""";
        const string expectedFileContent = "Alpha file content.";
        const string expectedMapVariables = @"{""0"":[""variables.file""]}";
        Dictionary<string, object?> variables = new()
        {
            { "file", new Upload(File.OpenRead("Test Data/a.txt")) },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.Multiple(() =>
        {
            string content = actual.Content.ReadAsStringAsync().Result;

            Assert.That(content, Does.Contain(expectedOperationsFormName),
                        "Assert content contains operation content name");
            Assert.That(content, Does.Contain(expectedMapFormName),
                        "Assert content contains map content name");
            Assert.That(content, Does.Contain(expectedFileFormName),
                        "Assert content contains file content name");
            Assert.That(content, Does.Contain(expectedFileContent),
                        "Assert content contains file content");
            Assert.That(content, Does.Contain(expectedMapVariables),
                        "Assert content contains map variables");
        });
    }

    [Test]
    public void BuildRequestWithFileListVariableReturnsContentWithExpectedForms()
    {
        // Arrange
        const string expectedOperationsFormName = @"name=""operations""";
        const string expectedMapFormName = @"name=""map""";
        const string expectedFile0FormName = @"name=""0""";
        const string expectedFile1FormName = @"name=""1""";
        const string expectedFile0Content = "Alpha file content.";
        const string expectedFile1Content = "Bravo file content.";
        const string expectedMapVariables = @"{""0"":[""variables.files.0""],""1"":[""variables.files.1""]}";
        Dictionary<string, object?> variables = new()
        {
            {
                "files", new List<Upload>
                {
                    new(File.OpenRead("Test Data/a.txt")),
                    new(File.OpenRead("Test Data/b.txt")),
                }
            },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.Multiple(() =>
        {
            string content = actual.Content.ReadAsStringAsync().Result;

            Assert.That(content, Does.Contain(expectedOperationsFormName),
                        "Assert content contains operation content name");
            Assert.That(content, Does.Contain(expectedMapFormName),
                        "Assert content contains map content name");
            Assert.That(content, Does.Contain(expectedFile0FormName),
                        "Assert content contains file content name for file '0'");
            Assert.That(content, Does.Contain(expectedFile1FormName),
                        "Assert content contains file content name for file '1'");
            Assert.That(content, Does.Contain(expectedFile0Content),
                        "Assert content contains file content for file '0'");
            Assert.That(content, Does.Contain(expectedFile1Content),
                        "Assert content contains file content for file '1'");
            Assert.That(content, Does.Contain(expectedMapVariables),
                        "Assert content contains map variables");
        });
    }

    [Test]
    public void BuildRequestWithNullableFileListVariableReturnsContentWithExpectedForms()
    {
        // Arrange
        const string expectedOperationsFormName = @"name=""operations""";
        const string expectedMapFormName = @"name=""map""";
        const string expectedFile0FormName = @"name=""0""";
        const string expectedFile1FormName = @"name=""1""";
        const string expectedFile0Content = "Alpha file content.";
        const string expectedFile1Content = "Bravo file content.";
        const string expectedMapVariables = @"{""0"":[""variables.files.0""],""1"":[""variables.files.1""]}";
        Dictionary<string, object?> variables = new()
        {
            {
                "files", new List<Upload?>
                {
                    new(File.OpenRead("Test Data/a.txt")),
                    new(File.OpenRead("Test Data/b.txt")),
                }
            },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.Multiple(() =>
        {
            string content = actual.Content.ReadAsStringAsync().Result;

            Assert.That(content, Does.Contain(expectedOperationsFormName),
                        "Assert content contains operation content name");
            Assert.That(content, Does.Contain(expectedMapFormName),
                        "Assert content contains map content name");
            Assert.That(content, Does.Contain(expectedFile0FormName),
                        "Assert content contains file content name for file '0'");
            Assert.That(content, Does.Contain(expectedFile1FormName),
                        "Assert content contains file content name for file '1'");
            Assert.That(content, Does.Contain(expectedFile0Content),
                        "Assert content contains file content for file '0'");
            Assert.That(content, Does.Contain(expectedFile1Content),
                        "Assert content contains file content for file '1'");
            Assert.That(content, Does.Contain(expectedMapVariables),
                        "Assert content contains map variables");
        });
    }

    [Test]
    public void BuildBatchRequestWithSingleFileVariableReturnsContentWithExpectedForms()
    {
        // Arrange
        const string expectedOperationsFormName = @"name=""operations""";
        const string expectedMapFormName = @"name=""map""";
        const string expectedFile0FormName = @"name=""0""";
        const string expectedFile1FormName = @"name=""1""";
        const string expectedFile0Content = "Alpha file content.";
        const string expectedFile1Content = "Bravo file content.";
        const string expectedMapVariables = @"{""0"":[""0.variables.file1""],""1"":[""1.variables.file2""]}";
        Dictionary<string, object?> variables1 = new()
        {
            { "file1", new Upload(File.OpenRead("Test Data/a.txt")) },
        };
        Dictionary<string, object?> variables2 = new()
        {
            { "file2", new Upload(File.OpenRead("Test Data/b.txt")) },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables1)
                                                .AddOperation(string.Empty, variables2);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.Multiple(() =>
        {
            string content = actual.Content.ReadAsStringAsync().Result;

            Assert.That(content, Does.Contain(expectedOperationsFormName),
                        "Assert content contains operation content name");
            Assert.That(content, Does.Contain(expectedMapFormName),
                        "Assert content contains map content name");
            Assert.That(content, Does.Contain(expectedFile0FormName),
                        "Assert content contains file content name for file '0'");
            Assert.That(content, Does.Contain(expectedFile0Content),
                        "Assert content contains file content for file '0'");
            Assert.That(content, Does.Contain(expectedFile1FormName),
                        "Assert content contains file content name for file '1'");
            Assert.That(content, Does.Contain(expectedFile1Content),
                        "Assert content contains file content for file '1'");
            Assert.That(content, Does.Contain(expectedMapVariables),
                        "Assert content contains map variables");
        });
    }

    [Test]
    public void BuildBatchRequestWithFileListVariableReturnsContentWithExpectedForms()
    {
        // Arrange
        const string expectedOperationsFormName = @"name=""operations""";
        const string expectedMapFormName = @"name=""map""";
        const string expectedFile0FormName = @"name=""0""";
        const string expectedFile1FormName = @"name=""1""";
        const string expectedFile2FormName = @"name=""2""";
        const string expectedFile3FormName = @"name=""3""";
        const string expectedFile0Content = "Alpha file content.";
        const string expectedFile1Content = "Bravo file content.";
        const string expectedFile2Content = "Charlie file content.";
        const string expectedFile3Content = "Delta file content.";
        const string expectedMapVariables =
            @"{""0"":[""0.variables.files.0""],""1"":[""0.variables.files.1""],""2"":[""1.variables.files.0""],""3"":[""1.variables.files.1""]}";
        Dictionary<string, object?> variables1 = new()
        {
            {
                "files", new List<Upload>
                {
                    new(File.OpenRead("Test Data/a.txt")),
                    new(File.OpenRead("Test Data/b.txt")),
                }
            },
        };
        Dictionary<string, object?> variables2 = new()
        {
            {
                "files", new List<Upload>
                {
                    new(File.OpenRead("Test Data/c.txt")),
                    new(File.OpenRead("Test Data/d.txt")),
                }
            },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables1)
                                                .AddOperation(string.Empty, variables2);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.Multiple(() =>
        {
            string content = actual.Content.ReadAsStringAsync().Result;

            Assert.That(content, Does.Contain(expectedOperationsFormName),
                        "Assert content contains operation content name");
            Assert.That(content, Does.Contain(expectedMapFormName),
                        "Assert content contains map content name");
            Assert.That(content, Does.Contain(expectedFile0FormName),
                        "Assert content contains file content name for file '0'");
            Assert.That(content, Does.Contain(expectedFile1FormName),
                        "Assert content contains file content name for file '1'");
            Assert.That(content, Does.Contain(expectedFile2FormName),
                        "Assert content contains file content name for file '2'");
            Assert.That(content, Does.Contain(expectedFile3FormName),
                        "Assert content contains file content name for file '3'");
            Assert.That(content, Does.Contain(expectedFile0Content),
                        "Assert content contains file content for file '0'");
            Assert.That(content, Does.Contain(expectedFile1Content),
                        "Assert content contains file content for file '1'");
            Assert.That(content, Does.Contain(expectedFile2Content),
                        "Assert content contains file content for file '2'");
            Assert.That(content, Does.Contain(expectedFile3Content),
                        "Assert content contains file content for file '3'");
            Assert.That(content, Does.Contain(expectedMapVariables),
                        "Assert content contains map variables");
        });
    }

    [Test]
    public void BuildBatchRequestWithNullableFileListVariableReturnsContentWithExpectedForms()
    {
        // Arrange
        const string expectedOperationsFormName = @"name=""operations""";
        const string expectedMapFormName = @"name=""map""";
        const string expectedFile0FormName = @"name=""0""";
        const string expectedFile1FormName = @"name=""1""";
        const string expectedFile2FormName = @"name=""2""";
        const string expectedFile3FormName = @"name=""3""";
        const string expectedFile0Content = "Alpha file content.";
        const string expectedFile1Content = "Bravo file content.";
        const string expectedFile2Content = "Charlie file content.";
        const string expectedFile3Content = "Delta file content.";
        const string expectedMapVariables =
            @"{""0"":[""0.variables.files.0""],""1"":[""0.variables.files.1""],""2"":[""1.variables.files.0""],""3"":[""1.variables.files.1""]}";
        Dictionary<string, object?> variables1 = new()
        {
            {
                "files", new List<Upload?>
                {
                    new(File.OpenRead("Test Data/a.txt")),
                    new(File.OpenRead("Test Data/b.txt")),
                }
            },
        };
        Dictionary<string, object?> variables2 = new()
        {
            {
                "files", new List<Upload?>
                {
                    new(File.OpenRead("Test Data/c.txt")),
                    new(File.OpenRead("Test Data/d.txt")),
                }
            },
        };
        RequestBuilder builder = PlatformRequest.Builder()
                                                .AddOperation(string.Empty, variables1)
                                                .AddOperation(string.Empty, variables2);

        // Act
        PlatformRequest actual = builder.Build();

        // Assert
        Assert.Multiple(() =>
        {
            string content = actual.Content.ReadAsStringAsync().Result;

            Assert.That(content, Does.Contain(expectedOperationsFormName),
                        "Assert content contains operation content name");
            Assert.That(content, Does.Contain(expectedMapFormName),
                        "Assert content contains map content name");
            Assert.That(content, Does.Contain(expectedFile0FormName),
                        "Assert content contains file content name for file '0'");
            Assert.That(content, Does.Contain(expectedFile1FormName),
                        "Assert content contains file content name for file '1'");
            Assert.That(content, Does.Contain(expectedFile2FormName),
                        "Assert content contains file content name for file '2'");
            Assert.That(content, Does.Contain(expectedFile3FormName),
                        "Assert content contains file content name for file '3'");
            Assert.That(content, Does.Contain(expectedFile0Content),
                        "Assert content contains file content for file '0'");
            Assert.That(content, Does.Contain(expectedFile1Content),
                        "Assert content contains file content for file '1'");
            Assert.That(content, Does.Contain(expectedFile2Content),
                        "Assert content contains file content for file '2'");
            Assert.That(content, Does.Contain(expectedFile3Content),
                        "Assert content contains file content for file '3'");
            Assert.That(content, Does.Contain(expectedMapVariables),
                        "Assert content contains map variables");
        });
    }
}