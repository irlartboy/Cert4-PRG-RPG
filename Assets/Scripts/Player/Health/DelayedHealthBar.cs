using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DelayedHealthBar : MonoBehaviour
{
    // Header ref to UI elements
    [Header("Reference to Health")]
    //maxHealth
    public float maxHealth;
    //curHealth
    public float curHealth;
    //DelayedHealth
    public float delayedHealth;

    [Header("Delay Drop Speed")]
    //speed that delay health drops at
    public float speed;

    [Header("Reference to UI Elemenets")]
    //Speed of healthdrop
    // ref to HealthSlider
    public Slider healthSlider;
    // Ref to delayedHealth Slider
    public Slider delayedHealthSlider;
    //Ref to health fill
    public Image healthFill;
    // ref to delayed health fill
    public Image delayedHealthFill;

  

    void Update()
    {
        // if current health < deyaled health bring delayed health to match curheath Speed over time 
        healthSlider.value = Mathf.Clamp01(curHealth / maxHealth);
        if (delayedHealth > curHealth)
        {
            delayedHealth -= Time.deltaTime * speed;
        }
        // delayed sliders value to be set to delayed health amount not pass min and max value - clamp?
        delayedHealthSlider.value = Mathf.Clamp01(delayedHealth / maxHealth);
        ManageHealthBar();
        // extra:
        // to manage health bar make sure forground fill is disabled upon death and enabled upon revive 

        // once delay helath is empty turn off delayed health fill upon revive turn on fill make sure delay health and slider value are full
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
}
