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
        
        nodeCreationRequest += context =>
        {
            AddElement(new DialogueGraphicNode());
        };


    }
}