using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider playerHealthSlider;
    public Gradient playerHealthGradient;
    public Image playerHealthFill;

    public void SetPlayerMaxHealth(float health)
    {
        playerHealthSlider.maxValue = health;
        playerHealthSlider.value = health;

        playerHealthFill.color = playerHealthGradient.Evaluate(1f);
    }

    public void SetPlayerHealth(float health)
    {
        playerHealthSlider.value = health;

        playerHealthFill.color = playerHealthGradient.Evaluate(playerHealthSlider.normalizedValue);
    }
}
