using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProperty
{
    public Dictionary<string, object> properties = new Dictionary<string, object>();
}

// [CreateAssetMenu(fileName = "New Custom Property", menuName = "Custom Property")]
// public class CustomPropertyObject : ScriptableObject
// {
//     public CustomProperty customProperty;
// }

// AssetDatabase.CreateAsset()

// https://docs.unity3d.com/Manual/class-ScriptableObject.html