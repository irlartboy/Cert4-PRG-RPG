using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HealthBar : MonoBehaviour
{

    // reference to health 
    [Header("Reference to Health")]
    // player's Max health
    public float maxHealth;
    // player's current health
    public float curHealth;
    [Header("Reference to UI Elements")]
    public Slider healthSlider;
    // Ref to fill
    public Image healthFill;
 
    void Update()
    {
        healthSlider.value = Mathf.Clamp01(curHealth / maxHealth);
        ManageHealthBar();
    }
    void ManageHealthBar()
    {
        if (curHealth <= 0 && healthFill.enabled)
        {
            Debug.Log("Dead");
            healthFill.enabled = false;
        }
        else if (!healthFill.enabled && curHealth > 0)
        {
            Debug.Log("Revive");
            healthFill.enabled = enabled;
        }
    }
}
