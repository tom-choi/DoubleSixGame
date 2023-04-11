using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MMap))]
public class MMapEditor : Editor
{
    private MMap mMap;
    private SerializedObject mMapObject;

    private SerializedProperty bBasePrefabProp;
    private SerializedProperty mapObjectProp;
    private int selectedMap = 0;
    private string[] options = new string[] { "Default Map", "Custom Map", "Placeholder" };
    public string inputFieldValue = "R5F3L4B2";
    
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

        // Selected 
        selectedMap = EditorGUILayout.Popup("Select Map", selectedMap, options);

        // Draw the button to generate the map
        // Default
        switch(selectedMap)
        {
            case 0:
            {
                if (GUILayout.Button("Generate Map"))
                {
                    if (mMap.mapObject == null)
                    {
                        EditorGUILayout.HelpBox("Map Container is null!", MessageType.Error);
                        return;
                    }
                    if (!mMap.GenerateMap())
                    {
                        EditorGUILayout.HelpBox("GenerateMap failed! check your Debug.LogError", MessageType.Error);
                    }
                }
                if (GUILayout.Button("Clear Map"))
                {
                    mMap.ClearMap();
                }
                // Draw the property to modify the selected map
                EditorGUILayout.PropertyField(mMapObject.FindProperty("selectedMap"));
                break;
            }
            case 1:
            {
                // Draw the input field in the editor
                mMapObject.FindProperty("MapPassword").stringValue = 
                EditorGUILayout.TextField("Map Password", mMapObject.FindProperty("MapPassword").stringValue); //MapPassword

                var mapPassword = mMapObject.FindProperty("MapPassword").stringValue;
                // Use the input field value in your code as needed
                // For example, you could use it to set a property value:
                // mMapObject.FindProperty("myProperty").stringValue = mapPassword;
                if (GUILayout.Button("Generate Map"))
                {
                    if (mMap.mapObject == null)
                    {
                        EditorGUILayout.HelpBox("Map Container is null!", MessageType.Error);
                        return;
                    }
                    if (!mMap.GenerateMap(mapPassword))
                    {
                        EditorGUILayout.HelpBox("GenerateMap failed! check your Debug.LogError", MessageType.Error);
                    }
                }
                if (GUILayout.Button("Clear Map"))
                {
                    mMap.ClearMap();
                }
                break;
            }
            default:
                break;

        }
        // Custom
        // if (GUILayout.Button("Generate Map"))
        // {
        //     if (mMap.mapObject == null)
        //     {
        //         EditorGUILayout.HelpBox("Map Container is null!", MessageType.Error);
        //         return;
        //     }
        //     mMap.GenerateMap();
        // }

        switch(selectedMap)
        {
            case 0:
            {
                GUILayout.Label("Default Map Info");
                break;
            }
            case 1:
            {
                GUILayout.Label("Custom Map Info");
                GUILayout.Label("back	Shorthand for writing Vector3(0, 0, -1).");
                GUILayout.Label("down	Shorthand for writing Vector3(0, -1, 0).");
                GUILayout.Label("forward	Shorthand for writing Vector3(0, 0, 1).");
                GUILayout.Label("left	Shorthand for writing Vector3(-1, 0, 0).");
                GUILayout.Label("one	Shorthand for writing Vector3(1, 1, 1).");
                GUILayout.Label("right	Shorthand for writing Vector3(1, 0, 0).");
                GUILayout.Label("up	Shorthand for writing Vector3(0, 1, 0).");
                GUILayout.Label("zero	Shorthand for writing Vector3(0, 0, 0).");
                break;
            }
            case 2:
            {
                GUILayout.Label("Placeholder Info");
                break;
            }
        }

        // Apply any changes to the serializedObject
        mMapObject.ApplyModifiedProperties();
    }
}

public class MyWindow : EditorWindow{
    //private string myText = "This class is responsible for creating and modifying maps in the DoubleSixGame game.";

    private Vector2 scrollPos;

    [MenuItem("Window/DoubleSixGame/SubOption1")]
    public static void ShowWindowSubOption1()
    {
        MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        window.titleContent = new GUIContent("DoubleSixGame");
        window.Show();
    }

    [MenuItem("Window/DoubleSixGame/SubOption2")]
    public static void ShowWindowSubOption2()
    {
        MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        window.titleContent = new GUIContent("DoubleSixGame");
        window.Show();
    }
    
    private void OnGUI()
    {
        GUILayout.Label("DoubleSixGame", EditorStyles.boldLabel);

        // Create a scrollable view
        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true),
         GUILayout.MaxWidth(2000), GUILayout.MaxHeight(2000),
          GUILayout.MinWidth(200), GUILayout.MinHeight(200));

        // Draw the nodes and connections
        GUI.Box(new Rect(0, 0, 50, 50), "Node 1");
        GUI.Box(new Rect(150, 150, 50, 50), "Node 2");
        Handles.DrawLine(new Vector3(25, 25), new Vector3(175, 175));

        // End the scrollable view
        GUILayout.EndScrollView();
    }
}
