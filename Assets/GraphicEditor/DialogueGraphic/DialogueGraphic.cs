using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

public class DialogueGraphic : EditorWindow 
{
    private DialogueGraphicView _graphView;

    [MenuItem("DoubleSixGame/DialogueGraphic")]
    private static void OpenDiaglogeueGraphWindow() 
    {
        var window = GetWindow<DialogueGraphic>();
        window.titleContent = new GUIContent("DialogueGraphic");
        window.Show();
    }
    
    private void OnEnable()
    {
        ConstructGraphView();
    }
    private void ConstructGraphView()
    {
        _graphView = new DialogueGraphicView()
        {
          style  = { flexGrow = 1}
        };

        //_graphView.StretchToParentSize();
        rootVisualElement.Add(_graphView);
    }
    private void OnDisable() {
        rootVisualElement.Remove(_graphView);
    }

}
