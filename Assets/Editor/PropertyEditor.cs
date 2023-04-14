using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomProperty))]
public class CustomPropertyEditor : Editor
{
    string[] DataType = new string[] { "String", "Int", "Float" };
    int selectedIndex = 0;
    private CustomProperty customProperty;
    private SerializedObject propertyObject;
    private SerializedProperty propertyName;
    private SerializedProperty value;

    private void OnEnable()
    {
        this.customProperty = (CustomProperty)target;
        this.propertyObject = new SerializedObject(target);

        this.propertyName = propertyObject.FindProperty("propertyName");
        this.value = propertyObject.FindProperty("value");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CustomProperty customProperty = (CustomProperty)target;

        // if (GUILayout.Button("Check All Properties"))
        // {
        //     customProperty.CheckAllPorperty();
        // }

        GUILayout.Space(10);

        GUILayout.Label("Set Property:");

        selectedIndex = EditorGUILayout.Popup("DataType", selectedIndex, DataType);
        EditorGUILayout.PropertyField(propertyName);
        EditorGUILayout.PropertyField(value);

        if (GUILayout.Button("Set"))
        {
            string datatype = DataType[selectedIndex];
            switch (datatype)
            {
                case "String":
                    customProperty.SetProperty(propertyName.stringValue, value.stringValue);
                    break;
                case "Int":
                    customProperty.SetProperty(propertyName.stringValue, value.intValue);
                    break;
                case "Float":
                    customProperty.SetProperty(propertyName.stringValue, value.floatValue);
                    break;
            }
        }

        GUILayout.Space(10);

        GUILayout.Label("Get Property:");

        // propertyName = EditorGUILayout.TextField("Name", "");

        if (GUILayout.Button("Get"))
        {
            // object value = customProperty.GetProperty<object>(propertyName);

            // if (value != null)
            // {
            //     EditorGUILayout.LabelField("Value", value.ToString());
            // }
        }
    }
}