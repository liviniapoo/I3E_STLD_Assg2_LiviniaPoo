/*
 * Author: Livinia Poo
 * Date: 25/06/2024
 * Description: 
 * Managing UI Interactions throughout the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractions : MonoBehaviour
{
    /*Health Bar*/
    public Slider healthSlider;
    public Gradient healthGradient;
    public Image healthFill;

    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        healthFill.color = healthGradient.Evaluate(1f);
    }
    
    public void SetHealth(float health)
    {
       healthSlider.value = health;

       healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
