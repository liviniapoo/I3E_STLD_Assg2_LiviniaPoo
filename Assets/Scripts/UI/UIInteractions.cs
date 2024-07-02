/*
 * Author: Livinia Poo
 * Date: 25/06/2024
 * Description: 
 * Updating Player UI throughout the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInteractions : MonoBehaviour
{
    /// <summary>
    /// Referencing Text UIs
    /// </summary>
    public TextMeshProUGUI ammoCounter;
    public TextMeshProUGUI medkitCounter;
    public TextMeshProUGUI gearCounter;
    public TextMeshProUGUI essenceCounter;

    /// <summary>
    /// Display text
    /// </summary>
    private void Update()
    {
        if(Player.hasGun == true)
        {
            ammoCounter.text = $"{Gun.currentAmmo}||{Player.ammoCount}";
        }
        else
        {
            ammoCounter.text = "";
        }

        if (Player.medkitCount >0)
        {
            medkitCounter.text = $"Medkits Left: {Player.medkitCount}";
        }
        else
        {
            medkitCounter.text = "";
        }

        if (RepairShip.shipFixed)
        {
            gearCounter.text = "";
            essenceCounter.text = "";
        }
        else
        {
            gearCounter.text = $"Gears Collected: {Player.gearCount}/6";
            essenceCounter.text = $"Crystal Essence Collected: {Player.essenceCount}/1";
        }
    }
}
