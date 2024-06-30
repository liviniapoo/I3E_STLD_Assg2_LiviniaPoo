/*
 * Author: Livinia Poo
 * Date: 1/07/2024
 * Description: 
 * Displaying and updating enemy healthbars
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    /*Health Bar*/
    public Slider enemyHealthSlider;
    public Gradient enemyHealthGradient;
    public Image enemyHealthFill;

    public void SetMaxHealth(float health)
    {
        enemyHealthSlider.maxValue = health;
        enemyHealthSlider.value = health;

        enemyHealthFill.color = enemyHealthGradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        enemyHealthSlider.value = health;

        enemyHealthFill.color = enemyHealthGradient.Evaluate(enemyHealthSlider.normalizedValue);
    }
}
