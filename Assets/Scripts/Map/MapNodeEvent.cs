using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MapNodeEvent(MapNode node);
public delegate void MapNodeEventWithMessage(MapNode node, string message);
// newNode.onPlayerEnter += node =>
// {
//     Debug.Log($"Player entered node {node.position}");
//     // 在这里添加触发事件的逻辑
// };
public class MapEvent
{
    public MapEventType mapEventType;
    public string eventMessage;
    public string mapEventTypeInString;
    

    public MapEvent(MapEventType type, string message,string metis)
    {
        mapEventType = type;
        eventMessage = message;
        mapEventTypeInString = metis;
    }
}

public class namingmapevent
{
    // Creating a MapEvent instance with type MapEventType.EnemyEncounter and a custom message
    MapEvent enemyEncounterEvent = new MapEvent(MapEventType.EnemyEncounter, "An enemy has appeared!", "EnemyEncounter");

    // Creating a MapEvent instance with type MapEventType.TreasureFound and a custom message
    MapEvent treasureFoundEvent = new MapEvent(MapEventType.TreasureFound, "You found a treasure chest!", "TreasureFound");

    // Creating a MapEvent instance with type MapEventType.Dialogue and a custom message
    MapEvent dialogueEvent = new MapEvent(MapEventType.Dialogue, "A character approaches you and starts talking.", "Dialogue");
}

