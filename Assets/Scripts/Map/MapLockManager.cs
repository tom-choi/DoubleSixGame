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
        locks[0] = new MapLock(3, true);
        locks[1] = new MapLock(4, true);
        MapLock currentLock = new MapLock(locks,2, true);
        AddMapLock(locks[0],0);
        AddMapLock(locks[1],1);
        AddMapLock(currentLock,2);

        locks[0].UnlockTheLock();
        locks[0].UnlockTheLock();
        locks[0].UnlockTheLock();
        
        currentLock.UnlockTheLock();

        locks[1].UnlockTheLock();
        locks[1].UnlockTheLock();
        locks[1].UnlockTheLock();

        currentLock.UnlockTheLock();
    }
}