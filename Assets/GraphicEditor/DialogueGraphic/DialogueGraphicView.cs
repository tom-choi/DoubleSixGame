using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


public class DialogueGraphicView : GraphView
{
    public DialogueGraphicView() : base()
    {
        Insert(0, new GridBackground());

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        
        GenerateSE();

        nodeCreationRequest += context =>
        {
            AddElement(GenerateEntryPointNode());
        };
    }

    public void CreateNode(string nodeName)
    {
        AddElement(GenerateEntryPointNode());
    }

    private Port GeneratePort(DialogueGraphicNode node, Direction portDirection,Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal,portDirection,capacity,typeof(float)); // Attrabute
    }
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();

        ports.ForEach((port)=>
        {
            if (startPort != port && startPort.node != port.node)
                compatiblePorts.Add(port);
        });

        return compatiblePorts;
    }

    private void GenerateSE()
    {
        var startNode = new DialogueGraphicNode
        {
            title = "開始節點",
            DialogueText = "Hello World",
            GUID = Guid.NewGuid().ToString(),
            EntryPoint = true
        };

        var endNode = new DialogueGraphicNode
        {
            title = "結束節點",
            DialogueText = "Goodbye World",
            GUID = Guid.NewGuid().ToString(),
            EntryPoint = false
        };

        var startPort = GeneratePort(startNode, Direction.Output);
        startPort.portName = "Next";
        startNode.outputContainer.Add(startPort);

        var endPort = GeneratePort(endNode, Direction.Input);
        endPort.portName = "Previous";
        endNode.inputContainer.Add(endPort);

        // Connect the two ports
        var edge = startPort.ConnectTo(endPort);

        startNode.SetPosition(new Rect(100, 200, 100, 150));
        endNode.SetPosition(new Rect(300, 200, 100, 150));

        AddElement(startNode);
        AddElement(endNode);
    }

    private void AddChoicePort(DialogueGraphicNode dialogueGraphicNode)
    {
        var generatePort = GeneratePort(dialogueGraphicNode, Direction.Output);

        var outputPortCount = dialogueGraphicNode.outputContainer.Query("connector").ToList().Count;
        generatePort.portName = $"出口 {outputPortCount}";

        dialogueGraphicNode.outputContainer.Add(generatePort);
        dialogueGraphicNode.RefreshExpandedState();
        dialogueGraphicNode.RefreshPorts();
    }

    public DialogueGraphicNode GenerateEntryPointNode()
    {
        var node = new DialogueGraphicNode
        {
            title = "普通節點",
            DialogueText = "Hello World",
            GUID = Guid.NewGuid().ToString(),
            EntryPoint = true
        };

        var generatePort = GeneratePort(node,Direction.Output);
        generatePort.portName = "出口";
        node.outputContainer.Add(generatePort);

        var InputPort = GeneratePort(node,Direction.Input);
        InputPort.portName = "入口";
        node.inputContainer.Add(InputPort);

        var button = new Button(() => {AddChoicePort(node);});
        button.text = "新增出口";
        node.titleContainer.Add(button);

        node.RefreshExpandedState();
        node.RefreshPorts();

        node.SetPosition(new Rect(100,200,100,150));
        return node;
    }
}