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

public delegate void MapNodeEvent(MapNode node);
// newNode.onPlayerEnter += node =>
// {
//     Debug.Log($"Player entered node {node.position}");
//     // 在这里添加触发事件的逻辑
// };

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
