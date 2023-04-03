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

public delegate void MapNodeEvent(MapNode node);
// newNode.onPlayerEnter += node =>
// {
//     Debug.Log($"Player entered node {node.position}");
//     // 在这里添加触发事件的逻辑
// };



public class MapNode
{
    public Vector3 position;
    public MapNode nextNode;
    public EventType eventType;
    public MapEvent eventInfo;

    // 添加事件委托类型的成员变量
    public MapNodeEvent onPlayerEnter;
    
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
