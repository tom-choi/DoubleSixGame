using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapEventType
{
    None,
    Start,
    Normal,
    End
}

public class MapEvent
{
    public MapEventType mapEventType;
    public string eventMessage;

    public MapEvent(MapEventType type, string message)
    {
        mapEventType = type;
        eventMessage = message;
    }
}

public class Map
{
    public MapNode firstNode;
}
