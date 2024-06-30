using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
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
