using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PropertiesSheet", menuName = "Custom/PropertiesSheet")]
public class PropertiesSheet : ScriptableObject
{
    [SerializeField] public Dictionary<string, string> StringDic = new Dictionary<string, string>();
    [SerializeField] public Dictionary<string, int> IntDic = new Dictionary<string, int>();
    [SerializeField] public Dictionary<string, float> FloatDic = new Dictionary<string, float>();
    [SerializeField] public Dictionary<string, bool> BoolDic = new Dictionary<string, bool>();
    PropertiesSheet()
    {
        IntDic["health"] = 100;
        IntDic["speed"] = 10;
        IntDic["damage"] = 20;
    }
}