/*
 * Author: Livinia Poo
 * Date: 30/06/2024
 * Description: 
 * Displaying and updating player healthbars
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    /// <summary>
    /// Variables to set up Player's Healthbar
    /// </summary>
    public Slider playerHealthSlider;
    public Gradient playerHealthGradient;
    public Image playerHealthFill;

    /// <summary>
    /// Setting for player's starting max health
    /// </summary>
    /// <param name="health"></param>
    public void SetPlayerMaxHealth(float health)
    {
        playerHealthSlider.maxValue = health;
        playerHealthSlider.value = health;

        playerHealthFill.color = playerHealthGradient.Evaluate(1f);
    }

    /// <summary>
    /// Adjusts the health bar's position based on the player's current health
    /// </summary>
    /// <param name="health"></param>
    public void SetPlayerHealth(float health)
    {
        playerHealthSlider.value = health;

        playerHealthFill.color = playerHealthGradient.Evaluate(playerHealthSlider.normalizedValue);
    }
}
