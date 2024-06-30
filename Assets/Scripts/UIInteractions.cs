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
    /// <summary>
    /// Variables to set up Player's Healthbar
    /// </summary>
    /*Health Bar*/
    public Slider healthSlider;
    public Gradient healthGradient;
    public Image healthFill;

    /// <summary>
    /// Setting for player's starting max health
    /// </summary>
    /// <param name="health"></param>
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        healthFill.color = healthGradient.Evaluate(1f);
    }
    
    /// <summary>
    /// Adjusts the health bar's position based on the player's current health
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(float health)
    {
       healthSlider.value = health;

       healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
