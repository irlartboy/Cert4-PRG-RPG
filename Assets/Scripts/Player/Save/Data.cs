using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int level;
    public string playerName;
    public float health;
    public float maxHp, curHp;
    public float x, y, z;

    public Data (Player player)
    {
        level = player.level;
        playerName = player.name;
        curHp = player.curHealth;
        maxHp = player.maxHealth;

        x = player.x;
        y = player.y;
        z = player.z;
    }
}
