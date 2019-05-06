﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//you will need to change Scenes
public class CustomisationSet : MonoBehaviour
{

    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int eyesIndex, mouthIndex, hairIndex, armourIndex, clothesIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int eyesMax, mouthMax, hairMax, armourMax, clothesMax;
    [Header("Character Name")]
    public string charName = "Hero";
    [Header("Stats")]
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] tempStats = new int[6];
    public int points = 10;
    public CharacterClass charClass = CharacterClass.Barbarian;
    public string[] selectedClass = new string[8];
    public int selectedIndex = 0;

    #endregion

    #region Start
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Barbarian", "Bard", "Druid", "Monk", "Paladin", "Ranger", "Sorcerer", "Warlock", "Wizard" };

        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            hair.Add(temp);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            mouth.Add(temp);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            eyes.Add(temp);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            armour.Add(temp);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            clothes.Add(temp);
        }
        #endregion
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        #endregion
    }
    #endregion

    #region SetTexture
    public void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        #region Switch Material
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 5;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 6;
                break;
        }
        #endregion

        #region OutSide Switch
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max-1)
        {
            index = 0;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;
        #region Set Material Switch
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
        }
        #endregion
    }
    #endregion

    #endregion

    #region Save
    void Save()
    {

    }
    #endregion

    public void SkinBackButton()
    {

        SetTexture("Skin", -1);
    }

    #region OnGUI
    //Function for our GUI elements
    //create the floats scrW and scrH that govern our 16:9 ratio
    //create an int that will help with shuffling your GUI elements under eachother
    #region Skin
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence Skin
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    //set up same things for Hair, Mouth and Eyes
    #region Hair
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Mouth
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Eyes
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Random Reset
    //create 2 buttons one Random and one Reset
    //Random will feed a random amount to the direction 
    //reset will set all to 0 both use SetTexture
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Character Name and Save & Play
    //name of our character equals a GUI TextField that holds our character name and limit of characters
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this

    //GUI Button called Save and Play
    //this button will run the save function and also load into the game level
    #endregion
    #endregion
}
public enum CharacterClass
{
    Barbarian, 
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladian,
    Ranger,
    Rogue,
    Sorcerer,
    Warlock,
    Wizard
}