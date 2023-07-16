
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvent
{
    private GameObject gameController;
    public TestingEvent()
    {
        gameController = GameObject.Find("GameController");
    }
    public string OnSomeoneEnterNode(MapNode node)
    {
        Debug.Log($"Someone at position {node.position}");
        // Add trigger event logic here
        return "OnSomeoneEnterNode";
    }
    public string OnPlayerEnterNode(MapNode node,string name)
    {
        Debug.Log($"{name} at position {node.position}");
        // Add trigger event logic here
        return "OnPlayerEnterNode";
    }
    public string NullMethod(MapNode node)
    {
        // Debug.Log($"This is AnotherMethod()");
        return "NullMethod";
    }
    public string NullMethod(MapNode node,string message)
    {
        // Debug.Log($"This is AnotherMethod()");
        return "NullMethod";
    }
    public string CurrentNodePosition(MapNode node)
    {
        Debug.Log($"{node.position}");
        return "CurrentNodePosition";
    }
    public string RedMethod(MapNode node)
    {
        Debug.Log($"This is RedMethod");
        return "RedMethod";
    }
    public string BlueMethod(MapNode node,string name)
    {
        int result = UnityEngine.Random.Range(1,5);
        gameController.GetComponent<GameController>().IncreasePlayerScore(name,result);
        // Debug.Log($"This is BlueMethod, added {result} Points! (now have {gameController.GetComponent<GameController>().GetPlayerScore(name)})");
        return "BlueMethod";
    }
    public string HelloMethod1(MapNode node, string name)
    {
        return "HelloMethod1";
    }
    public string HelloMethod2(MapNode node, string name)
    {
        return "HelloMethod2";
    }
    public string HelloMethod3(MapNode node, string name)
    {
        return "HelloMethod3";
    }
    public string GreenMethod(MapNode node,string name)
    {
        return "GreenMethod";
    }
}

// In the Property class:
// public class Property
// {
//     public Dictionary<string, object> properties = new Dictionary<string, object>();
// }

// // In the TestingEvent class:
// public class TestingEvent
// {
//     public void ChangePropertyVariable()
//     {
//         // Create an instance of the Property class
//         Property myProperty = new Property();

//         // Add properties to the dictionary
//         myProperty.properties.Add("id", 123);
//         myProperty.properties.Add("name", "My Property");
//         myProperty.properties.Add("price", 1000.0f);
//         myProperty.properties.Add("level", 2);
//         myProperty.properties.Add("owner", "John Doe");
//         myProperty.properties.Add("rent", 50.0f);

//         // Use the modified property as needed
//         Debug.Log($"Property name: {myProperty.properties["name"]}");
//     }
// }
