using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;


public class DialogueGraphic : EditorWindow 
{
    private DialogueGraphicView _graphView;
    private string _fileName = "New Narrative";

    [MenuItem("DoubleSixGame/DialogueGraphic")]
    private static void OpenDiaglogeueGraphWindow() 
    {
        var window = GetWindow<DialogueGraphic>();
        window.titleContent = new GUIContent("DialogueGraphic");
    }
    
    private void OnEnable()
    {
        ConstructGraphView();
        GenerateToolbar();
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
    private void GenerateToolbar()
    {
        // https://forum.unity.com/threads/uielements-toolbar-is-innacessible.1275149/
        var toolbar = new UnityEditor.UIElements.Toolbar();

        var fileNameTextField = new TextField("File Name:");
        fileNameTextField.SetValueWithoutNotify(_fileName);
        fileNameTextField.MarkDirtyRepaint();
        fileNameTextField.RegisterValueChangedCallback(evt => _fileName = evt.newValue);
        toolbar.Add(fileNameTextField);
        
        toolbar.Add(new Button(()=>SaveData()){text = "Save Data"});
        toolbar.Add(new Button(()=>LoadData()){text = "Load Data"});

        var nodeCreateButton = new Button( () => {_graphView.CreateNode("Tested");});
        nodeCreateButton.text = "Create Node";
        toolbar.Add(nodeCreateButton);

        rootVisualElement.Add(toolbar);
    }
    private void SaveData()
    {
        throw new NotImplementedException();
    }

    private void LoadData()
    {
        throw new NotImplementedException();
    }

    private void OnDisable() {
        rootVisualElement.Remove(_graphView);
    }

}
