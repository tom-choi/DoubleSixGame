using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}