using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    //Ref to Enemy max and current health
    [Header("Reference to Health")]
    public float maxHp = 100;
    public float curHp = 100;
    // ref to UI elements 
    [Header("Reference to UI Elements")]
    public Slider healthBar;
    public Canvas myCanvas;
   

    private void Start()
    {
        // this finds the canvas 
        myCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        // this find and references the slider within the canvas
        healthBar = myCanvas.transform.Find("Slider").GetComponent<Slider>();
    }

    private void Update()
    {
        // this clamps the health between a min and max 
        healthBar.value = Mathf.Clamp01(curHp / maxHp);
        // This makes the canvas always face the main camera
        myCanvas.transform.LookAt(Camera.main.transform);
    }


}

