using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class PropertyEditor : EditorWindow
{
    private int id;
    private string name;
    private float price;
    private int level;
    private string owner;
    private float rent;

    private List<Property> properties = new List<Property>();

    [MenuItem("Window/Property Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(PropertyEditor));
    }

    void OnGUI()
    {
        GUILayout.Label("Add New Property", EditorStyles.boldLabel);

        id = EditorGUILayout.IntField("ID", id);
        name = EditorGUILayout.TextField("Name", name);
        price = EditorGUILayout.FloatField("Price", price);
        level = EditorGUILayout.IntField("Level", level);
        owner = EditorGUILayout.TextField("Owner", owner);
        rent = EditorGUILayout.FloatField("Rent", rent);

        if (GUILayout.Button("Add Property"))
        {
            Property newProperty = new Property(id, name, price, level, owner, rent);
            properties.Add(newProperty);

            id = 0;
            name = "";
            price = 0f;
            level = 0;
            owner = "";
            rent = 0f;
        }

        GUILayout.Space(20);

        GUILayout.Label("Properties", EditorStyles.boldLabel);

        foreach (Property property in properties)
        {
            GUILayout.Label(property.name);
        }
    }
}