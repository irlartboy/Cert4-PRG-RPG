using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public static int money;

    public Vector2 scr;
    public Vector2 scrollPos;

    public string[] sortType = new string[7];
    public int index;
    public string sortingType = "All";

    public Transform dropLocation;
    public Transform[] equippedLoaction;
    /*
     Spawn Loactions:
     0 = right hand 
     1 = head
     */
    public GameObject curWeapon;
    public GameObject curHelm;
    public PlayerStats health;
    #endregion
    private void Start()
    {
        sortType = new string[] { "All", "Food", "Weapon", "Apparel", "Crafting", "Quest", "Ingridents", "Potions", "Scrolls" };
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(203));
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(3));
        inv.Add(ItemData.CreateItem(2));
        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }
    }
    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            return false;
        }
        else
        {
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            return true;
        }
      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if(!PauseMenu.isPaused)
            ToggleInv();
        }
    }

    private void DisplayInv(string sortType)
    {
       
        if (!(sortType == "All" || sortType == ""))
        {
            #region Types
            // then convert sorttype to our itemtype
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType); // converting string to enum
            int a = 0;// amount of tyoe
            int s = 0;// slot position of GUI item 
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)
                {
                    a++; // increse the amount of this type

                }
            }
            if (a <= 34)// if its 34 or less it will display withoiu a scroll bar
            {
                for (int i = 0; i < inv.Count; i++) // filter through items
                {
                    if (inv[i].Type == type) // if its the type we want to display
                    {
                        // we display a button that is of this type and slot them under the last
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        s++; // inceases the slot pos so the next one slides under 
                    }
                }
            }
            else // if more than 34 
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.75f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((a - 34) * (0.25f * scr.y))), false, true);
                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++) // filter through items
                {
                    if (inv[i].Type == type) // if its the type we want to display
                    {
                        // we display a button that is of this type and slot them under the last
                        if (GUI.Button(new Rect(0 * scr.x, 0 * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        s++; // inceases the slot pos so the next one slides under 


                    }
                }
                #endregion
                GUI.EndScrollView(); 
            }
            #endregion
        }
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), false, true);
                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++) // filter through items
                {
                        // we display a button that is of this type and slot them under the last
                        if (GUI.Button(new Rect(0 * scr.x, 0 * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                }
                #endregion
                GUI.EndScrollView();
            }
        }
    }

    void DisplayItem()
    {
        switch (selectedItem.Type)
        {
            case ItemType.Food:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y),selectedItem.Name+"\n"+selectedItem.Description+"\nValue:"+selectedItem.Value+"\nHeal:"+selectedItem.Heal +"\nAmount:"+selectedItem.Amount);
                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15*scr.x,8.75f*scr.y,scr.x,0.25f*scr.y),"Eat"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button (new Rect(14* scr.x,8.75f *scr.y,scr.x,0.25f *scr.y),"Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Weapon:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\nDamage:" + selectedItem.Heal + "\nAmount:" + selectedItem.Amount);
                if (curWeapon == null || selectedItem.Mesh.name != curWeapon.name)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        if (curWeapon != null)
                        {
                            Destroy(curWeapon);
                        }
                        curWeapon = Instantiate(selectedItem.Mesh, equippedLoaction[0]);
                        if (curWeapon.GetComponent<ItemHandler>() != null)
                        {
                            curWeapon.GetComponent<ItemHandler>().enabled = false;
                        }
                        curWeapon.name = selectedItem.Mesh.name;
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    if (curWeapon != null && selectedItem.Mesh.name == curWeapon.name)
                    {
                        Destroy(curWeapon);
                    }
                    Discard();
                }
                break;
            case ItemType.Apparel:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue:" + selectedItem.Value + "\nArmour" + selectedItem.Heal + "\nAmount:" + selectedItem.Amount);
                if (curHelm == null || selectedItem.Mesh.name != curHelm.name)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        if (curHelm != null)
                        {
                            Destroy(curHelm);
                        }
                        curHelm = Instantiate(selectedItem.Mesh, equippedLoaction[1]);
                        if (curHelm.GetComponent<ItemHandler>() != null)
                        {
                            curHelm.GetComponent<ItemHandler>().enabled = false;
                        }
                        curHelm.name = selectedItem.Mesh.name;
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    if (curHelm != null && selectedItem.Mesh.name == curHelm.name)
                    {
                        Destroy(curHelm);
                    }
                    Discard();
                }
                break;
            case ItemType.Crafting:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {
                    health.curHealth += selectedItem.Heal;
                    DepleteAmount();
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Quest:
                break;
            case ItemType.Ingredient:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Potions:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Drink"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Scrolls:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Read"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
        }
    }
    private void DepleteAmount()
    {
        if (selectedItem.Amount > 1)
        {
            selectedItem.Amount--;
        }
        else
        {
            inv.Remove(selectedItem);
            selectedItem = null;
        }
        return;
    }
    private void Discard()
    {
        GameObject clone = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
        clone.AddComponent<Rigidbody>().useGravity = true;
        clone.AddComponent<BoxCollider>();
        DepleteAmount();
    }
    private void OnGUI()
    {
        //if(!PauseMenu.isPaused)
        if (showInv)
        {
            GUI.Box(new Rect(0, 0, Screen.width , Screen.height), "Inventory");
            for (int i = 0; i < sortType.Length; i++)
            {
                if (GUI.Button(new Rect(5.5f * scr.x + i*(scr.x), 0.25f * scr.y,scr.x, 0.25f * scr.y),sortType[i]))
                {
                    sortingType = sortType[i];
                }
            }
            DisplayInv(sortingType);
            if (selectedItem != null)
            {
                GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y),selectedItem.Icon);
                DisplayItem();
            }
        }
    }
}
