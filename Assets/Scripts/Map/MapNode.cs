using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapNode
{
    public Vector3 position;
    public string GUID;
    public Dictionary<MapNode, int> nextNodes = new Dictionary<MapNode, int>();
    public Dictionary<MapNode, int> preNodes = new Dictionary<MapNode, int>();
    public MapEvent[] eventInfo;

    public void AddNodeInNextNodes(MapNode node,int level)
    {
        nextNodes.Add(node,level);
    }
    public void AddNodeInPreNodes(MapNode node,int level)
    {
        preNodes.Add(node,level);
    }
    public void RemoveNodeFromNextNodes(MapNode node)
    {
        if (nextNodes.ContainsKey(node))
        {
            nextNodes.Remove(node);
        }
    }
    public void RemoveNodeFromPreNodes(MapNode node)
    {
        if (preNodes.ContainsKey(node))
        {
            preNodes.Remove(node);
        }
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
        int randomIndex = UnityEngine.Random.Range(0, nodeList.Count);
        return nodeList[randomIndex];
    }

    // 添加事件委托类型的成员变量，當玩家進入地塊的時候
    private MapNodeEventWithMessage onPlayerEnter;
    private MapNodeEventWithMessage onPlayerPassed;
    public void addEvent(EventTriggerType type, MapNodeEventWithMessage func)
    {
        switch (type)
        {
            case EventTriggerType.Enter:
                this.onPlayerEnter += func;
                break;
            case EventTriggerType.Passed:
                this.onPlayerPassed += func;
                break;
            default:
                Debug.Log("addEvent failed! check is EventTriggerType correct");
                break;
        }
    }
    
    // can input some details(messages) depends on according event
    public string PlayerEntered(string details)
    {
        string ret = "";
        if (onPlayerEnter != null)
        {
            ret = onPlayerEnter(this,details);
        }
        return ret;
    }

    // can input some details(messages) depends on according event
    public string PlayerPassed(string details)
    {
        string ret = "";
        if (onPlayerPassed != null)
        {
            ret = onPlayerPassed(this,details);
        }
        return ret;
    }

    public MapNode()
    {
        this.GUID = Guid.NewGuid().ToString();
        TestingEvent testingEvent = new TestingEvent();

        this.addEvent(EventTriggerType.Enter, testingEvent.NullMethod);
        this.addEvent(EventTriggerType.Enter, testingEvent.OnPlayerEnterNode);

        this.addEvent(EventTriggerType.Passed, testingEvent.NullMethod);
        this.addEvent(EventTriggerType.Passed, testingEvent.CurrentNodePosition);
    }
}
