using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLockManager
{
    Dictionary<int,MapLock> DicMapLock;

    public void AddMapLock(MapLock mylock,int key)
    {
        DicMapLock.Add(key,mylock);
    }
    public MapLock FindMapLock(int key)
    {
        if(DicMapLock.ContainsKey(key))
        {
            return DicMapLock[key];
        }
        return null;
    }

    MapLockManager()
    {
        MapLock[] locks = new MapLock[2];
        locks[0] = new MapLock(0, true);
        locks[1] = new MapLock(0, true);
        MapLock currentLock = new MapLock(locks, true);
        AddMapLock(new MapLock(5, true),0);
        AddMapLock(new MapLock(5, true),1);
    }
}