using System.Collections.Generic;

public static class EventUtil
{

    private static EventDispatcher dispatcher = new EventDispatcher();

    public static void AddListener(EventNames eventType, EventListener.EventHandler eventHandler)
    {
        dispatcher.AddListener(eventType, eventHandler);
    }

    public static void RemoveListener(EventNames eventType, EventListener.EventHandler eventHandler)
    {
        dispatcher.RemoveListener(eventType, eventHandler);
    }

    public static bool HasListener(EventNames eventType)
    {
        return dispatcher.HasListener(eventType);
    }

    public static void DispatchEvent(EventNames eventType, params object[] args)
    {
        dispatcher.DispatchEvent(eventType, args);
    }

    public static void Clear()
    {
        dispatcher.Clear();
    }
}
public class EventDispatcher
{
    private Dictionary<EventNames, EventListener> EventsMap = new Dictionary<EventNames, EventListener>();

    public void AddListener(EventNames eventType, EventListener.EventHandler eventHandler)
    {
		if (!EventsMap.TryGetValue(eventType, out EventListener listener))
		{
			listener = new EventListener();
			EventsMap.Add(eventType, listener);
		}
		listener.eventHandler += eventHandler;
    }

    public void RemoveListener(EventNames eventType, EventListener.EventHandler eventHandler)
    {
		if (EventsMap.TryGetValue(eventType, out EventListener listener)) listener.eventHandler -= eventHandler;
	}

    public bool HasListener(EventNames eventType)
    {
        return EventsMap.ContainsKey(eventType);
    }

    public void DispatchEvent(EventNames eventType, params object[] args)
    {
		if (EventsMap.TryGetValue(eventType, out EventListener listener))
		{
			EventArgs evt;
			if (args == null || args.Length == 0)
			{
				evt = new EventArgs(eventType);
			}
			else
			{
				evt = new EventArgs(eventType, args);
			}
			listener.Invoke(evt);
		}
	}

    public void Clear()
    {
        foreach (EventListener listener in EventsMap.Values)
        {
            listener.Clear();
        }
        EventsMap.Clear();
    }
}

public class EventListener
{
    public delegate void EventHandler(EventArgs eventArgs);
    public EventHandler eventHandler;

    public void Invoke(EventArgs eventArgs)
    {
        eventHandler?.Invoke(eventArgs);
    }

    public void Clear()
    {
        eventHandler = null;
    }

}

public class EventArgs
{
    public readonly EventNames type;
    public readonly object[] args;

    public EventArgs(EventNames type)
    {
        this.type = type;
    }

    public EventArgs(EventNames type, params object[] args)
    {
        this.type = type;
        this.args = args;
    }
}

public enum EventNames
{
    OnPlayerPositionChanged,
    OnSpeedCollected,
    OnInputSwiped,
    OnPlayerSpeedChanged,
    OnPlayerScoreChanged,
    OnGoldCollected
}