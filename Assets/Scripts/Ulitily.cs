using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    None,
    Start,
    Normal,
    End
}

public class MapNode
{
    public Vector3 position;
    public MapNode nextNode;
    public EventType eventType;
    public MapEvent eventInfo;
}

public class MapEvent
{
    public EventType eventType;
    public string eventMessage;

    public MapEvent(EventType type, string message)
    {
        eventType = type;
        eventMessage = message;
    }
}

public class Map
{
    public MapNode firstNode;
}
