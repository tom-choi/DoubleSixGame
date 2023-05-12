using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public enum AssetType { RealEstate, Stock, Bonus };

public class Asset
{
    public string assetName;
    public int assetValue;
    public AssetType assetType;
    public string assetOwner;
    public Asset(string name, int value, AssetType type, string owner)
    {
        assetName = name;
        assetValue = value;
        assetType = type;
        assetOwner = owner;
    }
}

// Define the player information class
public class PlayerInfo
{
    // Player ID
    public int playerID;

    // Player name
    public string playerName;

    // Player position on the board
    public Vector2Int playerPosition;

    // Player's cash
    public int cashAmount;

    // Player's assets
    public List<Asset> assets;

    // Player's status
    public class PlayerStatus
    {
        public int playerID;
        public string playerName;
        public int goldCoins;
        public int points;
        public int position;
        public int status;
    }
    public PlayerStatus playerStatus;
    public PlayerInfo()
    {
        this.playerID = 1;
        this.playerName = "John";
        this.playerPosition = new Vector2Int(0, 0);
        this.cashAmount = 1000;
        this.assets = new List<Asset>();
        this.playerStatus = new PlayerInfo.PlayerStatus();
        this.playerStatus.playerID = 1;
        this.playerStatus.playerName = "John";
        this.playerStatus.goldCoins = 10;
        this.playerStatus.points = 0;
        this.playerStatus.position = 0;
        this.playerStatus.status = 0;
    }
}

public class testingCharacter
{    
    string json;
    PlayerInfo playerinfo = new PlayerInfo();
    public testingCharacter()
    {
        string myjson = JsonUtility.ToJson(this.playerinfo);
        PlayerPrefs.SetString("saveData", json);
    }
}