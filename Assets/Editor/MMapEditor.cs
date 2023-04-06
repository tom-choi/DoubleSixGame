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

    private void OnSceneGUI()
    {
        // Draw a grid handle at the position of the grid point
        Vector3 gridPoint = new Vector3(1, 0, 1);
        Handles.DrawWireDisc(gridPoint, Vector3.up, 0.1f);

        // Check if the grid point has been clicked
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.point == gridPoint)
                {
                    // Code to execute when the grid point is clicked
                    Debug.Log("Handles.DrawWireDisc");
                }
            }
        }
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
            if (mMap.mapObject == null)
            {
                EditorGUILayout.HelpBox("Map object is null!", MessageType.Error);
                return;
            }
            mMap.GenerateMap();
        }
        if (GUILayout.Button("Clear Map"))
        {
            mMap.ClearMap();
        }
        // Draw the property to modify the selected map
        EditorGUILayout.PropertyField(mMapObject.FindProperty("selectedMap"));

        // Apply any changes to the serializedObject
        mMapObject.ApplyModifiedProperties();
    }
}
