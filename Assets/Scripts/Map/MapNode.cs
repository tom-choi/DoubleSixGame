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
    public MapEvent[] enterEventInfo = new MapEvent[16];
    public MapEvent[] passEventInfo = new MapEvent[16];
    public int enterEventInfoSize = 0;
    public int passEventInfoSize = 0;
    public void addEvent(EventTriggerType type, MapNodeEventWithMessage func, MapEvent mapEvent = null)
    {
        if (mapEvent == null)
        {
            mapEvent = new MapEvent();
        }
        switch (type)
        {
            case EventTriggerType.Enter:
                this.onPlayerEnter += func;
                this.enterEventInfo[enterEventInfoSize++] = mapEvent;
                break;
            case EventTriggerType.Passed:
                this.onPlayerPassed += func;
                this.passEventInfo[passEventInfoSize++] = mapEvent;
                break;
            default:
                Debug.Log("addEvent() failed! check is EventTriggerType correct");
                break;
        }
    }
    public string GetAllEnterEventInfo()
    {
        string result = "";
        foreach (MapEvent mapEvent in enterEventInfo)
        {
            if (mapEvent != null)
            {
                result += $"{mapEvent.EventName()}: {mapEvent.EventDetail()}\n";
            }
        }
        return result;
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
        MapEvent me = new MapEvent();

        // me = new MapEvent("NullMethod","null");
        // this.addEvent(EventTriggerType.Enter, testingEvent.NullMethod, me);
        // me = new MapEvent("OnPlayerEnterNode","trigger of enter");
        // this.addEvent(EventTriggerType.Enter, testingEvent.OnPlayerEnterNode, me);

        me = new MapEvent("NullMethod","null");
        this.addEvent(EventTriggerType.Passed, testingEvent.NullMethod, me);
        me = new MapEvent("CurrentNodePosition","report current xyz");
        this.addEvent(EventTriggerType.Passed, testingEvent.CurrentNodePosition, me);
    }
}
