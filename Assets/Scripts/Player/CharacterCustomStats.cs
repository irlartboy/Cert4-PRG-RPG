using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomStats : MonoBehaviour
{
    public int strength;
    public int dext;
    public int constit;
    public int intel;
    public int wisd;
    public int chari;
    public string className;

    public Text strText, dexText, conText, intelText, wisText, charText;

    private void Start()
    {
        SetClass(0);
    }

    public void SetClass(int value)
    {
        switch (value)
        {
            default:
            case 0:
                className = "Barbarian";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 1:
                className = "Bard";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 5;
                break;
            case 2:
                className = "Cleric";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 3:
                className = "Druid";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 4:
                className = "Fighter";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 5:
                className = "Monk";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 6:
                className = "Paladian";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 7:
                className = "Ranger";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 8:
                className = "Rogue";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 9:
                className = "Sorcerer";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 10:
                className = "Warlock";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
            case 11:
                className = "Wizard";
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd = 1;
                chari = 1;
                break;
        }
        strText.text = "Strength: " + strength;
        dexText.text = "Dexterity: " + dext;
        conText.text = "Constitution: " + constit;
        intelText.text = "Intelligence: " + intel;
        wisText.text = "Wisdom: " + wisd;
        charText.text = "Charisma: " + chari;
    }
}
