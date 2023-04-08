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

    public readonly Vector2 DefaultNodeSize = new Vector2(200, 150);
    public readonly Vector2 DefaultCommentBlockSize = new Vector2(300, 200);
    public List<ExposedProperty> ExposedProperties { get; private set; } = new List<ExposedProperty>();

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

    public DialogueGraphicNode CreateNode(string nodeName, Vector2 position)
    {
        var tempDialogueNode = new DialogueGraphicNode()
        {
            title = nodeName,
            DialogueText = nodeName,
            GUID = Guid.NewGuid().ToString()
        };
        tempDialogueNode.styleSheets.Add(Resources.Load<StyleSheet>("Node"));
        var inputPort = GetPortInstance(tempDialogueNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input";
        tempDialogueNode.inputContainer.Add(inputPort);
        tempDialogueNode.RefreshExpandedState();
        tempDialogueNode.RefreshPorts();
        tempDialogueNode.SetPosition(new Rect(position,
            DefaultNodeSize)); //To-Do: implement screen center instantiation positioning

        var textField = new TextField("");
        textField.RegisterValueChangedCallback(evt =>
        {
            tempDialogueNode.DialogueText = evt.newValue;
            tempDialogueNode.title = evt.newValue;
        });
        textField.SetValueWithoutNotify(tempDialogueNode.title);
        tempDialogueNode.mainContainer.Add(textField);

        var button = new Button(() => { AddChoicePort(tempDialogueNode); })
        {
            text = "Add Choice"
        };
        tempDialogueNode.titleButtonContainer.Add(button);
        return tempDialogueNode;
    }

    public Group CreateCommentBlock(Rect rect, CommentBlockData commentBlockData = null)
    {
        if(commentBlockData==null)
            commentBlockData = new CommentBlockData();
        var group = new Group
        {
            autoUpdateGeometry = true,
            title = commentBlockData.Title
        };
        AddElement(group);
        group.SetPosition(rect);
        return group;
    }

    private Port GetPortInstance(DialogueGraphicNode node, Direction nodeDirection,
            Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, nodeDirection, capacity, typeof(float));
    }

    private Port GeneratePort(DialogueGraphicNode node, Direction portDirection,Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal,portDirection,capacity,typeof(float)); // Attrabute
    }

    private void RemovePort(Node node, Port socket)
    {
        var targetEdge = edges.ToList()
            .Where(x => x.output.portName == socket.portName && x.output.node == socket.node);
        if (targetEdge.Any())
        {
            var edge = targetEdge.First();
            edge.input.Disconnect(edge);
            RemoveElement(targetEdge.First());
        }

        node.outputContainer.Remove(socket);
        node.RefreshPorts();
        node.RefreshExpandedState();
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

    public void AddChoicePort(DialogueGraphicNode dialogueGraphicNode)
    {
        var generatePort = GeneratePort(dialogueGraphicNode, Direction.Output);

        var outputPortCount = dialogueGraphicNode.outputContainer.Query("connector").ToList().Count;
        generatePort.portName = $"出口 {outputPortCount}";

        dialogueGraphicNode.outputContainer.Add(generatePort);
        dialogueGraphicNode.RefreshExpandedState();
        dialogueGraphicNode.RefreshPorts();
    }

    public void AddChoicePort(DialogueGraphicNode nodeCache, string overriddenPortName = "")
    {
        var generatedPort = GetPortInstance(nodeCache, Direction.Output);
        var portLabel = generatedPort.contentContainer.Q<Label>("type");
        generatedPort.contentContainer.Remove(portLabel);

        var outputPortCount = nodeCache.outputContainer.Query("connector").ToList().Count();
        var outputPortName = string.IsNullOrEmpty(overriddenPortName)
            ? $"Option {outputPortCount + 1}"
            : overriddenPortName;


        var textField = new TextField()
        {
            name = string.Empty,
            value = outputPortName
        };
        textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);
        generatedPort.contentContainer.Add(new Label("  "));
        generatedPort.contentContainer.Add(textField);
        var deleteButton = new Button(() => RemovePort(nodeCache, generatedPort))
        {
            text = "X"
        };
        generatedPort.contentContainer.Add(deleteButton);
        generatedPort.portName = outputPortName;
        nodeCache.outputContainer.Add(generatedPort);
        nodeCache.RefreshPorts();
        nodeCache.RefreshExpandedState();
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