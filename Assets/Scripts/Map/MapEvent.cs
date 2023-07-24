using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEvent
{
    private string eventName;
    private string eventDetail;
    
    public MapEvent()
    {
        this.eventName = "Default Name";
        this.eventDetail = "No Details";
    }
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