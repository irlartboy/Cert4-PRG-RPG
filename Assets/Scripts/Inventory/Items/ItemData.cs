using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string _name = "";
        int _value = 0;
        string _description ="";
        string _icon = "";
        string _mesh = "";
        ItemType _type = ItemType.Food;
        int _heal = 0;
        int _damage = 0;
        int _armour = 0;
        int _amount = 0;


        switch (itemID)
        {
            #region Food 0 - 99
            case 0:
                 _name = "Meat";
                 _value = 15;
                 _description = "Mystery Meat";
                 _icon = "Food/Meat_Icon";
                 _mesh = "Food/Meat_Mesh";
                 _type = ItemType.Food;
                 _heal = 17;
                 _amount = 1;
                break;
            case 1:
                _name = "Chicken";
                _value = 10;
                _description = "It's a bird";
                _icon = "Food/Chicken_Icon";
                _mesh = "Food/Chicken_Mesh";
                _type = ItemType.Food;
                _heal = 10;
                _amount = 1;
                break;
            case 2:
                _name = "Bread";
                _value = 5;
                _description = "Fresh Bread";
                _icon = "Food/Bread_Icon";
                _mesh = "Food/Bread_Mesh";
                _type = ItemType.Food;
                _heal = 2;
                _amount = 1;
                break;
            case 3:
                _name = "Apple";
                _value = 5;
                _description = "An apple";
                _icon = "Food/Apple_Icon";
                _mesh = "Food/Apple_Mesh";
                _type = ItemType.Food;
                _heal = 2;
                _amount = 1;
                break;
            #endregion
            #region Weapon 100 - 199
            case 100:
                _name = "Short Sword";
                _value = 50;
                _description = "Fresh Bread";
                _icon = "Weapon/ShortSword_Icon";
                _mesh = "Weapon/ShortSword_Mesh";
                _type = ItemType.Weapon;
                _damage = 30;
                _amount = 1;
                break;
            case 101:
                _name = "Long Sword";
                _value = 75;
                _description = "Fresh Bread";
                _icon = "Weapon/LongSword_Icon";
                _mesh = "Weapon/LongSword_Mesh";
                _type = ItemType.Weapon;
                _damage = 50;
                _amount = 1;
                break;
            case 102:
                _name = "Axe";
                _value = 30;
                _description = "Fresh Bread";
                _icon = "Weapon/Axe_Icon";
                _mesh = "Weapon/Axe_Mesh";
                _type = ItemType.Weapon;
                _damage = 15;
                _amount = 1;
                break;
            #endregion
            #region Apparel 200 - 299
            case 200:
                _name = "Hat";
                _value = 20;
                _description = "a hat";
                _icon = "Apparel/Hat_Icon";
                _mesh = "Apparel/Hat_Mesh";
                _type = ItemType.Apparel;
                _armour = 5;
                _amount = 1;
                break;
            case 201:
                _name = "Cloak";
                _value = 20;
                _description = "a hat";
                _icon = "Apparel/Cloak_Icon";
                _mesh = "Apparel/Cloak_Mesh";
                _type = ItemType.Apparel;
                _armour = 5;
                _amount = 1;
                break;
            case 202:
                _name = "Chest Piece";
                _value = 20;
                _description = "a hat";
                _icon = "Apparel/ChestPiece_Icon";
                _mesh = "Apparel/ChestPiece_Mesh";
                _type = ItemType.Apparel;
                _armour = 5;
                _amount = 1;
                break;
            case 203:
                _name = "Boots";
                _value = 20;
                _description = "a hat";
                _icon = "Apparel/Boots_Icon";
                _mesh = "Apparel/Boots_Mesh";
                _type = ItemType.Apparel;
                _armour = 5;
                _amount = 1;
                break;
            #endregion
            #region Crafting 300 - 399
            case 300:
                _name = "Bag";
                _value = 20;
                _description = "leather bag";
                _icon = "Crafting/Bag_Icon";
                _mesh = "Crafting/Bag_Mesh";
                _type = ItemType.Crafting;
                _amount = 1;
                break;
            case 301:
                _name = "Lamp";
                _value = 20;
                _description = "lamp";
                _icon = "Crafting/Lamp_Icon";
                _mesh = "Crafting/Lamp_Mesh";
                _type = ItemType.Crafting;
                _amount = 1;
                break;
            case 302:
                _name = "Crate";
                _value = 20;
                _description = "Wooden Crate";
                _icon = "Crafting/Crate_Icon";
                _mesh = "Crafting/Crate_Mesh";
                _type = ItemType.Crafting;
                _amount = 1;
                break;
            #endregion
            #region Quest 400 - 499
            case 400:
                _name = "Ring";
                _value = 20;
                _description = "Stolen Ring";
                _icon = "Quest/Ring_Icon";
                _mesh = "Quest/Ring_Mesh";
                _type = ItemType.Quest;
                _amount = 1;
                break;
            case 401:
                _name = "Diamond";
                _value = 20;
                _description = "Diamond";
                _icon = "Quest/Diamond_Icon";
                _mesh = "Quest/Diamond_Mesh";
                _type = ItemType.Quest;
                _amount = 1;
                break;
            case 402:
                _name = "Golden Cup";
                _value = 20;
                _description = "A Golden Cup";
                _icon = "Quest/Cup_Icon";
                _mesh = "Quest/Cup_Mesh";
                _type = ItemType.Quest;
                _amount = 1;
                break;
            #endregion
            #region Ingreients 500 - 599
            case 500:
                _name = "Acorn";
                _value = 20;
                _description = "Acorn";
                _icon = "Ingredients/Acorn_Icon";
                _mesh = "Ingredients/Acorn_Mesh";
                _type = ItemType.Ingredient;
                _amount = 1;
                break;
            case 501:
                _name = "Egg";
                _value = 20;
                _description = "Egg";
                _icon = "Ingredients/Egg_Icon";
                _mesh = "Ingredients/Egg_Mesh";
                _type = ItemType.Ingredient;
                _amount = 1;
                break;
            case 502:
                _name = "Mushroom";
                _value = 20;
                _description = "Wild Mushroom";
                _icon = "Ingredients/Mushroom_Icon";
                _mesh = "Ingredients/Mushroom_Mesh";
                _type = ItemType.Ingredient;
                _amount = 1;
                break;
            #endregion
            #region Potions 600 - 699
            case 600:
                _name = "Small Health Potion";
                _value = 20;
                _description = "A small health potion";
                _icon = "Potions/S_Health_Icon";
                _mesh = "Potions/S_Health_Mesh";
                _type = ItemType.Potions;
                _heal = 20;
                _amount = 1;
                break;
            case 601:
                _name = "Medium Health Potion";
                _value = 20;
                _description = "A medium health potion";
                _icon = "Potions/M_Health_Icon";
                _mesh = "Potions/M_Health_Mesh";
                _type = ItemType.Potions;
                _heal = 50;
                _amount = 1;
                break;
            case 602:
                _name = "Large Health Potion";
                _value = 20;
                _description = "A large health potion";
                _icon = "Potions/L_Health_Icon";
                _mesh = "Potions/L_Health_Mesh";
                _type = ItemType.Potions;
                _heal = 100;
                _amount = 1;
                break;
            #endregion
            #region Scrolls 700 - 799
            case 700:
                _name = "Lore Scroll";
                _value = 20;
                _description = "A scroll";
                _icon = "Scrolls/Scroll_0_Icon";
                _mesh = "Scrolls/Scroll_0_Mesh";
                _type = ItemType.Scrolls;
                _amount = 1;
                break;
            case 701:
                _name = "Lore Scroll";
                _value = 5;
                _description = "Lore Scroll";
                _icon = "Scrolls/Scroll_1_Icon";
                _mesh = "Scrolls/Scroll_1_Mesh";
                _type = ItemType.Scrolls;
                _heal = 2;
                _amount = 1;
                break;
            case 702:
                _name = "Lore Scroll";
                _value = 5;
                _description = "Lore Scroll";
                _icon = "Scrolls/Scroll_2_Icon";
                _mesh = "Scrolls/Scroll_2_Mesh";
                _type = ItemType.Scrolls;
                _heal = 2;
                _amount = 1;
                break;
            #endregion
            default:
                _name = "Apple";
                _value = 5;
                _description = "An apple";
                _icon = "Food/Apple_Icon";
                _mesh = "Food/Apple_Mesh";
                _type = ItemType.Food;
                _heal = 2;
                _amount = 1;
                break;


        }
        Item temp = new Item
        {
            Name = _name,
            Value = _value,
            Description = _description,
            Icon =  Resources.Load("Icons/"+_icon) as Texture2D, 
            Mesh = Resources.Load("Mesh/"+ _mesh) as GameObject,
            Type = _type,
            Heal = _heal,
            Damage = _damage,
            Armour = _armour,
            Amount = _amount
            

        };
        return temp;
    }
}
