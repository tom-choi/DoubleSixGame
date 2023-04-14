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
    public static int ChebyshevDistance(MapNode node1, MapNode node2)
    {
        int dx = Mathf.Abs((int)node1.position.x - (int)node2.position.x);
        int dy = Mathf.Abs((int)node1.position.y - (int)node2.position.y);
        return Mathf.Max(dx, dy);
    }
    
}