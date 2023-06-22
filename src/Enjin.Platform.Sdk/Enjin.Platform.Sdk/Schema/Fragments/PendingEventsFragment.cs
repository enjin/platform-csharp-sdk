using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="PendingEvents"/> returned by the platform.
/// </summary>
[PublicAPI]
public class PendingEventsFragment : ConnectionFragment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PendingEventsFragment"/> class.
    /// </summary>
    public PendingEventsFragment()
    {
    }
}