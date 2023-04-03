using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    public Vector3 position;
    public MapNode nextNode;
    public EventType eventType;
    public MapEvent eventInfo;

    // 添加事件委托类型的成员变量
    public MapNodeEvent onPlayerEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
