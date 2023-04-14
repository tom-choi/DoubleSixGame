using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProperty : MonoBehaviour
{
    public PropertiesSheet propertiesSheet;
    public string propertyName = "";
    public string value = "";


    void Awake()
    {
    }
    
    public void SetProperty(string propertyName, string value)
    {
        propertiesSheet.StringDic[propertyName] = value;
    }

    public void SetProperty(string propertyName, int value)
    {
        propertiesSheet.IntDic[propertyName] = value;
    }

    public void SetProperty(string propertyName, float value)
    {
        propertiesSheet.FloatDic[propertyName] = value;
    }
    public void CheckAllPorperty()
    {
        if (this.propertiesSheet.IntDic.Count == 0)
        {
            Debug.Log("propertiesSheet has no properties.");
            return;
        }
        foreach (var property in this.propertiesSheet.IntDic)
        {
            Debug.Log(property.Key + ": " + property.Value.GetType());
        }
    }
    public System.Object GetProperty(string propertyName)
    {
        if (propertiesSheet.IntDic.ContainsKey(propertyName))
        {
            return propertiesSheet.IntDic[propertyName];
        }
        else
        {
            throw new System.Exception("Property " + propertyName + " does not exist.");
        }
    }
}

// AssetDatabase.CreateAsset()

// httpropertiesSheet://docs.unity3d.com/Manual/class-ScriptableObject.html