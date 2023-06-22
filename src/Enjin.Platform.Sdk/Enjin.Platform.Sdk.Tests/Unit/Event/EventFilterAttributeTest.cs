using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class EventFilterAttributeTest
{
    [Test]
    [TestCase(new[] { "Event1", "Event2" }, new[] { "Event3", "Event4" })]
    public void MatcherWhenEventsAreAllowedReturnsCorrectMatcher(string[] included, string[] other)
    {
        // Arrange
        const bool isAllowed = true;
        EventFilterAttribute attribute = new EventFilterAttribute(isAllowed, included);

        // Act
        Func<string, bool> matcher = attribute.Matcher;

        // Assert
        Assert.Multiple(() =>
        {
            foreach (string e in included)
            {
                Assert.That(matcher(e), Is.True, $"Assert allowed event '{e}' matches as true");
            }

            foreach (string e in other)
            {
                Assert.That(matcher(e), Is.False, $"Assert non-allowed event '{e}' matches as false");
            }
        });
    }

    [Test]
    [TestCase(new[] { "Event1", "Event2" }, new[] { "Event3", "Event4" })]
    public void MatcherWhenEventsAreNotAllowedReturnsCorrectMatcher(string[] excluded, string[] other)
    {
        // Arrange
        const bool isAllowed = false;
        EventFilterAttribute attribute = new EventFilterAttribute(isAllowed, excluded);

        // Act
        Func<string, bool> matcher = attribute.Matcher;

        // Assert
        Assert.Multiple(() =>
        {
            foreach (string e in excluded)
            {
                Assert.That(matcher(e), Is.False, $"Assert disallowed event '{e}' matches as false");
            }

            foreach (string e in other)
            {
                Assert.That(matcher(e), Is.True, $"Assert non-disallowed event '{e}' matches as true");
            }
        });
    }
}