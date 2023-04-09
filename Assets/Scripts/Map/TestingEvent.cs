using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvent
{
    public void OnPlayerEnterNode(MapNode node)
    {
        Debug.Log($"Player entered node {node.position}");
        // Add trigger event logic here
    }
    public void AnotherMethod(MapNode node)
    {
        Debug.Log($"This is AnotherMethod()");
    }
}
