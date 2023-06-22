using Moq;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

public class GraphQlFragmentImpl : GraphQlFragment<GraphQlFragmentImpl>
{
}

[TestFixture]
public class GraphQlFragmentTest
{
    private GraphQlFragmentImpl ClassUnderTest { get; set; }

    // Mocks
    private Mock<IGraphQlFragment> MockInnerFragment { get; set; }

    [SetUp]
    public void SetUp()
    {
        ClassUnderTest = new GraphQlFragmentImpl();
        MockInnerFragment = new Mock<IGraphQlFragment>();
    }

    [Test]
    public void CompileFieldsWhenNoFieldsAreSetThrowsInvalidOperationException()
    {
        // Assumptions
        Assume.That(ClassUnderTest.HasFields, Is.False,
                    $"Assume {nameof(ClassUnderTest.HasFields)} is false");

        // Assert
        Assert.Throws<InvalidOperationException>(() => ClassUnderTest.CompileFields());
    }

    [Test]
    public void CompileFieldsWhenScalarFieldIsSetReturnsExpectedString()
    {
        // Arrange
        const string expected = @"field";
        const string name = "field";
        ClassUnderTest.WithField(name, true);

        // Assumptions
        Assume.That(ClassUnderTest.HasFields, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasFields)} is true");

        // Act
        string actual = ClassUnderTest.CompileFields();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileFieldsWhenFragmentFieldIsSetReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"field { innerField }";
        const string name = "field";
        ClassUnderTest.WithField(name, MockInnerFragment.Object);

        // Arrange - Expectations
        MockInnerFragment.Setup(mock => mock.Compile())
                         .Returns(@"{ innerField }");

        // Assumptions
        Assume.That(ClassUnderTest.HasFields, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasFields)} is true");

        // Act
        string actual = ClassUnderTest.CompileFields();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockInnerFragment.Verify(mock => mock.Compile(), Times.Once);
    }

    [Test]
    public void CompileFieldsWhenFieldsAreSetReturnsExpectedString()
    {
        // Arrange - Data
        const string expected = @"field1 field2 { innerField }";
        const string name1 = "field1";
        const string name2 = "field2";
        ClassUnderTest.WithField(name1, true);
        ClassUnderTest.WithField(name2, MockInnerFragment.Object);

        // Arrange - Expectations
        MockInnerFragment.Setup(mock => mock.Compile())
                         .Returns(@"{ innerField }");

        // Assumptions
        Assume.That(ClassUnderTest.HasFields, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasFields)} is true");

        // Act
        string actual = ClassUnderTest.CompileFields();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

        // Verify
        MockInnerFragment.Verify(mock => mock.Compile(), Times.Once);
    }

    [Test]
    public void CompileWhenParametersAreSetAndNoFieldsAreSetThrowsInvalidOperationException()
    {
        // Arrange
        const string key = "key";
        const string value = "value";
        ClassUnderTest.SetParameter(key, value);

        // Assumptions
        Assume.That(ClassUnderTest.HasParameters, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasParameters)} is true");
        Assume.That(ClassUnderTest.HasFields, Is.False,
                    $"Assume {nameof(ClassUnderTest.HasFields)} is false");

        // Assert
        Assert.Throws<InvalidOperationException>(() => ClassUnderTest.Compile());
    }

    [Test]
    public void CompileWhenNoParametersAreSetAndFieldsAreSetReturnsExpectedString()
    {
        // Arrange
        const string expected = @"{ field }";
        const string name = "field";
        ClassUnderTest.WithField(name, true);

        // Assumptions
        Assume.That(ClassUnderTest.HasParameters, Is.False,
                    $"Assume {nameof(ClassUnderTest.HasParameters)} is false");
        Assume.That(ClassUnderTest.HasFields, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasFields)} is true");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CompileWhenParametersAreSetAndFieldsAreSetReturnsExpectedString()
    {
        // Arrange
        const string expected = @"(key: ""value"") { field }";
        const string key = "key";
        const string value = "value";
        const string name = "field";
        ClassUnderTest.SetParameter(key, value);
        ClassUnderTest.WithField(name, true);

        // Assumptions
        Assume.That(ClassUnderTest.HasParameters, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasParameters)} is true");
        Assume.That(ClassUnderTest.HasFields, Is.True,
                    $"Assume {nameof(ClassUnderTest.HasFields)} is true");

        // Act
        string actual = ClassUnderTest.Compile();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void HasFieldWhenTheFieldHasNotBeenSetReturnsFalse()
    {
        // Arrange
        const string name = "field";

        // Act
        bool actual = ClassUnderTest.HasField(name);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void HasFieldWhenPrimitiveFieldHasBeenSetReturnsTrue()
    {
        // Arrange
        const string name = "field";
        const bool isIncluded = true;
        ClassUnderTest.WithField(name, isIncluded);

        // Act
        bool actual = ClassUnderTest.HasField(name);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void HasFieldWhenFragmentFieldHasBeenSetReturnsTrue()
    {
        // Arrange
        const string name = "field";
        IGraphQlFragment fragment = MockInnerFragment.Object;
        ClassUnderTest.WithField(name, fragment);

        // Act
        bool actual = ClassUnderTest.HasField(name);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    public void WithFieldWhenNotIncludedRemovesField()
    {
        // Arrange
        const string name = "field";
        ClassUnderTest.WithField(name, true);

        // Assumptions
        Assume.That(ClassUnderTest.HasField(name), Is.True,
                    $"Assume {nameof(ClassUnderTest.HasField)} given '{name}' returns true");

        // Act
        ClassUnderTest.WithField(name, false);

        // Assert
        Assert.That(ClassUnderTest.HasField(name), Is.False);
    }

    [Test]
    public void WithFieldWhenGivenNullFragmentFieldRemovesField()
    {
        // Arrange
        const string name = "field";
        ClassUnderTest.WithField(name, MockInnerFragment.Object);

        // Assumptions
        Assume.That(ClassUnderTest.HasField(name), Is.True,
                    $"Assume {nameof(ClassUnderTest.HasField)} given '{name}' returns true");

        // Act
        ClassUnderTest.WithField(name, null);

        // Assert
        Assert.That(ClassUnderTest.HasField(name), Is.False);
    }

    [Test]
    public void WithFieldWhenFragmentFieldIsOwnInstanceThrowsArgumentException()
    {
        // Arrange
        const string name = "field";
        IGraphQlFragment fragment = ClassUnderTest;

        // Assert
        Assert.Throws<ArgumentException>(() => ClassUnderTest.WithField(name, fragment));
    }
}