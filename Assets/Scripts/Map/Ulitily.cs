using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

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

public static class MapNodeUtils
{
    public static void ListAllFunctions(MapNode node)
    {
        var type = node.GetType();
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        foreach (MethodInfo method in methods)
        {
            Debug.Log(method.Name);
        }
    }
}