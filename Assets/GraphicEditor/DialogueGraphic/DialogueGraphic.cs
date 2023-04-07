using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;

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
        
        toolbar.Add(new Button(()=>RequestDataOperation(true)){text = "Save Data"});
        toolbar.Add(new Button(()=>RequestDataOperation(false)){text = "Load Data"});

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

    private void RequestDataOperation(bool save)
    {
        if (!string.IsNullOrEmpty(_fileName))
        {
            var saveUtility = GraphSaveUtility.GetInstance(_graphView);
            if (save)
                saveUtility.SaveGraph(_fileName);
            else
                saveUtility.LoadNarrative(_fileName);
        }
        else
        {
            EditorUtility.DisplayDialog("Invalid File name", "Please Enter a valid filename", "OK");
        }
    }

    private void OnDisable() {
        rootVisualElement.Remove(_graphView);
    }

}
