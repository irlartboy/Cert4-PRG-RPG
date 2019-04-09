﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Key Varibles for the player
    //health, level, exp, mana, stamina, position, name, customisation
    public int level;
    public new string name;
    // public float health;
    public float maxHealth, curHealth;
    public float  x, y, z;
    public HealthBar health;
    public CheckPoint checkPoint;
    #endregion


    public void SaveFuntion(Player player)
    {
        maxHealth = health.maxHealth;
        curHealth = health.curHealth;
         x = player.x;
         y = player.y;
         z = player.z;
        Save.SaveData(this);
    }

   
   public void LoadData()
    {
        Data data = Save.LoadData();
        level = data.level;
        name = data.playerName;
        // health = data.health;
        maxHealth = data.maxHp;
        health.maxHealth = maxHealth;
        curHealth = data.curHp;
        health.curHealth = curHealth;
        x = data.x;
        y = data.y;
        z = data.z;
        this.transform.position = new Vector3(x, y, z);
    }

    private void Awake()
    {
        LoadData();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.F12))
        {
            SaveFuntion(this);
        }
    }
}
