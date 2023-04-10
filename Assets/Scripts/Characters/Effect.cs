using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Effect
{
    private int strength;
    private int defense;
    private int speed;
} 

public class Property
{
    public int id;
    public string name;
    public float price;
    public int level;
    public string owner;
    public float rent;

    public Property(int id, string name, float price, int level, string owner, float rent)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.level = level;
        this.owner = owner;
        this.rent = rent;
    }
}

public class Sample
{
    Sample()
    {
        List<Property> properties = new List<Property>();

        // Adding a residential property
        Property property1 = new Property(1, "101", 1000f, 1, null, 50f);
        properties.Add(property1);

        // Adding a commercial property
        Property property2 = new Property(2, "102", 2000f, 1, null, 100f);
        properties.Add(property2);

        // Adding another commercial property
        Property property3 = new Property(3, "103", 3000f, 1, null, 150f);
        properties.Add(property3);
    }
}