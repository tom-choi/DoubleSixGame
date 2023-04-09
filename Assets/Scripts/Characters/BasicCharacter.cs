using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public class Asset
    {
        public string assetName;
        public int assetValue;
        public enum AssetType { RealEstate, Stock, Bonus };
        public AssetType assetType;
        public string assetOwner;
    }
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