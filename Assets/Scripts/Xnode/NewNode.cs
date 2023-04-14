using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class NewNode : Node {

	// Use this for initialization
	[Input] public float value;
    [Output] public float result;

    public override object GetValue(NodePort port) {
        // Check which output is being requested. 
        // In this node, there aren't any other outputs than "result".
        if (port.fieldName == "result") {
            // Return input value + 1
            return GetInputValue<float>("value", this.value) + 1;
        }
        // Hopefully this won't ever happen, but we need to return something
        // in the odd case that the port isn't "result"
        else return null;
    }
}