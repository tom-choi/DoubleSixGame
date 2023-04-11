using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestingSS))]
public class NameDisplayer : Editor
{
    private void OnSceneGUI()
    {
        TestingSS testingSS = (TestingSS)target;

        // Display text above selected object
        Handles.Label(testingSS.transform.position + Vector3.up * 2.0f, testingSS.gameObject.name);
    }
}