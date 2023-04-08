using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DialogueGraphicNode : Node
{
    public string GUID;

    public string DialogueText;

    public bool EntryPoint = false;
    public DialogueGraphicNode()
    {
        DialogueText = "Sample";
        title = DialogueText;
 
        var inputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(Port));
        inputContainer.Add(inputPort);
 
        var outputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(Port));
        outputContainer.Add(outputPort);
    }
}