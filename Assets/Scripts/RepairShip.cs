using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairShip : MonoBehaviour
{
    public static bool shipFixed = false;
    public static bool materialsCheck = false;

    int gearsNeeded = 10;




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
