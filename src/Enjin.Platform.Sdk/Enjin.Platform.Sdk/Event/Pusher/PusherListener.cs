using System.Collections.Generic;
using System.Linq;
using PusherClient;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A listener class used by a <see cref="IPusherEventServiceImpl"/> for processing events received broadcasted through
/// a Pusher client.
/// </summary>
internal class PusherListener
{
    private readonly ILogger? _logger;
    private readonly IPusherEventServiceImpl _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="PusherListener"/> class for the given service.
    /// </summary>
    /// <param name="service">The event service this listener is for.</param>
    /// <param name="logger">The logger for this listener.</param>
    public PusherListener(IPusherEventServiceImpl service, ILogger? logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Receiver method for to process a <see cref="PusherEvent"/> broadcasted by the platform.
    /// </summary>
    /// <param name="evt">The <see cref="PusherEvent"/>.</param>
    public void OnEvent(PusherEvent evt)
    {
        IReadOnlyCollection<IEventListenerRegistration> registrations = _service.Registrations;

        if (!registrations.Any())
        {
            _logger?.Log(LogLevel.Warning, "No registered listeners when platform event was received");
            return;
        }

        string eventName = evt.EventName;
        PlatformEvent platformEvent = new PlatformEvent(eventName, evt.ChannelName, evt.Data);

        registrations.Where(r => r.Matcher(eventName))
                     .Do(r => r.Listener.OnEvent(platformEvent));
    }
}