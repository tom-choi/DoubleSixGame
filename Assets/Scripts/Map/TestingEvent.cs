using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvent
{
    public void OnSomeoneEnterNode(MapNode node)
    {
        Debug.Log($"Someone at position {node.position}");
        // Add trigger event logic here
    }
    public void OnPlayerEnterNode(MapNode node,string name)
    {
        Debug.Log($"{name} at position {node.position}");
        // Add trigger event logic here
    }
    public void AnotherMethod(MapNode node)
    {
        // Debug.Log($"This is AnotherMethod()");
    }
    public void CurrentNodePosition(MapNode node)
    {
        Debug.Log($"{node.position}");
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
