/*
 * Author: Livinia Poo
 * Date: 30/06/2024
 * Description: 
 * Checks whether player has materials to repair ship
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairShip : MonoBehaviour
{
    /// <summary>
    /// Declares the state of the ship's repair
    /// </summary>
    public static bool shipFixed = false;
    public static bool materialsCheck = false;

    /// <summary>
    /// Determines the minimum materials needed
    /// </summary>
    public int gearsNeeded = 6;

    /// <summary>
    /// Checks materials player has upon trigger
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered trigger");
            if (Player.gearCount >= gearsNeeded && Player.essenceCollected == true)
            {
                materialsCheck = true;
                FixShip();
            }
            else if (Player.gearCount < gearsNeeded || Player.essenceCollected == false)
            {
                materialsCheck = false;
                Debug.Log("Missing Materials!");
            }
        }
    }

    /// <summary>
    /// Function to fix ship
    /// </summary>
    public void FixShip()
    {
        Debug.Log("Ship has been fixed");
        shipFixed = true;
    }
}
