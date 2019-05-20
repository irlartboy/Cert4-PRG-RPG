using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//you will need to change Scenes
public class CustomisationGet : MonoBehaviour
{

    [Header("Character")]
    //public variable for the Skinned Mesh Renderer which is our character reference
    public Renderer character;

    #region Start
    private void Start()
    {
        //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
        character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>();  
        //Run the function LoadTexture
        LoadTexture();
    }
    #endregion

    #region LoadTexture Function
    public void LoadTexture()
    {
        //check to see if our save file for this character
        //if it doesnt then load the CustomSet level
        //if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes from PlayerPrefs
        //grab the gameObject in scene that is our character and set its Object name to the Characters name
    }
    #endregion
    #region SetTexture
    public void SetTexture(string type, int index)
    {
        //we need variables that exist only within this function
        //these are int material index and Texture2D array of textures
        Texture2D tex = null;
        int matIndex = 0;
        //inside a switch statement that is swapped by the string name of our material
        switch(type)
        {
            case "Skin":
                tex = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;
                break;
            case "Eyes":
                tex = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 2;
                break;
            case "Mouth":
                tex = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "Hair":
                tex = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "Armour":
                tex = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 5;
                break;
            case "Clothes":
                tex = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 6;
                break;
        }

        //Material array is equal to our characters material list
        Material[] mats = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mats[matIndex].mainTexture = tex;
        //our characters materials are equal to the material array
        character.materials = mats;
    }
    #endregion
}
