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
    int gearsNeeded = 10;

    /// <summary>
    /// Checks materials player has upon trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Player.gearCount >= gearsNeeded && Player.essenceCollected == true)
            {
                materialsCheck = true;
            }
            else if (Player.gearCount < gearsNeeded || Player.essenceCollected == false)
            {
                materialsCheck = false;
            }
        }
    }


    public void FixShip()
    {
        Debug.Log("Ship has been fixed");
        shipFixed = true;
    }
}
