/*
 * Author: Livinia Poo
 * Date: 30/06/2024
 * Description: 
 * Displaying and updating enemy healthbars
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    /// <summary>
    /// Variables to set up Enemy's Healthbar
    /// </summary>
    public Slider enemyHealthSlider;
    public Gradient enemyHealthGradient;
    public Image enemyHealthFill;

    /// <summary>
    /// Setting for enemy's starting max health
    /// </summary>
    /// <param name="health"></param>
    public void SetMaxHealth(float health)
    {
        enemyHealthSlider.maxValue = health;
        enemyHealthSlider.value = health;

        enemyHealthFill.color = enemyHealthGradient.Evaluate(1f);
    }

    /// <summary>
    /// Adjusts the health bar's position based on the enemy's current health
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(float health)
    {
        enemyHealthSlider.value = health;

        enemyHealthFill.color = enemyHealthGradient.Evaluate(enemyHealthSlider.normalizedValue);
    }
}
