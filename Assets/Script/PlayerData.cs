using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;
using UnityEngine.Rendering;

[Serializable]
public class PlayerData
{
    public string namePlayer;
    public int pointPlayer;
    public PlayerData()
    {
        
    }

    public PlayerData(string name, int point)
    {
        this.namePlayer = name;
        this.pointPlayer = point;
    }

    
}

[Serializable]
public class ListPLayerDatas
{
    public List<PlayerData> listPlayerDatas = new List<PlayerData>();

    public void AddPlayerData(PlayerData playerData)
    {
        foreach(PlayerData p in listPlayerDatas)
        {
            if(p.namePlayer.Equals(playerData.namePlayer))
            {
                if(p.pointPlayer > playerData.pointPlayer)
                {
                    p.pointPlayer = playerData.pointPlayer;
                }
                return;
            }

        }
        listPlayerDatas.Add(playerData);
    }
}
