using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    /// <summary>
    /// Ends the game if certain condition is met
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (RepairShip.shipFixed)
            {
                Debug.Log("Congratulations! You've made it off the planet!");
            }
            else
            {
                Debug.Log("Fix the ship first");
            }
        }
    }
}
