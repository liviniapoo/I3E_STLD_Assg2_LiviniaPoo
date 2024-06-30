/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*Health Handling*/
    [SerializeField]
    public float playerHealth = 100;

    /*Door Handling*/
    private NormalDoor normalDoor;

    /// <summary>
    /// Function to check door in front of player
    /// </summary>
    /// <param name="doorPos"></param>
    public void DoorUpdate(NormalDoor doorPos)
    {
        normalDoor = doorPos;
    }

    /*Gun Handling*/
    /// <summary>
    /// Variables to check whether player has a gun
    /// </summary>
    public static bool hasGun = false;
    public GameObject gunOnPlayer;

    /*Ammo Handling*/
    /// <summary>
    /// Variables to check how much ammo player has
    /// </summary>
    public static int ammoBoxCount = 0;
    public static int ammoCount = 0;

    /*Medkit Handling*/
    /// <summary>
    /// Variable to check how many medkits player has
    /// </summary>
    public static int medkitCount = 0;
    public int healthRestoredPerHeal = 20;

    /*Gear Handling*/
    /// <summary>
    /// Variable to check how many gears player has
    /// </summary>
    public static int gearCount = 0;

    public static bool gemstoneCollected = false;

    public static bool essenceCollected = false;

    void OnInteract()
    {
        if (normalDoor != null)
        {
            normalDoor.OpenShipDoor();
        }
    }

    private void OnHeal()
    {
        if (playerHealth < 100 && medkitCount > 0)
        {
            playerHealth += healthRestoredPerHeal;
            medkitCount -= 1;
            Debug.Log(playerHealth);
        }
        else if (medkitCount == 0)
        {
            Debug.Log("No more medkits!");
        }
    }

    /*Health System*/
    public void TakeDamage(float damageAmt)
    {
        playerHealth -= damageAmt;

        if (playerHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player died");
    }

    private void Start()
    {
        gunOnPlayer.SetActive(false);
    }

    private void Update()
    {
        if(hasGun)
        {
            gunOnPlayer.SetActive(true);
        }
    }
}
