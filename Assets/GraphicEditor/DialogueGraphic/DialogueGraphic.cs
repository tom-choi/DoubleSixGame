using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

public class DialogueGraphic : EditorWindow {

    [MenuItem("DoubleSixGame/DialogueGraphic")]
    private static void OpenDiaglogeueGraphWindow() 
    {
        var window = GetWindow<DialogueGraphic>();
        window.titleContent = new GUIContent("DialogueGraphic");
        window.Show();
    }
    
    void OnEnable()
    {
        rootVisualElement.Add(new DialogueGraphicView()
        {
          style  = { flexGrow = 1}
        });
    }
    private void OnGUI() {
        
    }
}
