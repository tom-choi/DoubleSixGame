using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate string MapNodeEvent(MapNode node);
public delegate string MapNodeEventWithMessage(MapNode node, string message);
// newNode.onPlayerEnter += node =>
// {
//     Debug.Log($"Player entered node {node.position}");
//     // 在这里添加触发事件的逻辑
// };

