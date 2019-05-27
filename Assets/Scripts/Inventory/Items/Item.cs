using UnityEngine;
//this public class doent inherit from MonoBehaviour
//this script is also referenced by other scripts but never attached to anything
public class Item
{
    //basic variables for items that we need are 
    #region Private Variables
    private int _idNum;
    private string _name;
    private int _value;
    private string _description;
    private Texture2D _icon;
    private GameObject _mesh;
    private ItemType _type;
    private int _heal;
    private int _damage;
    private int _armour;
    private int _amount;
    #endregion
    #region Constructors
    //A constructor is a bit of code that allows you to create objects from a class. You call the constructor by using the keyword new 
    //followed by the name of the class, followed by any necessary parameters.
    //the Item needs Identification Number, Object Name, Icon and Type
    //here we connect the parameters with the item variables
    public void ItemCon(int Itemid, string itemName, Texture2D itemIcon, ItemType itemType)
    {
        _idNum = Itemid;
        _name = itemName;
        _icon = itemIcon;
        _type = itemType;

    }
    #endregion
    #region Public Variables
    //here we are creating the public versions or our private variables that we can reference and connect to when interacting with items
    //public Identification Number
    public int ID
    {
        //get the private Identification Number
        get { return _idNum; }
        //and set it to the value of our public Identification Number
        set { _idNum = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }

    }
    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public GameObject Mesh
    {
        get { return _mesh; }
        set { _mesh = value; }

    }
    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    #endregion
}
#region Enums
public enum ItemType
{
    Food,
    Weapon,
    Apparel,
    Crafting, 
    Quest, 
    Money,
    Ingredient, 
    Potions,
    Scrolls
}
#endregion
