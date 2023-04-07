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

        //SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
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
            title = "START",
            DialogueText = "Hello World",
            GUID = Guid.NewGuid().ToString(),
            EntryPoint = true
        };

        var endNode = new DialogueGraphicNode
        {
            title = "END",
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

    public DialogueGraphicNode GenerateEntryPointNode()
    {
        var node = new DialogueGraphicNode
        {
            title = "Normal",
            DialogueText = "Hello World",
            GUID = Guid.NewGuid().ToString(),
            EntryPoint = true
        };

        var generatePort = GeneratePort(node,Direction.Output);
        generatePort.portName = "Next";
        node.outputContainer.Add(generatePort);

        node.RefreshExpandedState();
        node.RefreshPorts();

        node.SetPosition(new Rect(100,200,100,150));
        return node;
    }
}