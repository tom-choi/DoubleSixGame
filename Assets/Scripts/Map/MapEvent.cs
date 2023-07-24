using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEvent
{
    private string eventName;
    private string eventDetail;
    
    public MapEvent(string eventName,string eventDetail)
    {
        this.eventName = eventName;
        this.eventDetail = eventDetail;
    }
    public string EventName()
    {
        return eventName;
    }
    public string EventDetail()
    {
        return eventDetail;
    }
}