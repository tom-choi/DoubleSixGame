using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MMap))]
public class MMapEditor : Editor
{
    private MMap mMap;
    private SerializedObject mMapObject;

    private SerializedProperty bBasePrefabProp;
    private SerializedProperty mapObjectProp;

    private void OnEnable()
    {
        mMap = (MMap)target;
        mMapObject = new SerializedObject(target);

        bBasePrefabProp = mMapObject.FindProperty("bBasePrefab");
        mapObjectProp = mMapObject.FindProperty("mapObject");
    }

    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        // DrawDefaultInspector();

        // Draw a separator
        EditorGUILayout.Space();

        // Draw the properties we want to modify
        EditorGUILayout.PropertyField(bBasePrefabProp);
        EditorGUILayout.PropertyField(mapObjectProp);

        // Draw a separator
        EditorGUILayout.Space();

        // Draw the button to generate the map
        if (GUILayout.Button("Generate Map"))
        {
            mMap.GenerateMap();
        }
        if (GUILayout.Button("Clear Map"))
        {
            mMap.ClearMap();
        }

        // Apply any changes to the serializedObject
        mMapObject.ApplyModifiedProperties();
    }
}
