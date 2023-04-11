using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class MMap : MonoBehaviour
{
    public MapNode firstNode;
    public MapNode[,] nodes = new MapNode[30, 30];
    private int nodeCount = 0;
    
    //其他属性和方法
    public GameObject bBasePrefab;
    public GameObject mapObject;

    public int selectedMap = 1; // default to Map1
    public String MapPassword = "R10F10L5B5L5";

    void Awake()
    {
        // GenerateMap();
        GenerateMap(MapPassword);
    }

    public void AddNode(MapNode newNode, int x, int z)
    {
        nodes[x, z] = newNode;
    }

    // back	Shorthand for writing Vector3(0, 0, -1).
    // down	Shorthand for writing Vector3(0, -1, 0).
    // forward	Shorthand for writing Vector3(0, 0, 1).
    // left	Shorthand for writing Vector3(-1, 0, 0).
    // one	Shorthand for writing Vector3(1, 1, 1).
    // right	Shorthand for writing Vector3(1, 0, 0).
    // up	Shorthand for writing Vector3(0, 1, 0).
    // zero	Shorthand for writing Vector3(0, 0, 0).

    // seldom use
    // positiveInfinity	Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).
    // negativeInfinity	Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).

    private MapNode Map1(MapNode currentNode)
    {
        currentNode = CreateNodes(currentNode, Vector3.right, 10);
        currentNode = CreateNodes(currentNode, Vector3.forward, 10);
        currentNode = CreateNodes(currentNode, Vector3.left, 10);
        currentNode = CreateNodes(currentNode, Vector3.back, 9);
        return currentNode;
    }

    private MapNode Map2(MapNode currentNode)
    {
        currentNode = CreateNodes(currentNode, Vector3.right, 10);
        currentNode = CreateNodes(currentNode, Vector3.forward, 10);
        return currentNode;
    }

    private MapNode Map3(MapNode currentNode)
    {
        currentNode = CreateNodes(currentNode, Vector3.right, UnityEngine.Random.Range(1, 5));
        currentNode = CreateNodes(currentNode, Vector3.forward, UnityEngine.Random.Range(1, 5));
        currentNode = CreateNodes(currentNode, Vector3.right, UnityEngine.Random.Range(1, 5));
        currentNode = CreateNodes(currentNode, Vector3.forward, UnityEngine.Random.Range(1, 5));

        return currentNode;
    }
    
    private MapNode DecodeMapPassword(MapNode currentNode, string password)
    {
  
        string pattern = "^[BDFLORUZ]\\d+$";
        if (Regex.IsMatch(password, pattern))
        {
            throw new ArgumentException("Invalid password format");
        }

        int i = 0;
        foreach (Match match in Regex.Matches(password, @"[BDFLORUZ]\d+"))
        {
            string direction = match.Value.Substring(0, 1);
            int distance = int.Parse(match.Value.Substring(1));
            switch(direction)
            {
                case "B":
                    currentNode = CreateNodes(currentNode, Vector3.back, distance);
                    break;
                case "D":
                    currentNode = CreateNodes(currentNode, Vector3.down, distance);
                    break;
                case "F":
                    currentNode = CreateNodes(currentNode, Vector3.forward, distance);
                    break;
                case "L":
                    currentNode = CreateNodes(currentNode, Vector3.left, distance);
                    break;
                case "O":
                    currentNode = CreateNodes(currentNode, Vector3.one, distance);
                    break;
                case "R":
                    currentNode = CreateNodes(currentNode, Vector3.right, distance);
                    break;
                case "U":
                    currentNode = CreateNodes(currentNode, Vector3.up, distance);
                    break;
                case "Z":
                    currentNode = CreateNodes(currentNode, Vector3.zero, distance);
                    break;
            }
            // Debug.Log(match.Value);
        }
        return currentNode;
    }

    public bool GenerateMap()
    {
        ClearMap();

        //创建第一个节点
        firstNode = CreateFirstNodes();
        MapNode currentNode = firstNode;

        // 根据用户选择的地图生成节点
        switch (selectedMap)
        {
            case 1:
                currentNode = Map1(currentNode);
                break;
            case 2:
                currentNode = Map2(currentNode);
                break;
            case 3:
                currentNode = Map3(currentNode);
                break;
            default:
                Debug.LogError("Invalid map selection!");
                return false;
        }

        //创建最后一个节点，默認循環
        MapNode lastNode = firstNode;
        InstantiateAndRename(bBasePrefab, currentNode.position, mapObject.transform,
        "({0},{1})", (int)currentNode.position.x, (int)currentNode.position.z);
        currentNode.AddNodeInNextNodes(lastNode,0);
        lastNode.AddNodeInPreNodes(currentNode,0);
        AddNode(lastNode,(int)lastNode.position.x, (int)lastNode.position.z);

        return true;
    }
    
    public bool GenerateMap(string password)
    {
        ClearMap();

        //创建第一个节点
        firstNode = CreateFirstNodes();
        MapNode currentNode = firstNode;

        // 根据密碼生成节点
        currentNode = DecodeMapPassword(currentNode,password);

        //创建最后一个节点，默認循環
        MapNode lastNode = firstNode;
        InstantiateAndRename(bBasePrefab, currentNode.position, mapObject.transform,
        "({0},{1})", (int)currentNode.position.x, (int)currentNode.position.z);
        currentNode.AddNodeInNextNodes(lastNode,0);
        lastNode.AddNodeInPreNodes(currentNode,0);
        AddNode(lastNode,(int)lastNode.position.x, (int)lastNode.position.z);

        return true;
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
            switch (node.eventInfo.mapEventType)
            {
                case MapEventType.Start:
                    Debug.Log("Starting event: " + node.eventInfo.eventMessage);
                    break;
                case MapEventType.Normal:
                    Debug.Log("Normal event: " + node.eventInfo.eventMessage);
                    break;
                case MapEventType.End:
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
        firstNode.mapEventType = MapEventType.Start;
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
                newNode.mapEventType = MapEventType.Normal;
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

    private MapNode CreateNodes(MapNode currentNode, Vector3 nodeIncrements, int nodeCount)
    {
        for (int i = 0; i < nodeCount; i++)
        {
            MapNode newNode = new MapNode();
            newNode.position = currentNode.position + nodeIncrements;
            newNode.mapEventType = MapEventType.Normal;
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
        return currentNode;
    }

    private void InstantiateAndRename(GameObject prefab, Vector3 position,Transform parentTransform, string nameFormat, int i, int j)
    {
        GameObject instance = Instantiate(prefab, position, Quaternion.identity, parentTransform);
        instance.name = string.Format(nameFormat, i, j);

        // Add code here to find the instance named "GameController"
        GameObject gameController = GameObject.Find("GameController");

        // Set default color to red
        instance.GetComponent<Renderer>().material = gameController.GetComponent<GameController>().GetFirstMaterials();
        

        // Set random rainbow color
        // Color[] rainbowColors = new Color[] { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, Color.white };

        instance.GetComponent<Renderer>().material = gameController.GetComponent<GameController>().GetRandomMaterials();

        
        // Add code here to change the color of the gameobject instance
    }
}