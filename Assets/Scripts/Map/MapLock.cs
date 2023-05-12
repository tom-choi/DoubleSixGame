using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MapLockMode
{
    PV_mode,
    Required_mode
}

public class MapLock
{  

    int PV = 0;
    MapLock[] ML = {};
    bool isLock = false;
    MapLockMode mapLockMode;
    
    public MapLock(int pv, bool islock)
    {
        this.PV = pv;
        this.isLock = islock;
        mapLockMode = MapLockMode.PV_mode;
    }
    
    public MapLock(MapLock[] ml,int pv, bool islock)
    {
        this.ML = ml;
        this.PV = pv;
        this.isLock = islock;
        mapLockMode = MapLockMode.Required_mode;
    }
    private void LockMap()
    {
        this.isLock = true;
    }
    private void UnlockMap()
    {
        this.isLock = false;
    }
    public bool CheckIsLocked()
    {
        return isLock;
    }
    private void AddPV()
    {
        this.PV++;
    }
    private void ReducePV()
    {
        if (CheckPV() == 0) return;
        this.PV--;
    }
    private int CheckPV()
    {
        return this.PV;
    }
    private string CheckMapLockMode()
    {
        return mapLockMode.ToString();
    }
    public void UnlockTheLock()
    {
        string mode = CheckMapLockMode();
        bool succRedflag = true;
        bool succUnlockflag = false;
        bool alreadyUnlockflag = false;
        if (CheckPV() != 0)
            switch(mode)
            {
                case "PV_mode":
                    ReducePV();
                    break;
                case "Required_mode":
                    foreach(var ml in ML)
                    {
                        if (ml.CheckIsLocked())
                        {
                            Debug.Log("The previous locks have not implemented yet");
                            succRedflag = false;
                            break;
                        }
                    }
                    ReducePV();
                    if (CheckPV() == 0) succUnlockflag = true;
                    break;
                default:
                    Debug.Log("mapLockMode has not implemented yet");
                    succRedflag = false;
                    break;
            }
        else
        {
            succRedflag = false;
            alreadyUnlockflag = true;
        }

        if (succRedflag) Debug.Log("lock unlocked remained " + CheckPV() + " PV");
        if (succUnlockflag) Debug.Log("lock unlocked succ");
        if (alreadyUnlockflag) Debug.Log("lock already unlocked");

    }
}