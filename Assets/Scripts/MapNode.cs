using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    public Vector3 position;

    public Dictionary<MapNode, int> nextNodes = new Dictionary<MapNode, int>();
    public Dictionary<MapNode, int> preNodes = new Dictionary<MapNode, int>();
    public EventType eventType;
    public MapEvent eventInfo;

    public void AddNodeInNextNodes(MapNode node,int level)
    {
        nextNodes.Add(node,level);
    }

    public void AddNodeInPreNodes(MapNode node,int level)
    {
        preNodes.Add(node,level);
    }

    public bool NextNodesIsEmpty()
    {
        return nextNodes.Count == 0;
    }

    public bool PreNodesIsEmpty()
    {
        return preNodes.Count == 0;
    }
    public List<MapNode> ReConstractDict()
    {
        List<MapNode> nodeList = new List<MapNode>(nextNodes.Keys);
        return nodeList;
    }
    public MapNode GetRandomNextNode()
    {
        if (NextNodesIsEmpty())
        {
            return null;
        }
        List<MapNode> nodeList = ReConstractDict();
        int randomIndex = Random.Range(0, nodeList.Count);
        return nodeList[randomIndex];
    }


    // 添加事件委托类型的成员变量
    public MapNodeEvent onPlayerEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
