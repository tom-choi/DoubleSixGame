using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMap : MonoBehaviour
{
    
    public MapNode firstNode;
    public MapNode[,] nodes = new MapNode[30, 30];
    private int nodeCount = 0;
    //其他属性和方法
    public GameObject bBasePrefab;
    public GameObject mapObject;

    void Awake()
    {
        GenerateMap();
    }

    public void AddNode(MapNode newNode, int x, int z)
    {
        nodes[x, z] = newNode;
    }

    private MapNode Map1(MapNode currentNode)
    {
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(1, 0, 0) }, 10);
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(0, 0, 1) }, 10);
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(-1, 0, 0) }, 10);
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(0, 0, -1) }, 9);
        return currentNode;
    }

    public void GenerateMap()
    {
        ClearMap();

        //创建第一个节点
        firstNode = CreateFirstNodes();
        MapNode currentNode = firstNode;

        // 创建其余的节点
        currentNode = Map1(currentNode);

        //创建最后一个节点
        MapNode lastNode = firstNode;
        InstantiateAndRename(bBasePrefab, currentNode.position, mapObject.transform,
        "({0},{1})", (int)currentNode.position.x, (int)currentNode.position.z);
        currentNode.AddNodeInNextNodes(lastNode,0);
        lastNode.AddNodeInPreNodes(currentNode,0);
        AddNode(lastNode,(int)lastNode.position.x, (int)lastNode.position.z);
    }

    public void ClearMap()
    {
        // 删除所有子对象
        for (int i = mapObject.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = mapObject.transform.GetChild(i).gameObject;
            DestroyImmediate(child);
        }
        // 清空地图数据
        firstNode = null;
        nodeCount = 0;
    }

    public void OnNodeReached(MapNode node)
    {
        if (node.eventInfo != null)
        {
            switch (node.eventInfo.eventType)
            {
                case EventType.Start:
                    Debug.Log("Starting event: " + node.eventInfo.eventMessage);
                    break;
                case EventType.Normal:
                    Debug.Log("Normal event: " + node.eventInfo.eventMessage);
                    break;
                case EventType.End:
                    Debug.Log("Ending event: " + node.eventInfo.eventMessage);
                    break;
                default:
                    break;
            }
        }
    }

    //创建第一个节点
    private MapNode CreateFirstNodes()
    {
        firstNode = new MapNode();
        firstNode.position = mapObject.transform.position;
        firstNode.eventType = EventType.Start;
        nodeCount = 1;
        // 创建 BBase 物体的副本，并将其放置在节点的位置
        InstantiateAndRename(bBasePrefab, firstNode.position, mapObject.transform,
        "({0},{1})", (int)firstNode.position.x, (int)firstNode.position.z);
        AddNode(firstNode,(int)firstNode.position.x, (int)firstNode.position.z);
        return firstNode;
    }    
    //其他方法
    private MapNode CreateNodes(MapNode currentNode, Vector3[] nodeIncrements, int nodeCount)
    {
        foreach (Vector3 increment in nodeIncrements)
        {
            for (int i = 0; i < nodeCount; i++)
            {
                MapNode newNode = new MapNode();
                newNode.position = currentNode.position + increment;
                newNode.eventType = EventType.Normal;
                InstantiateAndRename(bBasePrefab, currentNode.position, mapObject.transform,
                    "({0},{1})", (int)currentNode.position.x, (int)currentNode.position.z);
                
                // connect
                AddNode(newNode,(int)currentNode.position.x, (int)currentNode.position.z);
                currentNode.AddNodeInNextNodes(newNode,0);
                newNode.AddNodeInPreNodes(currentNode,0);
                
                // reset
                currentNode = newNode;
                this.nodeCount++;
            }
        }
        return currentNode;
    }

    private void InstantiateAndRename(GameObject prefab, Vector3 position,Transform parentTransform, string nameFormat, int i, int j)
    {
        GameObject instance = Instantiate(prefab, position, Quaternion.identity, parentTransform);
        instance.name = string.Format(nameFormat, i, j);

        // Set default color to red
        instance.GetComponent<Renderer>().material.color = Color.red;

        // Set random rainbow color
        Color[] rainbowColors = new Color[] { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, Color.white };
        int randomColorIndex = Random.Range(0, rainbowColors.Length);
        instance.GetComponent<Renderer>().material.color = rainbowColors[randomColorIndex];

        
        // Add code here to change the color of the gameobject instance
    }
}