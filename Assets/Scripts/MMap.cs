using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMap : MonoBehaviour
{
    public MapNode firstNode;
    private int nodeCount;
    //其他属性和方法
    public GameObject bBasePrefab;
    public GameObject mapObject;

    public void GenerateMap()
    {
        //创建第一个节点
        firstNode = new MapNode();
        firstNode.position = transform.position;
        firstNode.eventType = EventType.Start;
        MapNode currentNode = firstNode;
        nodeCount = 1;
        // 创建 BBase 物体的副本，并将其放置在节点的位置
        InstantiateAndRename(bBasePrefab, currentNode.position, mapObject.transform,
        "({0},{1})", (int)currentNode.position.x, (int)currentNode.position.z);


        // 创建其余的节点
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(1, 0, 0) }, 10);
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(0, 0, 1) }, 10);
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(-1, 0, 0) }, 10);
        currentNode = CreateNodes(currentNode, new Vector3[] { new Vector3(0, 0, -1) }, 9);

        //创建最后一个节点
        MapNode lastNode = firstNode;
        InstantiateAndRename(bBasePrefab, currentNode.position, mapObject.transform,
        "({0},{1})", (int)currentNode.position.x, (int)currentNode.position.z);
        currentNode.nextNode = lastNode;
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
                currentNode.nextNode = newNode;
                currentNode = newNode;
                this.nodeCount++;
            }
        }
        return currentNode;
    }
    private void InstantiateAndRename(GameObject prefab, Vector3 position, Transform parentTransform, string nameFormat, int i, int j)
    {
        GameObject instance = Instantiate(prefab, position, Quaternion.identity, parentTransform);
        instance.name = string.Format(nameFormat, i, j);
    }

}