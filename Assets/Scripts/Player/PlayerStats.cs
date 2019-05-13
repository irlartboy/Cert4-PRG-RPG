using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public string[] stats;
    public int[] statData;
    public string playername;
    public int level;

    public float maxHealth;
    public float maxMana;
    public float maxExp;

    public float curHealth;
    public float curMana;
    public float curExp;

    public float delayedHealth;
    public float delayedMana;
    public float delayedExp;


    public float speed;

    [Header("Reference to Health UI Elemenets")]
    public Slider healthSlider;
    public Image healthFill;
    public Slider delayedHealthSlider;
    public Image delayedHealthFill;

    [Header("Reference to Mana UI Elemenets")]
    public Slider manaSlider;
    public Image manaFill;
    public Slider delayedManaSlider;
    public Image delayedManaFill;

    [Header("Reference to Exp UI Elemenets")]
    public Slider expSlider;
    public Image exFill;
    public Slider delayedExpSlider;
    public Image delayedExpFill;

    
     public int strength;
     public int dext;
     public int constit;
     public int intel;
     public int wisd;
     public int chari;
    


    void Update()
    {
        // if current health < deyaled health bring delayed health to match curheath Speed over time 
        healthSlider.value = Mathf.Clamp01(curHealth / maxHealth);
        if (delayedHealth > curHealth)
        {
            delayedHealth -= Time.deltaTime * speed;
        }
        // delayed sliders value to be set to delayed health amount not pass min and max value 
        delayedHealthSlider.value = Mathf.Clamp01(delayedHealth / maxHealth);
        ManageHealthBar();


        // if current mana < deyaled mana bring delayed mana to match curMana Speed over time 
        manaSlider.value = Mathf.Clamp01(curMana / maxMana);
        if (delayedMana > curMana)
        {
            delayedMana -= Time.deltaTime * speed;
        }

        // delayed sliders value to be set to delayed health amount not pass min and max value 
        delayedManaSlider.value = Mathf.Clamp01(delayedMana / maxMana);

        // if current health < deyaled health bring delayed health to match curheath Speed over time 
        expSlider.value = Mathf.Clamp01(curExp / maxExp);
        if (delayedExp < curExp)
        {
            delayedExp += Time.deltaTime * speed;
        }
        // delayed sliders value to be set to delayed exp amount not pass min and max value 
        delayedExpSlider.value = Mathf.Clamp01(delayedExp / maxExp);

    }
    private void ManageHealthBar()
    {
        if (curHealth <= 0 && healthFill.enabled)
        {
            healthFill.enabled = false;
        }
        else if (!healthFill.enabled && curHealth > 0)
        {
            Debug.Log("Revive");
            healthFill.enabled = enabled;
        }
        if (delayedHealth <= 0 && delayedHealthFill.enabled)
        {
            Debug.Log("Dead");
            delayedHealthFill.enabled = false;
        }
        else if (delayedHealth < curHealth)
        {
            healthFill.enabled = enabled;
            delayedHealth = curHealth;
            delayedHealthSlider.value = healthSlider.value; 
        }
    }

    public void SetClass(string classType)
    {
        switch (classType)
        {
            default:
            case "Barbarian":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Bard":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Cleric":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Druid":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Fighter":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Monk":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Paladian":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Ranger":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Rogue":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Sorcerer":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Warlock":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
            case "Wizard":
                strength = 1;
                dext = 1;
                constit = 1;
                intel = 1;
                wisd= 1;
                chari = 1;
                break;
        }
    }
}
